namespace SchedulingSoftware
{
    partial class calmonth
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.daylb = new System.Windows.Forms.Label();
            this.calapptpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // daylb
            // 
            this.daylb.AutoSize = true;
            this.daylb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.daylb.Location = new System.Drawing.Point(134, 11);
            this.daylb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.daylb.Name = "daylb";
            this.daylb.Size = new System.Drawing.Size(62, 42);
            this.daylb.TabIndex = 0;
            this.daylb.Text = "00";
            this.daylb.Click += new System.EventHandler(this.label1_Click);
            // 
            // calapptpanel
            // 
            this.calapptpanel.AutoSize = true;
            this.calapptpanel.Location = new System.Drawing.Point(4, 64);
            this.calapptpanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.calapptpanel.Name = "calapptpanel";
            this.calapptpanel.Size = new System.Drawing.Size(0, 0);
            this.calapptpanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(185, 113);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // calmonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.calapptpanel);
            this.Controls.Add(this.daylb);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "calmonth";
            this.Size = new System.Drawing.Size(204, 200);
            this.Load += new System.EventHandler(this.calmonth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label daylb;
        private System.Windows.Forms.FlowLayoutPanel calapptpanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
