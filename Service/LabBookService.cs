using LabBook.ADO;
using LabBook.Commons;
using LabBook.Forms.LabBook;
using LabBook.Forms.Viscosity;
using LabBook.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

public enum ViscosityType
{
    STD,
    STD_X,
    PRB,
    SOLVENT,
    SOLVENT_X,
    KREBS,
    ICI,
    KREBS_ICI,
    FULL,
    SPEC
}

public enum MeasureType
{
    BROOKFIELD,
    KREBS,
    ICI,
    MIXED
}

namespace LabBook.Service
{
    public class LabBookService
    {
        private static readonly string dataFormFileName = "LabBookForm";

        private static readonly SolidBrush redBrush = new SolidBrush(Color.Red);
        private static readonly Color LightGrey = Color.FromArgb(200, 210, 210, 210);

        private readonly User _user;
        private readonly SqlConnection _connection;
        private readonly LabBookForm _labBookForm;
        private readonly LabBookRepository _labBookRepository;
        private readonly ExpCycleRepository _expCycleRepository;
        private readonly ExpViscosityRepository _viscosityRepository;
        private readonly ExpContrastRepository _contrastRepository;

        private DataTable _labBookTable;
        private DataView _labBookView;
        private BindingSource _labBookBindingSource;
        private DataRowView _currentLabBook;
        private DataTable _viscosityTable;
        private DataView _viscosityView;
        private BindingSource _viscosityBindingSource;
        private ExpViscosityColumn _viscosityColumnsCurrent = new ExpViscosityColumn("STD");
        private IList<ExpContrast> _contrastList;
        private BindingSource _contrastBinding;

        private bool _modified = false;
        private bool _visModified = false;
        private MeasureType _measureType = MeasureType.BROOKFIELD;

        private IList<ExpCycle> _expCycles;
        private IList<ExpCycle> _expFilterCycles;

        private IDictionary<string, double> _formData = CommonFunction.LoadWindowsDataAsDictionary(dataFormFileName);

        public LabBookService(LabBookForm labBookForm, SqlConnection connection, User user)
        {
            _user = user;
            _connection = connection;
            _labBookForm = labBookForm;
            _labBookRepository = new LabBookRepository(_user, _connection);
            _expCycleRepository = new ExpCycleRepository(_connection);
            _viscosityRepository = new ExpViscosityRepository(_connection);
            _contrastRepository = new ExpContrastRepository(_connection);
        }


        #region Save and Load data for LabBook form 

        public void SaveFormData(LabBookForm labBookForm)
        {
            IDictionary<string, double> list = new Dictionary<string, double>
            {
                { "Left", labBookForm.Left },
                { "Top", labBookForm.Top },
                { "Width", labBookForm.Width },
                { "Height", labBookForm.Height }
            };

            foreach(DataGridViewColumn column in _labBookForm.GetDgvLabBook.Columns)
            {
                if (column.Visible)
                {
                    list.Add(column.Name, column.Width);
                }
            }

            CommonFunction.WriteWindowsData(list, dataFormFileName);
        }

        internal void LoadFormData(LabBookForm labBookForm)
        {            
            if (_formData.Count > 0)
            {
                labBookForm.Left = _formData.ContainsKey("Left") ? (int)_formData["Left"] : labBookForm.Left;
                labBookForm.Top = _formData.ContainsKey("Top") ? (int)_formData["Top"] : labBookForm.Top;
                labBookForm.Width = _formData.ContainsKey("Width") ? (int)_formData["Width"] : labBookForm.Width;
                labBookForm.Height = _formData.ContainsKey("Height") ? (int)_formData["Height"] : labBookForm.Height;
            }
        }

        #endregion


        #region Prepare all data

        public void PreapreAllData()
        {
            GetAllLabBook();
            PrepareDataGridViewLabBook();
            PrepareDataGridViewViscosity();
            PrepareDataGridViewContrast();
            FillComboBoxes();
            PrepareOthersControls();
        }

        private void PrepareDataGridViewLabBook()
        {
            DataGridView view = _labBookForm.GetDgvLabBook;
            view.DataSource = _labBookBindingSource;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.RowHeadersWidth = _labBookForm.IsAdmin ? 35 : 40;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.AutoGenerateColumns = false;

            view.Columns["user_id"].Visible = false;
            view.Columns["cycle_id"].Visible = false;
            view.Columns["deleted"].Visible = false;
            view.Columns.Remove("observation");
            view.Columns.Remove("remarks");
            view.Columns.Remove("created");
            view.Columns.Remove("modified");

            view.Columns["id"].HeaderText = "Nr D";
            view.Columns["id"].ReadOnly = true;
            view.Columns["id"].DisplayIndex = 0;
            view.Columns["id"].Width = _formData.ContainsKey("id") ? (int)_formData["id"] : 70;
            view.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["title"].HeaderText = "Tytuł";
            view.Columns["title"].ReadOnly = true;
            view.Columns["title"].DisplayIndex = 1;
            view.Columns["title"].Width = _formData.ContainsKey("title") ? (int)_formData["title"] : 100;
            view.Columns["title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //view.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            view.Columns["cyc_name"].HeaderText = "Cykl";
            view.Columns["cyc_name"].DisplayIndex = 2;
            view.Columns["cyc_name"].ReadOnly = true;
            view.Columns["cyc_name"].Width = _formData.ContainsKey("cyc_name") ? (int)_formData["cyc_name"] : 100;
            view.Columns["cyc_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            view.Columns["cyc_name"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["density"].HeaderText = "Gęstość";
            view.Columns["density"].DisplayIndex = 3;
            view.Columns["density"].Width = _formData.ContainsKey("density") ? (int)_formData["density"] : 100;
            view.Columns["density"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["density"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["identifier"].HeaderText = "User";
            view.Columns["identifier"].DisplayIndex = 4;
            view.Columns["identifier"].ReadOnly = true;
            view.Columns["identifier"].Width = _formData.ContainsKey("identifier") ? (int)_formData["identifier"] : 70;
            view.Columns["identifier"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["identifier"].SortMode = DataGridViewColumnSortMode.NotSortable;

            ResizeFilters();
        }

        private void PrepareDataGridViewViscosity()
        {
            DataGridView view = _labBookForm.GetDgvViscosity;
            view.DataSource = _viscosityBindingSource;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoGenerateColumns = false;
            view.RowHeadersWidth = 35;
            view.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["id"].Visible = false;
            view.Columns["id"].DisplayIndex = ColumnData.GetViscosityColumns.Count - 3;
            view.Columns["labbook_id"].Visible = false;
            view.Columns["labbook_id"].DisplayIndex = ColumnData.GetViscosityColumns.Count - 2;
            view.Columns["vis_type"].Visible = false;
            view.Columns["vis_type"].DisplayIndex = ColumnData.GetViscosityColumns.Count - 1;

            foreach (DataGridViewColumn column in view.Columns)
            {

                if (ColumnData.GetViscosityColumns.TryGetValue(column.Name, out IList<string> data))
                {
                    view.Columns[column.Name].HeaderText = data[0];
                    view.Columns[column.Name].DisplayIndex = int.Parse(data[1]);
                    view.Columns[column.Name].Width = int.Parse(data[2]);
                    view.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (column.Name == "days_distance")
                {
                    view.Columns[column.Name].ReadOnly = true;
                }
            }

            view.Columns["days_distance"].Frozen = true;
        }

        private void PrepareDataGridViewContrast()
        {
            DataGridView view = _labBookForm.GetDgvContrast;
            view.DataSource = _contrastBinding;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 10, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoGenerateColumns = false;
            view.RowHeadersWidth = 35;
            view.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["Id"].Visible = false;
            view.Columns["LabBookId"].Visible = false;
            view.Columns["Position"].Visible = false;
            view.Columns.Remove("State");

            view.Columns["DateCreated"].HeaderText = "Utworzony";
            view.Columns["DateCreated"].DisplayIndex = 0;
            view.Columns["DateCreated"].Width = 100;
            view.Columns["DateCreated"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["DateUpdated"].HeaderText = "Pomiar";
            view.Columns["DateUpdated"].DisplayIndex = 1;
            view.Columns["DateUpdated"].Width = 100;
            view.Columns["DateUpdated"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Day"].HeaderText = "Doba";
            view.Columns["Day"].DisplayIndex = 2;
            view.Columns["Day"].ReadOnly = true;
            view.Columns["Day"].Width = 80;
            view.Columns["Day"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["ApplicatorName"].HeaderText = "Aplikator";
            view.Columns["ApplicatorName"].DisplayIndex = 3;
            view.Columns["ApplicatorName"].Width = 250;
            view.Columns["ApplicatorName"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Substrate"].HeaderText = "Podłoże";
            view.Columns["Substrate"].DisplayIndex = 4;
            view.Columns["Substrate"].Width = 150;
            view.Columns["Substrate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Contrast"].HeaderText = "Krycie";
            view.Columns["Contrast"].DisplayIndex = 5;
            view.Columns["Contrast"].Width = 100;
            view.Columns["Contrast"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Tw"].HeaderText = "Tw";
            view.Columns["Tw"].DisplayIndex = 6;
            view.Columns["Tw"].Width = 100;
            view.Columns["Tw"].SortMode = DataGridViewColumnSortMode.NotSortable;

            view.Columns["Sp"].HeaderText = "Sp";
            view.Columns["Sp"].DisplayIndex = 7;
            view.Columns["Sp"].Width = 100;
            view.Columns["Sp"].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            view.Columns["Comments"].HeaderText = "Uwagi";
            view.Columns["Comments"].DisplayIndex = 8;
            view.Columns["Comments"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["Comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void PrepareOthersControls()
        {
            _labBookForm.GetTitle.DataBindings.Clear();
            _labBookForm.GetConclusion.Clear();
            _labBookForm.GetObservation.Clear();

            _labBookForm.GetTitle.DataBindings.Add("Text", _labBookBindingSource, "title");
            _labBookForm.GetConclusion.DataBindings.Add("Text", _labBookBindingSource, "remarks");
            _labBookForm.GetObservation.DataBindings.Add("Text", _labBookBindingSource, "observation");
        }

        private void FillComboBoxes()
        {
            _expCycles = _expCycleRepository.GetAllExpCycles();
            _labBookForm.GetComboExpCycle.DataSource = _expCycles;
            _labBookForm.GetComboExpCycle.ValueMember = "Id";
            _labBookForm.GetComboExpCycle.DisplayMember = "Name";
            _labBookForm.GetComboExpCycle.SelectedIndexChanged += GetComboExpCycle_SelectedIndexChanged;

            _expFilterCycles = new List<ExpCycle>();
            ExpCycle allData = new ExpCycle(0, "-- Wszystkie --", 1, DateTime.Now);
            _expFilterCycles.Add(allData);
            foreach (ExpCycle cycle in _expCycles)
            {
                _expFilterCycles.Add(cycle);
            }

            _labBookForm.GetComboCycleFilter.DataSource = _expFilterCycles;
            _labBookForm.GetComboCycleFilter.ValueMember = "Id";
            _labBookForm.GetComboCycleFilter.DisplayMember = "Name";
        }

        #endregion


        #region Load Data from Database

        private void GetAllLabBook()
        {
            #region LabBook DataTable and View
            _labBookTable = _labBookRepository.GetAllLabBook();
            _labBookTable.ColumnChanged += LabBookTable_ColumnChanged;
            _labBookView = new DataView(_labBookTable);
            _labBookView.Sort = "id";

            _labBookBindingSource = new BindingSource();
            _labBookBindingSource.DataSource = _labBookView;
            _labBookBindingSource.PositionChanged += LabBookBindingSource_PositionChanged;
            _labBookForm.GetBindingNavigator.BindingSource = _labBookBindingSource;
            #endregion

            #region Viscosity DataTable and View
            _viscosityTable = new DataTable();
            DataColumn kolumna = new DataColumn();
            kolumna.ColumnName = "Nr";
            kolumna.DataType = Type.GetType("System.Int64");
            kolumna.AllowDBNull = false;
            kolumna.AutoIncrement = true;
            kolumna.AutoIncrementSeed = 1;
            kolumna.AutoIncrementStep = 1;
            _viscosityTable.Columns.Add(kolumna);
            _viscosityRepository.GetViscosityByLabBookId(_viscosityTable, -1);
            _viscosityTable.ColumnChanged += ViscosityTable_ColumnChanged;

            _viscosityView = new DataView(_viscosityTable);
            _viscosityView.Sort = "date_created, date_update";
            _viscosityBindingSource = new BindingSource { DataSource = _viscosityView };
            #endregion

            #region Contrast List

            IList<ExpContrast> list = _contrastRepository.GetContrastListByLabBookId(-1);
            _contrastList = list
                .OrderBy(x => x.Position)
                .ToList();
            _contrastBinding = new BindingSource();
            _contrastBinding.DataSource = _contrastList;

            #endregion
        }

        #endregion


        #region CRUD Operation

        public bool Modify
        {
            get => _modified;
            set
            {
                _modified = value;
                _labBookForm.EnableSaveButton();
            }
        }

        public bool ViscosityModify
        {
            get => _visModified;
            set
            {
                _visModified = value;
                _labBookForm.EnableSaveButton();
            }
        }

        private void ReloadViscosity(long id)
        {
            _viscosityTable.Clear();
            _viscosityRepository.LoadViscosityByLabBookId(_viscosityTable, id);
            ViscosityModify = false;
        }

        private void ReloadContrast(long id)
        {
            SaveContrast();
            _contrastList.Clear();
            _labBookForm.GetDgvContrast.Invalidate();
            _contrastList = _contrastRepository.GetContrastListByLabBookId(id);
            _contrastList.OrderBy(i => i.Position);
            _contrastBinding = new BindingSource() { DataSource = _contrastList };
            _labBookForm.GetDgvContrast.DataSource = _contrastBinding;
            _labBookForm.GetDgvContrast.Invalidate();
        }

        private void Save()
        {

        }

        private void SaveViscosity()
        {
            _labBookForm.GetDgvViscosity.EndEdit();
            bool save = false;
            bool update = false;

            #region Save new

            DataTable addedRows = _viscosityTable.GetChanges(DataRowState.Added);

            if (addedRows != null)
            {
                foreach(DataRow row in addedRows.Rows)
                {
                    save = _viscosityRepository.SaveViscosity(row);
                    if (save)
                    {
                        row.AcceptChanges();
                    }
                }
            }

            #endregion

            #region Update

            DataTable updatedRows = _viscosityTable.GetChanges(DataRowState.Modified);

            if (updatedRows != null)
            {
                foreach (DataRow row in updatedRows.Rows)
                {
                    update = _viscosityRepository.UpdateViscosity(row);
                    if (update)
                    {
                        row.AcceptChanges();
                    }
                }
            }

            #endregion

            ViscosityModify = save & update;
            if (!ViscosityModify)
            {
                ReloadViscosity((long)_currentLabBook["id"]);
            }
            _labBookForm.EnableSaveButton();
        }

        private void SaveContrast()
        {
            _labBookForm.GetDgvContrast.EndEdit();
            _labBookBindingSource.EndEdit();

            IList<ExpContrast> saveList = _contrastList
                .Where(i => i.State == States.Added)
                .ToList();
            foreach (ExpContrast contrast in saveList)
                _contrastRepository.Save(contrast);

            IList<ExpContrast> updateList = _contrastList
                .Where(i => i.State == States.Modified)
                .ToList();
            foreach (ExpContrast contrast in updateList)
                _contrastRepository.Update(contrast);
        }

        private void SaveViscosityColumns()
        {
            _viscosityRepository.DeleteViscosityColumn((long)_currentLabBook["id"]);
            if (_viscosityColumnsCurrent != null && _viscosityColumnsCurrent.Type != ViscosityType.STD)
            {
                _ = _viscosityRepository.SaveViscosityColumn(_viscosityColumnsCurrent);
            }
        }

        #endregion


        #region Menu and Button

        public void AddNewButton()
        {

        }

        public void SaveButton()
        {
            SaveViscosity();
        }

        public void DeleteButton()
        {

        }


        #endregion


        #region Current/Binkding/Navigation/DataTable

        private void LabBookBindingSource_PositionChanged(object sender, System.EventArgs e)
        {
            long id = 0;
            bool admin = false;
            bool deleted = true;

            #region Get Current

            if (_labBookBindingSource.Count > 0)
            {
                _currentLabBook = (DataRowView)_labBookBindingSource.Current;
                id = Convert.ToInt64(_currentLabBook["id"]);
            }
            else
            {
                _currentLabBook = null;
            }

            #endregion

            #region Set Current Controls

            if (_currentLabBook != null)
            {
                DateTime date = Convert.ToDateTime(_currentLabBook["created"]);
                string show = date.ToString("dd-MM-yyyy");
                _labBookForm.GetDateCreated.Text = show;
                date = Convert.ToDateTime(_currentLabBook["modified"]);
                show = date.ToString("dd-MM-yyyy");
                _labBookForm.GetDateModified.Text = show;

                string nr = "D" + _currentLabBook["id"].ToString();
                _labBookForm.GetLabelNrD.Text = nr;
            }
            else
            {
                _labBookForm.GetLabelNrD.Text = "-1";
                _labBookForm.GetDateCreated.Text = "Brak";
                _labBookForm.GetDateModified.Text = "Brak";
            }

            #endregion

            #region Synchro Combo Experimental Cycle

            if (_currentLabBook != null)
            {
                _labBookForm.GetComboExpCycle.SelectedValue = _currentLabBook["cycle_id"];
            }
            else
            {
                _labBookForm.GetComboExpCycle.SelectedValue = 1;
            }

            #endregion

            #region Reload Viscosity and Change Viscosity Columns

            if (_currentLabBook != null)
            {
                ReloadViscosity(id);
                _viscosityColumnsCurrent = _viscosityRepository.GetViscosityColumnById(id);
                ShowHideViscosityColumns();
                ViscosityType type = _viscosityColumnsCurrent.Type;
                SelectViscosityItemOnMenu((int)type, null);
            }

            #endregion

            #region Reload Contrast and Contrast class

            if (_currentLabBook != null)
            {
                ReloadContrast(id);
            }

            #endregion

            #region Block Controls

            if (_currentLabBook != null)
            {
                admin = (long)_currentLabBook["user_id"] == _user.Id || _labBookForm.IsAdmin ? true : false;
                deleted = (bool)_currentLabBook["deleted"];
            }

            if (deleted || !admin)
            {
                BlockControls();
            }
            else
            {
                UnblockControls();
            }

            #endregion
        }

        private void LabBookTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            Modify = true;
        }

        private void ViscosityTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            ViscosityModify = true;
        }

        private void GetComboExpCycle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_currentLabBook != null)
            {
                ExpCycle widok = (ExpCycle)_labBookForm.GetExpCmbCycle.SelectedItem;
                if ((_currentLabBook["cycle_id"].ToString() != widok.Id.ToString()))
                {
                    _currentLabBook["cycle_id"] = widok.Id;
                    _currentLabBook["cyc_name"] = widok.Name;
                    _labBookBindingSource.EndEdit();
                }
            }
        }

        private void BlockControls()
        {
            DataGridView view = _labBookForm.GetDgvLabBook;

            view.Columns["id"].ReadOnly = true;
            view.Columns["title"].ReadOnly = true;
            view.Columns["cyc_name"].ReadOnly = true;
            view.Columns["density"].ReadOnly = true;
            view.Columns["identifier"].ReadOnly = true;

            _labBookForm.GetTitle.ReadOnly = true;
            _labBookForm.GetExpCmbCycle.Enabled = false;
        }

        private void UnblockControls()
        {
            DataGridView view = _labBookForm.GetDgvLabBook;

            view.Columns["density"].ReadOnly = false;
            _labBookForm.GetDgvLabBook.ReadOnly = false;
            _labBookForm.GetTitle.ReadOnly = false;
            _labBookForm.GetExpCmbCycle.Enabled = true;
        }

        public void DefaultValuesForViscosityDGV(DataGridViewRowEventArgs e)
        {
            if (_currentLabBook != null)
            {
                long id = Convert.ToInt64(_currentLabBook["id"]);
                e.Row.Cells["id"].Value = -1;
                e.Row.Cells["labbook_id"].Value = Convert.ToInt64(_currentLabBook["id"]);
                e.Row.Cells["date_created"].Value = Convert.ToDateTime(_currentLabBook["created"]);
                e.Row.Cells["date_update"].Value = DateTime.Today;
                e.Row.Cells["vis_type"].Value = _measureType.ToString();
            }
        }

        public void DefaultValuesForContrastDGV(DataGridViewRowEventArgs e)
        {
            if (_contrastBinding != null && _currentLabBook != null)
            {
                long id = Convert.ToInt64(_currentLabBook["id"]);
                e.Row.Cells["Id"].Value = -1;
                e.Row.Cells["LabBookId"].Value = id;
                e.Row.Cells["DateCreated"].Value = Convert.ToDateTime(_currentLabBook["created"]);
                e.Row.Cells["DateUpdated"].Value = DateTime.Today;
                e.Row.Cells["Position"].Value = _contrastList.Count == 0 ? 1 : _contrastList.Max(i => i.Position) + 1;
            }
        }

        #endregion


        #region Viscosity TAB

        private void ShowHideViscosityColumns()
        {
            HideViscosityColumns();
            ShowViscosityColumns();
        }
        
        private void HideViscosityColumns()
        {
            DataGridView dgvViscosity = _labBookForm.GetDgvViscosity;

            foreach (DataGridViewColumn column in dgvViscosity.Columns)
            {
                if (column.Name == "date_created" || column.Name == "date_update" || column.Name == "days_distance" || column.Name == "temp")
                {
                    continue;
                }
                column.Visible = false;
            }
        }

        private void ShowViscosityColumns()
        {
            DataGridView view = _labBookForm.GetDgvViscosity;
            IDictionary<ViscosityType, IList<string>> fields = ColumnData.GetViscosityFields;
            IList<string> columns;


            if (_viscosityColumnsCurrent.Type != ViscosityType.SPEC && fields.ContainsKey(_viscosityColumnsCurrent.Type))
            {
                columns = fields[_viscosityColumnsCurrent.Type];
            }
            else
            {
                columns = !string.IsNullOrEmpty(_viscosityColumnsCurrent.Fields) ? new List<string>(_viscosityColumnsCurrent.Fields.Split('|')) : fields[ViscosityType.STD];
            }

            foreach (string col in columns)
            {
                if (ColumnData.GetViscosityColumns.ContainsKey(col))
                {
                    view.Columns[col].Visible = true;
                }
            }
        }

        private void DeselctAllViscosityItems()
        {
            foreach (ToolStripMenuItem item in _labBookForm.GetViscosityMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
        }

        private void SelectViscosityView(int position)
        {
            switch(position)
            {
                case 0:
                    _viscosityColumnsCurrent.Type = ViscosityType.STD;
                    break;
                case 1:
                    _viscosityColumnsCurrent.Type = ViscosityType.STD_X;
                    break;
                case 2:
                    _viscosityColumnsCurrent.Type = ViscosityType.PRB;
                    break;
                case 3:
                    _viscosityColumnsCurrent.Type = ViscosityType.SOLVENT;
                    break;
                case 4:
                    _viscosityColumnsCurrent.Type = ViscosityType.SOLVENT_X;
                    break;
                case 5:
                    _viscosityColumnsCurrent.Type = ViscosityType.KREBS;
                    break;
                case 6:
                    _viscosityColumnsCurrent.Type = ViscosityType.ICI;
                    break;
                case 7:
                    _viscosityColumnsCurrent.Type = ViscosityType.KREBS_ICI;
                    break;
                case 8:
                    _viscosityColumnsCurrent.Type = ViscosityType.FULL;
                    break;
                default:
                    SetViscosityFields();
                    _viscosityColumnsCurrent.Type = ViscosityType.SPEC;
                    break;
            }
        }

        public void SelectViscosityItemOnMenu(int position, ToolStripMenuItem item)
        {
            DeselctAllViscosityItems();
            if (position < 0)                           // from menu
            {
                item.Checked = true;
                SelectViscosityView(Convert.ToInt32(item.Tag.ToString()));
                HideViscosityColumns();
                ShowViscosityColumns();
                SaveViscosityColumns();
            }
            else                                        // from LabBookBindingSource_PositionChanged
            {
                var itemFromPosition = (ToolStripMenuItem)_labBookForm.GetViscosityMenuItem.DropDownItems[position];
                itemFromPosition.Checked = true;
            }
        }

        public void SetViscosityFields()
        {
            using(ViscosityColumnsForm form = new ViscosityColumnsForm(_viscosityColumnsCurrent.Fields))
            {
                form.ShowDialog();
                _viscosityColumnsCurrent.Fields = form.Result;
            }
        }

        #endregion


        #region Contrast Tab

        public void AddAplicatorsToDatagrid(ToolStripMenuItem item)
        {
            if (item.Tag == null)
                return;

            string type = Convert.ToString(item.Tag);
            if (ColumnData.GetAplicatorMenuItems.ContainsKey(type))
            {
                IList<string> items = ColumnData.GetAplicatorMenuItems[type];

            }
        }

        #endregion


        #region Filter Data

        public void ResizeFilters()
        {
            int left = _labBookForm.GetDgvLabBook.Left + _labBookForm.GetDgvLabBook.RowHeadersWidth;
            int top = _labBookForm.GetDgvLabBook.Top - _labBookForm.GetTitleFilter.Height - 5;

            _labBookForm.GetNrDFilter.Left = left;
            _labBookForm.GetNrDFilter.Width = _labBookForm.GetDgvLabBook.Columns["id"].Width - 1;
            _labBookForm.GetNrDFilter.Top = top;

            _labBookForm.GetTitleFilter.Left = _labBookForm.GetNrDFilter.Left + _labBookForm.GetDgvLabBook.Columns["id"].Width;
            _labBookForm.GetTitleFilter.Width = _labBookForm.GetDgvLabBook.Columns["title"].Width - 1;
            _labBookForm.GetTitleFilter.Top = top;

            _labBookForm.GetComboCycleFilter.Left = _labBookForm.GetTitleFilter.Left + _labBookForm.GetDgvLabBook.Columns["title"].Width;
            _labBookForm.GetComboCycleFilter.Width = _labBookForm.GetDgvLabBook.Columns["cyc_name"].Width - 1;
            _labBookForm.GetComboCycleFilter.Top = top - 2;

            _labBookForm.GetIdentifierFilter.Left = _labBookForm.GetComboCycleFilter.Left + _labBookForm.GetDgvLabBook.Columns["cyc_name"].Width + _labBookForm.GetDgvLabBook.Columns["density"].Width;
            _labBookForm.GetIdentifierFilter.Width = _labBookForm.GetDgvLabBook.Columns["identifier"].Width - 1;
            _labBookForm.GetIdentifierFilter.Top = top;
        }

        public void Filter()
        {
            string id = _labBookForm.GetNrDFilter.Text;
            string name = _labBookForm.GetTitleFilter.Text;
            string cycle = _labBookForm.GetComboCycleFilter.Text;
            string user = _labBookForm.GetIdentifierFilter.Text;
            string filter = "";

            #region Filter by Id

            if (!CheckNrD(id))
            {
                _labBookView.RowFilter = "";
                _labBookBindingSource.Position = 0;
                return;
            }

            if (id.Length > 0)
            {
                filter += "id >= " + id;
            }

            #endregion

            #region Filter by title

            if (name.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += "and title LIKE '*" + name + "*'";
                }
                else
                {
                    filter += "title LIKE '*" + name + "*'";
                }
            }

            #endregion

            #region Filter by Cycle

            if (cycle.Length > 0 && cycle != "-- Wszystkie --")
            {
                if (filter.Length > 0)
                {
                    filter += "and cyc_name LIKE '" + cycle + "'";
                }
                else
                {
                    filter += "cyc_name LIKE '" + cycle + "'";
                }
            }

            #endregion

            #region Filter by User

            if (user.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += "and identifier LIKE '" + user + "*'";
                }
                else
                {
                    filter += "identifier LIKE '" + user + "*'";
                }
            }

            #endregion

            #region Add Filter to view

            if (filter.Length > 0)
            {
                _labBookView.RowFilter = filter;
            }
            else
            {
                _labBookView.RowFilter = "";
            }

            _labBookBindingSource.Position = 0;
            LabBookBindingSource_PositionChanged(null, null);

            #endregion
        }

        private bool CheckNrD(string id)
        {
            long nr = -1;

            if (id.Length ==0)
            {
                return true;
            }
            else if (!long.TryParse(id, out nr))
            {
                MessageBox.Show("Wprowadzona wartośc musi byc liczbą całkowitą!", "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        #endregion


        #region DataGridView and Others Events

        public void IconInCellPainting(DataGridViewRowPostPaintEventArgs e)
        {
            long userId = (long)_labBookForm.GetDgvLabBook.Rows[e.RowIndex].Cells["user_id"].Value;
            bool deleted = (bool)_labBookForm.GetDgvLabBook.Rows[e.RowIndex].Cells["deleted"].Value;

            if (deleted)
            {
                string drawString = "Deleted ... Deleted ...";
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                Font drawFont = new Font("Arial", 12, FontStyle.Bold);
                int x = _labBookForm.GetDgvLabBook.RowHeadersWidth + 20;
                int y = e.RowBounds.Top + 4;
                int width = 300;
                int height = e.RowBounds.Height;
                Rectangle drawRect = new Rectangle(x, y, width, height);

                e.Graphics.DrawString(drawString, drawFont, redBrush, drawRect, drawFormat);
            }
            else if (_user.Id != userId)
            {
                int x = e.RowBounds.Left + 25;
                int width = 4;
                Rectangle rectangleTop = new Rectangle(x, e.RowBounds.Top + 4, width, e.RowBounds.Height - 14);
                Rectangle rectangleBottom = new Rectangle(x, e.RowBounds.Top + e.RowBounds.Height - 8, width, 4);

                e.Graphics.FillRectangle(redBrush, rectangleTop);
                e.Graphics.FillRectangle(redBrush, rectangleBottom);
            }
        }

        public void BrightForeColorInDeleted(DataGridViewCellFormattingEventArgs e)
        {
            bool deleted = (bool)_labBookForm.GetDgvLabBook.Rows[e.RowIndex].Cells["deleted"].Value;

            if (deleted)
            {
                e.CellStyle.ForeColor = LightGrey;
            }
        }

        #endregion
    }
}
