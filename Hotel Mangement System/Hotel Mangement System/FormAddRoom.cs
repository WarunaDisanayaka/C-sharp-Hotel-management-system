using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mangement_System
{
    public partial class FormAddRoom : Form
    {
        public FormAddRoom()
        {
            InitializeComponent();
            read();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.register(textBox1.Text, textBox2.Text, comboBox1.Text, Int16.Parse(textBox3.Text), textBox4.Text);
            MessageBox.Show("Added");
            cls();
            read();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.update(textBox1.Text, textBox2.Text, comboBox1.Text, Int16.Parse(textBox3.Text), textBox4.Text);
            MessageBox.Show("Updated");
            cls();
            read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.delete(textBox2.Text);
            MessageBox.Show("Deleted");
            cls();
            read();
        }

        public void read()
        {
            Room room = new Room();
            room.read();
            dataGridView2.DataSource = room.dt;
        }

        public void cls()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    textBox1.Text = (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textBox2.Text = (dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                    comboBox1.Text = (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                    textBox3.Text = (dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                    textBox4.Text = (dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Do not click header.. ");
            }
        }
    }
}
