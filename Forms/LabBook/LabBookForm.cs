using LabBook.ADO;
using LabBook.Service;
using System.Data.SqlClient;
using System.Drawing;
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
        public DataGridView GetDgvViscosity => DgvViscosity;
        public BindingNavigator GetBindingNavigator => BindingNavigatorMain;
        public TextBox GetTitle => TxtTitle;
        public TextBox GetNrDFilter => TxtNrDFilter;
        public TextBox GetTitleFilter => TxtTitleFilter;
        public TextBox GetIdentifierFilter => TxtIdentifierFilter;
        public RichTextBox GetConclusion => RtbConclusion;
        public RichTextBox GetObservation => RtbObservation;
        public Label GetLabelNrD => LblNrD;
        public Label GetDateCreated => LblDateCreated;
        public Label GetDateModified => LblDateModified;
        public ComboBox GetExpCmbCycle => CmbExpCycle;
        public ComboBox GetComboCycleFilter => CmbCycleFilter;
        public ComboBox GetComboExpCycle => CmbExpCycle;

        public void EnableSaveButton() => BtnSave.Enabled = _service.Modify | _service.ViscosityModify;

        #region Form Open/Load/Closing

        private void LabBookForm_Load(object sender, System.EventArgs e)
        {
            _service.LoadFormData(this);
            _service.PreapreAllData();
            Resize += LabBookForm_Resize;

            DgvLabBook.RowPostPaint += DgvLabBook_RowPostPaint;
            DgvLabBook.CellFormatting += DgvLabBook_CellFormatting;
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

        private void DgvLabBook_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _service.BrightForeColorInDeleted(e);
        }

        #endregion


        #region Events

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

        private void TxtNrDFilter_TextChanged(object sender, System.EventArgs e)
        {
            _service.Filter();
        }

        private void CmbCycleFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _service.Filter();
        }

        private void BtnAddNew_Click(object sender, System.EventArgs e)
        {
            _service.AddNewButton();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            _service.SaveButton();
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            _service.DeleteButton();
        }

        private void DgvViscosity_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            _service.DefaultValuesForViscosityDGV(e);
        }

        private void StandardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem position = (ToolStripMenuItem)sender;

            int nr = 0;
            if (int.TryParse(position.Tag.ToString(), out nr))
            {
                SelectViscosityItem(nr);
                _service.SelectViscosityView(nr);
            }
        }

        private void LabBookTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TabControl tab = (TabControl)sender;
            
            if (tab.SelectedTab.Name == "TabPageViscosity")
            {
                ViscosityToolStripMenuItem.Enabled = true;
            }
            else
            {
                ViscosityToolStripMenuItem.Enabled = false;
            }
        }

        #endregion

        #region Others function

        public void SelectViscosityItem(int position)
        {
            DeselctAllViscosityItems();
            switch (position)
            {
                case 0:
                    StandardToolStripMenuItem.Checked = true;
                    break;
                case 1:
                    StandardXToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    PrbToolStripMenuItem.Checked = true;
                    break;
                case 3:
                    SolventToolStripMenuItem.Checked = true;
                    break;
                case 4:
                    SolventXToolStripMenuItem.Checked = true;
                    break;
                case 5:
                    KrebsStripMenuItem.Checked = true;
                    break;
                case 6:
                    IciToolStripMenuItem.Checked = true;
                    break;
                case 7:
                    KrebsICIToolStripMenuItem.Checked = true;
                    break;
                default:
                    FullToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void DeselctAllViscosityItems()
        {
            foreach (ToolStripMenuItem item in ViscosityToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
        }

        #endregion
    }
}
