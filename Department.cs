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
    public partial class Department : Form
    {
        Funtion fn = new Funtion();
        string query;
        public Department()
        {
            InitializeComponent();
            ChargeDgv();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepName.Text !="" && txtfees.Text !="" && txtIntake.Text !="")
            {
                query = "INSERT INTO tbDepartment(DepName,DepIntake,DepFees) VALUES('"+txtDepName.Text+"','"+txtIntake.Text+"','"+txtfees.Text+"')";
                fn.setData(query,"Department Added successfully!");
                Reset();
                ChargeDgv();
            }
            else
            {
                MessageBox.Show("Fill all fields","Message!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void Reset()
        {
            txtDepName.Clear();
            txtfees.Clear();
            txtIntake.Clear();
        }
        private void ChargeDgv()
        {
            query = "SELECT * FROM tbDepartment";
            DataSet ds = fn.getData(query);
            dgvDep.DataSource = ds.Tables[0];
        }

        int key = 0;
        private void dgvDep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDepName.Text = dgvDep.SelectedRows[0].Cells[1].Value.ToString();
            txtIntake.Text = dgvDep.SelectedRows[0].Cells[2].Value.ToString();
            txtfees.Text = dgvDep.SelectedRows[0].Cells[3].Value.ToString();
            if (txtDepName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvDep.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDepName.Text =="" && txtfees.Text =="" && txtIntake.Text =="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    query = "UPDATE tbDepartment SET DepName ='"+txtDepName.Text+"',DepIntake ='"+txtIntake.Text+"',DepFees ='"+txtfees.Text+"' WHERE Depid = '"+key+"'";
                    fn.setData(query,"Department Updated!");
                    ChargeDgv();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Department");
            }
            else
            {
                try
                {
                    query = "DELETE FROM tbDepartment WHERE Depid = '"+key+"'";
                    fn.setData(query, "Department Deleted!");
                    ChargeDgv();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Students Obj = new Students();
            Obj.Show();
            this.Hide();
        }

        private void btnProf_Click(object sender, EventArgs e)
        {
            Professor Obj = new Professor();
            Obj.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Courses Obj = new Courses();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Colleges Obj = new Colleges();
            Obj.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want Logout now?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
