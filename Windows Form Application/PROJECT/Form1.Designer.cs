namespace PROJECT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            lblGreetings = new Label();
            pictureBox1 = new PictureBox();
            lblRegister = new Label();
            panel2 = new Panel();
            linkRegister = new LinkLabel();
            btnSignin = new MaterialSkin.Controls.MaterialButton();
            lblPassword = new Label();
            lblEmail = new Label();
            panel4 = new Panel();
            picPassConfVisible = new PictureBox();
            txtBoxPassword = new TextBox();
            panel3 = new Panel();
            txtBoxEmail = new TextBox();
            lblSignin = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPassConfVisible).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblGreetings);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(378, 514);
            panel1.TabIndex = 0;
            // 
            // lblGreetings
            // 
            lblGreetings.AutoSize = true;
            lblGreetings.BackColor = Color.Transparent;
            lblGreetings.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblGreetings.ForeColor = Color.White;
            lblGreetings.Location = new Point(100, 212);
            lblGreetings.Name = "lblGreetings";
            lblGreetings.Size = new Size(138, 38);
            lblGreetings.TabIndex = 1;
            lblGreetings.Text = "Welcome";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.milad_fakurian_bexwsdM5BCw_unsplash__1_;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(378, 514);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Location = new Point(174, 413);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(135, 23);
            lblRegister.TabIndex = 2;
            lblRegister.Text = "Not a member ?";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(linkRegister);
            panel2.Controls.Add(lblRegister);
            panel2.Controls.Add(btnSignin);
            panel2.Controls.Add(lblPassword);
            panel2.Controls.Add(lblEmail);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lblSignin);
            panel2.Dock = DockStyle.Fill;
            panel2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(378, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(570, 514);
            panel2.TabIndex = 0;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Location = new Point(315, 413);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(71, 23);
            linkRegister.TabIndex = 9;
            linkRegister.TabStop = true;
            linkRegister.Text = "Register";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // btnSignin
            // 
            btnSignin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSignin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSignin.Depth = 0;
            btnSignin.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnSignin.HighEmphasis = true;
            btnSignin.Icon = null;
            btnSignin.Location = new Point(257, 353);
            btnSignin.Margin = new Padding(4, 6, 4, 6);
            btnSignin.MouseState = MaterialSkin.MouseState.HOVER;
            btnSignin.Name = "btnSignin";
            btnSignin.NoAccentTextColor = Color.Empty;
            btnSignin.Size = new Size(73, 36);
            btnSignin.TabIndex = 8;
            btnSignin.Text = "Sign in";
            btnSignin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSignin.UseAccentColor = false;
            btnSignin.UseVisualStyleBackColor = true;
            btnSignin.Click += btnSignin_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(135, 266);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(135, 196);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(101, 20);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email address";
            // 
            // panel4
            // 
            panel4.Controls.Add(picPassConfVisible);
            panel4.Controls.Add(txtBoxPassword);
            panel4.Location = new Point(135, 287);
            panel4.Name = "panel4";
            panel4.Size = new Size(302, 36);
            panel4.TabIndex = 2;
            // 
            // picPassConfVisible
            // 
            picPassConfVisible.Image = Properties.Resources.icons8_password_eye_48;
            picPassConfVisible.Location = new Point(271, 0);
            picPassConfVisible.Name = "picPassConfVisible";
            picPassConfVisible.Size = new Size(28, 28);
            picPassConfVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            picPassConfVisible.TabIndex = 22;
            picPassConfVisible.TabStop = false;
            picPassConfVisible.Click += picPassConfVisible_Click;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Dock = DockStyle.Fill;
            txtBoxPassword.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(0, 0);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password";
            txtBoxPassword.Size = new Size(302, 31);
            txtBoxPassword.TabIndex = 1;
            txtBoxPassword.UseSystemPasswordChar = true;
            txtBoxPassword.Click += txtBoxPassword_Click;
            txtBoxPassword.Leave += txtBoxPassword_Leave;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtBoxEmail);
            panel3.Location = new Point(135, 219);
            panel3.Name = "panel3";
            panel3.Size = new Size(302, 44);
            panel3.TabIndex = 1;
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Dock = DockStyle.Fill;
            txtBoxEmail.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(0, 0);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Email address";
            txtBoxEmail.Size = new Size(302, 31);
            txtBoxEmail.TabIndex = 10;
            txtBoxEmail.Click += txtBoxEmail_Click;
            txtBoxEmail.Leave += txtBoxEmail_Leave;
            // 
            // lblSignin
            // 
            lblSignin.AutoSize = true;
            lblSignin.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblSignin.ForeColor = Color.DarkViolet;
            lblSignin.ImageAlign = ContentAlignment.TopLeft;
            lblSignin.Location = new Point(257, 133);
            lblSignin.Name = "lblSignin";
            lblSignin.Size = new Size(91, 27);
            lblSignin.TabIndex = 0;
            lblSignin.Text = "Sign in";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(948, 514);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPassConfVisible).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label lblSignin;
        private Panel panel4;
        private Panel panel3;
        private TextBox txtBoxPassword;
        private TextBox txtBoxEmail;
        private Label lblGreetings;
        private Label lblPassword;
        private Label lblEmail;
        private MaterialSkin.Controls.MaterialButton btnSignin;
        private Label lblRegister;
        private LinkLabel linkRegister;
        private PictureBox picPassConfVisible;
    }
}