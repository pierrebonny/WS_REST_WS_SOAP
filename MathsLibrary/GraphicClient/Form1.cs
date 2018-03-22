using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicClient
{
    public partial class Form1 : Form
    {
        private MathsOperationsClient clientBase;
        private MathsOperationsClient clientWs;

        public Form1(MathsOperationsClient clientBase, MathsOperationsClient clientWs)
        {
            this.clientBase = clientBase;
            this.clientWs = clientWs;
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            comboBox2.Items.Add("Addition");
            comboBox2.Items.Add("Multiplication");
            comboBox2.Items.Add("Division");
            label8.Text = label4.Text = label6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            if(!int.TryParse(textBox1.Text,out a) || !int.TryParse(textBox2.Text, out b))
            {
                label8.Text = "Erreur veuillez rentrer 2 chiffres corrects";
            }
            else
            {
                switch (comboBox2.SelectedItem.ToString())
                {
                    case "Addition":
                        label4.Text = clientBase.Add(a, b).ToString();
                        label6.Text = clientBase.Add(a, b).ToString();
                        comboBox2.SelectedIndex = -1;
                        textBox1.Clear();
                        textBox2.Clear();
                        label8.Text = "";
                        break;
                    case "Multiplication":
                        label4.Text = clientBase.Multiply(a, b).ToString();
                        label6.Text = clientBase.Multiply(a, b).ToString();
                        comboBox2.SelectedIndex = -1;
                        textBox1.Clear();
                        textBox2.Clear();
                        label8.Text = "";
                        break;
                    case "Division":
                        label4.Text = clientBase.Divide(a, b).ToString();
                        label6.Text = clientBase.Divide(a, b).ToString();
                        comboBox2.SelectedIndex = -1;
                        textBox1.Clear();
                        textBox2.Clear();
                        label8.Text = "";
                        break;
                    default:
                        label8.Text = "Choisissez une opération svp";
                        break;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
