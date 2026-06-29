namespace TP1Gnasso.WForms
{
    partial class frmSizeAE
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
            components = new System.ComponentModel.Container();
            activeCheckBox = new CheckBox();
            label2 = new Label();
            sizeTextBox = new TextBox();
            label1 = new Label();
            cancelButton = new Button();
            saveButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // activeCheckBox
            // 
            activeCheckBox.AutoSize = true;
            activeCheckBox.Checked = true;
            activeCheckBox.CheckState = CheckState.Checked;
            activeCheckBox.Location = new Point(98, 89);
            activeCheckBox.Name = "activeCheckBox";
            activeCheckBox.Size = new Size(18, 17);
            activeCheckBox.TabIndex = 11;
            activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 86);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 10;
            label2.Text = "Active";
            // 
            // sizeTextBox
            // 
            sizeTextBox.Location = new Point(98, 31);
            sizeTextBox.Name = "sizeTextBox";
            sizeTextBox.Size = new Size(125, 27);
            sizeTextBox.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 31);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 8;
            label1.Text = "Size";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(50, 145);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(176, 145);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSizeAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 213);
            Controls.Add(activeCheckBox);
            Controls.Add(label2);
            Controls.Add(sizeTextBox);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Name = "frmSizeAE";
            Text = "frmSizeAE";
            Load += frmSizeAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox activeCheckBox;
        private Label label2;
        private TextBox sizeTextBox;
        private Label label1;
        private Button cancelButton;
        private Button saveButton;
        private ErrorProvider errorProvider1;
    }
}