using System;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class weeklyCal : Form
    {

        DateTime tempdate { get; set; }
        public weeklyCal()
        {
            InitializeComponent();

            Mainpage mp = new Mainpage();
            schedulemain sm = new schedulemain(mp);

            for(int i = 0; i < sm.appointmentview.Rows.Count-1; i++)
            {

                    DateTime temp = DateTime.Parse(sm.appointmentview.Rows[i].Cells[9].Value.ToString());
               
                    comboBox1.Items.Add(temp.ToShortDateString());
                
            }
            comboBox1.Text = DateTime.Now.ToShortDateString();

            tempdate = DateTime.Parse(comboBox1.Text);
            displayweek(tempdate);
        }

        private void weeklym_Load(object sender, EventArgs e)
        {

        }

        int year,month, day,y;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            byweekpanel.Controls.Clear();
            tempdate = DateTime.Parse((string)comboBox1.SelectedItem);
            displayweek(tempdate);
        }

        int currentindex;
    

        private void prevbtn_Click(object sender, EventArgs e)
        {
            byweekpanel.Controls.Clear();


            //DateTime now = DateTime.Now;
            // DateTime startdate = new DateTime(2021, 12, 18);
            // DateTime startdate = new DateTime(2018, 12, 23);
            // DateTime startdate = DateTime.Now;
            //DateTime startdate = new DateTime(2021, 1, 1);
            DateTime now = tempdate;
             


            DayOfWeek day = DayOfWeek.Sunday;
            int a = day - now.DayOfWeek;

            now = now.AddDays(a);

            DateTime startdate = now.AddDays(-8);

            startdate = startdate.AddDays(y);
            DateTime[] dates = new DateTime[8];
            for (int i = 0; i < 8; i++)
            {
                dates[i] = startdate.AddDays(i);
            }
           

            int days = DateTime.DaysInMonth(now.Year, now.Month);


            int DaysOftheWeek = Convert.ToInt32(startdate.DayOfWeek.ToString("d")) + 1;

            // MessageBox.Show(days.ToString() + " " + DaysOftheWeek.ToString());
            /*
                        for (int i = 1; i <= DaysOftheWeek; i++)
                        {
                            UserControl2 userControl2 = new UserControl2();
                            byweekpanel.Controls.Add(userControl2);


                        }
            */

            for (int i = 1; i < 8; i++)
            {
                weekbar weekbar2 = new weekbar();
                weekbar2.daychanger(int.Parse(dates[i].ToString("dd")),dates[i]);
                byweekpanel.Controls.Add(weekbar2);
                label1.Text = dates[i].ToString("Y");
            }
            // startdate.AddDays(y);
            y = y - 7;

        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
           
            byweekpanel.Controls.Clear();

            
          //  DateTime now = DateTime.Now;
            //
            //
            // DateTime startdate = new DateTime(now.Year, now.Month, 1);
            // DateTime startdate = new DateTime(2022, 1, 2);
           // DateTime startdate = new DateTime(2019, 1, 6);
            // DateTime startdate = DateTime.Now;


            DateTime now = tempdate;

            DayOfWeek day = DayOfWeek.Sunday;
            int a = day - now.DayOfWeek;

             now = now.AddDays(a);
           // MessageBox.Show(now.ToString());





            // DateTime startdate = new DateTime(2021, 12, 25);
            // DateTime startdate = new DateTime(2018, 12, 30);
            DateTime startdate = now.AddDays(7);







            startdate = startdate.AddDays(y);
            DateTime[] dates = new DateTime[8];
            for(int i = 0; i < 8; i++)
            {
                dates[i] = startdate.AddDays(i);
              
            }

            int days = DateTime.DaysInMonth(startdate.Year, startdate.Month);
            for (int i = 0; i < 8; i++)
            {
               // MessageBox.Show(dates[i].ToString("dd") + " " + days.ToString());
                if (dates[i].ToString("dd") == days.ToString())
                {
                    label1.Text = startdate.AddMonths(1).ToString("Y");
                }
               
            }
           // label1.Text = startdate.ToString("Y");



            // MessageBox.Show(days.ToString());


            int DaysOftheWeek = Convert.ToInt32(startdate.DayOfWeek.ToString("d")) + 1;

           // MessageBox.Show(days.ToString() + " " + DaysOftheWeek.ToString());
/*
            for (int i = 1; i <= DaysOftheWeek; i++)
            {
                UserControl2 userControl2 = new UserControl2();
                byweekpanel.Controls.Add(userControl2);


            }
*/

            for (int i = 0; i < 7; i++)
            {
                weekbar weekbar2 = new weekbar();
                weekbar2.daychanger(int.Parse(dates[i].ToString("dd")), dates[i]);
                byweekpanel.Controls.Add(weekbar2);
                label1.Text = dates[i].ToString("Y");

            }
            // startdate.AddDays(y);
            y = y + 7;

        }

        public void displayweek(DateTime x)
        {

            

            DateTime now =  x;
           
            DayOfWeek day = DayOfWeek.Sunday;
            int a = day - now.DayOfWeek;

            // MessageBox.Show(now.Date.ToString() + a.ToString() + now.AddDays(a).ToString());






            // DateTime startdate = new DateTime(2021, 12, 25);
            // DateTime startdate = new DateTime(2018, 12, 30);
            DateTime startdate = now.AddDays(a-1);
            startdate = startdate.AddDays(y);
            DateTime[] dates = new DateTime[8];
            for (int i = 0; i < 8; i++)
            {
                dates[i] = startdate.AddDays(i);
            }
           // label1.Text = startdate.ToString("Y");

            int days = DateTime.DaysInMonth(now.Year, now.Month);


            int DaysOftheWeek = Convert.ToInt32(startdate.DayOfWeek.ToString("d")) + 1;
            

            for (int i = 1; i < 8; i++)
            {
                weekbar weekbar2 = new weekbar();
                weekbar2.daychanger(int.Parse(dates[i].ToString("dd")), dates[i]);
                
               
                byweekpanel.Controls.Add(weekbar2);
                label1.Text = dates[i].ToString("Y");

            }

           






        }
    }
}
