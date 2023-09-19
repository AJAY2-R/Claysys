namespace PROJECT
{
    partial class CurdOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurdOperations));
            txtBoxConfPassword = new TextBox();
            txtBoxPassword = new TextBox();
            txtBoxUsername = new TextBox();
            txtBoxEmail = new TextBox();
            lblCity = new Label();
            lblState = new Label();
            comboBoxCity = new ComboBox();
            lblDateOfBirth = new Label();
            rdoBtnMale = new RadioButton();
            comboBoxState = new ComboBox();
            txtBoxAddress = new TextBox();
            lblGender = new Label();
            lblAge = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtBoxLastName = new TextBox();
            rdoBtnFemale = new RadioButton();
            panel3 = new Panel();
            rdoBtnOther = new RadioButton();
            txtBoxFirstName = new TextBox();
            panel2 = new Panel();
            picPassConfVisible = new PictureBox();
            picPassVisible = new PictureBox();
            txtBoxPhoneNumber = new TextBox();
            userDetailsData = new DataGridView();
            panel4 = new Panel();
            btnReset = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            lblCurd = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPassConfVisible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPassVisible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userDetailsData).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBoxConfPassword
            // 
            txtBoxConfPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxConfPassword.Location = new Point(527, 305);
            txtBoxConfPassword.Name = "txtBoxConfPassword";
            txtBoxConfPassword.PlaceholderText = "Confirm Password";
            txtBoxConfPassword.Size = new Size(225, 30);
            txtBoxConfPassword.TabIndex = 15;
            txtBoxConfPassword.UseSystemPasswordChar = true;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(278, 303);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password";
            txtBoxPassword.Size = new Size(225, 31);
            txtBoxPassword.TabIndex = 14;
            txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxUsername.Location = new Point(35, 303);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.PlaceholderText = "Username";
            txtBoxUsername.Size = new Size(225, 30);
            txtBoxUsername.TabIndex = 13;
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.Location = new Point(35, 232);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Email address";
            txtBoxEmail.Size = new Size(326, 31);
            txtBoxEmail.TabIndex = 12;
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
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(431, 141);
            lblState.Name = "lblState";
            lblState.Size = new Size(43, 20);
            lblState.TabIndex = 10;
            lblState.Text = "State";
            // 
            // comboBoxCity
            // 
            comboBoxCity.FormattingEnabled = true;
            comboBoxCity.Location = new Point(603, 164);
            comboBoxCity.Name = "comboBoxCity";
            comboBoxCity.Size = new Size(151, 28);
            comboBoxCity.TabIndex = 9;
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
            // txtBoxFirstName
            // 
            txtBoxFirstName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxFirstName.Location = new Point(35, 21);
            txtBoxFirstName.Name = "txtBoxFirstName";
            txtBoxFirstName.PlaceholderText = "First name";
            txtBoxFirstName.Size = new Size(326, 30);
            txtBoxFirstName.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(picPassConfVisible);
            panel2.Controls.Add(picPassVisible);
            panel2.Controls.Add(txtBoxPhoneNumber);
            panel2.Controls.Add(userDetailsData);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(txtBoxConfPassword);
            panel2.Controls.Add(txtBoxPassword);
            panel2.Controls.Add(txtBoxUsername);
            panel2.Controls.Add(txtBoxEmail);
            panel2.Controls.Add(lblCity);
            panel2.Controls.Add(lblState);
            panel2.Controls.Add(comboBoxCity);
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
            panel2.Size = new Size(788, 717);
            panel2.TabIndex = 3;
            // 
            // picPassConfVisible
            // 
            picPassConfVisible.Image = Properties.Resources.icons8_password_eye_48;
            picPassConfVisible.Location = new Point(724, 307);
            picPassConfVisible.Name = "picPassConfVisible";
            picPassConfVisible.Size = new Size(28, 28);
            picPassConfVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            picPassConfVisible.TabIndex = 21;
            picPassConfVisible.TabStop = false;
            picPassConfVisible.Click += pictureBox3_Click;
            // 
            // picPassVisible
            // 
            picPassVisible.Image = Properties.Resources.icons8_password_eye_48;
            picPassVisible.Location = new Point(475, 305);
            picPassVisible.Name = "picPassVisible";
            picPassVisible.Size = new Size(28, 28);
            picPassVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            picPassVisible.TabIndex = 20;
            picPassVisible.TabStop = false;
            picPassVisible.Click += pictureBox2_Click;
            // 
            // txtBoxPhoneNumber
            // 
            txtBoxPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPhoneNumber.Location = new Point(431, 234);
            txtBoxPhoneNumber.Name = "txtBoxPhoneNumber";
            txtBoxPhoneNumber.PlaceholderText = "Phone number";
            txtBoxPhoneNumber.Size = new Size(326, 30);
            txtBoxPhoneNumber.TabIndex = 19;
            // 
            // userDetailsData
            // 
            userDetailsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userDetailsData.Dock = DockStyle.Bottom;
            userDetailsData.Location = new Point(0, 429);
            userDetailsData.Name = "userDetailsData";
            userDetailsData.RowHeadersWidth = 51;
            userDetailsData.RowTemplate.Height = 29;
            userDetailsData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            userDetailsData.Size = new Size(788, 288);
            userDetailsData.TabIndex = 18;
            userDetailsData.CellClick += userDetailsData_CellClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnReset);
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(btnUpdate);
            panel4.Controls.Add(btnInsert);
            panel4.Location = new Point(35, 360);
            panel4.Name = "panel4";
            panel4.Size = new Size(719, 34);
            panel4.TabIndex = 17;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(568, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(384, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(193, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(28, 3);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // lblCurd
            // 
            lblCurd.AutoSize = true;
            lblCurd.BackColor = Color.Transparent;
            lblCurd.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurd.ForeColor = Color.White;
            lblCurd.Location = new Point(35, 28);
            lblCurd.Name = "lblCurd";
            lblCurd.Size = new Size(201, 31);
            lblCurd.TabIndex = 1;
            lblCurd.Text = "CURD Operations";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(788, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCurd);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 74);
            panel1.TabIndex = 2;
            // 
            // CurdOperations
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 791);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CurdOperations";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CurdOperations";
            FormClosing += CurdOperations_FormClosing;
            Load += CurdOperations_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPassConfVisible).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPassVisible).EndInit();
            ((System.ComponentModel.ISupportInitialize)userDetailsData).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtBoxConfPassword;
        private TextBox txtBoxPassword;
        private TextBox txtBoxUsername;
        private TextBox txtBoxEmail;
        private Label lblCity;
        private Label lblState;
        private ComboBox comboBoxCity;
        private Label lblDateOfBirth;
        private RadioButton rdoBtnMale;
        private ComboBox comboBoxState;
        private TextBox txtBoxAddress;
        private Label lblGender;
        private Label lblAge;
        private DateTimePicker dateTimePicker1;
        private TextBox txtBoxLastName;
        private RadioButton rdoBtnFemale;
        private Panel panel3;
        private RadioButton rdoBtnOther;
        private TextBox txtBoxFirstName;
        private Panel panel2;
        private Label lblCurd;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel4;
        private Button btnReset;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnInsert;
        private DataGridView userDetailsData;
        private TextBox txtBoxPhoneNumber;
        private PictureBox picPassVisible;
        private PictureBox picPassConfVisible;
    }
}