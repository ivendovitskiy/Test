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
    public partial class Checkin : Form
    {
        private string _filePath;

        public Checkin()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void Checkin_Load(object sender, EventArgs e)
        {

        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Если отмечено больше 2 элементов, то снимаем выделение со всех и отмечаем текущий.
            if (checkedListBox1.CheckedItems.Count > 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }

        //private void AddButton_Click(object sender, EventArgs e)
        //{
        //    Device device = new Device()
        //    {
        //        AppEui = appEuiTextBox.Text,
        //        AppKey = appKeyTextBox.Text,
        //        AppSKey = appSKeyTextBox.Text,
        //        DevAdd = devAddTextBox.Text,
        //        DevEui = devEuiTextBox.Text,
        //        Name = nameTextBox.Text,
        //        NwkSKEY = nwkSKEYTextBox.Text
        //    };

        //    using (TestDbContext context = new TestDbContext())
        //    {
        //        context.Devices.Add(device);
        //        context.SaveChanges();
        //    }
        //}

        //private void RefreshButton_Click(object sender, EventArgs e)
        //{
        //    using (TestDbContext context = new TestDbContext())
        //    {
        //        dataGridView1.DataSource = context.Devices.ToList();
        //    }
        //}

        //private void OpenFileButton_Click(object sender, EventArgs e)
        //{
        //    var result = openFileDialog1.ShowDialog();
        //    if (result == DialogResult.OK || result == DialogResult.Yes)
        //    {
        //        _filePath = openFileDialog1.FileName;
        //    }

        //    using(StreamReader  sr = File.OpenText(_filePath))
        //    {
        //        Regex regex = new Regex("devName:\n* DevEui:.*\n * (?< DevEui >.{ 1, })\n*AppEui:\n" +
        //            "(?< AppEui >.{ 1,})\n*AppKey:\n.{ 1,}\n *.{ 1,}\n*DevAdd:\n(?< DevAdd >.{ 1,})\n" +
        //            "*AppSKey:\n(?< AppSKey >.{ 1,})\n*NwkSKEY:\n * (?< NwkSKEY >.{ 1,})\n ? ");

        //        MatchCollection matches = regex.Matches(sr.ReadToEnd());

        //        foreach(var x in matches)
        //        {

        //        }
        //    }
        //}
    }
}
