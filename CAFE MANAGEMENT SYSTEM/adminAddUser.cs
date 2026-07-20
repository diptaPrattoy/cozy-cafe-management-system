using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CAFE_MANAGEMENT_SYSTEM
{
    public partial class adminAddUser : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=DIPTA-KARMAKAR\SQLEXPRESS;Initial Catalog=cafe2;Integrated Security=True");


        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAddUsersData();
        }







        public adminAddUser()
        {
            InitializeComponent();
            displayAddUsersData();
        }
        public void displayAddUsersData()
        {
            adminAddUserData usersData = new adminAddUserData();
            List<adminAddUserData> listData = usersData.usersListData();

            dataGridView1.DataSource = listData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public bool emptyFields()
        {
            if (adminAddUser_username.Text == "" || adminAddUser_password.Text == ""
                || adminAddUser_role.Text == "" || adminAddUser_status.Text == ""
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void clearFields()
        {
            adminAddUser_username.Text = "";
            adminAddUser_password.Text = "";
            adminAddUser_role.SelectedIndex = -1;
            adminAddUser_status.SelectedIndex = -1;
            // adminAddUsers_imageView.Image = null;
        }


        private void adminAddUsers_addBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        // CHECK USERNAME IF EXISTING ALREADY
                        string selectUsern = "SELECT * FROM Project_User WHERE username = @usern";

                        using (SqlCommand checkUsern = new SqlCommand(selectUsern, connect))
                        {
                            checkUsern.Parameters.AddWithValue("@usern", adminAddUser_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsern);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                string usern = adminAddUser_username.Text.Substring(0, 1).ToUpper() + adminAddUser_username.Text.Substring(1);
                                MessageBox.Show(usern + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                                string insertData = "INSERT INTO Project_User(username, password, role, status, date_reg) " +
                                    "VALUES(@usern, @pass, @role, @status, @date)";
                                DateTime today = DateTime.Today;
                                /*
                                string relativePath = Path.Combine("User_Directory", adminAddUser_username.Text.Trim() + ".jpg");
                                string path = Path.Combine(baseDirectory, relativePath);

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                */
                                // File.Copy(adminAddUsers_imageView.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@usern", adminAddUser_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", adminAddUser_password.Text.Trim());
                                    //cmd.Parameters.AddWithValue("@image", path);
                                    cmd.Parameters.AddWithValue("@role", adminAddUser_role.Text.Trim());
                                    cmd.Parameters.AddWithValue("@status", adminAddUser_status.Text.Trim());
                                    cmd.Parameters.AddWithValue("@date", today);

                                    cmd.ExecuteNonQuery();
                                    clearFields();

                                    MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    displayAddUsersData();
                                }
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






        private int id = 0;

       








        private void adminAddUser_clearBtn_Click(object sender, EventArgs e)
        {

            clearFields();
        }

        private void adminAddUser_updateBtn_Click(object sender, EventArgs e)
        {


            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Update Username: " + adminAddUser_username.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                            string updateData = "UPDATE Project_User SET username = @usern, password = @pass, role = @role, status = @status WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", adminAddUser_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", adminAddUser_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", adminAddUser_role.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", adminAddUser_status.Text.Trim());
                                cmd.Parameters.AddWithValue("@id", id);

                              //  string relativePath = Path.Combine("User_Directory", adminAddUser_username.Text.Trim() + ".jpg");
                               // string path = Path.Combine(baseDirectory, relativePath);

                               // string directoryPath = Path.GetDirectoryName(path);

                               // if (!Directory.Exists(directoryPath))
                               // {
                               //     Directory.CreateDirectory(directoryPath);
                               // }

                               // File.Copy(adminAddUsers_imageView.ImageLocation, path, true);

                                //cmd.Parameters.AddWithValue("@imagePath", path);

                                cmd.ExecuteNonQuery();
                                clearFields();

                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayAddUsersData();
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
        }

      private void adminAddUser_deleteBtn_Click(object sender, EventArgs e)
{
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Delete Username: " + adminAddUser_username.Text.Trim()
                    + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM Project_User WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", id);

                                cmd.ExecuteNonQuery();
                                clearFields();

                                MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayAddUsersData();
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
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            id = (int)row.Cells[0].Value;
            adminAddUser_username.Text = row.Cells[1].Value.ToString();
            adminAddUser_password.Text = row.Cells[2].Value.ToString();
            adminAddUser_role.Text = row.Cells[3].Value.ToString();
            adminAddUser_status.Text = row.Cells[4].Value.ToString();


        }
    }
}
    



 