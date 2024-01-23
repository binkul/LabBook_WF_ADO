using System.Windows.Forms;

namespace LabBook.Forms.Viscosity
{
    public partial class ViscosityColumnsForm : Form
    {
        private readonly string _columns;
        public string Result { get; } = "";

        public ViscosityColumnsForm(string column)
        {
            _columns = column;
            InitializeComponent();
        }

        private void ViscosityColumnsForm_Load(object sender, System.EventArgs e)
        {

        }

        private void InitFields()
        {

        }
    }
}
