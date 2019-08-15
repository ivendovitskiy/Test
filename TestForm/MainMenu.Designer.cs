namespace TestForm
{
    partial class MainMenu
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
            this.checkInButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.serviceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkInButton
            // 
            this.checkInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInButton.Location = new System.Drawing.Point(220, 74);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(347, 75);
            this.checkInButton.TabIndex = 0;
            this.checkInButton.Text = "Регистрация";
            this.checkInButton.UseVisualStyleBackColor = true;
            this.checkInButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // testButton
            // 
            this.testButton.Enabled = false;
            this.testButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton.Location = new System.Drawing.Point(220, 172);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(347, 75);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Тест";
            this.testButton.UseVisualStyleBackColor = true;
            // 
            // serviceButton
            // 
            this.serviceButton.Enabled = false;
            this.serviceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceButton.Location = new System.Drawing.Point(220, 271);
            this.serviceButton.Name = "serviceButton";
            this.serviceButton.Size = new System.Drawing.Size(347, 75);
            this.serviceButton.TabIndex = 2;
            this.serviceButton.Text = "Сервис";
            this.serviceButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 469);
            this.Controls.Add(this.serviceButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.checkInButton);
            this.Name = "MainMenu";
            this.Text = "Проверка работоспособости счетчиков с LoRa-модулем";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkInButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button serviceButton;
    }
}