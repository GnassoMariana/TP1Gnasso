namespace TP1Gnasso.WForms
{
    partial class frmSizeMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSizeMenu));
            cantidadLabel = new Label();
            label1 = new Label();
            sizeDgv = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            numberColumn = new DataGridViewTextBoxColumn();
            activeColumn = new DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)sizeDgv).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new Point(-153, 427);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new Size(0, 20);
            cantidadLabel.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-237, 427);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 6;
            label1.Text = "Cantidad:";
            // 
            // sizeDgv
            // 
            sizeDgv.AllowUserToDeleteRows = false;
            sizeDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sizeDgv.Columns.AddRange(new DataGridViewColumn[] { idColumn, numberColumn, activeColumn });
            sizeDgv.Dock = DockStyle.Fill;
            sizeDgv.Location = new Point(0, 27);
            sizeDgv.Name = "sizeDgv";
            sizeDgv.ReadOnly = true;
            sizeDgv.RowHeadersWidth = 51;
            sizeDgv.Size = new Size(430, 423);
            sizeDgv.TabIndex = 5;
            // 
            // idColumn
            // 
            idColumn.HeaderText = "Id";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Width = 125;
            // 
            // numberColumn
            // 
            numberColumn.HeaderText = "Number";
            numberColumn.MinimumWidth = 6;
            numberColumn.Name = "numberColumn";
            numberColumn.ReadOnly = true;
            numberColumn.Width = 125;
            // 
            // activeColumn
            // 
            activeColumn.HeaderText = "Active";
            activeColumn.MinimumWidth = 6;
            activeColumn.Name = "activeColumn";
            activeColumn.ReadOnly = true;
            activeColumn.Width = 125;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { addButton, updateButton, deleteButton, toolStripSeparator1, refreshButton, toolStripSeparator2, closeButton, tsbActive });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(430, 27);
            toolStrip1.TabIndex = 4;
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
            // frmSizeMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 450);
            Controls.Add(cantidadLabel);
            Controls.Add(label1);
            Controls.Add(sizeDgv);
            Controls.Add(toolStrip1);
            Name = "frmSizeMenu";
            Text = "frmSizeMenu";
            Load += frmSizeMenu_Load;
            ((System.ComponentModel.ISupportInitialize)sizeDgv).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cantidadLabel;
        private Label label1;
        private DataGridView sizeDgv;
        private ToolStrip toolStrip1;
        private ToolStripButton addButton;
        private ToolStripButton updateButton;
        private ToolStripButton deleteButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton refreshButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton closeButton;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn numberColumn;
        private DataGridViewTextBoxColumn activeColumn;
        private ToolStripDropDownButton tsbActive;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem inactiveToolStripMenuItem;
    }
}