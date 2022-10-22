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
    public partial class Courses : Form
    {
        Funtion fn = new Funtion();
        string query;
        public Courses()
        {
            InitializeComponent();
            ChargeDgv();
            fn.getDepid(txtCDepid);
            fn.getProfid(txtCPrid);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "" && txtCDepName.Text != "" && txtCDuaration.Text != "" && txtCPrid.SelectedIndex != -1 && txtCDepid.SelectedIndex != -1)
            {
                string name = txtCName.Text;
                int duration = int.Parse(txtCDuaration.Text);
                string depname = txtCDepName.Text;
                string profName = txtProfName.Text;
                int prid = int.Parse(txtCPrid.Text);
                int depid = int.Parse(txtCDepid.Text);
                query = "INSERT INTO tbcourse(CName,CDuration,CDepid,CDepName,CProfid,CPrName) VALUES('" + name + "','" + duration + "','" + depid + "','" + depname + "','" + prid + "','" + profName + "')";
                fn.setData(query, "Course Added successfully!");
                Reset();
                ChargeDgv();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ChargeDgv()
        {
            query = "SELECT * FROM tbcourse";
            fn.fillDGV(query, dgvCourses);
        }

        private void Reset()
        {
            txtCName.Clear();
            txtCDepName.Clear();
            txtProfName.Clear();
            txtCDuaration.Clear();
            txtCPrid.SelectedIndex = -1;
            txtCDepid.SelectedIndex = -1;
        }

        int key = 0;
        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                txtCName.Text = dgvCourses.SelectedRows[0].Cells[1].Value.ToString();
                txtCDuaration.Text = dgvCourses.SelectedRows[0].Cells[2].Value.ToString();
                txtCDepid.Text = dgvCourses.SelectedRows[0].Cells[3].Value.ToString();
                txtCDepName.Text = dgvCourses.SelectedRows[0].Cells[4].Value.ToString();
                txtCPrid.Text = dgvCourses.SelectedRows[0].Cells[5].Value.ToString();
                txtProfName.Text = dgvCourses.SelectedRows[0].Cells[6].Value.ToString();
                if (txtCName.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (key == 0)
                {
                    MessageBox.Show("Select the Course");
                }
                else
                {
                    try
                    {
                        query = "DELETE FROM tbcourse WHERE Cid = '" + key + "'";
                        fn.setData(query, "Course Deleted!");
                        ChargeDgv();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            private void btnEdit_Click(object sender, EventArgs e)
            {
                if (txtCName.Text != "" && txtCDepName.Text != "" && txtCDuaration.Text != "" && txtCPrid.SelectedIndex != -1 && txtCDepid.SelectedIndex != -1)
                {
                    string name = txtCName.Text;
                    int duration = int.Parse(txtCDuaration.Text);
                    string depname = txtCDepName.Text;
                    string profName = txtProfName.Text;
                    int prid = int.Parse(txtCPrid.Text);
                    int depid = int.Parse(txtCDepid.Text);
                    query = "UPDATE tbcourse SET CName='" + name + "',CDuration='" + duration + "',CDepid='" + depid + "',CDepName='" + depname + "',CProfid='" + prid + "' WHERE Cid LIKE '"+key+"'";
                    fn.setData(query, "Course Updated successfully!");
                    Reset();
                    ChargeDgv();
                }
                else
                {
                    MessageBox.Show("Fill all fields", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void txtDepid_SelectionChangeCommitted(object sender, EventArgs e)
            {
                string id = txtCDepid.Text;
                fn.getDepName(id, txtCDepName);
            }
        private void txtCPrid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = txtCPrid.Text;
            fn.getProfName(id,txtProfName);
        }

        private void btnDepartment_Click(object sender, EventArgs e)
            {
                Department Obj = new Department();
                Obj.Show();
                this.Hide();
            }

            private void btnStudent_Click(object sender, EventArgs e)
            {
                Students Obj = new Students();
                Obj.Show();
                this.Hide();
            }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void btnDepartment_Click_1(object sender, EventArgs e)
        {
            Department Obj = new Department();
            Obj.Show();
            this.Hide();
        }

        private void btnProf_Click(object sender, EventArgs e)
        {
            Professor Obj = new Professor();
            Obj.Show();
            this.Hide();
        }

        private void btnFees_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void btnColleges_Click(object sender, EventArgs e)
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
