using LabBook.ADO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabBook.Forms.LabBook
{
    public partial class LabBookForm : Form
    {
        private readonly User _user;
        private readonly SqlConnection _connection;

        public LabBookForm(User user, SqlConnection connection)
        {
            _user = user;
            _connection = connection;
            InitializeComponent();
        }
    }
}
