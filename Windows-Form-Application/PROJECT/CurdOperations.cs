using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PROJECT
{
    public partial class CurdOperations : Form
    {
        public CurdOperations()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-S5BQ42EL\\SQLEXPRESS;Initial Catalog=Claysys;Integrated Security=True");
        String? validate = "";
        private void CurdOperations_Load(object sender, EventArgs e)
        {
            GetUserDetails();
            LoadState();
            lblCurd.Parent = pictureBox1;
            lblCurd.BackColor = Color.Transparent;
        }

        private void GetUserDetails()
        {

            SqlCommand cmd = new SqlCommand("SP_GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            userDetailsData.DataSource = dt;
            con.Close();

        }
        private Dictionary<string, List<string>> citiesByState = new Dictionary<string, List<string>>
        {
            { "Kerala", new List<string> { "Trivandrum", "Ernakulam", "Kottayam" } },
            { "Tamil Nadu", new List<string> { "Chennai", "Coimbatore", "Madurai" } },
            { "Karnataka", new List<string> { "Bangalore", "Mysore", "Udupi" } },
        };

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

        /// <summary>
        /// calculate age when the date changed
        /// </summary>

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
                validate += "• Password is required and must meet the following criteria:\n";

                if (string.IsNullOrWhiteSpace(txtBoxPassword.Text))
                {
                    validate += "\t - Password cannot be empty\n";
                }

                if (!IsStrongPassword(txtBoxPassword.Text))
                {
                    validate += "\t - Password must be at least 8 characters long and include:\n";
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
            // Check if the password has at least 6 characters
            if (password.Length < 6)
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
        private void CurdOperations_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Set Value of gender based on the selected radio button

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
        /// <summary>
        ///  Insert user details to database if the form is valid
        /// </summary>
        private void btnInsert_Click(object sender, EventArgs e)
        {
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

                    MessageBox.Show("User details inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUserDetails();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Clear the input fields 
        /// </summary>
        private void ClearField()
        {
            txtBoxFirstName.Clear();
            txtBoxLastName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtBoxPhoneNumber.Clear();
            txtBoxEmail.Clear();
            txtBoxAddress.Clear();
            rdoBtnMale.Checked = false;
            rdoBtnFemale.Checked = false;
            rdoBtnOther.Checked = false;
            comboBoxState.Items.Clear();
            LoadState();
            comboBoxCity.SelectedIndex = -1;
            txtBoxUsername.Clear();
            txtBoxPassword.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void userDetailsData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxFirstName.Text = userDetailsData.SelectedRows[0].Cells[1].Value.ToString();
            txtBoxLastName.Text = userDetailsData.SelectedRows[0].Cells[2].Value.ToString();
            if (DateTime.TryParse(userDetailsData.SelectedRows[0].Cells[3].Value.ToString(), out DateTime dateOfBirth))
            {
                dateTimePicker1.Value = dateOfBirth;
            }
            txtBoxPhoneNumber.Text = userDetailsData.SelectedRows[0].Cells[4].Value.ToString();
            txtBoxEmail.Text = userDetailsData.SelectedRows[0].Cells[5].Value.ToString();
            txtBoxAddress.Text = userDetailsData.SelectedRows[0].Cells[6].Value.ToString();
            string? gender = userDetailsData.SelectedRows[0].Cells[7].Value.ToString();
            if (gender == "Male")
            {
                rdoBtnMale.Checked = true;
            }
            else if (gender == "Female")
            {
                rdoBtnFemale.Checked = true;
            }
            else if (gender == "Other")
            {
                rdoBtnOther.Checked = true;
            }
            comboBoxState.Text = userDetailsData.SelectedRows[0].Cells[8].Value.ToString();
            comboBoxCity.Text = userDetailsData.SelectedRows[0].Cells[9].Value.ToString();
            txtBoxUsername.Text = userDetailsData.SelectedRows[0].Cells[10].Value.ToString();
            txtBoxPassword.Text = userDetailsData.SelectedRows[0].Cells[11].Value.ToString();
            txtBoxPassword.UseSystemPasswordChar = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidateField())
                {
                    SqlCommand com = new SqlCommand("SP_UpdateUserDetails", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@user_id", userDetailsData.SelectedRows[0].Cells[0].Value);
                    com.Parameters.AddWithValue("@first_name", txtBoxFirstName.Text);
                    com.Parameters.AddWithValue("@last_name", txtBoxLastName.Text);
                    com.Parameters.AddWithValue("@date_of_birth", dateTimePicker1.Value.Date);
                    com.Parameters.AddWithValue("@phone_number", long.Parse(txtBoxPhoneNumber.Text));
                    com.Parameters.AddWithValue("@email", txtBoxEmail.Text);
                    com.Parameters.AddWithValue("@address", txtBoxAddress.Text);
                    com.Parameters.AddWithValue("@gender", GetSelectedGender());
                    com.Parameters.AddWithValue("@state", comboBoxState.Text);
                    com.Parameters.AddWithValue("@city", comboBoxCity.Text);
                    com.Parameters.AddWithValue("@username", txtBoxUsername.Text);
                    com.Parameters.AddWithValue("@password", txtBoxPassword.Text);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUserDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("SP_DeleteUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@user_id", userDetailsData.SelectedRows[0].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUserDetails();
                    ClearField();
                }

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = !txtBoxPassword.UseSystemPasswordChar;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtBoxConfPassword.UseSystemPasswordChar = !txtBoxConfPassword.UseSystemPasswordChar;
        }


    }
}
