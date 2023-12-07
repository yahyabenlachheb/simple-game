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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = Settings.defaultQ;
            textBox2.Text = Settings.defaultA;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\save.ch");
            sw.Write(textBox1.Text + "/" + textBox2.Text);
            sw.Close();
            Settings.defaultQ = textBox1.Text;
            Settings.defaultA = textBox2.Text;

        }
    }
}
