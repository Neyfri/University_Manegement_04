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
    public partial class Students : Form
    {
        Funtion fn = new Funtion();
        string query;
        int key = 0;
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniversityDb;Integrated Security=True");
        public Students()
        {
            InitializeComponent();
            ChargeDgv();
            fn.getDepid(txtStDepID);
        }

        private void txtStDepID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = txtStDepID.Text;
            fn.getDepName(id,txtStDepName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStAddress.Text != "" && txtStDoB.Text != "" && txtStGender.Text != "" && txtStName.Text !="" && txtStPhone.Text !="" && txtStsemeter.SelectedIndex !=1 && txtStDepID.SelectedIndex != -1)
            {
                string name = txtStName.Text;
                DateTime dob = txtStDoB.Value.Date;
                string gen = txtStGender.Text;
                string address = txtStAddress.Text;
                int depid = int.Parse(txtStDepID.Text);
                string depname = txtStDepName.Text;
                string phone = txtStPhone.Text;
                int semeter = int.Parse(txtStsemeter.Text);
                query = "INSERT INTO tbstudent(stname,stDoB,stGen,stAddress,stDepid,stDepName,stPhone,stSem) VALUES('" + name + "','" + dob + "','" + gen + "','"+address+"','"+depid+"','"+depname+"','"+phone+"','"+semeter+"')";
                fn.setData(query, "Student Added successfully!");
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
            query = "SELECT * FROM tbstudent";
            fn.fillDGV(query,dgvStudent);
        }

        private void Reset()
        {
            txtStsemeter.ResetText();
            txtStDepID.ResetText();
            txtStAddress.Clear();
            txtStDepName.Clear();
            txtStDoB.ResetText();
            txtStGender.ResetText();
            txtStName.Clear();
            txtStPhone.Clear();
            txtStsemeter.ResetText();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStName.Text = dgvStudent.SelectedRows[0].Cells[1].Value.ToString();
            txtStDoB.Text = dgvStudent.SelectedRows[0].Cells[2].Value.ToString();
            txtStGender.Text = dgvStudent.SelectedRows[0].Cells[3].Value.ToString();
            txtStAddress.Text = dgvStudent.SelectedRows[0].Cells[4].Value.ToString();
            txtStDepID.Text = dgvStudent.SelectedRows[0].Cells[5].Value.ToString();
            txtStDepName.Text = dgvStudent.SelectedRows[0].Cells[6].Value.ToString();
            txtStPhone.Text = dgvStudent.SelectedRows[0].Cells[7].Value.ToString();
            txtStsemeter.Text = dgvStudent.SelectedRows[0].Cells[8].Value.ToString();
            if (txtStName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvStudent.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Student");
            }
            else
            {
                try
                {
                    query = "DELETE FROM tbstudent WHERE stid = '" + key + "'";
                    fn.setData(query, "Student Deleted!");
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
            string name = txtStName.Text;
            DateTime dob = txtStDoB.Value.Date;
            string gen = txtStGender.Text;
            string address = txtStAddress.Text;
            int depid = int.Parse(txtStDepID.Text);
            string depname = txtStDepName.Text;
            string phone = txtStPhone.Text;
            int semeter = int.Parse(txtStsemeter.Text);
            query = "UPDATE tbstudent SET stname='"+name+ "',stDoB='"+dob+ "',stGen='"+gen+"',stAddress='"+address+"',stDepid='"+depid+"',stDepName='"+depname+"',stPhone='"+phone+"',stSem='"+semeter+"' WHERE stid='"+key+"'";
            fn.setData(query, "Student Updated successfully!");
            Reset();
            ChargeDgv();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
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
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }
    }
}
