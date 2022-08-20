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
    public partial class FormAddBooking : Form
    {
        Book book = new Book();

        public FormAddBooking()
        {
            InitializeComponent();
            read();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            book.roomdata();
            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox8.AutoCompleteCustomSource = book.collection;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            book.clientdata();
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = book.client;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            book.register(textBox8.Text, textBox2.Text, int.Parse(textBox5.Text),dateTimePicker4.Value.ToString("yyy-mm-dd"),dateTimePicker3.Value.ToString("yyy-mm-dd"),int.Parse(textBox6.Text),numericUpDown1.Value.ToString(),numericUpDown2.Value.ToString(),Breakfast.Text,checkBox2.Text,checkBox1.Text);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            cls();
        }

        private void read()
        {
            
            book.read();
            dataGridView1.DataSource = book.dt;
            cls();
        }

        private void cls()
        {
            textBox8.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker4.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            numericUpDown2.Value = 0;
            numericUpDown1.Value = 0;
            Breakfast.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Checked = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    textBox8.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    textBox5.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    dateTimePicker4.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    textBox6.Text = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    numericUpDown2.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    numericUpDown1.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                    if(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "Breakfast")
                    {
                        Breakfast.Checked = true;
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "Lunch")
                    {
                        checkBox2.Checked = true;
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString() == "Dinner")
                    {
                        checkBox1.Checked = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Do not click header.. ");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            book.pricecal(textBox8.Text, dateTimePicker4.Value.ToString("yyymmdd"), dateTimePicker3.Value.ToString("yyymmdd"), int.Parse(textBox6.Text));
            textBox5.Text = book.totalprice.ToString();
        }
    }
}
