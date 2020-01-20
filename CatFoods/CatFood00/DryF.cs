using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CatFood00
{
    public partial class DryF : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public DryF()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\CatFoods\CatFood00\CICA\cicamicaDB.accdb;
            Persist Security Info=False;";  //If the location of cicamicaDB.accdb is not there it can make problems, change it to that location.
        }

        private void button2_Click(object sender, EventArgs e)  //show all value
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Száraztáp";
                command.CommandText = query;
                
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)          //insert new values
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Száraztáp ([Termék neve],[Kiszerelés],[Ár],[Egységár],[Alapanyagok]) values('" + txt_textBox1.Text + "','" + txt_textBox2.Text + "','" + txt_textBox3.Text + "','" + txt_textBox4.Text + "','" + txt_textBox5.Text + "')";

                command.ExecuteNonQuery();
                MessageBox.Show("Adat elmentve az adatbázisba");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DryF_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)      //update values
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "UPDATE Száraztáp SET [Termék neve]='" + txt_textBox1.Text + "' ,[Kiszerelés]='" + txt_textBox2.Text + "' ,[Ár]='" + txt_textBox3.Text + "' ,[Egységár]='" + txt_textBox4.Text + "' ,[Alapanyagok]='" + txt_textBox5.Text + "' WHERE [ID]=" + ID_textBox6.Text + "";

                MessageBox.Show(query);
                command.CommandText = query;
                
                command.ExecuteNonQuery();
                MessageBox.Show("Adat megváltoztatva");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex);
            }
        }
       
        private void button5_Click(object sender, EventArgs e)      //delete values by ID
        {
            try
            {
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from Száraztáp where [ID]=" + ID_textBox6.Text + "";

            command.ExecuteNonQuery();

            MessageBox.Show("Adat törölve az adatbázisbol");
            connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex);
            }
        }
    }
}
