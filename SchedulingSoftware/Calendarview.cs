using System;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class Calendarview : Form
    {
        int month, year, currentmonth, currentyear;


        public Calendarview()
        {
            InitializeComponent();
           


            DateTime dateTime = new DateTime(2019,1,1);
            DateTime dateTime1 = DateTime.Now;
            int a = dateTime1.Year - dateTime.Year;
            a = Math.Abs(a);

            comboBox1.Text = "Select Month";
            comboBox2.Text = "Select Year";
            for(int i = 0; i < 12; i++)
            {
                comboBox1.Items.Add(dateTime.AddMonths(i).ToString("MMMM"));
            }
            for(int i = -1;i < a + 1; i++)
                
            {
                comboBox2.Items.Add(dateTime.AddYears(i).ToString("yyyy"));
            }
            displaycal(dateTime1.Month, dateTime1.Year);

        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {

            daycontainer.Controls.Clear();



            year = 2019;
            /*
            if (month != 12)
            {
                month++;
            }
            else
            {
                month = 1;
                year++;
            }
            */
            if (month != 12)
            {
                
                month++;
               // year++;
            }
            else if(month == 12)
            {

                month = 1;
                currentyear++;
               
            }

            //month++;

            //MessageBox.Show(year.ToString());

            DateTime startdate = new DateTime(currentyear, month, 1);
            label8.Text = startdate.ToString("Y");

            


            int days = DateTime.DaysInMonth(year, month);
            int DaysOftheWeek = Convert.ToInt32(startdate.DayOfWeek.ToString("d")) + 1;
            DateTime[] daysinmonth = new DateTime[days];

            for (int i = 1; i < DaysOftheWeek; i++)
            {

                UserControl1 ublank = new UserControl1();
                daycontainer.Controls.Add(ublank);
            }

            for (int i = 0; i < days; i++)
            {
                daysinmonth[i] = startdate.AddDays(i);
                //MessageBox.Show(daysinmonth[i].ToString());
                calmonth calmonth = new calmonth();
                calmonth.numdays(i + 1, daysinmonth[i]);
                daycontainer.Controls.Add(calmonth);
            }

          


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            currentmonth = comboBox1.SelectedIndex+ 1;
            displaycal(currentmonth, currentyear);
        }

        private void prevbtn_Click(object sender, EventArgs e)
        {

            daycontainer.Controls.Clear();





            // year = DateTime.Now.Year;

            // month = month - 1;
            // year = year -1 ;

            if (month == 1)
            {
                currentyear--;
                month = 12;
            }
            else
            {

                month--;
            }
          


            DateTime startdate = new DateTime(currentyear, month, 1);
            label8.Text = startdate.ToString("Y");

            int days = DateTime.DaysInMonth(year, month);
            int DaysOftheWeek = Convert.ToInt32(startdate.DayOfWeek.ToString("d")) + 1;
            DateTime[] daysinmonth = new DateTime[days];

            for (int i = 1; i < DaysOftheWeek; i++)
            {

                UserControl1 ublank = new UserControl1();
                daycontainer.Controls.Add(ublank);
            }

            for (int i = 0; i < days; i++)
            {
                daysinmonth[i] = startdate.AddDays(i);
               // MessageBox.Show(daysinmonth[i].ToString());
                calmonth calmonth = new calmonth();
                calmonth.numdays(i+1,daysinmonth[i]);
                daycontainer.Controls.Add(calmonth);
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            currentyear = int.Parse(comboBox2.Text);
            displaycal(currentmonth, currentyear);
        }

        public void displaycal(int m, int y)
        {
            daycontainer.Controls.Clear();
            //DateTime now = DateTime.Now;
            //DateTime now = new DateTime(2019, 1, 1);



            //DateTime now = new DateTime(currentyear, currentmonth,1);
            currentmonth = m;
            currentyear = y;
            month = currentmonth;
            year = currentyear;


            DateTime startdate = new DateTime(year, month, 1);
            label8.Text = startdate.ToString("Y");
      

            int days = DateTime.DaysInMonth(year, month);
            int DaysOftheWeek = Convert.ToInt32(startdate.DayOfWeek.ToString("d")) +1;
            DateTime[] daysinmonth = new DateTime[days];

            for (int i = 1; i < DaysOftheWeek; i++)
            {
                
                UserControl1 ublank = new UserControl1();
                daycontainer.Controls.Add(ublank);

            }

            for (int i = 0; i < days; i++)
            {
                /*
                DateTime tempdate = new DateTime(year, month, i);
                calmonth calmonth = new calmonth();
                calmonth.numdays(i,tempdate);
               daycontainer.Controls.Add(calmonth);
                */

                daysinmonth[i] = startdate.AddDays(i);
                // MessageBox.Show(daysinmonth[i].ToString());
                calmonth calmonth = new calmonth();
                calmonth.numdays(i + 1, daysinmonth[i]);
                daycontainer.Controls.Add(calmonth);
               

            }





        }










    }
}
