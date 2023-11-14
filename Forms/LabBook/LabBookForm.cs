using LabBook.ADO;
using LabBook.Service;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabBook.Forms.LabBook
{
    public partial class LabBookForm : Form
    {
        private readonly User _user;
        private readonly SqlConnection _connection;
        private readonly LabBookService _service;

        public LabBookForm(User user, SqlConnection connection)
        {
            InitializeComponent();
            _user = user;
            _connection = connection;
            _service = new LabBookService(this, _connection, _user);
        }

        public bool IsAdmin => _user.Permission.ToLower().Equals("admin");
        public DataGridView GetDgvLabBook => DgvLabBook;
        public BindingNavigator GetBindingNavigator => BindingNavigatorMain;
        public TextBox GetTxtTitle => TxtTitle;
        public TextBox GetNrDFilter => TxtNrDFilter;
        public TextBox GetTitleFilter => TxtTitleFilter;
        public TextBox GetIdentifierFilter => TxtIdentifierFilter;
        public ComboBox GetExpCmbCycle => CmbExpCycle;
        public ComboBox GetCmbProject => CmbProject;
        public ComboBox GetComboCycleFilter => CmbCycleFilter;
        public ComboBox GetComboExpCycle => CmbExpCycle;

        #region Form Open/Load/Closing

        private void LabBookForm_Load(object sender, System.EventArgs e)
        {
            _service.LoadFormData(this);
            _service.PreapreAllData();
            Resize += LabBookForm_Resize;

            if (!IsAdmin)
            {
                DgvLabBook.RowPostPaint += DgvLabBook_RowPostPaint; ;
            }
        }


        private void LabBookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                _service.SaveFormData(this);
                FormClosing -= LabBookForm_FormClosing;
                Application.Exit();
            }
        }

        #endregion

        #region Resize and change Filter boxes

        private void LabBookForm_Resize(object sender, System.EventArgs e)
        {
            _service.ResizeFilters();
        }

        private void DgvLabBook_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            _service.ResizeFilters();
        }

        #endregion


        #region DataGridView Events

        private void DgvLabBook_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            _service.IconInCellPainting(e);
        }

        #endregion

        private void TxtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{Tab}");
            }

            else
            {
                base.OnKeyPress(e);
            }
        }
    }
}
