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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
            read();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            cs.register(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
            MessageBox.Show("Added");
            read();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.update(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.delete(textBox3.Text);
            read();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void read()
        {
            Customer cu = new Customer();
            cu.read();
            dataGridView1.DataSource = cu.dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    textBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    textBox3.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    textBox4.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Do not click header.. ");
            }
        }
    }
}
