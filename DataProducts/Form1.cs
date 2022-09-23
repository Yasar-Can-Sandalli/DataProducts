using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataProducts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();

        public void Update()
        {
            table.Clear();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * From Products",connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            adapter.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("Insert into Products (ProductName,Stock) values ('"+textBox1.Text+"' , '"+textBox2.Text+"')",connection);
            command.ExecuteNonQuery();
            Update();
            MessageBox.Show("Added !");
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("Delete from Products where ID=" + Convert.ToInt32(textBox3.Text),connection);
            command.ExecuteNonQuery();
            Update();
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("Update Products set ProductName='"+textBox1.Text+"' , Stock='"+textBox2.Text+"' where ID=" + Convert.ToInt32(textBox3.Text),connection);
            command.ExecuteNonQuery();
            Update();
            MessageBox.Show("Updated !");
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table.Clear();
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Products where ID=" + Convert.ToInt32(textBox3.Text), connection);
            adapter.Fill(table);
            adapter.Dispose();
            dataGridView1.DataSource = table;
            connection.Close();
        }
    }
}
