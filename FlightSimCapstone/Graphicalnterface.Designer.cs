namespace FlightSimCapstone
{
    partial class Graphicalnterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphicalnterface));
            this.TurnCoordinatorAirplane = new System.Windows.Forms.PictureBox();
            this.TurnCoordinatorBack = new System.Windows.Forms.PictureBox();
            this.HeadingIndicatorOverlay = new System.Windows.Forms.PictureBox();
            this.HeadingIndicatorBack = new System.Windows.Forms.PictureBox();
            this.RotateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TurnCoordinatorAirplane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnCoordinatorBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingIndicatorOverlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingIndicatorBack)).BeginInit();
            this.SuspendLayout();
            // 
            // TurnCoordinatorAirplane
            // 
            this.TurnCoordinatorAirplane.BackColor = System.Drawing.Color.Transparent;
            this.TurnCoordinatorAirplane.Image = global::FlightSimCapstone.Properties.Resources.TurnCoordinatorAirplane;
            this.TurnCoordinatorAirplane.Location = new System.Drawing.Point(487, 12);
            this.TurnCoordinatorAirplane.Name = "TurnCoordinatorAirplane";
            this.TurnCoordinatorAirplane.Size = new System.Drawing.Size(400, 400);
            this.TurnCoordinatorAirplane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TurnCoordinatorAirplane.TabIndex = 4;
            this.TurnCoordinatorAirplane.TabStop = false;
            // 
            // TurnCoordinatorBack
            // 
            this.TurnCoordinatorBack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TurnCoordinatorBack.Image = global::FlightSimCapstone.Properties.Resources.TurnCoordinator;
            this.TurnCoordinatorBack.Location = new System.Drawing.Point(487, 12);
            this.TurnCoordinatorBack.Name = "TurnCoordinatorBack";
            this.TurnCoordinatorBack.Size = new System.Drawing.Size(400, 400);
            this.TurnCoordinatorBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TurnCoordinatorBack.TabIndex = 3;
            this.TurnCoordinatorBack.TabStop = false;
            // 
            // HeadingIndicatorOverlay
            // 
            this.HeadingIndicatorOverlay.BackColor = System.Drawing.Color.Transparent;
            this.HeadingIndicatorOverlay.Image = global::FlightSimCapstone.Properties.Resources.HeadingIndicator1_Airplane;
            this.HeadingIndicatorOverlay.Location = new System.Drawing.Point(12, 12);
            this.HeadingIndicatorOverlay.Name = "HeadingIndicatorOverlay";
            this.HeadingIndicatorOverlay.Size = new System.Drawing.Size(400, 400);
            this.HeadingIndicatorOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HeadingIndicatorOverlay.TabIndex = 2;
            this.HeadingIndicatorOverlay.TabStop = false;
            // 
            // HeadingIndicatorBack
            // 
            this.HeadingIndicatorBack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HeadingIndicatorBack.Image = global::FlightSimCapstone.Properties.Resources.HeadingIndicator1;
            this.HeadingIndicatorBack.Location = new System.Drawing.Point(12, 12);
            this.HeadingIndicatorBack.Name = "HeadingIndicatorBack";
            this.HeadingIndicatorBack.Size = new System.Drawing.Size(400, 400);
            this.HeadingIndicatorBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HeadingIndicatorBack.TabIndex = 0;
            this.HeadingIndicatorBack.TabStop = false;
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(12, 548);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(139, 50);
            this.RotateButton.TabIndex = 1;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // Graphicalnterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1116, 622);
            this.Controls.Add(this.TurnCoordinatorAirplane);
            this.Controls.Add(this.TurnCoordinatorBack);
            this.Controls.Add(this.HeadingIndicatorOverlay);
            this.Controls.Add(this.HeadingIndicatorBack);
            this.Controls.Add(this.RotateButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Graphicalnterface";
            this.Text = "Graphical Interface";
            ((System.ComponentModel.ISupportInitialize)(this.TurnCoordinatorAirplane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnCoordinatorBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingIndicatorOverlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingIndicatorBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox HeadingIndicatorBack;
        private System.Windows.Forms.PictureBox HeadingIndicatorOverlay;
        private System.Windows.Forms.PictureBox TurnCoordinatorAirplane;
        private System.Windows.Forms.PictureBox TurnCoordinatorBack;
        private System.Windows.Forms.Button RotateButton;
    }
}