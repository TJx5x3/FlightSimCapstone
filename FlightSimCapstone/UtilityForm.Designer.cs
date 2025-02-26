namespace FlightSimCapstone
{
    partial class UtilityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilityForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.AppConsole = new System.Windows.Forms.RichTextBox();
            this.AppConsoleTitle = new System.Windows.Forms.Label();
            this.OpenGraphicConfigButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rudderStatusLabel = new System.Windows.Forms.Label();
            this.yokeStatusLabel = new System.Windows.Forms.Label();
            this.arduinoStatusLabel = new System.Windows.Forms.Label();
            this.displayStatusLabel = new System.Windows.Forms.Label();
            this.rudderConnectionTitleLabel = new System.Windows.Forms.Label();
            this.yokeConnectionTitleLabel = new System.Windows.Forms.Label();
            this.arduinoConnectionTitleLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(255, 283);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(237, 52);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // AppConsole
            // 
            this.AppConsole.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AppConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.AppConsole.Location = new System.Drawing.Point(255, 25);
            this.AppConsole.Name = "AppConsole";
            this.AppConsole.ReadOnly = true;
            this.AppConsole.Size = new System.Drawing.Size(237, 218);
            this.AppConsole.TabIndex = 1;
            this.AppConsole.Text = "";
            this.AppConsole.WordWrap = false;
            // 
            // AppConsoleTitle
            // 
            this.AppConsoleTitle.AutoSize = true;
            this.AppConsoleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppConsoleTitle.Location = new System.Drawing.Point(252, 9);
            this.AppConsoleTitle.Name = "AppConsoleTitle";
            this.AppConsoleTitle.Size = new System.Drawing.Size(56, 13);
            this.AppConsoleTitle.TabIndex = 2;
            this.AppConsoleTitle.Text = "Console:";
            // 
            // OpenGraphicConfigButton
            // 
            this.OpenGraphicConfigButton.Location = new System.Drawing.Point(12, 283);
            this.OpenGraphicConfigButton.Name = "OpenGraphicConfigButton";
            this.OpenGraphicConfigButton.Size = new System.Drawing.Size(237, 52);
            this.OpenGraphicConfigButton.TabIndex = 3;
            this.OpenGraphicConfigButton.Text = "Configure Graphical Interface";
            this.OpenGraphicConfigButton.UseVisualStyleBackColor = true;
            this.OpenGraphicConfigButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connection Status:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rudderStatusLabel);
            this.panel1.Controls.Add(this.yokeStatusLabel);
            this.panel1.Controls.Add(this.arduinoStatusLabel);
            this.panel1.Controls.Add(this.displayStatusLabel);
            this.panel1.Controls.Add(this.rudderConnectionTitleLabel);
            this.panel1.Controls.Add(this.yokeConnectionTitleLabel);
            this.panel1.Controls.Add(this.arduinoConnectionTitleLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 265);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "n/a";
            // 
            // rudderStatusLabel
            // 
            this.rudderStatusLabel.AutoSize = true;
            this.rudderStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rudderStatusLabel.Location = new System.Drawing.Point(127, 97);
            this.rudderStatusLabel.Name = "rudderStatusLabel";
            this.rudderStatusLabel.Size = new System.Drawing.Size(31, 20);
            this.rudderStatusLabel.TabIndex = 11;
            this.rudderStatusLabel.Text = "n/a";
            // 
            // yokeStatusLabel
            // 
            this.yokeStatusLabel.AutoSize = true;
            this.yokeStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yokeStatusLabel.Location = new System.Drawing.Point(59, 62);
            this.yokeStatusLabel.Name = "yokeStatusLabel";
            this.yokeStatusLabel.Size = new System.Drawing.Size(31, 20);
            this.yokeStatusLabel.TabIndex = 10;
            this.yokeStatusLabel.Text = "n/a";
            // 
            // arduinoStatusLabel
            // 
            this.arduinoStatusLabel.AutoSize = true;
            this.arduinoStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arduinoStatusLabel.Location = new System.Drawing.Point(73, 30);
            this.arduinoStatusLabel.Name = "arduinoStatusLabel";
            this.arduinoStatusLabel.Size = new System.Drawing.Size(31, 20);
            this.arduinoStatusLabel.TabIndex = 7;
            this.arduinoStatusLabel.Text = "n/a";
            // 
            // displayStatusLabel
            // 
            this.displayStatusLabel.AutoSize = true;
            this.displayStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayStatusLabel.Location = new System.Drawing.Point(3, 134);
            this.displayStatusLabel.Name = "displayStatusLabel";
            this.displayStatusLabel.Size = new System.Drawing.Size(64, 20);
            this.displayStatusLabel.TabIndex = 9;
            this.displayStatusLabel.Text = "Display:";
            // 
            // rudderConnectionTitleLabel
            // 
            this.rudderConnectionTitleLabel.AutoSize = true;
            this.rudderConnectionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rudderConnectionTitleLabel.Location = new System.Drawing.Point(3, 97);
            this.rudderConnectionTitleLabel.Name = "rudderConnectionTitleLabel";
            this.rudderConnectionTitleLabel.Size = new System.Drawing.Size(118, 20);
            this.rudderConnectionTitleLabel.TabIndex = 8;
            this.rudderConnectionTitleLabel.Text = "Rudder Pedals:";
            // 
            // yokeConnectionTitleLabel
            // 
            this.yokeConnectionTitleLabel.AutoSize = true;
            this.yokeConnectionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yokeConnectionTitleLabel.Location = new System.Drawing.Point(3, 62);
            this.yokeConnectionTitleLabel.Name = "yokeConnectionTitleLabel";
            this.yokeConnectionTitleLabel.Size = new System.Drawing.Size(50, 20);
            this.yokeConnectionTitleLabel.TabIndex = 7;
            this.yokeConnectionTitleLabel.Text = "Yoke:";
            // 
            // arduinoConnectionTitleLabel
            // 
            this.arduinoConnectionTitleLabel.AutoSize = true;
            this.arduinoConnectionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arduinoConnectionTitleLabel.Location = new System.Drawing.Point(3, 30);
            this.arduinoConnectionTitleLabel.Name = "arduinoConnectionTitleLabel";
            this.arduinoConnectionTitleLabel.Size = new System.Drawing.Size(68, 20);
            this.arduinoConnectionTitleLabel.TabIndex = 6;
            this.arduinoConnectionTitleLabel.Text = "Arduino:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(255, 262);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(232, 15);
            this.progressBar1.TabIndex = 6;
            // 
            // UtilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 341);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenGraphicConfigButton);
            this.Controls.Add(this.AppConsoleTitle);
            this.Controls.Add(this.AppConsole);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UtilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Sim Capstone - Utility";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.RichTextBox AppConsole;
        private System.Windows.Forms.Label AppConsoleTitle;
        private System.Windows.Forms.Button OpenGraphicConfigButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label arduinoConnectionTitleLabel;
        private System.Windows.Forms.Label yokeConnectionTitleLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label rudderConnectionTitleLabel;
        private System.Windows.Forms.Label displayStatusLabel;
        private System.Windows.Forms.Label rudderStatusLabel;
        private System.Windows.Forms.Label yokeStatusLabel;
        private System.Windows.Forms.Label arduinoStatusLabel;
        private System.Windows.Forms.Label label2;
    }
}

