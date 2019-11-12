using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CrudOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CrudDeskApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text.Length < 1) && (textBox2.Text.Length<1)&& (textBox3.Text.Length<1) && (textBox4.Text.Length < 1) && (textBox5.Text.Length < 1) && (comboBox1.Text.Length < 1))
            {
                MessageBox.Show("Fill the Boxes");
                if ((textBox1.Text.Length < 1) || (textBox2.Text.Length < 1) || (textBox3.Text.Length < 1) || (textBox4.Text.Length < 1) || (textBox5.Text.Length < 1) || (comboBox1.Text.Length < 1))
                {
                    MessageBox.Show("Fill the Boxes");
                }
            }
            else if((textBox1.Text.Length >= 1) && (textBox2.Text.Length >= 1) && (textBox3.Text.Length >= 1) && (textBox4.Text.Length >= 1) && (textBox5.Text.Length >= 1) && (comboBox1.Text.Length >= 1))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Table_f (Id,Name,Surname,Age,Gender,Address) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "')";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                    sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message");
                }
                finally
                {
                    con.Close();
                }
            }
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                String query = "SELECT Id,Name,Surname,Age,Gender,Address FROM Table_f";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                con.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.ResetText();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                String query = "DELETE FROM Table_f";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                var Num = Convert.ToInt32(textBox6.Text);
                String query = "DELETE FROM Table_f WHERE Id =('"+Num+"')";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
