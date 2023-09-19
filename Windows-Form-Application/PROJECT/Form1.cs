using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Greetings()
        {
            DateTime curTime = DateTime.Now;
            int hour = curTime.Hour;

            if (hour >= 5 && hour < 12)
            {
                return "Good morning";
            }
            else if (hour >= 12 && hour < 15)
            {
                return "Good afternoon";
            }
            else if (hour >= 15 && hour < 18)
            {
                return "Good evening ";
            }
            else
            {
                return "Welcome";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lblGreetings.Parent = pictureBox1;
            lblSignin.BackColor = Color.Transparent;
            lblEmail.Visible = false;
            lblPassword.Visible = false;
            lblGreetings.Text = Greetings();


        }
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
            if (value)
            {
                this.ActiveControl = null;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void txtBoxPassword_Click(object sender, EventArgs e)
        {
            lblPassword.Visible = true;
        }

        private void txtBoxPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                lblPassword.Visible = true;
            }
            else
            {
                lblPassword.Visible = false;
            }
        }

        private void txtBoxEmail_Click(object sender, EventArgs e)
        {
            lblEmail.Visible = true;
        }

        private void txtBoxEmail_Leave(object sender, EventArgs e)
        {
            lblEmail.Visible = false;
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S5BQ42EL\\SQLEXPRESS;Initial Catalog=Claysys;Integrated Security=True");
            try
            {
                SqlCommand com = new SqlCommand("SP_LoginUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@email", txtBoxEmail.Text);
                com.Parameters.AddWithValue("@password", txtBoxPassword.Text);

                con.Open();

                int result = (int)com.ExecuteScalar(); //Return single value 0 or 1

                con.Close();

                if (result == 1)
                {
                    CurdOperations curdOperations = new CurdOperations();
                    curdOperations.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void picPassConfVisible_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = !txtBoxPassword.UseSystemPasswordChar;

        }
    }
}