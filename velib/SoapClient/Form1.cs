using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SoapClient
{
    //Class for the windows form
    public partial class Form1 : Form
    {
        private string[] cities;
        private string[] stations;
        private Service1Client client;

        public Form1(Service1Client client)
        {
            InitializeComponent();
            this.client = client;
            cities = client.GetAllCities();
            comboBox1.Items.AddRange(cities);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem as string != "" && comboBox2.SelectedItem as string != "")
            {
                label4.Text = this.client.GetAvailableBikes(comboBox2.SelectedItem as string,comboBox1.SelectedItem as string);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedItem as string);
            this.stations = client.GetAllStations(comboBox1.SelectedItem as string);
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(this.stations);
        }
    }
}
