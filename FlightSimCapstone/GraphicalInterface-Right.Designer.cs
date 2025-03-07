namespace FlightSimCapstone
{
    partial class GraphicalInterface_Right
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicalInterface_Right));
            this.VerticalAirspeedIndicator = new System.Windows.Forms.PictureBox();
            this.VerticalAirspeedIndicatorDial = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAirspeedIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAirspeedIndicatorDial)).BeginInit();
            this.SuspendLayout();
            // 
            // VerticalAirspeedIndicator
            // 
            this.VerticalAirspeedIndicator.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VerticalAirspeedIndicator.Image = global::FlightSimCapstone.Properties.Resources.VerticalAirspeedIndicator;
            this.VerticalAirspeedIndicator.Location = new System.Drawing.Point(34, 25);
            this.VerticalAirspeedIndicator.Name = "VerticalAirspeedIndicator";
            this.VerticalAirspeedIndicator.Size = new System.Drawing.Size(400, 400);
            this.VerticalAirspeedIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VerticalAirspeedIndicator.TabIndex = 4;
            this.VerticalAirspeedIndicator.TabStop = false;
            // 
            // VerticalAirspeedIndicatorDial
            // 
            this.VerticalAirspeedIndicatorDial.BackColor = System.Drawing.Color.Transparent;
            this.VerticalAirspeedIndicatorDial.Image = global::FlightSimCapstone.Properties.Resources.VerticalAirspeedIndicatorDial;
            this.VerticalAirspeedIndicatorDial.Location = new System.Drawing.Point(34, 25);
            this.VerticalAirspeedIndicatorDial.Name = "VerticalAirspeedIndicatorDial";
            this.VerticalAirspeedIndicatorDial.Size = new System.Drawing.Size(400, 400);
            this.VerticalAirspeedIndicatorDial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VerticalAirspeedIndicatorDial.TabIndex = 3;
            this.VerticalAirspeedIndicatorDial.TabStop = false;
            // 
            // GraphicalInterface_Right
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 574);
            this.Controls.Add(this.VerticalAirspeedIndicatorDial);
            this.Controls.Add(this.VerticalAirspeedIndicator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphicalInterface_Right";
            this.Text = "Graphical Interface - Right";
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAirspeedIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAirspeedIndicatorDial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox VerticalAirspeedIndicatorDial;
        private System.Windows.Forms.PictureBox VerticalAirspeedIndicator;
    }
}