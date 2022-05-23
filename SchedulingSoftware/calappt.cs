using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class calappt : UserControl
    {
        public calappt()
        {
            InitializeComponent();
        }

        public void appointmentloader(string start, string end, string title, string name)
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
