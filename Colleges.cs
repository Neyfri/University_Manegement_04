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
    public partial class Colleges : Form
    {
        Funtion fn = new Funtion();
        string query;
        int key = 0;
        public Colleges()
        {
            InitializeComponent();
            ChargeDgv();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCollegeName.Text != "" && txtCollegeDoB.Text != "" && txtCollegeCity.Text != "" && txtCollegePricipal.Text !="")
            {
                string name = txtCollegeName.Text;
                DateTime dob = Convert.ToDateTime(txtCollegeDoB.Text);
                string city = txtCollegeCity.Text;
                string principal = txtCollegePricipal.Text;
                query = "INSERT INTO tbcollege(CoName,CoCity,CoDate,CoPrincipal) VALUES('" + name + "','" + city + "','" + dob + "','" + principal + "')";
                fn.setData(query, "College Added successfully!");
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
            query = "SELECT * FROM tbcollege";
            fn.fillDGV(query, dgvColleges);
        }

        private void Reset()
        {
            txtCollegePricipal.Clear();
            txtCollegeName.Clear();
            txtCollegeDoB.ResetText();
            txtCollegeCity.Clear();
        }

        private void dgvCollege_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCollegeName.Text = dgvColleges.SelectedRows[0].Cells[1].Value.ToString();
            txtCollegeDoB.Text = dgvColleges.SelectedRows[0].Cells[3].Value.ToString();
            txtCollegeCity.Text = dgvColleges.SelectedRows[0].Cells[2].Value.ToString();
            txtCollegePricipal.Text = dgvColleges.SelectedRows[0].Cells[4].Value.ToString();
            if (txtCollegeName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvColleges.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the College");
            }
            else
            {
                try
                {
                    query = "DELETE FROM tbcollege WHERE Coid = '" + key + "'";
                    fn.setData(query, "College Deleted!");
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
            if (txtCollegeName.Text != "" && txtCollegeDoB.Text != "" && txtCollegeCity.Text != "" && txtCollegePricipal.Text != "")
            {
                string name = txtCollegeName.Text;
                DateTime dob = Convert.ToDateTime(txtCollegeDoB.Text);
                string city = txtCollegeCity.Text;
                string principal = txtCollegePricipal.Text;
                query = "UPDATE tbcollege SET CoName='" + name + "',CoDate='" + dob + "',CoCity='" + city + "',CoPrincipal='" + principal + "' WHERE Coid='" + key + "'";
                fn.setData(query, "College Updated successfully!");
                Reset();
                ChargeDgv();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void btnCourses_Click(object sender, EventArgs e)
        {
            Courses Obj = new Courses();
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

        private void btnCollege_Click(object sender, EventArgs e)
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
