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
            this.statusStrip1.SuspendLayout();
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
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.AllowDrop = true;
            this.checkedListBox1.CheckOnClick = true;
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
            this.checkedListBox1.Location = new System.Drawing.Point(129, 21);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBox1.Size = new System.Drawing.Size(155, 364);
            this.checkedListBox1.TabIndex = 43;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            this.checkedListBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckedListBox1_KeyDown);
            this.checkedListBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CheckedListBox1_KeyUp);
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
            this.devEuiBox.Location = new System.Drawing.Point(405, 54);
            this.devEuiBox.Name = "devEuiBox";
            this.devEuiBox.Size = new System.Drawing.Size(332, 29);
            this.devEuiBox.TabIndex = 45;
            // 
            // appEuiBox
            // 
            this.appEuiBox.Enabled = false;
            this.appEuiBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appEuiBox.Location = new System.Drawing.Point(405, 113);
            this.appEuiBox.Name = "appEuiBox";
            this.appEuiBox.Size = new System.Drawing.Size(332, 29);
            this.appEuiBox.TabIndex = 46;
            // 
            // appKeyBox
            // 
            this.appKeyBox.Enabled = false;
            this.appKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appKeyBox.Location = new System.Drawing.Point(405, 173);
            this.appKeyBox.Name = "appKeyBox";
            this.appKeyBox.Size = new System.Drawing.Size(332, 29);
            this.appKeyBox.TabIndex = 47;
            // 
            // devAddBox
            // 
            this.devAddBox.Enabled = false;
            this.devAddBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devAddBox.Location = new System.Drawing.Point(405, 229);
            this.devAddBox.Name = "devAddBox";
            this.devAddBox.Size = new System.Drawing.Size(332, 29);
            this.devAddBox.TabIndex = 48;
            // 
            // appSKeyBox
            // 
            this.appSKeyBox.Enabled = false;
            this.appSKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appSKeyBox.Location = new System.Drawing.Point(405, 288);
            this.appSKeyBox.Name = "appSKeyBox";
            this.appSKeyBox.Size = new System.Drawing.Size(332, 29);
            this.appSKeyBox.TabIndex = 49;
            // 
            // nwkSKey
            // 
            this.nwkSKey.Enabled = false;
            this.nwkSKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nwkSKey.Location = new System.Drawing.Point(405, 347);
            this.nwkSKey.Name = "nwkSKey";
            this.nwkSKey.Size = new System.Drawing.Size(332, 29);
            this.nwkSKey.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 51;
            this.label1.Text = "DevEui";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 52;
            this.label2.Text = "AppEui";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 53;
            this.label3.Text = "AppKey";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "DevAdd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 55;
            this.label5.Text = "AppSKey";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(405, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 56;
            this.label6.Text = "NwkSKey";
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
            // 
            // Checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 536);
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
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scanButton);
            this.Name = "Checkin";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.Checkin_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}

