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

        public bool isAdmin => _user.Permission.ToLower().Equals("admin");
        public DataGridView GetDgvLabBook => DgvLabBook;
        public BindingNavigator GetBindingNavigator => BindingNavigatorMain;
        public TextBox GetNrDFilter => TxtNrDFilter;
        public TextBox GetTitleFilter => TxtTitleFilter;
        public TextBox GetIdentifierFilter => TxtIdentifierFilter;
        public ComboBox GetComboCycleFilter => CmbCycleFilter;

        #region Form Open/Load/Closing

        private void LabBookForm_Load(object sender, System.EventArgs e)
        {
            _service.LoadFormData(this);
            _service.PreapreAllData();
            Resize += LabBookForm_Resize;
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

    }
}
