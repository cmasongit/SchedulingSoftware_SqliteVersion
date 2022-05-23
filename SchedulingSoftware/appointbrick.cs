using System;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class appointbrick : UserControl
    {
        public appointbrick()
        {
            InitializeComponent();
        }

        private void appointbrick_Load(object sender, EventArgs e)
        {

        }


        public void appointmentloader(string end, string start, string title, string name)
        {
            //Time
            //end
            label1.Text = start;
            //start time
            label2.Text = end;

            //Title
            label3.Text = title;

            //Name
            label4.Text = name;



        }
   






    }
}
