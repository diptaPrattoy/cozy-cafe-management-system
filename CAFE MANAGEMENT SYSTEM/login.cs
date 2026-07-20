using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CAFE_MANAGEMENT_SYSTEM
{
    public partial class login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DIPTA-KARMAKAR\SQLEXPRESS;Initial Catalog=cafe2;Integrated Security=True");


        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void login_registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();

            this.Hide();
        }
        public bool emptyFields()
        {
            if (login_username.Text == "" || login_password.Text == "")
            { return true; }
            else { return false; }
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectAccount = "SELECT COUNT(*) FROM project_user WHERE username = @usern AND password = @pass AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectAccount, connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass", login_password.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", "Active");

                            int rowCount = (int)cmd.ExecuteScalar();

                            if (rowCount > 0)
                            {
                                string selectRole = "SELECT role FROM project_user WHERE username = @usern AND password = @pass";

                                using (SqlCommand getRole = new SqlCommand(selectRole, connect))
                                {
                                    getRole.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                                    getRole.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                                    string userRole = getRole.ExecuteScalar() as string;

                                    MessageBox.Show("Login successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (userRole == "Admin")
                                    {
                                        //username = login_username.Text;
                                        adminDashboard adminForm = new adminDashboard();
                                        adminForm.Show();

                                        this.Hide();
                                    }
                                    else if (userRole == "Cashier")
                                    {
                                        CashierMainForm cashierForm = new CashierMainForm();

                                        cashierForm.Show();
                                        this.Hide();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password or there's no Admin's approval.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }

            }
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
