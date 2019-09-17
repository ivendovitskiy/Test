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
        Device[] devices;
        //private string _filePath;

        public Checkin()
        {
            InitializeComponent();
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Если отмечено больше 2 элементов, то снимаем выделение со всех и отмечаем текущий.
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
            devEuiBox.Text = devices[Convert.ToInt32(checkedListBox1.SelectedItem) - 1].DevEui;
            appEuiBox.Text = devices[Convert.ToInt32(checkedListBox1.SelectedItem) - 1].AppEui;
            appKeyBox.Text = devices[Convert.ToInt32(checkedListBox1.SelectedItem) - 1].AppKey;
            devAddBox.Text = devices[Convert.ToInt32(checkedListBox1.SelectedItem) - 1].DevAdd;
            appSKeyBox.Text = devices[Convert.ToInt32(checkedListBox1.SelectedItem) - 1].AppSKey;
            nwkSKeyBox.Text = devices[Convert.ToInt32(checkedListBox1.SelectedItem) - 1].NwkSKey;
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Text files(*.txt)|*.txt";
            //var result = dialog.ShowDialog();
            //if (result == DialogResult.OK || result == DialogResult.Yes)
            //{
            //    _filePath = dialog.FileName;
            //}
            //else
            //{
            //    return;
            //}
            using (StreamReader sr = File.OpenText(@"D:\Стенд LoRa\ПО Вега\v1.2.4\Devices.txt"))
            {
                string s = @"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAdd:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?";
                Regex regex = new Regex(s);

                string text = sr.ReadToEnd();
                MatchCollection matches = regex.Matches(text);

                devices = new Device[matches.Count];

                if (matches.Count > 24)
                {
                    MessageBox.Show("Отсканируйте не больше 24 сканеров");
                    return;
                }
                else
                {
                    if (matches.Count == 0)
                    {
                        MessageBox.Show("Отсканируйте хотя бы один сканер");
                    }
                    else
                    {
                        checkedListBox1.Items.Clear();
                        checkedListBox1.Enabled = true;
                        //continueTestButton.Enabled = true;

                        for (int i = 0; i < matches.Count; ++i)
                        {
                            checkedListBox1.Items.Add(i + 1, false);
                            //checkedListBox1.Items.
                            devices[i] = new Device()
                            {
                                Name = matches[i].Groups["DevName"].Value,
                                DevEui = matches[i].Groups["DevEui"].Value,
                                AppEui = matches[i].Groups["AppEui"].Value,
                                AppKey = matches[i].Groups["AppKey"].Value,
                                DevAdd = matches[i].Groups["DevAdd"].Value,
                                AppSKey = matches[i].Groups["AppSKey"].Value,
                                NwkSKey = matches[i].Groups["NwkSKey"].Value
                            };
                        }
                    }
                    MessageBox.Show("Сканирование завершено. Протокол сохранен на рабочий стол");
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (TestDbContext context = new TestDbContext())
            {
                toolStripProgressBar1.Value = 0;
                for (int i = 0; i < devices.Length; ++i)
                {
                    context.Devices.Add(devices[i]);
                    toolStripProgressBar1.Value += Convert.ToInt32(100 / devices.Length);
                }
                context.SaveChanges();
            }
        }

        private void RegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanButton.Visible = true;
            //continueTestButton.Visible = true;
            //saveButton.Visible = true;
            checkedListBox1.Visible = true;
            devEuiBox.Visible = true;
            appEuiBox.Visible = true;
            appKeyBox.Visible = true;
            devAddBox.Visible = true;
            appSKeyBox.Visible = true;
            nwkSKeyBox.Visible = true;
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ServToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
