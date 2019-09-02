namespace TestForm
{
    partial class Checkin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scanButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.devEuiBox = new System.Windows.Forms.TextBox();
            this.appEuiBox = new System.Windows.Forms.TextBox();
            this.appKeyBox = new System.Windows.Forms.TextBox();
            this.devAddBox = new System.Windows.Forms.TextBox();
            this.appSKeyBox = new System.Windows.Forms.TextBox();
            this.nwkSKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.continueTestButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.regToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softwareVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devEui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devAddNwkSKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appSKeyAppEuiAppKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relayOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relayOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanButton.Location = new System.Drawing.Point(40, 445);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(200, 57);
            this.scanButton.TabIndex = 17;
            this.scanButton.Text = "Сканировать";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Visible = false;
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(581, 445);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 57);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.AllowDrop = true;
            this.checkedListBox1.ColumnWidth = 75;
            this.checkedListBox1.Enabled = false;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.checkedListBox1.Location = new System.Drawing.Point(129, 29);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBox1.Size = new System.Drawing.Size(155, 364);
            this.checkedListBox1.TabIndex = 43;
            this.checkedListBox1.Visible = false;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(810, 22);
            this.statusStrip1.TabIndex = 44;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // devEuiBox
            // 
            this.devEuiBox.Enabled = false;
            this.devEuiBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devEuiBox.Location = new System.Drawing.Point(405, 62);
            this.devEuiBox.Name = "devEuiBox";
            this.devEuiBox.Size = new System.Drawing.Size(332, 29);
            this.devEuiBox.TabIndex = 45;
            this.devEuiBox.Visible = false;
            // 
            // appEuiBox
            // 
            this.appEuiBox.Enabled = false;
            this.appEuiBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appEuiBox.Location = new System.Drawing.Point(405, 121);
            this.appEuiBox.Name = "appEuiBox";
            this.appEuiBox.Size = new System.Drawing.Size(332, 29);
            this.appEuiBox.TabIndex = 46;
            this.appEuiBox.Visible = false;
            // 
            // appKeyBox
            // 
            this.appKeyBox.Enabled = false;
            this.appKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appKeyBox.Location = new System.Drawing.Point(405, 181);
            this.appKeyBox.Name = "appKeyBox";
            this.appKeyBox.Size = new System.Drawing.Size(332, 29);
            this.appKeyBox.TabIndex = 47;
            this.appKeyBox.Visible = false;
            // 
            // devAddBox
            // 
            this.devAddBox.Enabled = false;
            this.devAddBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devAddBox.Location = new System.Drawing.Point(405, 237);
            this.devAddBox.Name = "devAddBox";
            this.devAddBox.Size = new System.Drawing.Size(332, 29);
            this.devAddBox.TabIndex = 48;
            this.devAddBox.Visible = false;
            // 
            // appSKeyBox
            // 
            this.appSKeyBox.Enabled = false;
            this.appSKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appSKeyBox.Location = new System.Drawing.Point(405, 296);
            this.appSKeyBox.Name = "appSKeyBox";
            this.appSKeyBox.Size = new System.Drawing.Size(332, 29);
            this.appSKeyBox.TabIndex = 49;
            this.appSKeyBox.Visible = false;
            // 
            // nwkSKey
            // 
            this.nwkSKey.Enabled = false;
            this.nwkSKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nwkSKey.Location = new System.Drawing.Point(405, 355);
            this.nwkSKey.Name = "nwkSKey";
            this.nwkSKey.Size = new System.Drawing.Size(332, 29);
            this.nwkSKey.TabIndex = 50;
            this.nwkSKey.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 51;
            this.label1.Text = "DevEui";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 52;
            this.label2.Text = "AppEui";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 53;
            this.label3.Text = "AppKey";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "DevAdd";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 55;
            this.label5.Text = "AppSKey";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(405, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 56;
            this.label6.Text = "NwkSKey";
            this.label6.Visible = false;
            // 
            // continueTestButton
            // 
            this.continueTestButton.Enabled = false;
            this.continueTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueTestButton.Location = new System.Drawing.Point(246, 445);
            this.continueTestButton.Name = "continueTestButton";
            this.continueTestButton.Size = new System.Drawing.Size(200, 57);
            this.continueTestButton.TabIndex = 57;
            this.continueTestButton.Text = "Продолжить тестирование";
            this.continueTestButton.UseVisualStyleBackColor = true;
            this.continueTestButton.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(107, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 37);
            this.label7.TabIndex = 58;
            this.label7.Text = "Используйте стрелочки ↑ и ↓ для переключения счетчиков";
            this.label7.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regToolStripMenuItem,
            this.testToolStripMenuItem,
            this.servToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 59;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // regToolStripMenuItem
            // 
            this.regToolStripMenuItem.Name = "regToolStripMenuItem";
            this.regToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.regToolStripMenuItem.Text = "Регистрация";
            this.regToolStripMenuItem.Click += new System.EventHandler(this.RegToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.testToolStripMenuItem.Text = "Тестирование";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // servToolStripMenuItem
            // 
            this.servToolStripMenuItem.Name = "servToolStripMenuItem";
            this.servToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.servToolStripMenuItem.Text = "Сервис";
            this.servToolStripMenuItem.Click += new System.EventHandler(this.ServToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.factoryNumber,
            this.softwareVersion,
            this.devEui,
            this.devAddNwkSKey,
            this.appSKeyAppEuiAppKey,
            this.snr,
            this.timeBefore,
            this.timeAfter,
            this.relayOff,
            this.relayOn,
            this.notes});
            this.dataGridView1.Location = new System.Drawing.Point(373, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(425, 42);
            this.dataGridView1.TabIndex = 60;
            this.dataGridView1.Visible = false;
            // 
            // Position
            // 
            this.Position.HeaderText = "Номер места";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // factoryNumber
            // 
            this.factoryNumber.HeaderText = "Заводской номер";
            this.factoryNumber.Name = "factoryNumber";
            this.factoryNumber.ReadOnly = true;
            // 
            // softwareVersion
            // 
            this.softwareVersion.HeaderText = "Версия ПО";
            this.softwareVersion.Name = "softwareVersion";
            this.softwareVersion.ReadOnly = true;
            // 
            // devEui
            // 
            this.devEui.HeaderText = "DevEui";
            this.devEui.Name = "devEui";
            this.devEui.ReadOnly = true;
            // 
            // devAddNwkSKey
            // 
            this.devAddNwkSKey.HeaderText = "DevAdd/NwkSKey";
            this.devAddNwkSKey.Name = "devAddNwkSKey";
            this.devAddNwkSKey.ReadOnly = true;
            // 
            // appSKeyAppEuiAppKey
            // 
            this.appSKeyAppEuiAppKey.HeaderText = "AppSKey/AppEui/AppKey";
            this.appSKeyAppEuiAppKey.Name = "appSKeyAppEuiAppKey";
            this.appSKeyAppEuiAppKey.ReadOnly = true;
            // 
            // snr
            // 
            this.snr.HeaderText = "Качество связи(SNR)";
            this.snr.Name = "snr";
            this.snr.ReadOnly = true;
            // 
            // timeBefore
            // 
            this.timeBefore.HeaderText = "Отклонение времени до коррекции (с)";
            this.timeBefore.Name = "timeBefore";
            this.timeBefore.ReadOnly = true;
            // 
            // timeAfter
            // 
            this.timeAfter.HeaderText = "Отклонение времени после коррекции (с)";
            this.timeAfter.Name = "timeAfter";
            this.timeAfter.ReadOnly = true;
            // 
            // relayOff
            // 
            this.relayOff.HeaderText = "Реле откл.";
            this.relayOff.Name = "relayOff";
            this.relayOff.ReadOnly = true;
            // 
            // relayOn
            // 
            this.relayOn.HeaderText = "Реле вкл.";
            this.relayOn.Name = "relayOn";
            this.relayOn.ReadOnly = true;
            // 
            // notes
            // 
            this.notes.HeaderText = "Примечания";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            // 
            // Checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 536);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.continueTestButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nwkSKey);
            this.Controls.Add(this.appSKeyBox);
            this.Controls.Add(this.devAddBox);
            this.Controls.Add(this.appKeyBox);
            this.Controls.Add(this.appEuiBox);
            this.Controls.Add(this.devEuiBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scanButton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Checkin";
            this.Text = "Регистрация";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox devEuiBox;
        private System.Windows.Forms.TextBox appEuiBox;
        private System.Windows.Forms.TextBox appKeyBox;
        private System.Windows.Forms.TextBox devAddBox;
        private System.Windows.Forms.TextBox appSKeyBox;
        private System.Windows.Forms.TextBox nwkSKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button continueTestButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem regToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn softwareVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn devEui;
        private System.Windows.Forms.DataGridViewTextBoxColumn devAddNwkSKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn appSKeyAppEuiAppKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn snr;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn relayOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn relayOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
    }
}

