using LabBook.ADO;
using LabBook.Commons;
using LabBook.Forms.LabBook;
using LabBook.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LabBook.Service
{
    public class LabBookService
    {
        private static readonly string dataFormFileName = "LabBookForm";

        private readonly User _user;
        private readonly SqlConnection _connection;
        private readonly LabBookForm _labBookForm;
        private readonly LabBookRepository _labBookRepository;
        private readonly ExpCycleRepository _expCycleRepository;

        private DataTable _labBookTable;
        private DataView _labBookView;
        private BindingSource _labBookBindingSource;

        private IList<ExpCycle> _expCycles;

        private IDictionary<string, double> _formData = CommonFunction.LoadWindowsDataAsDictionary(dataFormFileName);

        public LabBookService(LabBookForm labBookForm, SqlConnection connection, User user)
        {
            _user = user;
            _connection = connection;
            _labBookForm = labBookForm;
            _labBookRepository = new LabBookRepository(_user, _connection);
            _expCycleRepository = new ExpCycleRepository(_connection);
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

            GetAllExpCycles();
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
            view.RowHeadersWidth = _labBookForm.isAdmin ? 35 : 40;
            view.DefaultCellStyle.ForeColor = Color.Black;
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.AutoGenerateColumns = false;

            view.Columns["user_id"].Visible = false;
            view.Columns["cycle_id"].Visible = false;
            view.Columns["project_id"].Visible = false;
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

        #endregion


        #region Load Data from Database

        private void GetAllLabBook()
        {
            _labBookTable = _labBookRepository.GetAllLabBook();
            _labBookView = new DataView(_labBookTable);
            _labBookView.Sort = "id";

            _labBookBindingSource = new BindingSource();
            _labBookBindingSource.DataSource = _labBookView;
            _labBookBindingSource.PositionChanged += LabBookBindingSource_PositionChanged;
            _labBookForm.GetBindingNavigator.BindingSource = _labBookBindingSource;
        }

        private void GetAllExpCycles()
        {
            _expCycles = _expCycleRepository.GetAllExpCycles();
            _labBookForm.GetComboExpCycle.DataSource = _expCycles;
            _labBookForm.GetComboExpCycle.ValueMember = "Id";
            _labBookForm.GetComboExpCycle.DisplayMember = "Name";
            _labBookForm.GetComboExpCycle.SelectedIndexChanged += GetComboExpCycle_SelectedIndexChanged;

            _labBookForm.GetComboCycleFilter.DataSource = _expCycles;
            _labBookForm.GetComboCycleFilter.ValueMember = "Id";
            _labBookForm.GetComboCycleFilter.DisplayMember = "Name";
        }

        #endregion


        #region Navigation and Currents

        private void LabBookBindingSource_PositionChanged(object sender, System.EventArgs e)
        {

        }

        private void GetComboExpCycle_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        #endregion
    }
}
