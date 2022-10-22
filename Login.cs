using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUsername.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPass.Text != "")
            {
                if (txtUsername.Text == "admin" && txtPass.Text == "demo")
                {
                    Home Obj = new Home();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or Password Wrong", "Try it Again!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill all fields", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblReset_MouseMove(object sender, MouseEventArgs e)
        {
            lblReset.ForeColor = Color.Red;
        }

        private void lblReset_MouseLeave(object sender, EventArgs e)
        {
            lblReset.ForeColor = Color.Black;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want Logout now?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
