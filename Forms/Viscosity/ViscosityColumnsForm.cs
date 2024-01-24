using LabBook.Commons;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LabBook.Forms.Viscosity
{
    /*
     * After update CheckBoxes or change his names, update ColumnData with new names of the CheckBoxes !!!!
     */
    public partial class ViscosityColumnsForm : Form
    {
        public string Result { get; set; } = "";

        private readonly string _fields;
        private IList<string> _selectedColumns = new List<string>();
        private IDictionary<string, string> _viscosityColumns = new Dictionary<string, string>();
        

        public ViscosityColumnsForm(string column)
        {
            _fields = column;
            InitializeComponent();
        }

        private void ViscosityColumnsForm_Load(object sender, System.EventArgs e)
        {
            InitFields();
            PrepareDataFromColumnData();
        }

        private void PrepareDataFromColumnData()
        {
            foreach (var column in ColumnData.GetViscosityColumns)
            {
                string key = column.Key;
                string value = column.Value[4];
                if (value == "NULL")
                    continue;
                _viscosityColumns.Add(value, key);
            }
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

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            _selectedColumns.Clear();
            foreach(var con in Controls.OfType<CheckBox>())
            {
                if (con.Checked)
                    _selectedColumns.Add(_viscosityColumns[con.Name]);
            }

            Result = "";
            foreach (string column in _selectedColumns)
            {
                Result += column;
                Result += "|";
            }

            if (Result.Length > 0)
            {
                Result = Result.Substring(0, Result.Length - 1);
            }
            Close();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            _selectedColumns.Clear();
            Close();
        }
    }
}
