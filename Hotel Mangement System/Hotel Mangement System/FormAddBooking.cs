using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            roomID.AutoCompleteMode = AutoCompleteMode.Suggest;
            roomID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            roomID.AutoCompleteCustomSource = book.collection;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            book.clientdata();
            cusID.AutoCompleteMode = AutoCompleteMode.Suggest;
            cusID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cusID.AutoCompleteCustomSource = book.client;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string br="";
            string lu = "";
            string din = "";

            if (Breakfast.CheckState==CheckState.Checked)
            {
                br = Breakfast.Text;
            }
            if (checkBox1.CheckState == CheckState.Checked)
            {
                lu = checkBox1.Text;
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                din = checkBox2.Text;
            }


            book.register(roomID.Text, cusID.Text, int.Parse(textBox5.Text), dateTimePicker4.Value.ToString("yyy-mm-dd"), dateTimePicker3.Value.ToString("yyy-mm-dd"), int.Parse(textBox6.Text), textBox1.Text.ToString(), textBox2.Text.ToString(), br, lu, din);
            MessageBox.Show("Booking Added Success!");
            read();


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
            cusID.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker4.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            textBox1.Text = "";
            roomID.Text = "";
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
                    if (string.Equals(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(), "Breakfast"))
                    {
                        Breakfast.Checked = true;
                    }

                    if (string.Equals(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString(), "Lunch"))
                    {
                        checkBox1.Checked = true;
                    }

                    if (string.Equals(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString(), "Dinner"))
                    {
                        checkBox2.Checked = true;
                    }
                    label6.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    label5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    textBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                    textBox6.Text = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    dateTimePicker4.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    dateTimePicker3.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());




                   

                }
            }
            catch
            {
                MessageBox.Show("Do not click header.. ");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox6.Text!=null)
            {
                book.pricecal(roomID.Text, dateTimePicker4.Value.ToString("yyymmdd"), dateTimePicker3.Value.ToString("yyymmdd"), int.Parse(textBox6.Text));
                textBox5.Text = book.totalprice.ToString();
            }
            else
            {
                MessageBox.Show("Please Enter no of Rooms ");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {



            book.update(label6.Text.ToString(), Int32.Parse(textBox5.Text), dateTimePicker4.Text, dateTimePicker3.Text, Int32.Parse(textBox6.Text.ToString()), Int32.Parse(textBox1.Text.ToString()), Int32.Parse(textBox2.Text.ToString()), Breakfast.Text.ToString(), checkBox2.Text.ToString(), checkBox1.Text.ToString(),
                label6.Text.ToString());
            read();
            cls();
            MessageBox.Show("Booking Updated ");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            book.delete(label5.Text);
            read();
            cls();
            label5.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FormAddBooking_Load(object sender, EventArgs e)
        {

        }
    }
}
