
namespace LabBook.Forms.LabBook
{
    partial class LabBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabBookForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AplicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TspContrastStd = new System.Windows.Forms.ToolStripMenuItem();
            this.TspContrastPRB = new System.Windows.Forms.ToolStripMenuItem();
            this.TspContrastStdPRB = new System.Windows.Forms.ToolStripMenuItem();
            this.TspContrastKF = new System.Windows.Forms.ToolStripMenuItem();
            this.AllApplicatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViscosityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StandardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StandardXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SolventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SolventXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KrebsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KrebsICIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblNrD = new System.Windows.Forms.Label();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.LblDateCreated = new System.Windows.Forms.Label();
            this.BindingNavigatorMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LabBookTabControl = new System.Windows.Forms.TabControl();
            this.TabPageMain = new System.Windows.Forms.TabPage();
            this.CmbCycleFilter = new System.Windows.Forms.ComboBox();
            this.TxtIdentifierFilter = new System.Windows.Forms.TextBox();
            this.TxtTitleFilter = new System.Windows.Forms.TextBox();
            this.TxtNrDFilter = new System.Windows.Forms.TextBox();
            this.DgvLabBook = new System.Windows.Forms.DataGridView();
            this.TabPageRemarks = new System.Windows.Forms.TabPage();
            this.RtbConclusion = new System.Windows.Forms.RichTextBox();
            this.TabPageObservation = new System.Windows.Forms.TabPage();
            this.RtbObservation = new System.Windows.Forms.RichTextBox();
            this.TabPageViscosity = new System.Windows.Forms.TabPage();
            this.DgvViscosity = new System.Windows.Forms.DataGridView();
            this.TabPageContrast = new System.Windows.Forms.TabPage();
            this.BtnContrastDown = new System.Windows.Forms.Button();
            this.BtnContrastUp = new System.Windows.Forms.Button();
            this.DgvContrast = new System.Windows.Forms.DataGridView();
            this.TabPageGloss = new System.Windows.Forms.TabPage();
            this.TabPageClass = new System.Windows.Forms.TabPage();
            this.TabPageResults = new System.Windows.Forms.TabPage();
            this.CmbExpCycle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblDateModified = new System.Windows.Forms.Label();
            this.BtnConProject = new System.Windows.Forms.Button();
            this.BtnOpenProject = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAddNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigatorMain)).BeginInit();
            this.BindingNavigatorMain.SuspendLayout();
            this.LabBookTabControl.SuspendLayout();
            this.TabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLabBook)).BeginInit();
            this.TabPageRemarks.SuspendLayout();
            this.TabPageObservation.SuspendLayout();
            this.TabPageViscosity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViscosity)).BeginInit();
            this.TabPageContrast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.dodajToolStripMenuItem,
            this.widokToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1227, 31);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(54, 27);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AplicatorToolStripMenuItem});
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // AplicatorToolStripMenuItem
            // 
            this.AplicatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TspContrastStd,
            this.TspContrastPRB,
            this.TspContrastStdPRB,
            this.TspContrastKF,
            this.AllApplicatorMenuItem});
            this.AplicatorToolStripMenuItem.Enabled = false;
            this.AplicatorToolStripMenuItem.Name = "AplicatorToolStripMenuItem";
            this.AplicatorToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.AplicatorToolStripMenuItem.Text = "Aplikator";
            // 
            // TspContrastStd
            // 
            this.TspContrastStd.Name = "TspContrastStd";
            this.TspContrastStd.Size = new System.Drawing.Size(224, 28);
            this.TspContrastStd.Tag = "STD";
            this.TspContrastStd.Text = "Standard";
            this.TspContrastStd.Click += new System.EventHandler(this.ContrastToolStripMenuItem_Click);
            // 
            // TspContrastPRB
            // 
            this.TspContrastPRB.Name = "TspContrastPRB";
            this.TspContrastPRB.Size = new System.Drawing.Size(224, 28);
            this.TspContrastPRB.Tag = "PRB";
            this.TspContrastPRB.Text = "PRB";
            this.TspContrastPRB.Click += new System.EventHandler(this.ContrastToolStripMenuItem_Click);
            // 
            // TspContrastStdPRB
            // 
            this.TspContrastStdPRB.Name = "TspContrastStdPRB";
            this.TspContrastStdPRB.Size = new System.Drawing.Size(224, 28);
            this.TspContrastStdPRB.Tag = "STD_PRB";
            this.TspContrastStdPRB.Text = "Standard+PRB";
            this.TspContrastStdPRB.Click += new System.EventHandler(this.ContrastToolStripMenuItem_Click);
            // 
            // TspContrastKF
            // 
            this.TspContrastKF.Name = "TspContrastKF";
            this.TspContrastKF.Size = new System.Drawing.Size(224, 28);
            this.TspContrastKF.Tag = "KF";
            this.TspContrastKF.Text = "Standard+KF";
            this.TspContrastKF.Click += new System.EventHandler(this.ContrastToolStripMenuItem_Click);
            // 
            // AllApplicatorMenuItem
            // 
            this.AllApplicatorMenuItem.Name = "AllApplicatorMenuItem";
            this.AllApplicatorMenuItem.Size = new System.Drawing.Size(224, 28);
            this.AllApplicatorMenuItem.Text = "Wszystkie";
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViscosityToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(77, 27);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // ViscosityToolStripMenuItem
            // 
            this.ViscosityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StandardToolStripMenuItem,
            this.StandardXToolStripMenuItem,
            this.PrbToolStripMenuItem,
            this.SolventToolStripMenuItem,
            this.SolventXToolStripMenuItem,
            this.KrebsStripMenuItem,
            this.IciToolStripMenuItem,
            this.KrebsICIToolStripMenuItem,
            this.FullToolStripMenuItem,
            this.SetToolStripMenuItem});
            this.ViscosityToolStripMenuItem.Enabled = false;
            this.ViscosityToolStripMenuItem.Name = "ViscosityToolStripMenuItem";
            this.ViscosityToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.ViscosityToolStripMenuItem.Text = "Lepkość";
            // 
            // StandardToolStripMenuItem
            // 
            this.StandardToolStripMenuItem.Checked = true;
            this.StandardToolStripMenuItem.CheckOnClick = true;
            this.StandardToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StandardToolStripMenuItem.Name = "StandardToolStripMenuItem";
            this.StandardToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.StandardToolStripMenuItem.Tag = "0";
            this.StandardToolStripMenuItem.Text = "Standard";
            this.StandardToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // StandardXToolStripMenuItem
            // 
            this.StandardXToolStripMenuItem.CheckOnClick = true;
            this.StandardXToolStripMenuItem.Name = "StandardXToolStripMenuItem";
            this.StandardXToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.StandardXToolStripMenuItem.Tag = "1";
            this.StandardXToolStripMenuItem.Text = "Standrad X";
            this.StandardXToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // PrbToolStripMenuItem
            // 
            this.PrbToolStripMenuItem.CheckOnClick = true;
            this.PrbToolStripMenuItem.Name = "PrbToolStripMenuItem";
            this.PrbToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.PrbToolStripMenuItem.Tag = "2";
            this.PrbToolStripMenuItem.Text = "PRB";
            this.PrbToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // SolventToolStripMenuItem
            // 
            this.SolventToolStripMenuItem.CheckOnClick = true;
            this.SolventToolStripMenuItem.Name = "SolventToolStripMenuItem";
            this.SolventToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.SolventToolStripMenuItem.Tag = "3";
            this.SolventToolStripMenuItem.Text = "Rozpuszczalnik";
            this.SolventToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // SolventXToolStripMenuItem
            // 
            this.SolventXToolStripMenuItem.CheckOnClick = true;
            this.SolventXToolStripMenuItem.Name = "SolventXToolStripMenuItem";
            this.SolventXToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.SolventXToolStripMenuItem.Tag = "4";
            this.SolventXToolStripMenuItem.Text = "Rozpuszczalnik X";
            this.SolventXToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // KrebsStripMenuItem
            // 
            this.KrebsStripMenuItem.CheckOnClick = true;
            this.KrebsStripMenuItem.Name = "KrebsStripMenuItem";
            this.KrebsStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.KrebsStripMenuItem.Tag = "5";
            this.KrebsStripMenuItem.Text = "Krebs";
            this.KrebsStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // IciToolStripMenuItem
            // 
            this.IciToolStripMenuItem.CheckOnClick = true;
            this.IciToolStripMenuItem.Name = "IciToolStripMenuItem";
            this.IciToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.IciToolStripMenuItem.Tag = "6";
            this.IciToolStripMenuItem.Text = "ICI";
            this.IciToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // KrebsICIToolStripMenuItem
            // 
            this.KrebsICIToolStripMenuItem.CheckOnClick = true;
            this.KrebsICIToolStripMenuItem.Name = "KrebsICIToolStripMenuItem";
            this.KrebsICIToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.KrebsICIToolStripMenuItem.Tag = "7";
            this.KrebsICIToolStripMenuItem.Text = "Krebs + ICI";
            this.KrebsICIToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // FullToolStripMenuItem
            // 
            this.FullToolStripMenuItem.CheckOnClick = true;
            this.FullToolStripMenuItem.Name = "FullToolStripMenuItem";
            this.FullToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.FullToolStripMenuItem.Tag = "8";
            this.FullToolStripMenuItem.Text = "FULL";
            this.FullToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // SetToolStripMenuItem
            // 
            this.SetToolStripMenuItem.Name = "SetToolStripMenuItem";
            this.SetToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.SetToolStripMenuItem.Tag = "9";
            this.SetToolStripMenuItem.Text = "Wybrane";
            this.SetToolStripMenuItem.Click += new System.EventHandler(this.ViscosityToolStripMenuItem_Click);
            // 
            // LblNrD
            // 
            this.LblNrD.AutoSize = true;
            this.LblNrD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblNrD.ForeColor = System.Drawing.Color.Blue;
            this.LblNrD.Location = new System.Drawing.Point(12, 101);
            this.LblNrD.Name = "LblNrD";
            this.LblNrD.Size = new System.Drawing.Size(32, 25);
            this.LblNrD.TabIndex = 2;
            this.LblNrD.Text = "-1";
            // 
            // TxtTitle
            // 
            this.TxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TxtTitle.Location = new System.Drawing.Point(115, 101);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(812, 27);
            this.TxtTitle.TabIndex = 1;
            this.TxtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTitle_KeyPress);
            // 
            // LblDateCreated
            // 
            this.LblDateCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDateCreated.AutoSize = true;
            this.LblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblDateCreated.ForeColor = System.Drawing.Color.Blue;
            this.LblDateCreated.Location = new System.Drawing.Point(1074, 104);
            this.LblDateCreated.Name = "LblDateCreated";
            this.LblDateCreated.Size = new System.Drawing.Size(59, 20);
            this.LblDateCreated.TabIndex = 4;
            this.LblDateCreated.Text = "BRAK";
            // 
            // BindingNavigatorMain
            // 
            this.BindingNavigatorMain.AddNewItem = null;
            this.BindingNavigatorMain.CountItem = this.bindingNavigatorCountItem;
            this.BindingNavigatorMain.DeleteItem = this.bindingNavigatorDeleteItem;
            this.BindingNavigatorMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BindingNavigatorMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BindingNavigatorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.BindingNavigatorMain.Location = new System.Drawing.Point(0, 626);
            this.BindingNavigatorMain.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BindingNavigatorMain.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BindingNavigatorMain.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BindingNavigatorMain.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BindingNavigatorMain.Name = "BindingNavigatorMain";
            this.BindingNavigatorMain.PositionItem = this.bindingNavigatorPositionItem;
            this.BindingNavigatorMain.Size = new System.Drawing.Size(1227, 27);
            this.BindingNavigatorMain.TabIndex = 5;
            this.BindingNavigatorMain.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 24);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Suma elementów";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Usuń";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Przenieś pierwszy";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Przenieś poprzedni";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Pozycja";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Bieżąca pozycja";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Przenieś następny";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Przenieś ostatni";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // LabBookTabControl
            // 
            this.LabBookTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabBookTabControl.Controls.Add(this.TabPageMain);
            this.LabBookTabControl.Controls.Add(this.TabPageRemarks);
            this.LabBookTabControl.Controls.Add(this.TabPageObservation);
            this.LabBookTabControl.Controls.Add(this.TabPageViscosity);
            this.LabBookTabControl.Controls.Add(this.TabPageContrast);
            this.LabBookTabControl.Controls.Add(this.TabPageGloss);
            this.LabBookTabControl.Controls.Add(this.TabPageClass);
            this.LabBookTabControl.Controls.Add(this.TabPageResults);
            this.LabBookTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabBookTabControl.Location = new System.Drawing.Point(0, 178);
            this.LabBookTabControl.Name = "LabBookTabControl";
            this.LabBookTabControl.SelectedIndex = 0;
            this.LabBookTabControl.Size = new System.Drawing.Size(1227, 445);
            this.LabBookTabControl.TabIndex = 6;
            this.LabBookTabControl.SelectedIndexChanged += new System.EventHandler(this.LabBookTabControl_SelectedIndexChanged);
            // 
            // TabPageMain
            // 
            this.TabPageMain.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageMain.Controls.Add(this.CmbCycleFilter);
            this.TabPageMain.Controls.Add(this.TxtIdentifierFilter);
            this.TabPageMain.Controls.Add(this.TxtTitleFilter);
            this.TabPageMain.Controls.Add(this.TxtNrDFilter);
            this.TabPageMain.Controls.Add(this.DgvLabBook);
            this.TabPageMain.Location = new System.Drawing.Point(4, 29);
            this.TabPageMain.Name = "TabPageMain";
            this.TabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMain.Size = new System.Drawing.Size(1219, 412);
            this.TabPageMain.TabIndex = 0;
            this.TabPageMain.Text = "Strona główna";
            // 
            // CmbCycleFilter
            // 
            this.CmbCycleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCycleFilter.FormattingEnabled = true;
            this.CmbCycleFilter.Location = new System.Drawing.Point(255, 16);
            this.CmbCycleFilter.Name = "CmbCycleFilter";
            this.CmbCycleFilter.Size = new System.Drawing.Size(177, 28);
            this.CmbCycleFilter.TabIndex = 4;
            this.CmbCycleFilter.SelectedIndexChanged += new System.EventHandler(this.CmbCycleFilter_SelectedIndexChanged);
            // 
            // TxtIdentifierFilter
            // 
            this.TxtIdentifierFilter.Location = new System.Drawing.Point(507, 16);
            this.TxtIdentifierFilter.Name = "TxtIdentifierFilter";
            this.TxtIdentifierFilter.Size = new System.Drawing.Size(94, 27);
            this.TxtIdentifierFilter.TabIndex = 3;
            this.TxtIdentifierFilter.TextChanged += new System.EventHandler(this.TxtNrDFilter_TextChanged);
            // 
            // TxtTitleFilter
            // 
            this.TxtTitleFilter.Location = new System.Drawing.Point(111, 16);
            this.TxtTitleFilter.Name = "TxtTitleFilter";
            this.TxtTitleFilter.Size = new System.Drawing.Size(122, 27);
            this.TxtTitleFilter.TabIndex = 2;
            this.TxtTitleFilter.TextChanged += new System.EventHandler(this.TxtNrDFilter_TextChanged);
            // 
            // TxtNrDFilter
            // 
            this.TxtNrDFilter.Location = new System.Drawing.Point(8, 16);
            this.TxtNrDFilter.Name = "TxtNrDFilter";
            this.TxtNrDFilter.Size = new System.Drawing.Size(97, 27);
            this.TxtNrDFilter.TabIndex = 1;
            this.TxtNrDFilter.TextChanged += new System.EventHandler(this.TxtNrDFilter_TextChanged);
            // 
            // DgvLabBook
            // 
            this.DgvLabBook.AllowUserToAddRows = false;
            this.DgvLabBook.AllowUserToDeleteRows = false;
            this.DgvLabBook.AllowUserToResizeRows = false;
            this.DgvLabBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvLabBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLabBook.Location = new System.Drawing.Point(3, 49);
            this.DgvLabBook.Name = "DgvLabBook";
            this.DgvLabBook.RowHeadersWidth = 51;
            this.DgvLabBook.RowTemplate.Height = 24;
            this.DgvLabBook.Size = new System.Drawing.Size(1208, 357);
            this.DgvLabBook.TabIndex = 0;
            this.DgvLabBook.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvLabBook_ColumnWidthChanged);
            // 
            // TabPageRemarks
            // 
            this.TabPageRemarks.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageRemarks.Controls.Add(this.RtbConclusion);
            this.TabPageRemarks.Location = new System.Drawing.Point(4, 29);
            this.TabPageRemarks.Name = "TabPageRemarks";
            this.TabPageRemarks.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRemarks.Size = new System.Drawing.Size(1219, 412);
            this.TabPageRemarks.TabIndex = 1;
            this.TabPageRemarks.Text = "Uwagi";
            // 
            // RtbConclusion
            // 
            this.RtbConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbConclusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RtbConclusion.Location = new System.Drawing.Point(3, 6);
            this.RtbConclusion.Name = "RtbConclusion";
            this.RtbConclusion.Size = new System.Drawing.Size(1212, 400);
            this.RtbConclusion.TabIndex = 0;
            this.RtbConclusion.Text = "";
            // 
            // TabPageObservation
            // 
            this.TabPageObservation.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageObservation.Controls.Add(this.RtbObservation);
            this.TabPageObservation.Location = new System.Drawing.Point(4, 29);
            this.TabPageObservation.Name = "TabPageObservation";
            this.TabPageObservation.Size = new System.Drawing.Size(1219, 412);
            this.TabPageObservation.TabIndex = 2;
            this.TabPageObservation.Text = "Obserwacje";
            // 
            // RtbObservation
            // 
            this.RtbObservation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbObservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RtbObservation.Location = new System.Drawing.Point(3, 3);
            this.RtbObservation.Name = "RtbObservation";
            this.RtbObservation.Size = new System.Drawing.Size(1213, 406);
            this.RtbObservation.TabIndex = 0;
            this.RtbObservation.Text = "";
            // 
            // TabPageViscosity
            // 
            this.TabPageViscosity.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageViscosity.Controls.Add(this.DgvViscosity);
            this.TabPageViscosity.Location = new System.Drawing.Point(4, 29);
            this.TabPageViscosity.Name = "TabPageViscosity";
            this.TabPageViscosity.Size = new System.Drawing.Size(1219, 412);
            this.TabPageViscosity.TabIndex = 3;
            this.TabPageViscosity.Text = "Lepkość";
            // 
            // DgvViscosity
            // 
            this.DgvViscosity.AllowUserToDeleteRows = false;
            this.DgvViscosity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvViscosity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvViscosity.Location = new System.Drawing.Point(0, 3);
            this.DgvViscosity.Name = "DgvViscosity";
            this.DgvViscosity.RowHeadersWidth = 51;
            this.DgvViscosity.RowTemplate.Height = 24;
            this.DgvViscosity.Size = new System.Drawing.Size(1215, 406);
            this.DgvViscosity.TabIndex = 0;
            this.DgvViscosity.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvViscosity_DefaultValuesNeeded);
            // 
            // TabPageContrast
            // 
            this.TabPageContrast.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageContrast.Controls.Add(this.BtnContrastDown);
            this.TabPageContrast.Controls.Add(this.BtnContrastUp);
            this.TabPageContrast.Controls.Add(this.DgvContrast);
            this.TabPageContrast.Location = new System.Drawing.Point(4, 29);
            this.TabPageContrast.Name = "TabPageContrast";
            this.TabPageContrast.Size = new System.Drawing.Size(1219, 412);
            this.TabPageContrast.TabIndex = 4;
            this.TabPageContrast.Text = "Krycie";
            // 
            // BtnContrastDown
            // 
            this.BtnContrastDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnContrastDown.BackgroundImage = global::LabBook.Properties.Resources.arrow_down;
            this.BtnContrastDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnContrastDown.Location = new System.Drawing.Point(1170, 289);
            this.BtnContrastDown.Name = "BtnContrastDown";
            this.BtnContrastDown.Size = new System.Drawing.Size(47, 55);
            this.BtnContrastDown.TabIndex = 20;
            this.BtnContrastDown.UseVisualStyleBackColor = true;
            // 
            // BtnContrastUp
            // 
            this.BtnContrastUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnContrastUp.BackgroundImage = global::LabBook.Properties.Resources.arrow_up;
            this.BtnContrastUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnContrastUp.Location = new System.Drawing.Point(1169, 228);
            this.BtnContrastUp.Name = "BtnContrastUp";
            this.BtnContrastUp.Size = new System.Drawing.Size(47, 55);
            this.BtnContrastUp.TabIndex = 1;
            this.BtnContrastUp.UseVisualStyleBackColor = true;
            // 
            // DgvContrast
            // 
            this.DgvContrast.AllowUserToDeleteRows = false;
            this.DgvContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvContrast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContrast.Location = new System.Drawing.Point(3, 3);
            this.DgvContrast.Name = "DgvContrast";
            this.DgvContrast.RowHeadersWidth = 51;
            this.DgvContrast.RowTemplate.Height = 24;
            this.DgvContrast.Size = new System.Drawing.Size(1160, 406);
            this.DgvContrast.TabIndex = 0;
            this.DgvContrast.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvContrast_CellValueChanged);
            this.DgvContrast.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvContrast_DefaultValuesNeeded);
            // 
            // TabPageGloss
            // 
            this.TabPageGloss.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageGloss.Location = new System.Drawing.Point(4, 29);
            this.TabPageGloss.Name = "TabPageGloss";
            this.TabPageGloss.Size = new System.Drawing.Size(1219, 412);
            this.TabPageGloss.TabIndex = 5;
            this.TabPageGloss.Text = "Połysk";
            // 
            // TabPageClass
            // 
            this.TabPageClass.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageClass.Location = new System.Drawing.Point(4, 29);
            this.TabPageClass.Name = "TabPageClass";
            this.TabPageClass.Size = new System.Drawing.Size(1219, 412);
            this.TabPageClass.TabIndex = 6;
            this.TabPageClass.Text = "Klasyfikacja";
            // 
            // TabPageResults
            // 
            this.TabPageResults.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageResults.Location = new System.Drawing.Point(4, 29);
            this.TabPageResults.Name = "TabPageResults";
            this.TabPageResults.Size = new System.Drawing.Size(1219, 412);
            this.TabPageResults.TabIndex = 7;
            this.TabPageResults.Text = "Wyniki";
            // 
            // CmbExpCycle
            // 
            this.CmbExpCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbExpCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CmbExpCycle.FormattingEnabled = true;
            this.CmbExpCycle.Location = new System.Drawing.Point(115, 134);
            this.CmbExpCycle.Name = "CmbExpCycle";
            this.CmbExpCycle.Size = new System.Drawing.Size(388, 28);
            this.CmbExpCycle.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cykl";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(962, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Utworzony";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(951, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Modyfikacja";
            // 
            // LblDateModified
            // 
            this.LblDateModified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDateModified.AutoSize = true;
            this.LblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblDateModified.ForeColor = System.Drawing.Color.Blue;
            this.LblDateModified.Location = new System.Drawing.Point(1074, 142);
            this.LblDateModified.Name = "LblDateModified";
            this.LblDateModified.Size = new System.Drawing.Size(59, 20);
            this.LblDateModified.TabIndex = 12;
            this.LblDateModified.Text = "BRAK";
            // 
            // BtnConProject
            // 
            this.BtnConProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnConProject.ForeColor = System.Drawing.Color.Red;
            this.BtnConProject.Location = new System.Drawing.Point(699, 135);
            this.BtnConProject.Name = "BtnConProject";
            this.BtnConProject.Size = new System.Drawing.Size(228, 37);
            this.BtnConProject.TabIndex = 14;
            this.BtnConProject.Text = "Projekty powiązane";
            this.BtnConProject.UseVisualStyleBackColor = true;
            // 
            // BtnOpenProject
            // 
            this.BtnOpenProject.BackgroundImage = global::LabBook.Properties.Resources.Project_icon;
            this.BtnOpenProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOpenProject.Location = new System.Drawing.Point(203, 35);
            this.BtnOpenProject.Name = "BtnOpenProject";
            this.BtnOpenProject.Size = new System.Drawing.Size(50, 48);
            this.BtnOpenProject.TabIndex = 15;
            this.BtnOpenProject.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImage = global::LabBook.Properties.Resources.Save;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(72, 35);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(50, 48);
            this.BtnSave.TabIndex = 16;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackgroundImage = global::LabBook.Properties.Resources.Delete;
            this.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDelete.Location = new System.Drawing.Point(147, 35);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(50, 48);
            this.BtnDelete.TabIndex = 17;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAddNew
            // 
            this.BtnAddNew.BackgroundImage = global::LabBook.Properties.Resources.Add_new;
            this.BtnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAddNew.Location = new System.Drawing.Point(16, 34);
            this.BtnAddNew.Name = "BtnAddNew";
            this.BtnAddNew.Size = new System.Drawing.Size(50, 48);
            this.BtnAddNew.TabIndex = 18;
            this.BtnAddNew.UseVisualStyleBackColor = true;
            this.BtnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(4, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1215, 10);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // LabBookForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 653);
            this.Controls.Add(this.BtnAddNew);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnOpenProject);
            this.Controls.Add(this.BtnConProject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblDateModified);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbExpCycle);
            this.Controls.Add(this.LabBookTabControl);
            this.Controls.Add(this.BindingNavigatorMain);
            this.Controls.Add(this.LblDateCreated);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.LblNrD);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "LabBookForm";
            this.Text = "LabBook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LabBookForm_FormClosing);
            this.Load += new System.EventHandler(this.LabBookForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigatorMain)).EndInit();
            this.BindingNavigatorMain.ResumeLayout(false);
            this.BindingNavigatorMain.PerformLayout();
            this.LabBookTabControl.ResumeLayout(false);
            this.TabPageMain.ResumeLayout(false);
            this.TabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLabBook)).EndInit();
            this.TabPageRemarks.ResumeLayout(false);
            this.TabPageObservation.ResumeLayout(false);
            this.TabPageViscosity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViscosity)).EndInit();
            this.TabPageContrast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.Label LblNrD;
        private System.Windows.Forms.TextBox TxtTitle;
        private System.Windows.Forms.Label LblDateCreated;
        private System.Windows.Forms.BindingNavigator BindingNavigatorMain;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TabControl LabBookTabControl;
        private System.Windows.Forms.TabPage TabPageMain;
        private System.Windows.Forms.TabPage TabPageRemarks;
        private System.Windows.Forms.TabPage TabPageObservation;
        private System.Windows.Forms.TabPage TabPageViscosity;
        private System.Windows.Forms.TabPage TabPageContrast;
        private System.Windows.Forms.TabPage TabPageGloss;
        private System.Windows.Forms.TabPage TabPageClass;
        private System.Windows.Forms.DataGridView DgvLabBook;
        private System.Windows.Forms.TextBox TxtNrDFilter;
        private System.Windows.Forms.TextBox TxtTitleFilter;
        private System.Windows.Forms.TextBox TxtIdentifierFilter;
        private System.Windows.Forms.ComboBox CmbCycleFilter;
        private System.Windows.Forms.ComboBox CmbExpCycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblDateModified;
        private System.Windows.Forms.Button BtnConProject;
        private System.Windows.Forms.Button BtnOpenProject;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAddNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RtbConclusion;
        private System.Windows.Forms.RichTextBox RtbObservation;
        private System.Windows.Forms.DataGridView DgvViscosity;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViscosityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StandardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StandardXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SolventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SolventXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KrebsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KrebsICIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullToolStripMenuItem;
        private System.Windows.Forms.TabPage TabPageResults;
        private System.Windows.Forms.ToolStripMenuItem SetToolStripMenuItem;
        private System.Windows.Forms.DataGridView DgvContrast;
        private System.Windows.Forms.Button BtnContrastUp;
        private System.Windows.Forms.Button BtnContrastDown;
        private System.Windows.Forms.ToolStripMenuItem AplicatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TspContrastStd;
        private System.Windows.Forms.ToolStripMenuItem TspContrastPRB;
        private System.Windows.Forms.ToolStripMenuItem TspContrastStdPRB;
        private System.Windows.Forms.ToolStripMenuItem TspContrastKF;
        private System.Windows.Forms.ToolStripMenuItem AllApplicatorMenuItem;
    }
}