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
namespace chwaf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool rec = false;
        string answer = "";
        
        int c = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && !rec) { rec = true; e.KeyChar = '\t'; }
            else if (e.KeyChar == '.' && rec) { rec = false; e.KeyChar = '\t'; }
            if (c == Settings.defaultQ.Length) rec = false;
            if (rec)
            {
                answer += e.KeyChar;
                e.KeyChar = Settings.defaultQ[c];
                c++;
            }
            if (e.KeyChar == '\t') e.KeyChar = '\0';
        }


      private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                
                createMessage(panel1.Width - 230, textBox1.Text,Color.Wheat,Color.Gray);
                
            }
            
            if (e.KeyCode == Keys.Enter && answer != "")
            {
                createMessage(10, answer, Color.FromArgb(52, 152, 219),Color.White);
                answer = "";
                textBox1.Clear();
                c = 0;
            }
            else if(e.KeyCode == Keys.Enter && answer == "")
            {
                createMessage(10, Settings.defaultA, Color.FromArgb(52, 152, 219), Color.White);
                
                textBox1.Clear();
            }

            
            
        }
        int y = 10;
        public void createMessage(int x,string an,Color a,Color b) {
            timer1.Stop();
            panel1.VerticalScroll.Value = 0;
            Label l = new Label();
             l.BackColor = a;
             l.ForeColor = b;
             l.Text = an;
             l.Location = new Point(x, y);
             l.Width = 200;
             l.Height = Convert.ToInt32(Math.Ceiling((an.Length / 20.0)) * 25);
             l.Font = new Font("", 12);
             l.TextAlign = ContentAlignment.MiddleLeft;
            
             y = y + l.Size.Height + 10;
            
            panel1.Controls.Add(l);
            timer1.Start();


        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;

            string[] x = File.ReadAllText(Environment.CurrentDirectory + "\\save.ch").Split('/');
            Settings.defaultQ = x[0];
            Settings.defaultA = x[1];
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
             
        }
    }
}
