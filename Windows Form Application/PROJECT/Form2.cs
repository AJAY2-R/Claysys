using System.Data;
using System.Data.SqlClient;

namespace PROJECT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Dictionary to store the city and state
        private Dictionary<string, List<string>> citiesByState = new Dictionary<string, List<string>>
        {
            { "Kerala", new List<string> { "Trivandrum", "Ernakulam", "Kottayam" } },
            { "Tamil Nadu", new List<string> { "Chennai", "Coimbatore", "Madurai" } },
            { "Karnataka", new List<string> { "Bangalore", "Mysore", "Udupi" } },
        };
        private void Form2_Load(object sender, EventArgs e)
        {
            lblSignup.Parent = pictureBox1;
            lblSignup.BackColor = Color.Transparent;
            lnkLogin.Parent = pictureBox1;
            lnkLogin.BackColor = Color.Transparent;// To make the background of the text to transperent

            LoadState();
        }

        //Load the state in to the combobox
        private void LoadState()
        {
            comboBoxState.Items.AddRange(citiesByState.Keys.ToArray());
        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedState = comboBoxState.SelectedItem.ToString();
            // Clear the city ComboBox
            comboBoxCity.Items.Clear();
            comboBoxCity.Text = "";
            // Populate the city ComboBox based on the selected state
            if (citiesByState.ContainsKey(selectedState))
            {
                comboBoxCity.Items.AddRange(citiesByState[selectedState].ToArray());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            TimeSpan age = DateTime.Now - selectedDate;
            int years = (int)(age.TotalDays / 365);
            lblAge.Text = $"{years} Years Old ";
            if (years < 18)
                lblAge.ForeColor = Color.Red;
            else
                lblAge.ForeColor = Color.Green;
        }
        String? validate = "";
        public bool ValidateField()
        {
            bool isValid = true;
            //Validate first name
            if (string.IsNullOrWhiteSpace(txtBoxFirstName.Text))
            {
                validate += "• First Name is required .\n";
                isValid = false;
            }
            //Validate last name
            if (string.IsNullOrWhiteSpace(txtBoxLastName.Text))
            {
                validate += "• Last Name is required. \n";
                isValid = false;
            }
            //validate date of birth
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime today = DateTime.Now;
            int age = today.Year - selectedDate.Year;
            //check age is 18 or less
            if (age < 18)
            {
                validate += "• Age must be greater than or equal to 18.\n";
                isValid = false;
            }

            // Validate gender 
            if (!rdoBtnMale.Checked && !rdoBtnFemale.Checked && !rdoBtnOther.Checked)
            {
                validate += "• Gender is required. Please select a gender.\n";
                isValid = false;
            }
            //Validate address
            if (string.IsNullOrWhiteSpace(txtBoxAddress.Text))
            {
                validate += "• Address is required. \n";
                isValid = false;
            }
            //Validate state
            if (string.IsNullOrWhiteSpace(comboBoxState.Text))
            {
                validate += "• State is required. \n";
                isValid = false;
            }

            // Validate city 
            if (string.IsNullOrWhiteSpace(comboBoxCity.Text))
            {
                validate += "• City is required.\n";
                isValid = false;
            }
            //validate phone number
            if (!IsValidPhoneNumber(txtBoxPhoneNumber.Text))
            {
                validate += "• Invalid Phone Number. Please enter a valid phone number with at least 10 digits.\n";
                isValid = false;
            }
            //Validate username
            if (string.IsNullOrWhiteSpace(txtBoxUsername.Text) || txtBoxUsername.Text.Length < 4)
            {
                validate += "• Username required and must be atleast 4 charcters long  \n";
                isValid = false;
            }
            //Validate Email
            if (string.IsNullOrWhiteSpace(txtBoxEmail.Text) || !IsValidEmail(txtBoxEmail.Text))
            {
                validate += "• Invalid Email. Please enter a valid email address. \n";

                isValid = false;
            }
            //Validate Password
            if (string.IsNullOrWhiteSpace(txtBoxPassword.Text) || !IsStrongPassword(txtBoxPassword.Text))
            {
                isValid = false;
                // Append error messages only when the password is not valid
                validate += "\t Password is required and must meet the following criteria:\n";

                if (string.IsNullOrWhiteSpace(txtBoxPassword.Text))
                {
                    validate += "\t - Password cannot be empty\n";
                }

                if (!IsStrongPassword(txtBoxPassword.Text))
                {
                    validate += "\t - Password must be at least 6 characters long and include:\n";
                    validate += "\t   - At least one uppercase letter\n";
                    validate += "\t   - At least one lowercase letter\n";
                    validate += "\t   - At least one digit\n";
                    validate += "\t   - At least one special character\n";
                }
            }

            //Validate confirm password
            if (txtBoxPassword.Text != txtBoxConfPassword.Text)
            {
                validate += "• Confirm Password not match \n";
                isValid = false;
            }
            if (isValid == false)
                MessageBox.Show(validate, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            validate = "";
            return isValid;
        }

        // Check email is valid format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //check phone number i s valid
        private bool IsValidPhoneNumber(string phoneNumber)
        {

            string PhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray()); // Remove any non-digit characters
            return PhoneNumber.Length >= 10;
        }
        //check password
        private bool IsStrongPassword(string password)
        {
            // Check if the password has at least 8 characters
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            bool hasSpecialCharacter = false;
            string specialCharacters = "!@#$%^&*()_+[]{}|;:,.<>?";

            foreach (char character in password)
            {
                if (char.IsUpper(character))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(character))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(character))
                {
                    hasDigit = true;
                }
                else if (specialCharacters.Contains(character))
                {
                    hasSpecialCharacter = true;
                }
            }
            return hasUppercase && hasLowercase && hasDigit && hasSpecialCharacter;
        }


        private string GetSelectedGender()
        {
            if (rdoBtnMale.Checked)
            {
                return "Male";
            }
            else if (rdoBtnFemale.Checked)
            {
                return "Female";
            }
            else if (rdoBtnOther.Checked)
            {
                return "Other";
            }
            else
            {
                return string.Empty;
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S5BQ42EL\\SQLEXPRESS;Initial Catalog=Claysys;Integrated Security=True");
            try
            {
                if (ValidateField())
                {
                    SqlCommand com = new SqlCommand("SP_InsertUserDetails", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@first_name", txtBoxFirstName.Text);
                    com.Parameters.AddWithValue("@last_name", txtBoxLastName.Text);
                    com.Parameters.AddWithValue("@date_of_birth", dateTimePicker1.Value.Date);
                    com.Parameters.AddWithValue("@phone_number", long.Parse(txtBoxPhoneNumber.Text));
                    com.Parameters.AddWithValue("@email", txtBoxEmail.Text);
                    com.Parameters.AddWithValue("@address", txtBoxAddress.Text);
                    com.Parameters.AddWithValue("@gender", GetSelectedGender()); //Load Value based on the gender 
                    com.Parameters.AddWithValue("@state", comboBoxState.Text);
                    com.Parameters.AddWithValue("@city", comboBoxCity.Text);
                    com.Parameters.AddWithValue("@username", txtBoxUsername.Text);
                    com.Parameters.AddWithValue("@password", txtBoxPassword.Text);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Registered details inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();
            this.Hide();
        }
        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = !txtBoxPassword.UseSystemPasswordChar;
        }

        private void picPassConfVisible_Click(object sender, EventArgs e)
        {
            txtBoxConfPassword.UseSystemPasswordChar = !txtBoxConfPassword.UseSystemPasswordChar;
        }
    }
}
