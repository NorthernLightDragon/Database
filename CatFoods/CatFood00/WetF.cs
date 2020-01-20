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
    public partial class WetF : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public WetF()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\CatFoods\CatFood00\CICA\cicamicaDB.accdb;
            Persist Security Info=False;";  //If the location of cicamicaDB.accdb is not there it can make problems, change it to that location.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //show all value
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Nedvestáp";
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
                command.CommandText = "insert into Nedvestáp ([Termék neve],[Kiszerelés],[Ár],[Egységár],[Alapanyagok]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

                command.ExecuteNonQuery();
                MessageBox.Show("Adat elmentve az adatbázisba");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)      //update values
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "UPDATE Nedvestáp SET [Termék neve]='" + textBox1.Text + "' ,[Kiszerelés]='" + textBox2.Text + "' ,[Ár]='" + textBox3.Text + "' ,[Egységár]='" + textBox4.Text + "' ,[Alapanyagok]='" + textBox5.Text + "' WHERE [ID]=" + textBox6.Text + "";

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
            command.CommandText = "delete from Nedvestáp where [ID]=" + textBox6.Text + "";

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
