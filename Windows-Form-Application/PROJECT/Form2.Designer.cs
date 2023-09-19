namespace PROJECT
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            lnkLogin = new LinkLabel();
            lblSignup = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            picPassConfVisible = new PictureBox();
            txtBoxPhoneNumber = new TextBox();
            btnSignup = new MaterialSkin.Controls.MaterialButton();
            txtBoxConfPassword = new TextBox();
            lblCity = new Label();
            txtBoxPassword = new TextBox();
            lblState = new Label();
            txtBoxUsername = new TextBox();
            comboBoxCity = new ComboBox();
            txtBoxEmail = new TextBox();
            comboBoxState = new ComboBox();
            txtBoxAddress = new TextBox();
            lblGender = new Label();
            lblDateOfBirth = new Label();
            panel3 = new Panel();
            rdoBtnOther = new RadioButton();
            rdoBtnFemale = new RadioButton();
            rdoBtnMale = new RadioButton();
            lblAge = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtBoxLastName = new TextBox();
            txtBoxFirstName = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPassConfVisible).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lnkLogin);
            panel1.Controls.Add(lblSignup);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 74);
            panel1.TabIndex = 0;
            // 
            // lnkLogin
            // 
            lnkLogin.AutoSize = true;
            lnkLogin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lnkLogin.ForeColor = Color.Transparent;
            lnkLogin.LinkColor = Color.White;
            lnkLogin.Location = new Point(695, 39);
            lnkLogin.Name = "lnkLogin";
            lnkLogin.Size = new Size(98, 20);
            lnkLogin.TabIndex = 2;
            lnkLogin.TabStop = true;
            lnkLogin.Text = "Back to login";
            lnkLogin.LinkClicked += lnkLogin_LinkClicked;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.BackColor = Color.Transparent;
            lblSignup.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblSignup.ForeColor = Color.White;
            lblSignup.Location = new Point(35, 28);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(96, 31);
            lblSignup.TabIndex = 1;
            lblSignup.Text = "Sign up";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(803, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(picPassConfVisible);
            panel2.Controls.Add(txtBoxPhoneNumber);
            panel2.Controls.Add(btnSignup);
            panel2.Controls.Add(txtBoxConfPassword);
            panel2.Controls.Add(lblCity);
            panel2.Controls.Add(txtBoxPassword);
            panel2.Controls.Add(lblState);
            panel2.Controls.Add(txtBoxUsername);
            panel2.Controls.Add(comboBoxCity);
            panel2.Controls.Add(txtBoxEmail);
            panel2.Controls.Add(comboBoxState);
            panel2.Controls.Add(txtBoxAddress);
            panel2.Controls.Add(lblGender);
            panel2.Controls.Add(lblDateOfBirth);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lblAge);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(txtBoxLastName);
            panel2.Controls.Add(txtBoxFirstName);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 74);
            panel2.Name = "panel2";
            panel2.Size = new Size(803, 440);
            panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_password_eye_48;
            pictureBox2.Location = new Point(475, 301);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // picPassConfVisible
            // 
            picPassConfVisible.Image = Properties.Resources.icons8_password_eye_48;
            picPassConfVisible.Location = new Point(724, 301);
            picPassConfVisible.Name = "picPassConfVisible";
            picPassConfVisible.Size = new Size(28, 28);
            picPassConfVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            picPassConfVisible.TabIndex = 25;
            picPassConfVisible.TabStop = false;
            picPassConfVisible.Click += picPassConfVisible_Click;
            // 
            // txtBoxPhoneNumber
            // 
            txtBoxPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPhoneNumber.Location = new Point(431, 230);
            txtBoxPhoneNumber.Name = "txtBoxPhoneNumber";
            txtBoxPhoneNumber.PlaceholderText = "Phone number";
            txtBoxPhoneNumber.Size = new Size(326, 30);
            txtBoxPhoneNumber.TabIndex = 24;
            // 
            // btnSignup
            // 
            btnSignup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSignup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSignup.Depth = 0;
            btnSignup.HighEmphasis = true;
            btnSignup.Icon = null;
            btnSignup.Location = new Point(361, 376);
            btnSignup.Margin = new Padding(4, 6, 4, 6);
            btnSignup.MouseState = MaterialSkin.MouseState.HOVER;
            btnSignup.Name = "btnSignup";
            btnSignup.NoAccentTextColor = Color.Empty;
            btnSignup.Size = new Size(77, 36);
            btnSignup.TabIndex = 16;
            btnSignup.Text = "Sign up";
            btnSignup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSignup.UseAccentColor = false;
            btnSignup.UseVisualStyleBackColor = true;
            btnSignup.Click += btnSignup_Click;
            // 
            // txtBoxConfPassword
            // 
            txtBoxConfPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxConfPassword.Location = new Point(527, 301);
            txtBoxConfPassword.Name = "txtBoxConfPassword";
            txtBoxConfPassword.PlaceholderText = "Confirm Password";
            txtBoxConfPassword.Size = new Size(225, 30);
            txtBoxConfPassword.TabIndex = 23;
            txtBoxConfPassword.UseSystemPasswordChar = true;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(603, 141);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(34, 20);
            lblCity.TabIndex = 11;
            lblCity.Text = "City";
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(278, 299);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password";
            txtBoxPassword.Size = new Size(225, 31);
            txtBoxPassword.TabIndex = 22;
            txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(431, 141);
            lblState.Name = "lblState";
            lblState.Size = new Size(43, 20);
            lblState.TabIndex = 10;
            lblState.Text = "State";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxUsername.Location = new Point(35, 299);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.PlaceholderText = "Username";
            txtBoxUsername.Size = new Size(225, 30);
            txtBoxUsername.TabIndex = 21;
            // 
            // comboBoxCity
            // 
            comboBoxCity.FormattingEnabled = true;
            comboBoxCity.Location = new Point(603, 164);
            comboBoxCity.Name = "comboBoxCity";
            comboBoxCity.Size = new Size(151, 28);
            comboBoxCity.TabIndex = 9;
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(35, 228);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Email address";
            txtBoxEmail.Size = new Size(326, 31);
            txtBoxEmail.TabIndex = 20;
            // 
            // comboBoxState
            // 
            comboBoxState.FormattingEnabled = true;
            comboBoxState.Location = new Point(431, 164);
            comboBoxState.Name = "comboBoxState";
            comboBoxState.Size = new Size(151, 28);
            comboBoxState.TabIndex = 8;
            comboBoxState.SelectedIndexChanged += comboBoxState_SelectedIndexChanged;
            // 
            // txtBoxAddress
            // 
            txtBoxAddress.Location = new Point(35, 157);
            txtBoxAddress.Multiline = true;
            txtBoxAddress.Name = "txtBoxAddress";
            txtBoxAddress.PlaceholderText = "Address";
            txtBoxAddress.Size = new Size(326, 35);
            txtBoxAddress.TabIndex = 7;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(433, 68);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(57, 20);
            lblGender.TabIndex = 6;
            lblGender.Text = "Gender";
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Location = new Point(31, 68);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(94, 20);
            lblDateOfBirth.TabIndex = 5;
            lblDateOfBirth.Text = "Date of birth";
            // 
            // panel3
            // 
            panel3.Controls.Add(rdoBtnOther);
            panel3.Controls.Add(rdoBtnFemale);
            panel3.Controls.Add(rdoBtnMale);
            panel3.Location = new Point(431, 88);
            panel3.Name = "panel3";
            panel3.Size = new Size(326, 33);
            panel3.TabIndex = 4;
            // 
            // rdoBtnOther
            // 
            rdoBtnOther.AutoSize = true;
            rdoBtnOther.Location = new Point(250, 2);
            rdoBtnOther.Name = "rdoBtnOther";
            rdoBtnOther.Size = new Size(73, 24);
            rdoBtnOther.TabIndex = 2;
            rdoBtnOther.TabStop = true;
            rdoBtnOther.Text = "Others";
            rdoBtnOther.UseVisualStyleBackColor = true;
            // 
            // rdoBtnFemale
            // 
            rdoBtnFemale.AutoSize = true;
            rdoBtnFemale.Location = new Point(125, 3);
            rdoBtnFemale.Name = "rdoBtnFemale";
            rdoBtnFemale.Size = new Size(78, 24);
            rdoBtnFemale.TabIndex = 1;
            rdoBtnFemale.TabStop = true;
            rdoBtnFemale.Text = "Female";
            rdoBtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdoBtnMale
            // 
            rdoBtnMale.AutoSize = true;
            rdoBtnMale.Location = new Point(3, 2);
            rdoBtnMale.Name = "rdoBtnMale";
            rdoBtnMale.Size = new Size(63, 24);
            rdoBtnMale.TabIndex = 0;
            rdoBtnMale.TabStop = true;
            rdoBtnMale.Text = "Male";
            rdoBtnMale.UseVisualStyleBackColor = true;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblAge.Location = new Point(244, 91);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(0, 25);
            lblAge.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(35, 91);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(205, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtBoxLastName
            // 
            txtBoxLastName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxLastName.Location = new Point(433, 21);
            txtBoxLastName.Name = "txtBoxLastName";
            txtBoxLastName.PlaceholderText = "Last name";
            txtBoxLastName.Size = new Size(326, 30);
            txtBoxLastName.TabIndex = 1;
            // 
            // txtBoxFirstName
            // 
            txtBoxFirstName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxFirstName.Location = new Point(35, 21);
            txtBoxFirstName.Name = "txtBoxFirstName";
            txtBoxFirstName.PlaceholderText = "First name";
            txtBoxFirstName.Size = new Size(326, 30);
            txtBoxFirstName.TabIndex = 0;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 514);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Signup";
            FormClosing += Form2_FormClosing_1;
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPassConfVisible).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblSignup;
        private Panel panel2;
        private TextBox txtBoxLastName;
        private TextBox txtBoxFirstName;
        private Label lblAge;
        private DateTimePicker dateTimePicker1;
        private Panel panel3;
        private RadioButton rdoBtnFemale;
        private RadioButton rdoBtnMale;
        private Label lblGender;
        private Label lblDateOfBirth;
        private RadioButton rdoBtnOther;
        private ComboBox comboBoxCity;
        private ComboBox comboBoxState;
        private TextBox txtBoxAddress;
        private Label lblCity;
        private Label lblState;
        private MaterialSkin.Controls.MaterialButton btnSignup;
        private LinkLabel lnkLogin;
        private TextBox txtBoxPhoneNumber;
        private TextBox txtBoxConfPassword;
        private TextBox txtBoxPassword;
        private TextBox txtBoxUsername;
        private TextBox txtBoxEmail;
        private PictureBox pictureBox2;
        private PictureBox picPassConfVisible;
    }
}