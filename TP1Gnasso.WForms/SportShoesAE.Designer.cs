namespace TP1Gnasso.WForms
{
    partial class SportShoesAE
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
            modelLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            modelTextBox = new TextBox();
            sportTextBox = new TextBox();
            brandTextBox = new TextBox();
            priceTextBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            activeCheckbox = new CheckBox();
            genreComboBox = new ComboBox();
            sizeComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new Point(34, 45);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(64, 20);
            modelLabel.TabIndex = 0;
            modelLabel.Text = "Modelo:";
            modelLabel.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 132);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 1;
            label2.Text = "Genre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 91);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 2;
            label3.Text = "Brand:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 171);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 3;
            label4.Text = "Sport:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 216);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 4;
            label5.Text = "Size:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 261);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 5;
            label6.Text = "Price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 308);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 6;
            label7.Text = "Realase Date:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 354);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 7;
            label8.Text = "Active:";
            // 
            // modelTextBox
            // 
            modelTextBox.Location = new Point(179, 45);
            modelTextBox.Name = "modelTextBox";
            modelTextBox.Size = new Size(125, 27);
            modelTextBox.TabIndex = 10;
            // 
            // sportTextBox
            // 
            sportTextBox.Location = new Point(179, 168);
            sportTextBox.Name = "sportTextBox";
            sportTextBox.Size = new Size(125, 27);
            sportTextBox.TabIndex = 11;
            // 
            // brandTextBox
            // 
            brandTextBox.Location = new Point(179, 91);
            brandTextBox.Name = "brandTextBox";
            brandTextBox.Size = new Size(125, 27);
            brandTextBox.TabIndex = 12;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(179, 254);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(125, 27);
            priceTextBox.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(181, 305);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 14;
            // 
            // activeCheckbox
            // 
            activeCheckbox.AutoSize = true;
            activeCheckbox.Location = new Point(181, 354);
            activeCheckbox.Name = "activeCheckbox";
            activeCheckbox.Size = new Size(101, 24);
            activeCheckbox.TabIndex = 15;
            activeCheckbox.Text = "checkBox1";
            activeCheckbox.UseVisualStyleBackColor = true;
            // 
            // genreComboBox
            // 
            genreComboBox.FormattingEnabled = true;
            genreComboBox.Location = new Point(181, 130);
            genreComboBox.Name = "genreComboBox";
            genreComboBox.Size = new Size(151, 28);
            genreComboBox.TabIndex = 16;
            // 
            // sizeComboBox
            // 
            sizeComboBox.FormattingEnabled = true;
            sizeComboBox.Location = new Point(181, 208);
            sizeComboBox.Name = "sizeComboBox";
            sizeComboBox.Size = new Size(151, 28);
            sizeComboBox.TabIndex = 17;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(463, 398);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 18;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(319, 398);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 19;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // SportShoesAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 450);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(sizeComboBox);
            Controls.Add(genreComboBox);
            Controls.Add(activeCheckbox);
            Controls.Add(dateTimePicker1);
            Controls.Add(priceTextBox);
            Controls.Add(brandTextBox);
            Controls.Add(sportTextBox);
            Controls.Add(modelTextBox);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(modelLabel);
            Name = "SportShoesAE";
            Text = "SportShoesAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label modelLabel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox modelTextBox;
        private TextBox sportTextBox;
        private TextBox brandTextBox;
        private TextBox priceTextBox;
        private DateTimePicker dateTimePicker1;
        private CheckBox activeCheckbox;
        private ComboBox genreComboBox;
        private ComboBox sizeComboBox;
        private Button saveButton;
        private Button cancelButton;
        private ErrorProvider errorProvider1;
    }
}