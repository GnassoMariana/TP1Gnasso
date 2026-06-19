namespace TP1Gnasso.WForms
{
    partial class frmSportShoesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSportShoesMenu));
            toolStrip1 = new ToolStrip();
            addButton = new ToolStripButton();
            updateButton = new ToolStripButton();
            deleteButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            refreshButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            closeButton = new ToolStripButton();
            tsbActive = new ToolStripDropDownButton();
            activeToolStripMenuItem = new ToolStripMenuItem();
            inactiveToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            modelColumn = new DataGridViewTextBoxColumn();
            brandColumn = new DataGridViewTextBoxColumn();
            genreColumn = new DataGridViewTextBoxColumn();
            sportColumn = new DataGridViewTextBoxColumn();
            sizeColumn = new DataGridViewTextBoxColumn();
            priceColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            activeColumn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            cantidadLabel = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { addButton, updateButton, deleteButton, toolStripSeparator1, refreshButton, toolStripSeparator2, closeButton, tsbActive });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1213, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            addButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            addButton.Image = (Image)resources.GetObject("addButton.Image");
            addButton.ImageTransparentColor = Color.Magenta;
            addButton.Name = "addButton";
            addButton.Size = new Size(41, 24);
            addButton.Text = "Add";
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            updateButton.Image = (Image)resources.GetObject("updateButton.Image");
            updateButton.ImageTransparentColor = Color.Magenta;
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(62, 24);
            updateButton.Text = "Update";
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
            deleteButton.ImageTransparentColor = Color.Magenta;
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(57, 24);
            deleteButton.Text = "Delete";
            deleteButton.Click += deleteButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // refreshButton
            // 
            refreshButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            refreshButton.Image = (Image)resources.GetObject("refreshButton.Image");
            refreshButton.ImageTransparentColor = Color.Magenta;
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(62, 24);
            refreshButton.Text = "Refresh";
            refreshButton.Click += refreshButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // closeButton
            // 
            closeButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            closeButton.Image = (Image)resources.GetObject("closeButton.Image");
            closeButton.ImageTransparentColor = Color.Magenta;
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(49, 24);
            closeButton.Text = "Close";
            closeButton.Click += closeButton_Click;
            // 
            // tsbActive
            // 
            tsbActive.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbActive.DropDownItems.AddRange(new ToolStripItem[] { activeToolStripMenuItem, inactiveToolStripMenuItem });
            tsbActive.Image = (Image)resources.GetObject("tsbActive.Image");
            tsbActive.ImageTransparentColor = Color.Magenta;
            tsbActive.Name = "tsbActive";
            tsbActive.Size = new Size(56, 24);
            tsbActive.Text = "Filter";
            // 
            // activeToolStripMenuItem
            // 
            activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            activeToolStripMenuItem.Size = new Size(224, 26);
            activeToolStripMenuItem.Text = "Active";
            activeToolStripMenuItem.Click += activeToolStripMenuItem_Click;
            // 
            // inactiveToolStripMenuItem
            // 
            inactiveToolStripMenuItem.Name = "inactiveToolStripMenuItem";
            inactiveToolStripMenuItem.Size = new Size(224, 26);
            inactiveToolStripMenuItem.Text = "Inactive";
            inactiveToolStripMenuItem.Click += inactiveToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idColumn, modelColumn, brandColumn, genreColumn, sportColumn, sizeColumn, priceColumn, dateColumn, activeColumn });
            dataGridView1.Location = new Point(0, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1213, 385);
            dataGridView1.TabIndex = 1;
            // 
            // idColumn
            // 
            idColumn.HeaderText = "Id";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Width = 125;
            // 
            // modelColumn
            // 
            modelColumn.HeaderText = "Model";
            modelColumn.MinimumWidth = 6;
            modelColumn.Name = "modelColumn";
            modelColumn.ReadOnly = true;
            modelColumn.Width = 125;
            // 
            // brandColumn
            // 
            brandColumn.HeaderText = "Brand";
            brandColumn.MinimumWidth = 6;
            brandColumn.Name = "brandColumn";
            brandColumn.ReadOnly = true;
            brandColumn.Width = 125;
            // 
            // genreColumn
            // 
            genreColumn.HeaderText = "Genre";
            genreColumn.MinimumWidth = 6;
            genreColumn.Name = "genreColumn";
            genreColumn.ReadOnly = true;
            genreColumn.Width = 125;
            // 
            // sportColumn
            // 
            sportColumn.HeaderText = "Sport";
            sportColumn.MinimumWidth = 6;
            sportColumn.Name = "sportColumn";
            sportColumn.ReadOnly = true;
            sportColumn.Width = 125;
            // 
            // sizeColumn
            // 
            sizeColumn.HeaderText = "Size";
            sizeColumn.MinimumWidth = 6;
            sizeColumn.Name = "sizeColumn";
            sizeColumn.ReadOnly = true;
            sizeColumn.Width = 125;
            // 
            // priceColumn
            // 
            priceColumn.HeaderText = "Price";
            priceColumn.MinimumWidth = 6;
            priceColumn.Name = "priceColumn";
            priceColumn.ReadOnly = true;
            priceColumn.Width = 125;
            // 
            // dateColumn
            // 
            dateColumn.HeaderText = "Release Date";
            dateColumn.MinimumWidth = 6;
            dateColumn.Name = "dateColumn";
            dateColumn.ReadOnly = true;
            dateColumn.Width = 125;
            // 
            // activeColumn
            // 
            activeColumn.HeaderText = "Active";
            activeColumn.MinimumWidth = 6;
            activeColumn.Name = "activeColumn";
            activeColumn.ReadOnly = true;
            activeColumn.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 423);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 2;
            label1.Text = "Cantidad:";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new Point(104, 423);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new Size(0, 20);
            cantidadLabel.TabIndex = 3;
            // 
            // frmSportShoesMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 450);
            Controls.Add(cantidadLabel);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Name = "frmSportShoesMenu";
            Text = "frmSportShoesMenu";
            Load += frmSportShoesMenu_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton addButton;
        private ToolStripButton updateButton;
        private ToolStripButton deleteButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton filterButton;
        private ToolStripButton refreshButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton closeButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn modelColumn;
        private DataGridViewTextBoxColumn brandColumn;
        private DataGridViewTextBoxColumn genreColumn;
        private DataGridViewTextBoxColumn sportColumn;
        private DataGridViewTextBoxColumn sizeColumn;
        private DataGridViewTextBoxColumn priceColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn activeColumn;
        private Label label1;
        private Label cantidadLabel;
        private ToolStripDropDownButton tsbActive;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem inactiveToolStripMenuItem;
    }
}