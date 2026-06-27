namespace TP1Gnasso.WForms
{
    partial class frmGenreMenu
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
            genreDgv = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            genreColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)genreDgv).BeginInit();
            SuspendLayout();
            // 
            // genreDgv
            // 
            genreDgv.AllowUserToAddRows = false;
            genreDgv.AllowUserToDeleteRows = false;
            genreDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            genreDgv.Columns.AddRange(new DataGridViewColumn[] { idColumn, genreColumn });
            genreDgv.Dock = DockStyle.Fill;
            genreDgv.Location = new Point(0, 0);
            genreDgv.Name = "genreDgv";
            genreDgv.ReadOnly = true;
            genreDgv.RowHeadersWidth = 51;
            genreDgv.Size = new Size(362, 268);
            genreDgv.TabIndex = 0;
            // 
            // idColumn
            // 
            idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idColumn.HeaderText = "ID";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            // 
            // genreColumn
            // 
            genreColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            genreColumn.HeaderText = "Genre";
            genreColumn.MinimumWidth = 6;
            genreColumn.Name = "genreColumn";
            genreColumn.ReadOnly = true;
            // 
            // frmGenreMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 268);
            Controls.Add(genreDgv);
            Name = "frmGenreMenu";
            Text = "frmGenreMenu";
            Load += frmGenreMenu_Load;
            ((System.ComponentModel.ISupportInitialize)genreDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView genreDgv;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn genreColumn;
    }
}