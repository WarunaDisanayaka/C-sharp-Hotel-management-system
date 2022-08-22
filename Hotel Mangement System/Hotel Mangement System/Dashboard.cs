using MySql.Data.MySqlClient;
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
    public partial class Dashboard : Form
    {

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        public Dashboard()
        {
            

            DBconnection db=new DBconnection();
            db.Connect();

            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex==index)
            {
               index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];

            return ColorTranslator.FromHtml(color);
        }

        public void customerCount()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            string sql = "SELECT COUNT(*) FROM `customer`";
            MySqlCommand cmd = new MySqlCommand(sql, db.conn);
            var count1=cmd.ExecuteScalar();
           label8.Text = count1.ToString();
           
        }


        public void roomCount()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            string sql = "SELECT COUNT(*) FROM `room`";
            MySqlCommand cmd = new MySqlCommand(sql, db.conn);
            var count1 = cmd.ExecuteScalar();
          label6.Text = count1.ToString();

        }


        public void bookedCount()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            string sql = "SELECT COUNT(*) FROM `books`";
            MySqlCommand cmd = new MySqlCommand(sql, db.conn);
            var count1 = cmd.ExecuteScalar();
           label9.Text = count1.ToString();

        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font= new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(38, 16, 61);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCustomer(),sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddRoom(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddBooking(), sender);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            timer1.Start();
           label1.Text=DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            customerCount();
            roomCount();
            bookedCount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormProperty(), sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
