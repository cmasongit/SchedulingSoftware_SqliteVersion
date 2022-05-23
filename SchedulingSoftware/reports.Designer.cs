namespace SchedulingSoftware
{
    partial class reports
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
            this.apptbymonth = new System.Windows.Forms.DataGridView();
            this.apptcurrent = new System.Windows.Forms.DataGridView();
            this.countryappt = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.typemonth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.apptbymonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apptcurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryappt)).BeginInit();
            this.SuspendLayout();
            // 
            // apptbymonth
            // 
            this.apptbymonth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.apptbymonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptbymonth.Location = new System.Drawing.Point(65, 131);
            this.apptbymonth.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.apptbymonth.Name = "apptbymonth";
            this.apptbymonth.RowHeadersWidth = 82;
            this.apptbymonth.RowTemplate.Height = 41;
            this.apptbymonth.Size = new System.Drawing.Size(986, 167);
            this.apptbymonth.TabIndex = 0;
            // 
            // apptcurrent
            // 
            this.apptcurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptcurrent.Location = new System.Drawing.Point(65, 361);
            this.apptcurrent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.apptcurrent.Name = "apptcurrent";
            this.apptcurrent.RowHeadersWidth = 82;
            this.apptcurrent.RowTemplate.Height = 41;
            this.apptcurrent.Size = new System.Drawing.Size(986, 169);
            this.apptcurrent.TabIndex = 1;
            // 
            // countryappt
            // 
            this.countryappt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.countryappt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.countryappt.Location = new System.Drawing.Point(65, 593);
            this.countryappt.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.countryappt.Name = "countryappt";
            this.countryappt.RowHeadersWidth = 82;
            this.countryappt.RowTemplate.Height = 41;
            this.countryappt.Size = new System.Drawing.Size(986, 169);
            this.countryappt.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 101);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 28);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(65, 332);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(209, 28);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(65, 565);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(209, 28);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // typemonth
            // 
            this.typemonth.AutoSize = true;
            this.typemonth.Location = new System.Drawing.Point(475, 101);
            this.typemonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typemonth.Name = "typemonth";
            this.typemonth.Size = new System.Drawing.Size(138, 20);
            this.typemonth.TabIndex = 6;
            this.typemonth.Text = "Appointment Types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 335);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Appointments For Current User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 571);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Location by Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(475, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 46);
            this.label1.TabIndex = 9;
            this.label1.Text = "REPORTS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(979, 785);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1116, 824);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typemonth);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.countryappt);
            this.Controls.Add(this.apptcurrent);
            this.Controls.Add(this.apptbymonth);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.apptbymonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apptcurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryappt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView apptbymonth;
        private System.Windows.Forms.DataGridView apptcurrent;
        private System.Windows.Forms.DataGridView countryappt;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label typemonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}