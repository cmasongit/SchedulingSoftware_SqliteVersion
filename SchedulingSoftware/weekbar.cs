using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class weekbar : UserControl
    {
        public weekbar()
        {
            InitializeComponent();
            
        }

        private void weekbar_Load(object sender, EventArgs e)
        {

        }

        public void daychanger(int a, DateTime date)
        {
            appointmentSQLloader();

            label1.Text = a.ToString();
           
         
               
            for(int i = 0; i < startdate.Count; i++)
            {
                DateTime tempdate = DateTime.Parse(startdate[i]);
                if (tempdate.ToLongDateString() == date.ToLongDateString())
                {

                 
                    appointbrick apt = new appointbrick();
                     DateTime start = DateTime.Parse(startdate[i]);
                     DateTime end = DateTime.Parse(enddate[i]);
                    start = start.ToLocalTime();
                    end = end.ToLocalTime();

                    apt.appointmentloader(start.ToString("t"), end.ToString("t"), apptitle[i], customname[i]);
                    apptpanel.Controls.Add(apt);


                    // MessageBox.Show("true");
                }
                
                


              //  MessageBox.Show(DateTime.Parse(startdate[i]).ToString());
            }
            

                
                
            

        }

        List<string> customname = new List<string>();
        List<string> apptitle = new List<string>();
        List<string> apptdesc = new List<string>();
        List<string> startdate = new List<string>();
        List<string> enddate = new List<string>();

        public void appointmentSQLloader()
        {

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand apsql = conn.CreateCommand();




            //Country Command
          
            apsql.CommandText = " SELECT customer.customerName, title, description, start, end FROM appointment INNER JOIN customer ON customer.ID = Appointment.customerID;";
            SqliteDataReader apreader = apsql.ExecuteReader();
           
            while (apreader.Read())
            {
                customname.Add(apreader[0].ToString());
                apptitle.Add(apreader[1].ToString());
                apptdesc.Add(apreader[2].ToString());
                startdate.Add(apreader[3].ToString());
                enddate.Add(apreader[4].ToString());

            }

            conn.Close();
        }

        public void apptload(DateTime date, int a)
        {
         

                    appointmentSQLloader();
                    appointbrick apt = new appointbrick();
                   // DateTime start = DateTime.Parse(startdate[i]);
                   // DateTime end = DateTime.Parse(enddate[i]);

                    apt.appointmentloader(date.ToString("G"), date.ToString("t"), apptitle[a], customname[a]);
                    apptpanel.Controls.Add(apt);
                
               
               
            
        }

        private DateTime currentDate;
        public DateTime CurrentDate { get { return currentDate; } set { currentDate = value; } }





    }
}
