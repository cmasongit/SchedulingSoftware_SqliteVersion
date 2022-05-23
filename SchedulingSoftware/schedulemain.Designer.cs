
namespace SchedulingSoftware
{
    partial class schedulemain
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
            this.components = new System.ComponentModel.Container();
            this.appointmentview = new System.Windows.Forms.DataGridView();
            this.customerview = new System.Windows.Forms.DataGridView();
            this.Appointmenttab = new System.Windows.Forms.Label();
            this.Customerlabel = new System.Windows.Forms.Label();
            this.viewcalendarbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addcustombtn = new System.Windows.Forms.Button();
            this.removecustbtn = new System.Windows.Forms.Button();
            this.updatecustbtn = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Schedulerlabel = new System.Windows.Forms.Label();
            this.removeapbtn = new System.Windows.Forms.Button();
            this.updateapbtn = new System.Windows.Forms.Button();
            this.weeklycalbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appointmentview
            // 
            this.appointmentview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentview.Location = new System.Drawing.Point(86, 108);
            this.appointmentview.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.appointmentview.Name = "appointmentview";
            this.appointmentview.RowHeadersWidth = 82;
            this.appointmentview.RowTemplate.Height = 41;
            this.appointmentview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentview.Size = new System.Drawing.Size(1054, 208);
            this.appointmentview.TabIndex = 0;
            // 
            // customerview
            // 
            this.customerview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerview.Location = new System.Drawing.Point(503, 413);
            this.customerview.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customerview.Name = "customerview";
            this.customerview.RowHeadersWidth = 82;
            this.customerview.RowTemplate.Height = 41;
            this.customerview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerview.Size = new System.Drawing.Size(636, 246);
            this.customerview.TabIndex = 1;
            // 
            // Appointmenttab
            // 
            this.Appointmenttab.AutoSize = true;
            this.Appointmenttab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Appointmenttab.Location = new System.Drawing.Point(534, 76);
            this.Appointmenttab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Appointmenttab.Name = "Appointmenttab";
            this.Appointmenttab.Size = new System.Drawing.Size(110, 20);
            this.Appointmenttab.TabIndex = 2;
            this.Appointmenttab.Text = "Appointments";
            // 
            // Customerlabel
            // 
            this.Customerlabel.AutoSize = true;
            this.Customerlabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Customerlabel.Location = new System.Drawing.Point(788, 391);
            this.Customerlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Customerlabel.Name = "Customerlabel";
            this.Customerlabel.Size = new System.Drawing.Size(84, 20);
            this.Customerlabel.TabIndex = 3;
            this.Customerlabel.Text = "Customers";
            // 
            // viewcalendarbtn
            // 
            this.viewcalendarbtn.Location = new System.Drawing.Point(89, 494);
            this.viewcalendarbtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.viewcalendarbtn.Name = "viewcalendarbtn";
            this.viewcalendarbtn.Size = new System.Drawing.Size(158, 72);
            this.viewcalendarbtn.TabIndex = 4;
            this.viewcalendarbtn.Text = "View Monthly Calendar";
            this.viewcalendarbtn.UseVisualStyleBackColor = true;
            this.viewcalendarbtn.Click += new System.EventHandler(this.viewcalendar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(89, 587);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(324, 72);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reports";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addcustombtn
            // 
            this.addcustombtn.Location = new System.Drawing.Point(503, 672);
            this.addcustombtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.addcustombtn.Name = "addcustombtn";
            this.addcustombtn.Size = new System.Drawing.Size(196, 40);
            this.addcustombtn.TabIndex = 7;
            this.addcustombtn.Text = "Add";
            this.addcustombtn.UseVisualStyleBackColor = true;
            this.addcustombtn.Click += new System.EventHandler(this.addcustombtn_Click);
            // 
            // removecustbtn
            // 
            this.removecustbtn.Location = new System.Drawing.Point(727, 671);
            this.removecustbtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.removecustbtn.Name = "removecustbtn";
            this.removecustbtn.Size = new System.Drawing.Size(196, 40);
            this.removecustbtn.TabIndex = 8;
            this.removecustbtn.Text = "Remove";
            this.removecustbtn.UseVisualStyleBackColor = true;
            this.removecustbtn.Click += new System.EventHandler(this.removecustbtn_Click);
            // 
            // updatecustbtn
            // 
            this.updatecustbtn.Location = new System.Drawing.Point(942, 672);
            this.updatecustbtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.updatecustbtn.Name = "updatecustbtn";
            this.updatecustbtn.Size = new System.Drawing.Size(196, 39);
            this.updatecustbtn.TabIndex = 9;
            this.updatecustbtn.Text = "Update";
            this.updatecustbtn.UseVisualStyleBackColor = true;
            this.updatecustbtn.Click += new System.EventHandler(this.updatecustbtn_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(324, 320);
            this.Add.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(166, 40);
            this.Add.TabIndex = 10;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Schedulerlabel
            // 
            this.Schedulerlabel.AutoSize = true;
            this.Schedulerlabel.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Schedulerlabel.Location = new System.Drawing.Point(76, 41);
            this.Schedulerlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Schedulerlabel.Name = "Schedulerlabel";
            this.Schedulerlabel.Size = new System.Drawing.Size(177, 46);
            this.Schedulerlabel.TabIndex = 13;
            this.Schedulerlabel.Text = "Scheduler";
            // 
            // removeapbtn
            // 
            this.removeapbtn.Location = new System.Drawing.Point(534, 320);
            this.removeapbtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.removeapbtn.Name = "removeapbtn";
            this.removeapbtn.Size = new System.Drawing.Size(166, 40);
            this.removeapbtn.TabIndex = 14;
            this.removeapbtn.Text = "Remove";
            this.removeapbtn.UseVisualStyleBackColor = true;
            this.removeapbtn.Click += new System.EventHandler(this.removeapbtn_Click);
            // 
            // updateapbtn
            // 
            this.updateapbtn.Location = new System.Drawing.Point(727, 320);
            this.updateapbtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.updateapbtn.Name = "updateapbtn";
            this.updateapbtn.Size = new System.Drawing.Size(166, 40);
            this.updateapbtn.TabIndex = 15;
            this.updateapbtn.Text = "Update";
            this.updateapbtn.UseVisualStyleBackColor = true;
            this.updateapbtn.Click += new System.EventHandler(this.updateapbtn_Click);
            // 
            // weeklycalbtn
            // 
            this.weeklycalbtn.Location = new System.Drawing.Point(255, 494);
            this.weeklycalbtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.weeklycalbtn.Name = "weeklycalbtn";
            this.weeklycalbtn.Size = new System.Drawing.Size(158, 72);
            this.weeklycalbtn.TabIndex = 16;
            this.weeklycalbtn.Text = "View Weekly Calendar";
            this.weeklycalbtn.UseVisualStyleBackColor = true;
            this.weeklycalbtn.Click += new System.EventHandler(this.weeklycalbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(87, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(988, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(607, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(508, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Current User:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1246, 41);
            this.panel1.TabIndex = 21;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1124, 734);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(86, 448);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 38);
            this.label5.TabIndex = 23;
            this.label5.Text = "Note: In Monthly Calendar, if date is shown in bold red, \r\nits has multiple appoi" +
    "ntments on that date.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // schedulemain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1245, 791);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.weeklycalbtn);
            this.Controls.Add(this.updateapbtn);
            this.Controls.Add(this.removeapbtn);
            this.Controls.Add(this.Schedulerlabel);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.updatecustbtn);
            this.Controls.Add(this.removecustbtn);
            this.Controls.Add(this.addcustombtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.viewcalendarbtn);
            this.Controls.Add(this.Customerlabel);
            this.Controls.Add(this.Appointmenttab);
            this.Controls.Add(this.customerview);
            this.Controls.Add(this.appointmentview);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "schedulemain";
            this.Text = "schedulemain";
            this.Load += new System.EventHandler(this.schedulemain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Appointmenttab;
        private System.Windows.Forms.Label Customerlabel;
        private System.Windows.Forms.Button viewcalendarbtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button addcustombtn;
        private System.Windows.Forms.Button removecustbtn;
        private System.Windows.Forms.Button updatecustbtn;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label Schedulerlabel;
        private System.Windows.Forms.Button removeapbtn;
        private System.Windows.Forms.Button updateapbtn;
        public System.Windows.Forms.DataGridView customerview;
        public System.Windows.Forms.DataGridView appointmentview;
        private System.Windows.Forms.Button weeklycalbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}