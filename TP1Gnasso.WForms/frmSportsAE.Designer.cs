namespace TP1Gnasso.WForms
{
    partial class frmSportsAE
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
            saveButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            sportTextBox = new TextBox();
            label2 = new Label();
            activeCheckBox = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(199, 140);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(73, 140);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 37);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 2;
            label1.Text = "Sport";
            // 
            // sportTextBox
            // 
            sportTextBox.Location = new Point(98, 34);
            sportTextBox.Name = "sportTextBox";
            sportTextBox.Size = new Size(125, 27);
            sportTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 93);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            label2.Text = "Active";
            // 
            // activeCheckBox
            // 
            activeCheckBox.AutoSize = true;
            activeCheckBox.Checked = true;
            activeCheckBox.CheckState = CheckState.Checked;
            activeCheckBox.Location = new Point(98, 92);
            activeCheckBox.Name = "activeCheckBox";
            activeCheckBox.Size = new Size(18, 17);
            activeCheckBox.TabIndex = 5;
            activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSportsAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 193);
            Controls.Add(activeCheckBox);
            Controls.Add(label2);
            Controls.Add(sportTextBox);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Name = "frmSportsAE";
            Text = "frmSportsAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private Button cancelButton;
        private Label label1;
        private TextBox sportTextBox;
        private Label label2;
        private CheckBox activeCheckBox;
        private ErrorProvider errorProvider1;
    }
}