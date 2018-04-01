using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            string selectedItem1 = comboBox1.SelectedItem as string;
            string selectedItem2 = comboBox2.SelectedItem as string;
            if (selectedItem1 != "" && selectedItem2 != "")
            {
                label4.Text = await Task.Run(() => this.client.GetAvailableBikes(selectedItem2, selectedItem1));
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem as string;
            this.stations = await Task.Run(() => client.GetAllStations(selectedItem));
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(this.stations);
        }
    }
}
