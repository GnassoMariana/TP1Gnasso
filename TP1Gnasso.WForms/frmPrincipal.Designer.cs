namespace TP1Gnasso.WForms
{
    partial class frmPrincipal
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
            logoutButton = new Button();
            sportShoesButton = new Button();
            brandsButton = new Button();
            sportsButton = new Button();
            sizesButton = new Button();
            genreButton = new Button();
            label1 = new Label();
            label2 = new Label();
            conectedUserLabel = new Label();
            SuspendLayout();
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(665, 30);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(94, 29);
            logoutButton.TabIndex = 0;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // sportShoesButton
            // 
            sportShoesButton.Location = new Point(39, 30);
            sportShoesButton.Name = "sportShoesButton";
            sportShoesButton.Size = new Size(162, 52);
            sportShoesButton.TabIndex = 1;
            sportShoesButton.Text = "Sport Shoes Menu";
            sportShoesButton.UseVisualStyleBackColor = true;
            sportShoesButton.Click += sportShoesButton_Click;
            // 
            // brandsButton
            // 
            brandsButton.Location = new Point(39, 106);
            brandsButton.Name = "brandsButton";
            brandsButton.Size = new Size(162, 50);
            brandsButton.TabIndex = 2;
            brandsButton.Text = "Brands Menu";
            brandsButton.UseVisualStyleBackColor = true;
            brandsButton.Click += brandsButton_Click;
            // 
            // sportsButton
            // 
            sportsButton.Location = new Point(39, 190);
            sportsButton.Name = "sportsButton";
            sportsButton.Size = new Size(162, 46);
            sportsButton.TabIndex = 3;
            sportsButton.Text = "Sports Menu";
            sportsButton.UseVisualStyleBackColor = true;
            sportsButton.Click += sportsButton_Click;
            // 
            // sizesButton
            // 
            sizesButton.Location = new Point(39, 257);
            sizesButton.Name = "sizesButton";
            sizesButton.Size = new Size(162, 46);
            sizesButton.TabIndex = 4;
            sizesButton.Text = "Sizes Menu";
            sizesButton.UseVisualStyleBackColor = true;
            sizesButton.Click += sizesButton_Click;
            // 
            // genreButton
            // 
            genreButton.Location = new Point(39, 331);
            genreButton.Name = "genreButton";
            genreButton.Size = new Size(162, 48);
            genreButton.TabIndex = 5;
            genreButton.Text = "Genre";
            genreButton.UseVisualStyleBackColor = true;
            genreButton.Click += genreButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(286, 115);
            label1.Name = "label1";
            label1.Size = new Size(335, 20);
            label1.TabIndex = 7;
            label1.Text = "Seleccionar una opcion del menu para comenzar.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 421);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 8;
            label2.Text = "User:";
            // 
            // conectedUserLabel
            // 
            conectedUserLabel.AutoSize = true;
            conectedUserLabel.Location = new Point(74, 421);
            conectedUserLabel.Name = "conectedUserLabel";
            conectedUserLabel.Size = new Size(113, 20);
            conectedUserLabel.TabIndex = 9;
            conectedUserLabel.Text = "Connected User";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(conectedUserLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(genreButton);
            Controls.Add(sizesButton);
            Controls.Add(sportsButton);
            Controls.Add(brandsButton);
            Controls.Add(sportShoesButton);
            Controls.Add(logoutButton);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button logoutButton;
        private Button sportShoesButton;
        private Button brandsButton;
        private Button sportsButton;
        private Button sizesButton;
        private Button genreButton;
        private Label label1;
        private Label label2;
        private Label conectedUserLabel;
    }
}