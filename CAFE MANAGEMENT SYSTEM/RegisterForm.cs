using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CAFE_MANAGEMENT_SYSTEM
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DIPTA-KARMAKAR\SQLEXPRESS;Initial Catalog=cafe2;Integrated Security=True");

        public RegisterForm()
        {
            InitializeComponent();
        }



        private void register_showPass_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPass.Checked ? '\0' : '*';
            register_cPassword.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }



        private void register_passwordChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void register_usernameChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void register_cPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void register_loginBtn_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
            this.Hide();
        }

        public bool emptyFields()
        {
            if (register_username.Text == "" || register_password.Text == "" || register_cPassword.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void register_btn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show(" All fields are required to be filled at first.", " Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string selectUsername = "SELECT * FROM project_user WHERE username = @userna ";

                        using (SqlCommand checkUsername = new SqlCommand(selectUsername, connect))
                        {
                            checkUsername.Parameters.AddWithValue("@userna", register_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsername);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                string userna = register_username.Text.Substring(0, 1).ToUpper() + register_username.Text.Substring(1);
                                MessageBox.Show(userna + " is alraedy taken ", "error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (register_password.Text != register_cPassword.Text)
                            {
                                MessageBox.Show("Password does not match yet. ", "error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (register_password.Text != register_cPassword.Text)
                            {
                                MessageBox.Show("Invalid password atleast 8 characters needed for login.", "error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO project_user (username, password, role, status, date_reg) " +
                                    "VALUES (@userna, @pass,@role,@status,@date)";

                                DateTime today = DateTime.Today;
                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@userna", register_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", register_password.Text.Trim());
                                    //cmd.Parameters.AddWithValue("@image", "");
                                    cmd.Parameters.AddWithValue("@role", "Cashier");
                                    cmd.Parameters.AddWithValue("@status", "Approval");
                                    cmd.Parameters.AddWithValue("@date", today);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Registered Succesfully", "Information Message ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    //switching from this frame to login frame
                                    login loginForm = new login();
                                    loginForm.Show();
                                    this.Hide();
                                        
                                }
                            }
                        }
                    }
                    
                    catch (Exception ex)
                    {
                    MessageBox.Show("Connection failed:"+ ex, "error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();

                    }
                }
               
            }

        }
    }
}
