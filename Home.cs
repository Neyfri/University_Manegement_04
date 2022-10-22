using System;
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
    public partial class Home : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniversityDb;Integrated Security=True");
        public Home()
        {
            InitializeComponent();
            CountStudents();
            CountColleges();
            CountDepartment();
            CountProf();
            SumFinancesAmount();
            SumSalaryAmount();
        }
        private void SumFinancesAmount()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(FeAmount) FROM tbfees", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblQty.Text ="$ "+ dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void SumSalaryAmount()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(PrSalary) FROM tbSalary", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblSalary.Text = "$ " + dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void CountStudents()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tbstudent", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblStudent.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void CountProf()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tbProfessor", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblProf.Text = dt.Rows[0][0].ToString();
            lblFalcuty.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void CountDepartment()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tbDepartment", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblDep.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void CountColleges()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tbcollege", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblCollege.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want Logout now?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void btnCourse_Click(object sender, EventArgs e)
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
    }
}
