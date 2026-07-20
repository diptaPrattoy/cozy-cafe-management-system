using CAFE_MANAGEMENT_SYSTEM;
using System;
using System.Windows.Forms;

namespace CAFE_MANAGEMENT_SYSTEM
{
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to sign out?"
                , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                login loginForm = new login();
                loginForm.Show();

                this.Hide();
            }
        }

        private void cashierOrderForm1_Load(object sender, EventArgs e)
        {

        }

        private void addProducts_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm2.Visible = false;
            adminAddProducts4.Visible = true;
            cashierOrderForm1.Visible = false;
            cashierCustomersForm1.Visible = false;

            AdminAddProducts aaProd = adminAddProducts1 as AdminAddProducts;

            if (aaProd != null)
            {
                aaProd.refreshData();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {

            adminDashboardForm2.Visible = true;
            adminAddProducts4.Visible = false;
            //adminDashboardForm1.Visible = true;
            //adminAddProducts1.Visible = false;
            //cashierOrderForm1.Visible = false;
            cashierCustomersForm1.Visible = false;
            cashierOrderForm1.Visible = false;
            //AdminDashboardForm adForm = adminDashboardForm1 as AdminDashboardForm;

            //if (adForm != null)
            //{
            //    adForm.refreshData();
            //}
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm2.Visible = false;
            adminAddProducts4.Visible = false;
            cashierOrderForm1.Visible = true;

              //cashierOrderForm1.Visible = true;
            cashierCustomersForm1.Visible = false;

            CashierOrderForm coForm = cashierOrderForm1 as CashierOrderForm;

             if (coForm != null)
             {
                 coForm.refreshData();
             }
        }

        private void customer_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm2.Visible = false;
            adminAddProducts4.Visible = false;
           // cashierOrderForm1.Visible = false;
            cashierCustomersForm1.Visible = true;
            cashierOrderForm1.Visible = false;

             CashierCustomersForm ccForm = cashierCustomersForm1 as CashierCustomersForm;

             if (ccForm != null)
             {
                 ccForm.refreshData();
             }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}


// THATS IT FOR THIS VIDEO, THANKS FOR WATCHING !!
// HOPE YOU ENJOY THIS VIDEO TUTORIAL
// SUBSCRIBE OUR CHANNEL FOR MORE COOL PROJECT TUTORIALS : ) 
// THANK YOU !! 