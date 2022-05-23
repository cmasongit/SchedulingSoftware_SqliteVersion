using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class calmonth : UserControl
    {
        public calmonth()
        {
            InitializeComponent();
            appointmentSQLloader();
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void calmonth_Load(object sender, EventArgs e)
        {

        }

        public void numdays(int a, DateTime date)
        {

            daylb.Text  = a.ToString()+"";
            
            int counter = 0;
         



            for (int i = 0; i < startdate.Count; i++)
            {
               

                DateTime tempdate = DateTime.Parse(startdate[i].ToString());

                
                if (tempdate.ToShortDateString() == date.ToShortDateString())
                {

                    counter++;
                    calappt apt = new calappt();
                   
                    DateTime start = DateTime.Parse(startdate[i]);
                    DateTime end = DateTime.Parse(enddate[i]);
                    start = start.ToLocalTime();
                    end = end.ToLocalTime();

                    apt.appointmentloader(start.ToString("t"), end.ToString("t"), apptitle[i], customname[i]);
                    //calapptpanel.Controls.Add(apt);
                    flowLayoutPanel1.Controls.Add(apt);

                    if(counter > 1)
                    {
                        daylb.Font = new Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold); 
                        daylb.ForeColor = Color.Red;
                    }

                    
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
            //Load customer list


            sqlitecon slc = new sqlitecon();

            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand apsql = conn.CreateCommand();



          



            apsql.CommandText = "SELECT customer.customerName, title, description, start, end FROM appointment INNER JOIN customer ON customer.ID = Appointment.customerID; ";
          
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




    }
}
