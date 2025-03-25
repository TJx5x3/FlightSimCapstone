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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RollLabel = new System.Windows.Forms.Label();
            this.PitchLabel = new System.Windows.Forms.Label();
            this.AmmeterLabel = new System.Windows.Forms.Label();
            this.CurrentFuelLabel = new System.Windows.Forms.Label();
            this.TotalFuelLabel = new System.Windows.Forms.Label();
            this.SuctionGaugeLabel = new System.Windows.Forms.Label();
            this.VerticalAirspeedIndicatorLabel = new System.Windows.Forms.Label();
            this.TurnIndicatorLabel = new System.Windows.Forms.Label();
            this.AirspeedIndicatorLabel = new System.Windows.Forms.Label();
            this.TurnCoordinatorLabel = new System.Windows.Forms.Label();
            this.potentiometerValueLabel = new System.Windows.Forms.Label();
            this.CloseSerialPortButton = new System.Windows.Forms.Button();
            this.HeadingIndicatorLabel = new System.Windows.Forms.Label();
            this.AltimeterLabel = new System.Windows.Forms.Label();
            this.InitializeSimconnectButton = new System.Windows.Forms.Button();
            this.TestSimConnect_Button = new System.Windows.Forms.Button();
            this.RightSkeleton = new System.Windows.Forms.PictureBox();
            this.LeftSkeleton = new System.Windows.Forms.PictureBox();
            this.TitleGif = new System.Windows.Forms.PictureBox();
            this.HourLabel = new System.Windows.Forms.Label();
            this.MinuteLabel = new System.Windows.Forms.Label();
            this.SecondsLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightSkeleton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSkeleton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleGif)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SecondsLabel);
            this.panel1.Controls.Add(this.MinuteLabel);
            this.panel1.Controls.Add(this.HourLabel);
            this.panel1.Controls.Add(this.RollLabel);
            this.panel1.Controls.Add(this.PitchLabel);
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
            this.panel1.Controls.Add(this.RightSkeleton);
            this.panel1.Controls.Add(this.LeftSkeleton);
            this.panel1.Controls.Add(this.TitleGif);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 495);
            this.panel1.TabIndex = 1;
            // 
            // RollLabel
            // 
            this.RollLabel.AutoSize = true;
            this.RollLabel.Location = new System.Drawing.Point(336, 403);
            this.RollLabel.Name = "RollLabel";
            this.RollLabel.Size = new System.Drawing.Size(25, 13);
            this.RollLabel.TabIndex = 19;
            this.RollLabel.Text = "Roll";
            // 
            // PitchLabel
            // 
            this.PitchLabel.AutoSize = true;
            this.PitchLabel.Location = new System.Drawing.Point(336, 381);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(31, 13);
            this.PitchLabel.TabIndex = 18;
            this.PitchLabel.Text = "Pitch";
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
            // CurrentFuelLabel
            // 
            this.CurrentFuelLabel.AutoSize = true;
            this.CurrentFuelLabel.Location = new System.Drawing.Point(336, 334);
            this.CurrentFuelLabel.Name = "CurrentFuelLabel";
            this.CurrentFuelLabel.Size = new System.Drawing.Size(64, 13);
            this.CurrentFuelLabel.TabIndex = 16;
            this.CurrentFuelLabel.Text = "Current Fuel";
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
            // SuctionGaugeLabel
            // 
            this.SuctionGaugeLabel.AutoSize = true;
            this.SuctionGaugeLabel.Location = new System.Drawing.Point(336, 287);
            this.SuctionGaugeLabel.Name = "SuctionGaugeLabel";
            this.SuctionGaugeLabel.Size = new System.Drawing.Size(78, 13);
            this.SuctionGaugeLabel.TabIndex = 14;
            this.SuctionGaugeLabel.Text = "Suction Gauge";
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
            this.potentiometerValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potentiometerValueLabel.Location = new System.Drawing.Point(3, 403);
            this.potentiometerValueLabel.Name = "potentiometerValueLabel";
            this.potentiometerValueLabel.Size = new System.Drawing.Size(216, 24);
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
            // RightSkeleton
            // 
            this.RightSkeleton.Image = ((System.Drawing.Image)(resources.GetObject("RightSkeleton.Image")));
            this.RightSkeleton.Location = new System.Drawing.Point(603, 124);
            this.RightSkeleton.Name = "RightSkeleton";
            this.RightSkeleton.Size = new System.Drawing.Size(101, 99);
            this.RightSkeleton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightSkeleton.TabIndex = 3;
            this.RightSkeleton.TabStop = false;
            // 
            // LeftSkeleton
            // 
            this.LeftSkeleton.Image = ((System.Drawing.Image)(resources.GetObject("LeftSkeleton.Image")));
            this.LeftSkeleton.Location = new System.Drawing.Point(3, 124);
            this.LeftSkeleton.Name = "LeftSkeleton";
            this.LeftSkeleton.Size = new System.Drawing.Size(101, 99);
            this.LeftSkeleton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftSkeleton.TabIndex = 2;
            this.LeftSkeleton.TabStop = false;
            // 
            // TitleGif
            // 
            this.TitleGif.Image = ((System.Drawing.Image)(resources.GetObject("TitleGif.Image")));
            this.TitleGif.Location = new System.Drawing.Point(58, 3);
            this.TitleGif.Name = "TitleGif";
            this.TitleGif.Size = new System.Drawing.Size(601, 105);
            this.TitleGif.TabIndex = 0;
            this.TitleGif.TabStop = false;
            // 
            // HourLabel
            // 
            this.HourLabel.AutoSize = true;
            this.HourLabel.Location = new System.Drawing.Point(335, 423);
            this.HourLabel.Name = "HourLabel";
            this.HourLabel.Size = new System.Drawing.Size(35, 13);
            this.HourLabel.TabIndex = 20;
            this.HourLabel.Text = "Hours";
            // 
            // MinuteLabel
            // 
            this.MinuteLabel.AutoSize = true;
            this.MinuteLabel.Location = new System.Drawing.Point(336, 445);
            this.MinuteLabel.Name = "MinuteLabel";
            this.MinuteLabel.Size = new System.Drawing.Size(44, 13);
            this.MinuteLabel.TabIndex = 21;
            this.MinuteLabel.Text = "Minutes";
            // 
            // SecondsLabel
            // 
            this.SecondsLabel.AutoSize = true;
            this.SecondsLabel.Location = new System.Drawing.Point(336, 468);
            this.SecondsLabel.Name = "SecondsLabel";
            this.SecondsLabel.Size = new System.Drawing.Size(49, 13);
            this.SecondsLabel.TabIndex = 22;
            this.SecondsLabel.Text = "Seconds";
            // 
            // DevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 564);
            this.Controls.Add(this.panel1);
            this.Name = "DevForm";
            this.Text = "Secret Dev Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightSkeleton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSkeleton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleGif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TitleGif;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox LeftSkeleton;
        private System.Windows.Forms.PictureBox RightSkeleton;
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
        private System.Windows.Forms.Label RollLabel;
        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.Label SecondsLabel;
        private System.Windows.Forms.Label MinuteLabel;
        private System.Windows.Forms.Label HourLabel;
    }
}