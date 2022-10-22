using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management
{
    internal class Funtion
    {
        protected SqlConnection getConnection()
        {
           SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniversityDb;Integrated Security=True");
            return conn;
        }

        public DataSet getData(string query)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(string query,string message)
        {
            try
            {
                SqlConnection conn = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("' " + message + " '", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void fillDGV(string query,DataGridView dgv)
        {
            DataSet ds = getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        public void getDepName(string id,Guna2TextBox text)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            string query = "SELECT * FROM tbDepartment WHERE Depid= " + id + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                text.Text = dr["DepName"].ToString();
            }
            conn.Close();
        }

        public void getDepid(Guna2ComboBox comboBox)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Depid FROM tbDepartment", conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Depid", typeof(int));
            dt.Load(sdr);
            comboBox.ValueMember = "Depid";
            comboBox.DataSource = dt;
            conn.Close();
        }
        public void getProfName(string id, Guna2TextBox text)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            string query = "SELECT * FROM tbProfessor WHERE Prid LIKE '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                text.Text = dr["PrName"].ToString();
            }
            conn.Close();
        }
        public void getProfid(Guna2ComboBox comboBox)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Prid FROM tbProfessor", conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Prid", typeof(int));
            dt.Load(sdr);
            comboBox.ValueMember = "Prid";
            comboBox.DataSource = dt;
            conn.Close();
        }
        public void getStName(string id, Guna2TextBox text)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            string query = "SELECT * FROM tbstudent WHERE stid LIKE '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                text.Text = dr["stname"].ToString();
            }
            conn.Close();
        }
        public void getStid(Guna2ComboBox comboBox)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT stid FROM tbstudent", conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stid", typeof(int));
            dt.Load(sdr);
            comboBox.ValueMember = "stid";
            comboBox.DataSource = dt;
            conn.Close();
        }
        public void getStDepName(string id, Guna2TextBox text)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            string query = "SELECT * FROM tbstudent WHERE stid LIKE '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                text.Text = dr["stDepName"].ToString();
            }
            conn.Close();
        }
    }
}
