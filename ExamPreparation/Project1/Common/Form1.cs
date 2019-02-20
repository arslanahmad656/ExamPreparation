using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Common
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ShowIcon = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Button clicked!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ChangeTextFieldValue();
            }).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ChangeTextFieldValue();
            });
        }

        private void ChangeTextFieldValue(TextBox txtBox = null, string value = "Value Changed!")
        {
            txtBox = txtBox ?? textBox1;
            try
            {
                textBox1.Text = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
