using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool lmao = true;

        int n=0;
        Point[] t= new Point[100];
        Random rng = new Random();
        Bitmap bmp;
        int a,b;
        float x, y, x_, y_;
        double count = 0;
        Stopwatch vreme = new Stopwatch();
        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (lmao)
            {
                t[n].X = Cursor.Position.X;
                t[n].Y = Cursor.Position.Y;
                n++;
                this.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            vreme.Stop();
            lmao = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lmao)
            {
                a = rng.Next(n);
                b = rng.Next(n);
                while (a == b) b = rng.Next(n);
                x = t[a].X; y = t[a].Y;
                x_ = t[b].X; y_ = t[b].Y;
            }
            vreme.Start();
            if (radioButton1.Checked)
            {
                timer1.Start();
            }
            else if (radioButton2.Checked)
            {
                while (count < Convert.ToDouble(textBox1.Text))
                {
                    skec();
                    label1.Text = "Dots: " + Convert.ToString(count++) + "\n" +
                         "Vreme: " + vreme.Elapsed;
                    this.Invalidate();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton1.ForeColor = Color.White;
            radioButton2.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.Text = "Dots: " + Convert.ToString(count) + "\n" +
                "Vreme: " + vreme.Elapsed;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;

            this.BackColor = Color.Black;
            bmp = new Bitmap(this.Width, this.Height);
            /*t[0].X = 200; t[0].Y = 50;
            t[1].X = 100; t[1].Y = 300;
            t[2].X = 300; t[2].Y = 300;*/

            timer1.Interval = 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (n != 0)
            {
                for (int i = 0; i < n; i++)
                    e.Graphics.FillEllipse(Brushes.Red, t[i].X, t[i].Y, 7, 7);
                e.Graphics.DrawImage(bmp, 0, 0);
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            skec();
            label1.Text = "Dots: " + Convert.ToString(count++) + "\n" +
                 "Vreme: " + vreme.Elapsed;
            this.Invalidate();
            if (count > Convert.ToDouble(textBox1.Text)) timer1.Stop();
        }

        void skec()
        {
            x = (x + x_) / 2;
            y = (y + y_) / 2;
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(Brushes.Green);
                g.FillEllipse(Brushes.Green, x, y, 2, 2);
            }
            x_ = x; y_ = y;
            b = rng.Next(n);
            x = t[b].X;
            y = t[b].Y;
        }
    }
}
