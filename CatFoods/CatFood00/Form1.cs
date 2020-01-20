using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CatFood00
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\CatFoods\CatFood00\CICA\cicamicaDB.accdb;
            Persist Security Info=False;";  //If the location of cicamicaDB.accdb is not there it can make problems, change it to that location.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Felhasználónév where Felhasználó ='" + textBox1.Text + "' and  Jelszó='" + textBox2.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;

            }
            if (count == 1)
            {
                connection.Close();
                connection.Dispose();
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show("A felhasználó név ezzel a jelszóval már használatban van");
            }
            else
            {
                MessageBox.Show("Felhasználó név és jelszó nem jó");
            }
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Biztos ki akar lépni a programból?", "Kilép", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
  }

