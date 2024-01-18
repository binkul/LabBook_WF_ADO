using LabBook.ADO;
using LabBook.Commons;
using LabBook.Forms.LabBook;
using LabBook.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

enum ViscosityType
{
    NOT_SET,
    START,
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
        private readonly ViscosityRepository _viscosityRepository;

        private DataTable _labBookTable;
        private DataView _labBookView;
        private BindingSource _labBookBindingSource;
        private DataRowView _currentLabBook;
        private DataTable _viscosityTable;
        private DataView _viscosityView;
        private ViscosityColumn _viscosityColumnsOld = null;
        private ViscosityColumn _viscosityColumnsCurrent = new ViscosityColumn("START");

        private bool _modified = false;
        private bool _visModified = false;

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
            _viscosityRepository = new ViscosityRepository(_connection);
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
            FillComboBoxes();
            PrepareOthersControls();

            //LabBookBindingSource_PositionChanged(null, null);
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
            view.DataSource = _viscosityView;
            view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.RowsDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Regular);
            view.ColumnHeadersDefaultCellStyle.Font = new Font(view.DefaultCellStyle.Font.Name, 9, FontStyle.Bold);
            view.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.AutoGenerateColumns = false;
            view.RowHeadersWidth = 35;
            view.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns["id"].Visible = false;
            view.Columns["id"].DisplayIndex = ColumnData.GetViscosityColumns.Count - 2;
            view.Columns["labbook_id"].Visible = false;
            view.Columns["labbook_id"].DisplayIndex = ColumnData.GetViscosityColumns.Count - 1;
            view.Columns.Remove("vis_type");

            foreach (DataGridViewColumn column in view.Columns)
            {
                string data;
                if (ColumnData.GetViscosityColumns.TryGetValue(column.Name, out data))
                {
                    string[] colData = data.Split('|');
                    view.Columns[column.Name].HeaderText = colData[0];
                    view.Columns[column.Name].DisplayIndex = int.Parse(colData[1]);
                    view.Columns[column.Name].Width = int.Parse(colData[2]);
                    view.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            view.Columns["days_distance"].Frozen = true;
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
            _labBookTable = _labBookRepository.GetAllLabBook();
            _labBookTable.ColumnChanged += LabBookTable_ColumnChanged;
            _labBookView = new DataView(_labBookTable);
            _labBookView.Sort = "id";

            _labBookBindingSource = new BindingSource();
            _labBookBindingSource.DataSource = _labBookView;
            _labBookBindingSource.PositionChanged += LabBookBindingSource_PositionChanged;
            _labBookForm.GetBindingNavigator.BindingSource = _labBookBindingSource;

            _viscosityTable = _viscosityRepository.GetViscosityByLabBookId(-1);
            _viscosityTable.ColumnChanged += ViscosityTable_ColumnChanged;
            _viscosityView = new DataView(_viscosityTable);
            _viscosityView.Sort = "date_created, date_update";
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

        #endregion


        #region Current/Binkding/Navigation/DataTable

        private void LabBookTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            Modify = true;
        }

        private void ViscosityTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            ViscosityModify = true;
        }

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

            #region Reload Viscosity

            if (_currentLabBook != null)
            {
                ReloadViscosity(id);
                _viscosityColumnsOld = _viscosityColumnsCurrent;
                _viscosityColumnsCurrent = _viscosityRepository.GetViscosityColumnById(id);
                ShowViscosityColumns();
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

        private void ShowViscosityColumns()
        {
            if (_viscosityColumnsOld.Type == _viscosityColumnsCurrent.Type)
            {
                return;
            }
            else
            {
                DataGridView view = _labBookForm.GetDgvViscosity;
                HideViscosityColumns();
                ViscosityType type;
                Enum.TryParse(_viscosityColumnsCurrent.Type, out type);
                string[] columns;

                switch (type)
                {
                    case ViscosityType.START:
                        columns = ColumnData.START_FIELDS.Split('|');
                        break;
                    case ViscosityType.NOT_SET:
                        columns = ColumnData.STD_FIELDS.Split('|');
                        break;
                    case ViscosityType.STD:
                        columns = ColumnData.STD_FIELDS.Split('|');
                        break;
                    case ViscosityType.STD_X:
                        columns = ColumnData.STD_X_FIELDS.Split('|');
                        break;
                    case ViscosityType.PRB:
                        columns = ColumnData.PRB_FIELDS.Split('|');
                        break;
                    case ViscosityType.SOLVENT:
                        columns = ColumnData.SLV_FIELDS.Split('|');
                        break;
                    case ViscosityType.SOLVENT_X:
                        columns = ColumnData.SLV_X_FIELDS.Split('|');
                        break;
                    case ViscosityType.KREBS:
                        columns = ColumnData.KREBS_FIELDS.Split('|');
                        break;
                    case ViscosityType.ICI:
                        columns = ColumnData.ICI_FIELDS.Split('|');
                        break;
                    case ViscosityType.KREBS_ICI:
                        columns = ColumnData.KREBS_ICI_FIELDS.Split('|');
                        break;
                    case ViscosityType.FULL:
                        columns = ColumnData.FULL_FIELDS.Split('|');
                        break;
                    case ViscosityType.SPEC:
                        columns = _viscosityColumnsCurrent.Fields.Split('|');
                        break;
                    default:
                        columns = ColumnData.STD_FIELDS.Split('|');
                        break;
                }

                foreach (string col in columns)
                {
                    if (ColumnData.GetViscosityColumns.ContainsKey(col))
                    {
                        view.Columns[col].Visible = true;
                    }
                }

            }
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
