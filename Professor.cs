using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management
{
    public partial class Professor : Form
    {
        Funtion fn = new Funtion();
        string query;
        int key = 0;
        public Professor()
        {
            InitializeComponent();
            ChargeDgv();
            fn.getDepid(txtDepid);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPrName.Text != "" && txtPrDepName .Text != "" && txtPrEx.Text != "" && txtPraddress.Text != "" && txtPrSalary.Text != "" && txtPrGen.SelectedIndex != -1 && txtPrSem.SelectedIndex != -1)
            {
                string name = txtPrName.Text;
                DateTime dob = txtProfDoB.Value.Date;
                string gen = txtPrGen.Text;
                string address = txtPraddress.Text;
                string qual = txtPrQual.Text;
                string exp = txtPrEx.Text;
                int depid = int.Parse(txtDepid.Text);
                string depname = txtPrDepName.Text;
                int salary = int.Parse(txtPrSalary.Text);
                int semeter = int.Parse(txtPrSem.Text);
                query = "INSERT INTO tbProfessor(Prname,PrDoB,PrGen,PrAdd,PrQual,PrExp,PrDepid,PrDepName,PrSalary,PrSem) VALUES('" + name + "','" + dob + "','" + gen + "','" + address + "','"+qual+"','"+exp+"','" + depid + "','" + depname + "','" + salary + "','" + semeter + "')";
                fn.setData(query, "Professor Added successfully!");
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
            query = "SELECT * FROM tbProfessor";
            fn.fillDGV(query, dgvProfessor);
        }

        private void Reset()
        {
            txtPrSem.SelectedIndex = -1;
            txtPraddress.Clear();
            txtPrDepName.Clear();
            txtPrName.Clear();
            txtProfDoB.ResetText();
            txtPrGen.SelectedIndex = -1;
            txtPrSalary.Clear();
            txtDepid.SelectedIndex = -1;
            txtPrEx.Clear();
        }

        private void dgvProfessor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPrName.Text = dgvProfessor.SelectedRows[0].Cells[1].Value.ToString();
            txtProfDoB.Text = dgvProfessor.SelectedRows[0].Cells[2].Value.ToString();
            txtPrGen.Text = dgvProfessor.SelectedRows[0].Cells[3].Value.ToString();
            txtPraddress.Text = dgvProfessor.SelectedRows[0].Cells[4].Value.ToString();
            txtPrQual.Text = dgvProfessor.SelectedRows[0].Cells[5].Value.ToString();
            txtPrEx.Text = dgvProfessor.SelectedRows[0].Cells[6].Value.ToString();
            txtDepid.Text = dgvProfessor.SelectedRows[0].Cells[7].Value.ToString();
            txtPrDepName.Text = dgvProfessor.SelectedRows[0].Cells[8].Value.ToString();
            txtPrSalary.Text = dgvProfessor.SelectedRows[0].Cells[9].Value.ToString();
            txtPrSem.Text = dgvProfessor.SelectedRows[0].Cells[10].Value.ToString();
            if (txtPrName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvProfessor.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Professor");
            }
            else
            {
                try
                {
                    query = "DELETE FROM tbProfessor WHERE Prid = '" + key + "'";
                    fn.setData(query, "Professor Deleted!");
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
            if (txtPrName.Text != "" && txtPrDepName.Text != "" && txtPrEx.Text != "" && txtPraddress.Text != "" && txtPrSalary.Text != "" && txtPrGen.SelectedIndex != -1 && txtPrSem.SelectedIndex != -1)
            {
                string name = txtPrName.Text;
                DateTime dob = txtProfDoB.Value.Date;
                string gen = txtPrGen.Text;
                string address = txtPraddress.Text;
                string qual = txtPrQual.Text;
                string exp = txtPrEx.Text;
                int depid = int.Parse(txtDepid.Text);
                string depname = txtPrDepName.Text;
                int salary = int.Parse(txtPrSalary.Text);
                int semeter = int.Parse(txtPrSem.Text);
                query = "UPDATE tbProfessor SET Prname='" + name + "',PrDoB='" + dob + "',PrGen='" + gen + "',PrAdd='" + address + "',PrQual='" + qual + "',PrExp='" + exp + "',PrDepid='" + depid + "',PrDepName='" + depname + "',PrSalary='" + salary + "',PrSem='" + semeter + "' WHERE Prid='" + key + "'";
                fn.setData(query, "Professor Updated successfully!");
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
            string id = txtDepid.Text;
            fn.getDepName(id, txtPrDepName);
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
