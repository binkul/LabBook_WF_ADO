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

        private DataTable _labBookTable;
        private DataView _labBookView;
        private BindingSource _labBookBindingSource;

        public LabBookService(LabBookForm labBookForm, SqlConnection connection, User user)
        {
            _user = user;
            _connection = connection;
            _labBookForm = labBookForm;
            _labBookRepository = new LabBookRepository(_user, _connection);
        }

        #region Save and Load data for LabBook form 

        public void SaveFormData(LabBookForm labBookForm)
        {
            List<double> list = new List<double>
            {
                labBookForm.Left,
                labBookForm.Top,
                labBookForm.Width,
                labBookForm.Height,
            };
            CommonFunction.WriteWindowsData(list, dataFormFileName);
        }

        internal void LoadFormData(LabBookForm labBookForm)
        {
            List<double> list = CommonFunction.LoadWindowsData(dataFormFileName);

            if (list.Count == 4)
            {
                labBookForm.Left = (int)list[0];
                labBookForm.Top = (int)list[1];
                labBookForm.Width = (int)list[2];
                labBookForm.Height = (int)list[3];
            }
        }

        #endregion


        #region Prepare all data

        public void PreapreAllData()
        {
            GetAllLabBook();
            PrepareDataGridViewLabBook();

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
            view.Columns.Remove("name");

            view.Columns["id"].HeaderText = "Nr D";
            view.Columns["id"].ReadOnly = true;
            view.Columns["id"].DisplayIndex = 0;
            view.Columns["id"].Width = 70;
            view.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["id"].Resizable = DataGridViewTriState.False;

            view.Columns["title"].HeaderText = "Tytuł";
            view.Columns["title"].ReadOnly = true;
            view.Columns["title"].DisplayIndex = 1;
            view.Columns["title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            view.Columns["density"].HeaderText = "Gęstość";
            view.Columns["density"].DisplayIndex = 2;
            view.Columns["density"].Width = 95;
            view.Columns["density"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["density"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["density"].Resizable = DataGridViewTriState.False;

            view.Columns["identifier"].HeaderText = "User";
            view.Columns["identifier"].DisplayIndex = 3;
            view.Columns["identifier"].ReadOnly = true;
            view.Columns["identifier"].Width = 75;
            view.Columns["identifier"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["identifier"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["identifier"].Resizable = DataGridViewTriState.False;

            view.Columns["modified"].HeaderText = "Modyfikacja";
            view.Columns["modified"].DisplayIndex = 4;
            view.Columns["modified"].ReadOnly = true;
            view.Columns["modified"].Width = 120;
            view.Columns["modified"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Columns["modified"].SortMode = DataGridViewColumnSortMode.NotSortable;
            view.Columns["modified"].Resizable = DataGridViewTriState.False;
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

        #endregion


        #region Navigation and Currents

        private void LabBookBindingSource_PositionChanged(object sender, System.EventArgs e)
        {

        }

        #endregion
    }
}
