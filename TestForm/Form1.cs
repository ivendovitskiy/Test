using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestForm.Data;

namespace TestForm
{
    public partial class Form1 : Form
    {
        private string _filePath;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Device device = new Device()
            {
                AppEui = appEuiTextBox.Text,
                AppKey = appKeyTextBox.Text,
                AppSKey = appSKeyTextBox.Text,
                DevAdd = devAddTextBox.Text,
                DevEui = devEuiTextBox.Text,
                Name = nameTextBox.Text,
                NwkSKEY = nwkSKEYTextBox.Text
            };

            using (TestDbContext context = new TestDbContext())
            {
                context.Devices.Add(device);
                context.SaveChanges();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (TestDbContext context = new TestDbContext())
            {
                dataGridView1.DataSource = context.Devices.ToList();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                _filePath = openFileDialog1.FileName;
            }

            using(StreamReader  sr = File.OpenText(_filePath))
            {
                Regex regex = new Regex("[wdwd]");

                MatchCollection matches = regex.Matches(sr.ReadToEnd());


                foreach(var x in matches)
                {

                }
            }
        }
    }
}
