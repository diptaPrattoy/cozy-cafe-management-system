using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace CAFE_MANAGEMENT_SYSTEM
{
    public partial class Welcome:Form
    {
        public Welcome()
        {
            InitializeComponent();
            pber.Value = 0;
            timer1.Interval = 100;
            timer1.Start();
        }
        // int startpoint = 0;
        /*private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            pber.Value = startpoint;

            if (pber.Value >= 100)
            {
                pber.Value = 0;
                timer1.Stop();
                login login = new login();
                this.Hide();
                login.Show();
            }
        }*/
      /*  private void timer1_Tick(object sender, EventArgs e)
        {
            pber.Value += 1;
            pber.Text = pber.Value.ToString() + "%";
            if (pber.Value == 100)
            {
                timer1.Enabled = false;
                //login login = new login();
                //this.Hide();
                // login.Show(); 
               // groupmember groupmember = new groupmember();
                this.Hide();
               // groupmember.Show();
            }
        }*/


       

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

       

        private void pber_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            pber.Value += 2;
            pber.Text = pber.Value.ToString() + "%";
            if (pber.Value == 100)
            {
                timer1.Enabled = false;
               // login login = new login();
                //login.Show(); 
                 GroupMembers groupmember = new GroupMembers();
                this.Hide();
                groupmember.Show();
            }
        }
    }
}
