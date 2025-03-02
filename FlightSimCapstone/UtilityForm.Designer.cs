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
            this.startButton = new System.Windows.Forms.Button();
            this.appConsole = new System.Windows.Forms.RichTextBox();
            this.appConsoleTitle = new System.Windows.Forms.Label();
            this.openGraphicConfigButton = new System.Windows.Forms.Button();
            this.connectionStatusTitleLabel = new System.Windows.Forms.Label();
            this.statusInfoPanel = new System.Windows.Forms.Panel();
            this.displayStatusLabel = new System.Windows.Forms.Label();
            this.rudderStatusLabel = new System.Windows.Forms.Label();
            this.yokeStatusLabel = new System.Windows.Forms.Label();
            this.arduinoStatusLabel = new System.Windows.Forms.Label();
            this.displayConnectionTitleLabel = new System.Windows.Forms.Label();
            this.rudderConnectionTitleLabel = new System.Windows.Forms.Label();
            this.yokeConnectionTitleLabel = new System.Windows.Forms.Label();
            this.arduinoConnectionTitleLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(255, 283);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(237, 52);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // appConsole
            // 
            this.appConsole.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.appConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.appConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.appConsole.Location = new System.Drawing.Point(255, 25);
            this.appConsole.Name = "appConsole";
            this.appConsole.ReadOnly = true;
            this.appConsole.Size = new System.Drawing.Size(237, 231);
            this.appConsole.TabIndex = 1;
            this.appConsole.Text = "";
            this.appConsole.WordWrap = false;
            // 
            // appConsoleTitle
            // 
            this.appConsoleTitle.AutoSize = true;
            this.appConsoleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appConsoleTitle.Location = new System.Drawing.Point(252, 9);
            this.appConsoleTitle.Name = "appConsoleTitle";
            this.appConsoleTitle.Size = new System.Drawing.Size(56, 13);
            this.appConsoleTitle.TabIndex = 2;
            this.appConsoleTitle.Text = "Console:";
            // 
            // openGraphicConfigButton
            // 
            this.openGraphicConfigButton.Location = new System.Drawing.Point(12, 283);
            this.openGraphicConfigButton.Name = "openGraphicConfigButton";
            this.openGraphicConfigButton.Size = new System.Drawing.Size(237, 52);
            this.openGraphicConfigButton.TabIndex = 3;
            this.openGraphicConfigButton.Text = "Configure Graphical Interface";
            this.openGraphicConfigButton.UseVisualStyleBackColor = true;
            this.openGraphicConfigButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // connectionStatusTitleLabel
            // 
            this.connectionStatusTitleLabel.AutoSize = true;
            this.connectionStatusTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatusTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.connectionStatusTitleLabel.Name = "connectionStatusTitleLabel";
            this.connectionStatusTitleLabel.Size = new System.Drawing.Size(115, 13);
            this.connectionStatusTitleLabel.TabIndex = 4;
            this.connectionStatusTitleLabel.Text = "Connection Status:";
            // 
            // statusInfoPanel
            // 
            this.statusInfoPanel.Controls.Add(this.displayStatusLabel);
            this.statusInfoPanel.Controls.Add(this.rudderStatusLabel);
            this.statusInfoPanel.Controls.Add(this.yokeStatusLabel);
            this.statusInfoPanel.Controls.Add(this.arduinoStatusLabel);
            this.statusInfoPanel.Controls.Add(this.displayConnectionTitleLabel);
            this.statusInfoPanel.Controls.Add(this.rudderConnectionTitleLabel);
            this.statusInfoPanel.Controls.Add(this.yokeConnectionTitleLabel);
            this.statusInfoPanel.Controls.Add(this.arduinoConnectionTitleLabel);
            this.statusInfoPanel.Controls.Add(this.connectionStatusTitleLabel);
            this.statusInfoPanel.Location = new System.Drawing.Point(12, 12);
            this.statusInfoPanel.Name = "statusInfoPanel";
            this.statusInfoPanel.Size = new System.Drawing.Size(222, 265);
            this.statusInfoPanel.TabIndex = 5;
            // 
            // displayStatusLabel
            // 
            this.displayStatusLabel.AutoSize = true;
            this.displayStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayStatusLabel.Location = new System.Drawing.Point(73, 134);
            this.displayStatusLabel.Name = "displayStatusLabel";
            this.displayStatusLabel.Size = new System.Drawing.Size(31, 20);
            this.displayStatusLabel.TabIndex = 7;
            this.displayStatusLabel.Text = "n/a";
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
            // displayConnectionTitleLabel
            // 
            this.displayConnectionTitleLabel.AutoSize = true;
            this.displayConnectionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayConnectionTitleLabel.Location = new System.Drawing.Point(3, 134);
            this.displayConnectionTitleLabel.Name = "displayConnectionTitleLabel";
            this.displayConnectionTitleLabel.Size = new System.Drawing.Size(64, 20);
            this.displayConnectionTitleLabel.TabIndex = 9;
            this.displayConnectionTitleLabel.Text = "Display:";
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
            this.Controls.Add(this.statusInfoPanel);
            this.Controls.Add(this.openGraphicConfigButton);
            this.Controls.Add(this.appConsoleTitle);
            this.Controls.Add(this.appConsole);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UtilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Sim Capstone - Utility";
            this.statusInfoPanel.ResumeLayout(false);
            this.statusInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox appConsole;
        private System.Windows.Forms.Label appConsoleTitle;
        private System.Windows.Forms.Button openGraphicConfigButton;
        private System.Windows.Forms.Label connectionStatusTitleLabel;
        private System.Windows.Forms.Panel statusInfoPanel;
        private System.Windows.Forms.Label arduinoConnectionTitleLabel;
        private System.Windows.Forms.Label yokeConnectionTitleLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label rudderConnectionTitleLabel;
        private System.Windows.Forms.Label displayConnectionTitleLabel;
        private System.Windows.Forms.Label rudderStatusLabel;
        private System.Windows.Forms.Label yokeStatusLabel;
        private System.Windows.Forms.Label arduinoStatusLabel;
        private System.Windows.Forms.Label displayStatusLabel;
    }
}

