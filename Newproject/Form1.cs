using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;

namespace Newproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            String query = "Select * From employee_table";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            String query = "Insert into employee_table(EMPID,FirstName,Mi,LastName,Gender,Position )Values('" + this.txtEmpid.Text + "','" + this.txtfname.Text + "','" + this.txtmi.Text + "','" + this.txtLname.Text + "','" + this.txtgender.Text + "','" + this.txtposition.Text + "')";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Successfully Data Saved");
            con.Close();
            

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            String query = "Update employee_table Set FirstName='" + this.txtfname.Text + "',Mi='" + this.txtmi.Text + "',LastName='" + this.txtLname.Text + "',Gender='" + this.txtgender.Text + "',Position='" + this.txtposition.Text + "'  Where  EMPID='" + this.txtEmpid.Text + "' ";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Record has been Updated Successfully");
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            String query = "Delete From employee_table  Where  EMPID='" + this.txtEmpid.Text + "' ";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Successfully Deleted");
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            String query = "Select * From employee_table";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlDataAdapter da;
            DataTable dt;
            con.Open();
            da = new MySqlDataAdapter("Select * From employee_table Where FirstName LIKE'" + textBox1.Text + "%'OR LastName LIKE'" + textBox1.Text + "%' OR Mi LIKE'" + textBox1.Text + "%'", con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

               private void button1_Click(object sender, EventArgs e)
        {
            String Connection = "server=localhost; Username=root; Password=; database=employeecrud";
            String query = "Select * From employee_table";
            MySqlConnection con = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Picture", Type.GetType("System.Byte[]"));

            
            dataGridView1.DataSource = dt;
        }
    }
}
