﻿
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
            this.ToolStripMenu = new System.Windows.Forms.ToolStrip();
            this.ToolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.ToolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSave = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageMain = new System.Windows.Forms.TabPage();
            this.CmbCycleFilter = new System.Windows.Forms.ComboBox();
            this.TxtIdentifierFilter = new System.Windows.Forms.TextBox();
            this.TxtTitleFilter = new System.Windows.Forms.TextBox();
            this.TxtNrDFilter = new System.Windows.Forms.TextBox();
            this.DgvLabBook = new System.Windows.Forms.DataGridView();
            this.TabPageRemarks = new System.Windows.Forms.TabPage();
            this.TabPageObservation = new System.Windows.Forms.TabPage();
            this.TabPageViscosity = new System.Windows.Forms.TabPage();
            this.TabPageContrast = new System.Windows.Forms.TabPage();
            this.TabPageGloss = new System.Windows.Forms.TabPage();
            this.TabPageClass = new System.Windows.Forms.TabPage();
            this.CmbExpCycle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ToolStripMenu.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigatorMain)).BeginInit();
            this.BindingNavigatorMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLabBook)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStripMenu
            // 
            this.ToolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripAdd,
            this.ToolStripDelete,
            this.toolStripSeparator1,
            this.ToolStripSave});
            this.ToolStripMenu.Location = new System.Drawing.Point(0, 31);
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Size = new System.Drawing.Size(1227, 27);
            this.ToolStripMenu.TabIndex = 0;
            this.ToolStripMenu.Text = "toolStrip1";
            // 
            // ToolStripAdd
            // 
            this.ToolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripAdd.Image = global::LabBook.Properties.Resources.Add_new;
            this.ToolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripAdd.Name = "ToolStripAdd";
            this.ToolStripAdd.Size = new System.Drawing.Size(29, 24);
            // 
            // ToolStripDelete
            // 
            this.ToolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripDelete.Image = global::LabBook.Properties.Resources.Delete;
            this.ToolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDelete.Name = "ToolStripDelete";
            this.ToolStripDelete.Size = new System.Drawing.Size(29, 24);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // ToolStripSave
            // 
            this.ToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripSave.Image = global::LabBook.Properties.Resources.Save;
            this.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSave.Name = "ToolStripSave";
            this.ToolStripSave.Size = new System.Drawing.Size(29, 24);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.dodajToolStripMenuItem});
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
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // LblNrD
            // 
            this.LblNrD.AutoSize = true;
            this.LblNrD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblNrD.ForeColor = System.Drawing.Color.Blue;
            this.LblNrD.Location = new System.Drawing.Point(22, 73);
            this.LblNrD.Name = "LblNrD";
            this.LblNrD.Size = new System.Drawing.Size(49, 20);
            this.LblNrD.TabIndex = 2;
            this.LblNrD.Text = "1000";
            // 
            // TxtTitle
            // 
            this.TxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TxtTitle.Location = new System.Drawing.Point(98, 70);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(829, 27);
            this.TxtTitle.TabIndex = 1;
            this.TxtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTitle_KeyPress);
            // 
            // LblDateCreated
            // 
            this.LblDateCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDateCreated.AutoSize = true;
            this.LblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblDateCreated.ForeColor = System.Drawing.Color.Blue;
            this.LblDateCreated.Location = new System.Drawing.Point(1074, 73);
            this.LblDateCreated.Name = "LblDateCreated";
            this.LblDateCreated.Size = new System.Drawing.Size(131, 20);
            this.LblDateCreated.TabIndex = 4;
            this.LblDateCreated.Text = " DD-MM-YYYY";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TabPageMain);
            this.tabControl1.Controls.Add(this.TabPageRemarks);
            this.tabControl1.Controls.Add(this.TabPageObservation);
            this.tabControl1.Controls.Add(this.TabPageViscosity);
            this.tabControl1.Controls.Add(this.TabPageContrast);
            this.tabControl1.Controls.Add(this.TabPageGloss);
            this.tabControl1.Controls.Add(this.TabPageClass);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.Location = new System.Drawing.Point(0, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1227, 472);
            this.tabControl1.TabIndex = 6;
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
            this.TabPageMain.Size = new System.Drawing.Size(1219, 439);
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
            // 
            // TxtIdentifierFilter
            // 
            this.TxtIdentifierFilter.Location = new System.Drawing.Point(507, 16);
            this.TxtIdentifierFilter.Name = "TxtIdentifierFilter";
            this.TxtIdentifierFilter.Size = new System.Drawing.Size(94, 27);
            this.TxtIdentifierFilter.TabIndex = 3;
            // 
            // TxtTitleFilter
            // 
            this.TxtTitleFilter.Location = new System.Drawing.Point(111, 16);
            this.TxtTitleFilter.Name = "TxtTitleFilter";
            this.TxtTitleFilter.Size = new System.Drawing.Size(122, 27);
            this.TxtTitleFilter.TabIndex = 2;
            // 
            // TxtNrDFilter
            // 
            this.TxtNrDFilter.Location = new System.Drawing.Point(8, 16);
            this.TxtNrDFilter.Name = "TxtNrDFilter";
            this.TxtNrDFilter.Size = new System.Drawing.Size(97, 27);
            this.TxtNrDFilter.TabIndex = 1;
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
            this.DgvLabBook.Size = new System.Drawing.Size(1208, 384);
            this.DgvLabBook.TabIndex = 0;
            this.DgvLabBook.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvLabBook_ColumnWidthChanged);
            // 
            // TabPageRemarks
            // 
            this.TabPageRemarks.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageRemarks.Location = new System.Drawing.Point(4, 29);
            this.TabPageRemarks.Name = "TabPageRemarks";
            this.TabPageRemarks.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRemarks.Size = new System.Drawing.Size(1219, 439);
            this.TabPageRemarks.TabIndex = 1;
            this.TabPageRemarks.Text = "Uwagi";
            // 
            // TabPageObservation
            // 
            this.TabPageObservation.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageObservation.Location = new System.Drawing.Point(4, 29);
            this.TabPageObservation.Name = "TabPageObservation";
            this.TabPageObservation.Size = new System.Drawing.Size(1219, 439);
            this.TabPageObservation.TabIndex = 2;
            this.TabPageObservation.Text = "Obserwacje";
            // 
            // TabPageViscosity
            // 
            this.TabPageViscosity.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageViscosity.Location = new System.Drawing.Point(4, 29);
            this.TabPageViscosity.Name = "TabPageViscosity";
            this.TabPageViscosity.Size = new System.Drawing.Size(1219, 439);
            this.TabPageViscosity.TabIndex = 3;
            this.TabPageViscosity.Text = "Lepkość";
            // 
            // TabPageContrast
            // 
            this.TabPageContrast.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageContrast.Location = new System.Drawing.Point(4, 29);
            this.TabPageContrast.Name = "TabPageContrast";
            this.TabPageContrast.Size = new System.Drawing.Size(1219, 439);
            this.TabPageContrast.TabIndex = 4;
            this.TabPageContrast.Text = "Krycie";
            // 
            // TabPageGloss
            // 
            this.TabPageGloss.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageGloss.Location = new System.Drawing.Point(4, 29);
            this.TabPageGloss.Name = "TabPageGloss";
            this.TabPageGloss.Size = new System.Drawing.Size(1219, 439);
            this.TabPageGloss.TabIndex = 5;
            this.TabPageGloss.Text = "Połysk";
            // 
            // TabPageClass
            // 
            this.TabPageClass.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageClass.Location = new System.Drawing.Point(4, 29);
            this.TabPageClass.Name = "TabPageClass";
            this.TabPageClass.Size = new System.Drawing.Size(1219, 439);
            this.TabPageClass.TabIndex = 6;
            this.TabPageClass.Text = "Klasyfikacja";
            // 
            // CmbExpCycle
            // 
            this.CmbExpCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbExpCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CmbExpCycle.FormattingEnabled = true;
            this.CmbExpCycle.Location = new System.Drawing.Point(98, 103);
            this.CmbExpCycle.Name = "CmbExpCycle";
            this.CmbExpCycle.Size = new System.Drawing.Size(405, 28);
            this.CmbExpCycle.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(22, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cykl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(604, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Projekt";
            // 
            // CmbProject
            // 
            this.CmbProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CmbProject.FormattingEnabled = true;
            this.CmbProject.Location = new System.Drawing.Point(707, 103);
            this.CmbProject.Name = "CmbProject";
            this.CmbProject.Size = new System.Drawing.Size(220, 28);
            this.CmbProject.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(962, 73);
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
            this.label4.Location = new System.Drawing.Point(951, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Modyfikacja";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(1074, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = " DD-MM-YYYY";
            // 
            // LabBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 653);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbExpCycle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BindingNavigatorMain);
            this.Controls.Add(this.LblDateCreated);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.LblNrD);
            this.Controls.Add(this.ToolStripMenu);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "LabBookForm";
            this.Text = "LabBook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LabBookForm_FormClosing);
            this.Load += new System.EventHandler(this.LabBookForm_Load);
            this.ToolStripMenu.ResumeLayout(false);
            this.ToolStripMenu.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigatorMain)).EndInit();
            this.BindingNavigatorMain.ResumeLayout(false);
            this.BindingNavigatorMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageMain.ResumeLayout(false);
            this.TabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLabBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStripMenu;
        private System.Windows.Forms.ToolStripButton ToolStripAdd;
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
        private System.Windows.Forms.ToolStripButton ToolStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolStripDelete;
        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}