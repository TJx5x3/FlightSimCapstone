namespace FlightSimCapstone
{
    partial class DevForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TurnIndicatorLabel = new System.Windows.Forms.Label();
            this.AirspeedIndicatorLabel = new System.Windows.Forms.Label();
            this.TurnCoordinatorLabel = new System.Windows.Forms.Label();
            this.potentiometerValueLabel = new System.Windows.Forms.Label();
            this.CloseSerialPortButton = new System.Windows.Forms.Button();
            this.HeadingIndicatorLabel = new System.Windows.Forms.Label();
            this.AltimeterLabel = new System.Windows.Forms.Label();
            this.InitializeSimconnectButton = new System.Windows.Forms.Button();
            this.TestSimConnect_Button = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.VerticalAirspeedIndicatorLabel = new System.Windows.Forms.Label();
            this.SuctionGaugeLabel = new System.Windows.Forms.Label();
            this.TotalFuelLabel = new System.Windows.Forms.Label();
            this.CurrentFuelLabel = new System.Windows.Forms.Label();
            this.AmmeterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(58, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 105);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AmmeterLabel);
            this.panel1.Controls.Add(this.CurrentFuelLabel);
            this.panel1.Controls.Add(this.TotalFuelLabel);
            this.panel1.Controls.Add(this.SuctionGaugeLabel);
            this.panel1.Controls.Add(this.VerticalAirspeedIndicatorLabel);
            this.panel1.Controls.Add(this.TurnIndicatorLabel);
            this.panel1.Controls.Add(this.AirspeedIndicatorLabel);
            this.panel1.Controls.Add(this.TurnCoordinatorLabel);
            this.panel1.Controls.Add(this.potentiometerValueLabel);
            this.panel1.Controls.Add(this.CloseSerialPortButton);
            this.panel1.Controls.Add(this.HeadingIndicatorLabel);
            this.panel1.Controls.Add(this.AltimeterLabel);
            this.panel1.Controls.Add(this.InitializeSimconnectButton);
            this.panel1.Controls.Add(this.TestSimConnect_Button);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 495);
            this.panel1.TabIndex = 1;
            // 
            // TurnIndicatorLabel
            // 
            this.TurnIndicatorLabel.AutoSize = true;
            this.TurnIndicatorLabel.Location = new System.Drawing.Point(336, 208);
            this.TurnIndicatorLabel.Name = "TurnIndicatorLabel";
            this.TurnIndicatorLabel.Size = new System.Drawing.Size(73, 13);
            this.TurnIndicatorLabel.TabIndex = 12;
            this.TurnIndicatorLabel.Text = "Turn Indicator";
            // 
            // AirspeedIndicatorLabel
            // 
            this.AirspeedIndicatorLabel.AutoSize = true;
            this.AirspeedIndicatorLabel.Location = new System.Drawing.Point(336, 236);
            this.AirspeedIndicatorLabel.Name = "AirspeedIndicatorLabel";
            this.AirspeedIndicatorLabel.Size = new System.Drawing.Size(92, 13);
            this.AirspeedIndicatorLabel.TabIndex = 11;
            this.AirspeedIndicatorLabel.Text = "Airspeed Indicator";
            // 
            // TurnCoordinatorLabel
            // 
            this.TurnCoordinatorLabel.AutoSize = true;
            this.TurnCoordinatorLabel.Location = new System.Drawing.Point(336, 181);
            this.TurnCoordinatorLabel.Name = "TurnCoordinatorLabel";
            this.TurnCoordinatorLabel.Size = new System.Drawing.Size(86, 13);
            this.TurnCoordinatorLabel.TabIndex = 10;
            this.TurnCoordinatorLabel.Text = "Turn Coordinator";
            // 
            // potentiometerValueLabel
            // 
            this.potentiometerValueLabel.AutoSize = true;
            this.potentiometerValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potentiometerValueLabel.Location = new System.Drawing.Point(3, 403);
            this.potentiometerValueLabel.Name = "potentiometerValueLabel";
            this.potentiometerValueLabel.Size = new System.Drawing.Size(279, 29);
            this.potentiometerValueLabel.TabIndex = 9;
            this.potentiometerValueLabel.Text = "Potentiometer Readings:";
            // 
            // CloseSerialPortButton
            // 
            this.CloseSerialPortButton.Location = new System.Drawing.Point(110, 185);
            this.CloseSerialPortButton.Name = "CloseSerialPortButton";
            this.CloseSerialPortButton.Size = new System.Drawing.Size(178, 22);
            this.CloseSerialPortButton.TabIndex = 8;
            this.CloseSerialPortButton.Text = "Close COM5 ";
            this.CloseSerialPortButton.UseVisualStyleBackColor = true;
            this.CloseSerialPortButton.Click += new System.EventHandler(this.CloseSerialPortButton_Click);
            // 
            // HeadingIndicatorLabel
            // 
            this.HeadingIndicatorLabel.AutoSize = true;
            this.HeadingIndicatorLabel.Location = new System.Drawing.Point(336, 153);
            this.HeadingIndicatorLabel.Name = "HeadingIndicatorLabel";
            this.HeadingIndicatorLabel.Size = new System.Drawing.Size(91, 13);
            this.HeadingIndicatorLabel.TabIndex = 7;
            this.HeadingIndicatorLabel.Text = "Heading Indicator";
            // 
            // AltimeterLabel
            // 
            this.AltimeterLabel.AutoSize = true;
            this.AltimeterLabel.Location = new System.Drawing.Point(336, 124);
            this.AltimeterLabel.Name = "AltimeterLabel";
            this.AltimeterLabel.Size = new System.Drawing.Size(47, 13);
            this.AltimeterLabel.TabIndex = 6;
            this.AltimeterLabel.Text = "Altimeter";
            // 
            // InitializeSimconnectButton
            // 
            this.InitializeSimconnectButton.Location = new System.Drawing.Point(110, 153);
            this.InitializeSimconnectButton.Name = "InitializeSimconnectButton";
            this.InitializeSimconnectButton.Size = new System.Drawing.Size(178, 26);
            this.InitializeSimconnectButton.TabIndex = 5;
            this.InitializeSimconnectButton.Text = "Initialize SimConnect Readings";
            this.InitializeSimconnectButton.UseVisualStyleBackColor = true;
            this.InitializeSimconnectButton.Click += new System.EventHandler(this.InitializeSimConnectButton_Click);
            // 
            // TestSimConnect_Button
            // 
            this.TestSimConnect_Button.Location = new System.Drawing.Point(110, 124);
            this.TestSimConnect_Button.Name = "TestSimConnect_Button";
            this.TestSimConnect_Button.Size = new System.Drawing.Size(178, 23);
            this.TestSimConnect_Button.TabIndex = 4;
            this.TestSimConnect_Button.Text = "Test SimConnect Connection";
            this.TestSimConnect_Button.UseVisualStyleBackColor = true;
            this.TestSimConnect_Button.Click += new System.EventHandler(this.TestSimConnectButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(603, 124);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(101, 99);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // VerticalAirspeedIndicatorLabel
            // 
            this.VerticalAirspeedIndicatorLabel.AutoSize = true;
            this.VerticalAirspeedIndicatorLabel.Location = new System.Drawing.Point(335, 261);
            this.VerticalAirspeedIndicatorLabel.Name = "VerticalAirspeedIndicatorLabel";
            this.VerticalAirspeedIndicatorLabel.Size = new System.Drawing.Size(130, 13);
            this.VerticalAirspeedIndicatorLabel.TabIndex = 13;
            this.VerticalAirspeedIndicatorLabel.Text = "Vertical Airspeed Indicator";
            // 
            // SuctionGaugeLabel
            // 
            this.SuctionGaugeLabel.AutoSize = true;
            this.SuctionGaugeLabel.Location = new System.Drawing.Point(336, 287);
            this.SuctionGaugeLabel.Name = "SuctionGaugeLabel";
            this.SuctionGaugeLabel.Size = new System.Drawing.Size(78, 13);
            this.SuctionGaugeLabel.TabIndex = 14;
            this.SuctionGaugeLabel.Text = "Suction Gauge";
            // 
            // TotalFuelLabel
            // 
            this.TotalFuelLabel.AutoSize = true;
            this.TotalFuelLabel.Location = new System.Drawing.Point(335, 310);
            this.TotalFuelLabel.Name = "TotalFuelLabel";
            this.TotalFuelLabel.Size = new System.Drawing.Size(54, 13);
            this.TotalFuelLabel.TabIndex = 15;
            this.TotalFuelLabel.Text = "Total Fuel";
            // 
            // CurrentFuelLabel
            // 
            this.CurrentFuelLabel.AutoSize = true;
            this.CurrentFuelLabel.Location = new System.Drawing.Point(336, 334);
            this.CurrentFuelLabel.Name = "CurrentFuelLabel";
            this.CurrentFuelLabel.Size = new System.Drawing.Size(64, 13);
            this.CurrentFuelLabel.TabIndex = 16;
            this.CurrentFuelLabel.Text = "Current Fuel";
            // 
            // AmmeterLabel
            // 
            this.AmmeterLabel.AutoSize = true;
            this.AmmeterLabel.Location = new System.Drawing.Point(336, 359);
            this.AmmeterLabel.Name = "AmmeterLabel";
            this.AmmeterLabel.Size = new System.Drawing.Size(48, 13);
            this.AmmeterLabel.TabIndex = 17;
            this.AmmeterLabel.Text = "Ammeter";
            // 
            // DevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 564);
            this.Controls.Add(this.panel1);
            this.Name = "DevForm";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button TestSimConnect_Button;
        private System.Windows.Forms.Button InitializeSimconnectButton;
        private System.Windows.Forms.Label AltimeterLabel;
        private System.Windows.Forms.Label HeadingIndicatorLabel;
        private System.Windows.Forms.Button CloseSerialPortButton;
        private System.Windows.Forms.Label potentiometerValueLabel;
        private System.Windows.Forms.Label TurnCoordinatorLabel;
        private System.Windows.Forms.Label AirspeedIndicatorLabel;
        private System.Windows.Forms.Label TurnIndicatorLabel;
        private System.Windows.Forms.Label VerticalAirspeedIndicatorLabel;
        private System.Windows.Forms.Label SuctionGaugeLabel;
        private System.Windows.Forms.Label CurrentFuelLabel;
        private System.Windows.Forms.Label TotalFuelLabel;
        private System.Windows.Forms.Label AmmeterLabel;
    }
}