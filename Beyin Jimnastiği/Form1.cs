using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Beyin_Jimnastiği
{
    public partial class Form1 : Form
    {
        Bitmap bm1;
        Bitmap bm2;
        int dogru = 0;
        int yanlis = 0;
        int sn = 72;
        int index;
        bool ctr1 = true;
        List<Image> il = new List<Image>();
        static bool karsi(Bitmap bm1, Bitmap bm2)
        {
            for (int i = 0; i < bm1.Width; i++)
            {
                for (int j = 0; j < bm1.Height; j++)
                {
                    Color cl1 = bm1.GetPixel(i, j);
                    Color cl2 = bm2.GetPixel(i, j);
                    if (cl1 != cl2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.OrangeRed;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            this.BackgroundImage = default; 
            pictureBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            label5.Visible = true;
            timer1.Enabled = true;
            Random r = new Random();
            index = r.Next(il.Count());
            pictureBox1.Image = il[index];
            bm1 = new Bitmap(pictureBox1.Image);
            ctr1 = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            il.Add(Properties.Resources.Adsız2_cutout);
            il.Add(Properties.Resources.Adsız4_cutout);
            il.Add(Properties.Resources.Adsız_cutout);
            pictureBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            Random r = new Random();
            index = r.Next(il.Count());
            timer1.Enabled = false;
            pictureBox2.Visible = false;            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sn--;
            if(sn==70)
            {
                Random r = new Random();
                index = r.Next(il.Count());
                pictureBox1.Image = il[index];
                if (ctr1 == false)
                {
                    bm2 = new Bitmap(pictureBox1.Image);
                    ctr1 = true;
                }
                else
                {
                    bm1 = new Bitmap(pictureBox1.Image);
                    ctr1 = false;
                }
            }
            label6.Text = sn.ToString();
            if (sn == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Doğru= " + dogru.ToString() + ", Yanlış" + yanlis.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            index = r.Next(il.Count());
            if (ctr1 == false)
            {
                bm2 = new Bitmap(pictureBox1.Image);
                ctr1 = true;
            }
            else
            {
                bm1 = new Bitmap(pictureBox1.Image);
                ctr1 = false;
            }
            if (!karsi(bm1, bm2))
            {
                dogru++;
                pictureBox2.Image = Properties.Resources.pngresmi;
                pictureBox2.Visible = true;
                timer2.Enabled = true;
            }
            else
            {
                yanlis++;
                pictureBox2.Image = Properties.Resources.pngresmi__1_;
                pictureBox2.Visible = true;
                timer2.Enabled = true;
            }
            pictureBox1.Image = il[index];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            index = r.Next(il.Count());
            if (ctr1 == false)
            {
                bm2 = new Bitmap(pictureBox1.Image);
                ctr1 = true;
            }
            else
            {
                bm1 = new Bitmap(pictureBox1.Image);
                ctr1 = false;
            }
            if (karsi(bm1, bm2))
            {
                dogru++;
                pictureBox2.Image = Properties.Resources.pngresmi;
                pictureBox2.Visible = true;
                timer2.Enabled = true;
            }
            else
            {
                yanlis++;
                pictureBox2.Image = Properties.Resources.pngresmi__1_;
                pictureBox2.Visible = true;
                timer2.Enabled = true;
            }
            pictureBox1.Image = il[index];
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            timer2.Enabled = false;
        }
    }
}
