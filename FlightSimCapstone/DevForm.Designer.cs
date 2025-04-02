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
            this.throttleComboBox = new System.Windows.Forms.ComboBox();
            this.throttleLabel = new System.Windows.Forms.Label();
            this.arduinoMapLabel = new System.Windows.Forms.Label();
            this.SecondsLabel = new System.Windows.Forms.Label();
            this.MinuteLabel = new System.Windows.Forms.Label();
            this.HourLabel = new System.Windows.Forms.Label();
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
            this.setButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mixtureLabel = new System.Windows.Forms.Label();
            this.mixtureComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightSkeleton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSkeleton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleGif)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.mixtureComboBox);
            this.panel1.Controls.Add(this.mixtureLabel);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.setButton);
            this.panel1.Controls.Add(this.throttleComboBox);
            this.panel1.Controls.Add(this.throttleLabel);
            this.panel1.Controls.Add(this.arduinoMapLabel);
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
            this.panel1.Location = new System.Drawing.Point(12, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 510);
            this.panel1.TabIndex = 1;
            // 
            // throttleComboBox
            // 
            this.throttleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.throttleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.throttleComboBox.FormattingEnabled = true;
            this.throttleComboBox.ItemHeight = 13;
            this.throttleComboBox.Items.AddRange(new object[] {
            "Port 1",
            "Port 2",
            "Port 3",
            "Port 4"});
            this.throttleComboBox.Location = new System.Drawing.Point(64, 295);
            this.throttleComboBox.Name = "throttleComboBox";
            this.throttleComboBox.Size = new System.Drawing.Size(121, 21);
            this.throttleComboBox.TabIndex = 25;
            // 
            // throttleLabel
            // 
            this.throttleLabel.AutoSize = true;
            this.throttleLabel.Location = new System.Drawing.Point(15, 298);
            this.throttleLabel.Name = "throttleLabel";
            this.throttleLabel.Size = new System.Drawing.Size(43, 13);
            this.throttleLabel.TabIndex = 24;
            this.throttleLabel.Text = "Throttle";
            // 
            // arduinoMapLabel
            // 
            this.arduinoMapLabel.AutoSize = true;
            this.arduinoMapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arduinoMapLabel.Location = new System.Drawing.Point(14, 265);
            this.arduinoMapLabel.Name = "arduinoMapLabel";
            this.arduinoMapLabel.Size = new System.Drawing.Size(141, 20);
            this.arduinoMapLabel.TabIndex = 23;
            this.arduinoMapLabel.Text = "Arduino Mappings:";
            // 
            // SecondsLabel
            // 
            this.SecondsLabel.AutoSize = true;
            this.SecondsLabel.Location = new System.Drawing.Point(336, 469);
            this.SecondsLabel.Name = "SecondsLabel";
            this.SecondsLabel.Size = new System.Drawing.Size(49, 13);
            this.SecondsLabel.TabIndex = 22;
            this.SecondsLabel.Text = "Seconds";
            // 
            // MinuteLabel
            // 
            this.MinuteLabel.AutoSize = true;
            this.MinuteLabel.Location = new System.Drawing.Point(336, 446);
            this.MinuteLabel.Name = "MinuteLabel";
            this.MinuteLabel.Size = new System.Drawing.Size(44, 13);
            this.MinuteLabel.TabIndex = 21;
            this.MinuteLabel.Text = "Minutes";
            // 
            // HourLabel
            // 
            this.HourLabel.AutoSize = true;
            this.HourLabel.Location = new System.Drawing.Point(335, 424);
            this.HourLabel.Name = "HourLabel";
            this.HourLabel.Size = new System.Drawing.Size(35, 13);
            this.HourLabel.TabIndex = 20;
            this.HourLabel.Text = "Hours";
            // 
            // RollLabel
            // 
            this.RollLabel.AutoSize = true;
            this.RollLabel.Location = new System.Drawing.Point(336, 404);
            this.RollLabel.Name = "RollLabel";
            this.RollLabel.Size = new System.Drawing.Size(25, 13);
            this.RollLabel.TabIndex = 19;
            this.RollLabel.Text = "Roll";
            // 
            // PitchLabel
            // 
            this.PitchLabel.AutoSize = true;
            this.PitchLabel.Location = new System.Drawing.Point(336, 382);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(31, 13);
            this.PitchLabel.TabIndex = 18;
            this.PitchLabel.Text = "Pitch";
            // 
            // AmmeterLabel
            // 
            this.AmmeterLabel.AutoSize = true;
            this.AmmeterLabel.Location = new System.Drawing.Point(336, 360);
            this.AmmeterLabel.Name = "AmmeterLabel";
            this.AmmeterLabel.Size = new System.Drawing.Size(48, 13);
            this.AmmeterLabel.TabIndex = 17;
            this.AmmeterLabel.Text = "Ammeter";
            // 
            // CurrentFuelLabel
            // 
            this.CurrentFuelLabel.AutoSize = true;
            this.CurrentFuelLabel.Location = new System.Drawing.Point(336, 335);
            this.CurrentFuelLabel.Name = "CurrentFuelLabel";
            this.CurrentFuelLabel.Size = new System.Drawing.Size(64, 13);
            this.CurrentFuelLabel.TabIndex = 16;
            this.CurrentFuelLabel.Text = "Current Fuel";
            // 
            // TotalFuelLabel
            // 
            this.TotalFuelLabel.AutoSize = true;
            this.TotalFuelLabel.Location = new System.Drawing.Point(335, 311);
            this.TotalFuelLabel.Name = "TotalFuelLabel";
            this.TotalFuelLabel.Size = new System.Drawing.Size(54, 13);
            this.TotalFuelLabel.TabIndex = 15;
            this.TotalFuelLabel.Text = "Total Fuel";
            // 
            // SuctionGaugeLabel
            // 
            this.SuctionGaugeLabel.AutoSize = true;
            this.SuctionGaugeLabel.Location = new System.Drawing.Point(336, 288);
            this.SuctionGaugeLabel.Name = "SuctionGaugeLabel";
            this.SuctionGaugeLabel.Size = new System.Drawing.Size(78, 13);
            this.SuctionGaugeLabel.TabIndex = 14;
            this.SuctionGaugeLabel.Text = "Suction Gauge";
            // 
            // VerticalAirspeedIndicatorLabel
            // 
            this.VerticalAirspeedIndicatorLabel.AutoSize = true;
            this.VerticalAirspeedIndicatorLabel.Location = new System.Drawing.Point(335, 262);
            this.VerticalAirspeedIndicatorLabel.Name = "VerticalAirspeedIndicatorLabel";
            this.VerticalAirspeedIndicatorLabel.Size = new System.Drawing.Size(130, 13);
            this.VerticalAirspeedIndicatorLabel.TabIndex = 13;
            this.VerticalAirspeedIndicatorLabel.Text = "Vertical Airspeed Indicator";
            // 
            // TurnIndicatorLabel
            // 
            this.TurnIndicatorLabel.AutoSize = true;
            this.TurnIndicatorLabel.Location = new System.Drawing.Point(336, 209);
            this.TurnIndicatorLabel.Name = "TurnIndicatorLabel";
            this.TurnIndicatorLabel.Size = new System.Drawing.Size(73, 13);
            this.TurnIndicatorLabel.TabIndex = 12;
            this.TurnIndicatorLabel.Text = "Turn Indicator";
            // 
            // AirspeedIndicatorLabel
            // 
            this.AirspeedIndicatorLabel.AutoSize = true;
            this.AirspeedIndicatorLabel.Location = new System.Drawing.Point(336, 237);
            this.AirspeedIndicatorLabel.Name = "AirspeedIndicatorLabel";
            this.AirspeedIndicatorLabel.Size = new System.Drawing.Size(92, 13);
            this.AirspeedIndicatorLabel.TabIndex = 11;
            this.AirspeedIndicatorLabel.Text = "Airspeed Indicator";
            // 
            // TurnCoordinatorLabel
            // 
            this.TurnCoordinatorLabel.AutoSize = true;
            this.TurnCoordinatorLabel.Location = new System.Drawing.Point(336, 182);
            this.TurnCoordinatorLabel.Name = "TurnCoordinatorLabel";
            this.TurnCoordinatorLabel.Size = new System.Drawing.Size(86, 13);
            this.TurnCoordinatorLabel.TabIndex = 10;
            this.TurnCoordinatorLabel.Text = "Turn Coordinator";
            // 
            // potentiometerValueLabel
            // 
            this.potentiometerValueLabel.AutoSize = true;
            this.potentiometerValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.potentiometerValueLabel.Location = new System.Drawing.Point(3, 490);
            this.potentiometerValueLabel.Name = "potentiometerValueLabel";
            this.potentiometerValueLabel.Size = new System.Drawing.Size(185, 20);
            this.potentiometerValueLabel.TabIndex = 9;
            this.potentiometerValueLabel.Text = "Potentiometer Readings:";
            // 
            // CloseSerialPortButton
            // 
            this.CloseSerialPortButton.Location = new System.Drawing.Point(110, 182);
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
            this.HeadingIndicatorLabel.Location = new System.Drawing.Point(336, 150);
            this.HeadingIndicatorLabel.Name = "HeadingIndicatorLabel";
            this.HeadingIndicatorLabel.Size = new System.Drawing.Size(91, 13);
            this.HeadingIndicatorLabel.TabIndex = 7;
            this.HeadingIndicatorLabel.Text = "Heading Indicator";
            // 
            // AltimeterLabel
            // 
            this.AltimeterLabel.AutoSize = true;
            this.AltimeterLabel.Location = new System.Drawing.Point(336, 121);
            this.AltimeterLabel.Name = "AltimeterLabel";
            this.AltimeterLabel.Size = new System.Drawing.Size(47, 13);
            this.AltimeterLabel.TabIndex = 6;
            this.AltimeterLabel.Text = "Altimeter";
            // 
            // InitializeSimconnectButton
            // 
            this.InitializeSimconnectButton.Location = new System.Drawing.Point(110, 150);
            this.InitializeSimconnectButton.Name = "InitializeSimconnectButton";
            this.InitializeSimconnectButton.Size = new System.Drawing.Size(178, 26);
            this.InitializeSimconnectButton.TabIndex = 5;
            this.InitializeSimconnectButton.Text = "Initialize SimConnect Readings";
            this.InitializeSimconnectButton.UseVisualStyleBackColor = true;
            this.InitializeSimconnectButton.Click += new System.EventHandler(this.InitializeSimConnectButton_Click);
            // 
            // TestSimConnect_Button
            // 
            this.TestSimConnect_Button.Location = new System.Drawing.Point(110, 121);
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
            this.RightSkeleton.Location = new System.Drawing.Point(603, 104);
            this.RightSkeleton.Name = "RightSkeleton";
            this.RightSkeleton.Size = new System.Drawing.Size(101, 99);
            this.RightSkeleton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightSkeleton.TabIndex = 3;
            this.RightSkeleton.TabStop = false;
            // 
            // LeftSkeleton
            // 
            this.LeftSkeleton.Image = ((System.Drawing.Image)(resources.GetObject("LeftSkeleton.Image")));
            this.LeftSkeleton.Location = new System.Drawing.Point(3, 104);
            this.LeftSkeleton.Name = "LeftSkeleton";
            this.LeftSkeleton.Size = new System.Drawing.Size(101, 99);
            this.LeftSkeleton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftSkeleton.TabIndex = 2;
            this.LeftSkeleton.TabStop = false;
            // 
            // TitleGif
            // 
            this.TitleGif.Image = ((System.Drawing.Image)(resources.GetObject("TitleGif.Image")));
            this.TitleGif.Location = new System.Drawing.Point(54, -7);
            this.TitleGif.Name = "TitleGif";
            this.TitleGif.Size = new System.Drawing.Size(601, 105);
            this.TitleGif.TabIndex = 0;
            this.TitleGif.TabStop = false;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(18, 394);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 26;
            this.setButton.Text = "Set Mapping";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.SetButton_OnClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(99, 394);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_OnClick);
            // 
            // mixtureLabel
            // 
            this.mixtureLabel.AutoSize = true;
            this.mixtureLabel.Location = new System.Drawing.Point(16, 339);
            this.mixtureLabel.Name = "mixtureLabel";
            this.mixtureLabel.Size = new System.Drawing.Size(41, 13);
            this.mixtureLabel.TabIndex = 28;
            this.mixtureLabel.Text = "Mixture";
            // 
            // mixtureComboBox
            // 
            this.mixtureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mixtureComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mixtureComboBox.FormattingEnabled = true;
            this.mixtureComboBox.ItemHeight = 13;
            this.mixtureComboBox.Items.AddRange(new object[] {
            "Port 1",
            "Port 2",
            "Port 3",
            "Port 4"});
            this.mixtureComboBox.Location = new System.Drawing.Point(63, 336);
            this.mixtureComboBox.Name = "mixtureComboBox";
            this.mixtureComboBox.Size = new System.Drawing.Size(121, 21);
            this.mixtureComboBox.TabIndex = 29;
            // 
            // DevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 564);
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
        private System.Windows.Forms.Label arduinoMapLabel;
        private System.Windows.Forms.ComboBox throttleComboBox;
        private System.Windows.Forms.Label throttleLabel;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox mixtureComboBox;
        private System.Windows.Forms.Label mixtureLabel;
    }
}