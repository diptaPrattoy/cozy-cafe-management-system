using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAFE_MANAGEMENT_SYSTEM
{
    public partial class GroupMembers :Form 
    {
        public GroupMembers()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }
    }
}
