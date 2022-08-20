using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mangement_System
{
    public partial class FormProperty : Form
    {
        public FormProperty()
        {
            InitializeComponent();
            read();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    label7.Text=dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    textBox1.Text = (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textBox2.Text = (dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                    textBox3.Text = (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                    textBox4.Text = (dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                    dateTimePicker1.Text = (dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Do not click header.. ");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            int NoItems=Convert.ToInt32(textBox3.Text);
            decimal price = Convert.ToDecimal(textBox4.Text);

            Property pr = new Property();
            pr.add(textBox1.Text,textBox2.Text,NoItems,price, dateTimePicker1.Text);

            MessageBox.Show("Property added success!");
            read();
            cle();
            
        }

        private void cle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label7.Text = "";
        }

        private void read()
        {
            Property pr = new Property();
            pr.read();
            dataGridView2.DataSource = pr.dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int NoItems = Convert.ToInt32(textBox3.Text);
            decimal price = Convert.ToDecimal(textBox4.Text);
            int id = Convert.ToInt32(label7.Text);

            Property pr = new Property();
            pr.update(textBox1.Text, textBox2.Text, NoItems, price, dateTimePicker1.Text,id);
            read();
            cle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

           if(label7.Text=="")
            {
                MessageBox.Show("Please Select Item");
            }
            else
            {
                int id = Convert.ToInt32(label7.Text);
                Property pr = new Property();
                pr.delete(id);
                read();
                cle();
            }
        }
    }


}
