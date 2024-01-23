using LabBook.Commons;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabBook.Forms.Viscosity
{
    public partial class ViscosityColumnsForm : Form
    {
        private readonly string _fields;
        public string Result { get; } = "";

        public ViscosityColumnsForm(string column)
        {
            _fields = column;
            InitializeComponent();
        }

        private void ViscosityColumnsForm_Load(object sender, System.EventArgs e)
        {
            InitFields();
        }

        private void InitFields()
        {
            if (!string.IsNullOrEmpty(_fields))
            {
                string[] separate = _fields.Split('|');
                IList<string> columns = new List<string>(separate);

                foreach (string column in columns)
                {
                    if (ColumnData.GetViscosityColumns.TryGetValue(column, out IList<string> data))
                    {
                        CheckBox box = (CheckBox)Controls.Find(data[4], true)[0];
                        box.Checked = true;
                    }
                }                
            }
        }
    }
}
