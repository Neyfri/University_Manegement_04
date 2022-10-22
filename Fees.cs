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
    public partial class Fees : Form
    {
        Funtion fn = new Funtion();
        string query;
        public Fees()
        {
            InitializeComponent();
            ChargeDgvFees();
            ChargeDgvSalary();
            fn.getProfid(txtPrid);
            fn.getStid(txtStid);
        }

        private void btnStPay_Click(object sender, EventArgs e)
        {
            if (txtStid.SelectedIndex != -1 && txtStDep.Text != "" && txtStName.Text != "" && txtStAmount.Text != "" && txtStPeriod.SelectedIndex != -1)
            {
                string name = txtStName.Text;
                string period = txtStPeriod.SelectedItem.ToString();
                string amount = txtStAmount.Text;
                string department = txtStDep.Text;
                string stid = txtStid.SelectedValue.ToString();
                query = "INSERT INTO tbfees(stid,stName,stDep,FePeriod,FeAmount,PayDate) VALUES('" + stid + "','" + name + "','" + department + "','" + period + "','"+amount+"',getdate())";
                fn.setData(query, "Fees paid!");
                ResetFees();
                ChargeDgvFees();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrPay_Click(object sender, EventArgs e)
        {
            if (txtPrid.SelectedIndex != -1 && txtPrName.Text != "" && txtPrSalary.Text != "" && txtPrPeriod.SelectedIndex != -1)
            {
                string name = txtPrName.Text;
                string period = txtPrPeriod.SelectedItem.ToString();
                string salary = txtPrSalary.Text;
                string stid = txtPrid.SelectedValue.ToString();
                query = "INSERT INTO tbSalary(Prid,PrName,PrSalary,SaPeriod,SaPayDate) VALUES('" + stid + "','" + name + "','" + salary + "','" + period + "',getdate())";
                fn.setData(query, "Salary paid!");
                ResetSalary();
                ChargeDgvSalary();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ChargeDgvFees()
        {
            query = "SELECT * FROM tbfees";
            fn.fillDGV(query, dgvFees);
        }
        private void ChargeDgvSalary()
        {
            query = "SELECT * FROM tbSalary";
            fn.fillDGV(query, dgvSalary);
        }

        public void ResetFees()
        {
            txtStDep.Clear();
            txtStAmount.Clear();
            txtStName.Clear();
            txtStPeriod.SelectedIndex = -1;
            txtStid.SelectedIndex = -1;

        }
        public void ResetSalary()
        {
            txtPrName.Clear();
            txtPrSalary.Clear();
            txtPrPeriod.SelectedIndex = -1;
            txtPrid.SelectedIndex = -1;

        }

        private void txtStid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = txtStid.Text;
            fn.getStName(id,txtStName);
            fn.getStDepName(id,txtStDep);
        }

        private void txtPrid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = txtPrid.Text;
            fn.getProfName(id, txtPrName);
        }

        private void btnStReset_Click(object sender, EventArgs e)
        {
            ResetFees();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void btnPrReset_Click(object sender, EventArgs e)
        {
            ResetSalary();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Students Obj = new Students();
            Obj.Show();
            this.Hide();
        }

        private void btnDep_Click(object sender, EventArgs e)
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

        private void btnSalary_Click(object sender, EventArgs e)
        {
            this.Refresh();
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
