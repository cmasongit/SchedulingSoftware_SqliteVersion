using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class schedulemain : Form
    {
        Mainpage smtemp = new Mainpage();

        public schedulemain(Mainpage sm)
        {
            smtemp = sm;
          
            InitializeComponent();
            SQLloader();

            timezonechange();
            SetCurrentUser(smtemp.currentuser);
           SetCurrentuserid2(smtemp.GetCurrentuserid());

            //  MessageBox.Show(smtemp.usernametb.Text);
          //  MessageBox.Show(smtemp.GetCurrentuserid().ToString());
            smCustomerSQl();
            // appointmentimeadjust();



            //Updates to User's Local time
           

            timer1.Start();


            timebox();
            appointmentalert();

        }

        public void appointmentalert()
        {
           
            DateTime start;

            DateTime now = DateTime.Now;
            TimeZoneInfo ccurrent = TimeZoneInfo.Local;
            TimeZoneInfo utct = TimeZoneInfo.Utc;

            //now = new DateTime(2019, 1,2,16,45,0); //works
            //now = TimeZoneInfo.ConvertTimeToUtc(now);
           // now = TimeZoneInfo.ConvertTimeFromUtc(now,ccurrent );
            DateTime tempy = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second); //Converts year to 2019
            now = tempy;
            //Test
       
            String currentuser2;
            for (int i = 0; i < appointmentview.Rows.Count - 1; i++)
            {
                start = DateTime.Parse(appointmentview.Rows[i].Cells[9].Value.ToString());
                //start = start.ToLocalTime();
                currentuser2 = appointmentview.Rows[i].Cells[12].Value.ToString();



               // MessageBox.Show(now.ToShortTimeString() + " " + start.ToShortTimeString());
                if (currentuser2 == GetCurrentUser())
                {
                   

                    if (now.Date == start.Date)
                    {
                     
                        if (now.Hour == start.Hour)
                        {
                            if (now.Minute <= start.Minute)
                            {
                                if (start.Minute <= now.AddMinutes(15).Minute)
                                {

                                    MessageBox.Show("You Have an appointment in 15 or less minutes");

                                    if (start.Minute == now.Minute)
                                    {
                                        MessageBox.Show("You Have an Appointment starting now");
                                    }


                                }
                              
                            }
                        }
                        else if (now.Hour != start.Hour)
                        {

                            //  MessageBox.Show(start.Hour.ToString() +" " +now.Hour.ToString());
                            if (now.AddHours(1).Hour == start.Hour)
                            {


                                if (now <= start)
                                {
                                    if (start <= now.AddMinutes(15))
                                    {


                                        // MessageBox.Show(start.Minute.ToString() + " " + now.Minute.ToString());
                                        MessageBox.Show("You Have an appointment in 15 or less minutes");

                                       if(start.Minute == now.Minute)
                                        {
                                            MessageBox.Show("You Have an Appointment starting now");
                                        }



                                    }
                                   






                                }
                            }
                        }
                    }
                }
               


            }

        }






        public void timebox()
        {


            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime current = DateTime.Now;
            DateTime current2 = current.ToLocalTime();
            string timezonename = localZone.DisplayName.ToString();
            //  MessageBox.Show(localZone.IsDaylightSavingTime(current).ToString());
            label1.Text = timezonename;
           // label2.Text = current.ToString();
            label3.Text = GetCurrentUser();
            
            //MessageBox.Show(localZone.StandardName.ToString());

        }








        private int currentuserid2;
        public void SetCurrentuserid2(int a) { this.currentuserid2 = a; }
        public int GetCurrentuserid2() { return currentuserid2; }


        public void SQLloader()
        {
           

            sqlitecon slc = new sqlitecon();

            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();



            string selectc = "SELECT * FROM appointment";
           
            cmd.CommandText= selectc;

            SqliteDataReader ra = cmd.ExecuteReader();
           // MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable temp = new DataTable();


            for (int i = 0; i < ra.FieldCount; i++)
            {
                temp.Columns.Add(new DataColumn(ra.GetName(i)));

            }

            while (ra.Read())
            {
                DataRow dataRow = temp.NewRow();
                for (int i = 0; i < ra.FieldCount; i++)
                {

                    dataRow[temp.Columns[i]] = ra.GetValue(i);




                }
                temp.Rows.Add(dataRow);

            }



            conn.Close();





            BindingSource bs = new BindingSource();
            bs.DataSource = temp;
            appointmentview.DataSource = bs;

       
            string customv = "Select * FROM customer";
            conn.Open();

            SqliteCommand cmd1 = conn.CreateCommand();




            cmd1.CommandText = customv;
     


            DataTable customtable = new DataTable();


            SqliteDataReader ra1 = cmd1.ExecuteReader();





            for (int i = 0; i < ra1.FieldCount; i++) {
                customtable.Columns.Add(new DataColumn(ra1.GetName(i)));

            }

            while (ra1.Read())
            {
                DataRow dataRow = customtable.NewRow();
                for (int i = 0; i < ra1.FieldCount; i++) {
                   
                    dataRow[customtable.Columns[i]] = ra1.GetValue(i);



                    
                }
                customtable.Rows.Add(dataRow);

            }

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = customtable;
            customerview.DataSource = bs2;
            

          //  timezonechange();


            
        }

        public void timezonechange()
        {
            DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);




            TimeZoneInfo local = TimeZoneInfo.Local;
            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo tz2 = TimeZoneInfo.Utc;



            time2 = TimeZoneInfo.ConvertTimeToUtc(time2, tz2);
            // time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);
          //  MessageBox.Show(time2.ToString());
            DateTime closing = time2.AddHours(7);
            int b =DateTime.Now.Hour - DateTime.UtcNow.Hour;
           // MessageBox.Show( b.ToString());
           // MessageBox.Show(TimeZoneInfo.Local.ToString() +" "+tz2.ToString());


            if (!(b==0))
            {



                for (int i = 0; i < appointmentview.Rows.Count - 1; i++)
                {
                    DateTime temp = DateTime.Parse(appointmentview.Rows[i].Cells[9].Value.ToString());
                    DateTime temp2 = DateTime.Parse(appointmentview.Rows[i].Cells[10].Value.ToString());






                    temp = TimeZoneInfo.ConvertTimeFromUtc(temp, tz);
                    temp2 = TimeZoneInfo.ConvertTimeFromUtc(temp2, tz);

                    appointmentview.Rows[i].Cells[9].Value = temp;
                    appointmentview.Rows[i].Cells[10].Value = temp2;





                    // temp = TimeZoneInfo.ConvertTime(temp, tz2);
                    // temp2 = TimeZoneInfo.ConvertTime(temp2, tz2);

                    // MessageBox.Show(temp3.AddHours(diff).ToUniversalTime().ToString());
                    // MessageBox.Show(temp4.AddHours(diff).ToUniversalTime().ToString());






                    // appointmentview.Rows[i].Cells[9].Value = temp.ToUniversalTime();
                    // appointmentview.Rows[i].Cells[9].Value = temp.ToLocalTime();
                    // appointmentview.Rows[i].Cells[9].Value = TimeZoneInfo.ConvertTimeFromUtc(temp, tz2);


                    // appointmentview.Rows[i].Cells[10].Value = temp2.ToUniversalTime();
                    //  appointmentview.Rows[i].Cells[10].Value = TimeZoneInfo.ConvertTimeFromUtc(temp2, tz2);
                    //  appointmentview.Rows[i].Cells[10].Value = temp2.ToLocalTime();


                }



            }else if(b == 0)
            {

                for (int i = 0; i < appointmentview.Rows.Count - 1; i++)
                {
                    DateTime temp = DateTime.Parse(appointmentview.Rows[i].Cells[9].Value.ToString());
                    DateTime temp2 = DateTime.Parse(appointmentview.Rows[i].Cells[10].Value.ToString());






                 //   temp = TimeZoneInfo.ConvertTimeFromUtc(temp, tz).AddHours(a);
                 //  temp2 = TimeZoneInfo.ConvertTimeFromUtc(temp2, tz).AddHours(a);

                    appointmentview.Rows[i].Cells[9].Value = temp;
                    appointmentview.Rows[i].Cells[10].Value = temp2;




                }






            }












            //  appointmentreload();


            /*
       
           
           
          */






            /************************/

            /*
            string sqlrun = "SERVER=127.0.0.1;DATABASE=client_schedule;UID=sqlUser;PASSWORD=Passw0rd!;";
            MySqlConnection mySqlrun = new MySqlConnection(sqlrun);
            mySqlrun.Open();

            MySqlCommand cmdrun = new MySqlCommand();
            cmdrun.Connection = mySqlrun;
            cmdrun.CommandType = CommandType.Text;
            cmdrun.CommandText = "UPDATE appointment SET start = @start1, end = @end1, lastUpdate = NOW(), lastUpdateBy = @currentuser1 WHERE appointmentID = @currentappoinmentid;";
            //VALUES(@custid, @userid, @titlew, @description,@location, @contact, @type,@url @start, @end, NOW(), @currentuser, NOW(), @currentuser
            //UPDATE appointment SET customerID = @custid, userID = @user1, title = @title1, description = @description1, location = @location1, contact = contact1, type = @type1, url = @url1, start = @start1, end = @end1, lastUpdate = NOW(), lastUpdateBy = @currentuser1 WHERE appointmentID = @currentappoinmentid;

          //  int currentapid = (int)appointmentview.CurrentRow.Cells[0].Value;

            cmdrun.Parameters.AddWithValue("@start1", start1    );
            cmdrun.Parameters.AddWithValue("@end1", end1 );
            cmdrun.Parameters.AddWithValue("@currentuser1", smtemp.usernametb.Text);
            cmdrun.Parameters.AddWithValue("@currentappoinmentid", appid);
            cmdrun.ExecuteNonQuery();
            mySqlrun.Close();
            appointmentreload();
            */

        }
        

        List<int> apptnum = new List<int>();
        List<DateTime> appdate = new List<DateTime>();
        List<DateTime> appdate2 = new List<DateTime>();
        public void appointmentimeadjust()
        {
            sqlitecon slc = new sqlitecon();

            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand apsql = conn.CreateCommand();



            string selectc = "SELECT * FROM appointment";

            apsql.CommandText = selectc;

            SqliteDataReader ra = apsql.ExecuteReader();

            //Country Command
           
           
            apsql.CommandText = "SELECT appointmentID, start,end FROM appointment;";
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            
          
            while (ra.Read())
            {
                apptnum.Add(int.Parse(ra[0].ToString()));
                // appdate.Add(DateTime.Parse(apreader[1].ToString()));
                appdate.Add(TimeZoneInfo.ConvertTime(DateTime.Parse(ra[1].ToString()), localZone));
                appdate2.Add(TimeZoneInfo.ConvertTime(DateTime.Parse(ra[2].ToString()), localZone));
              //  appdate2.Add(DateTime.Parse(apreader[2].ToString()));
            }

            conn.Close();

           
          
           // TimeZoneInfo.ConvertTime(DateTime.Parse(apreader[1].ToString()), localZone).ToString();



        }



        public void appointmentreload()
        {


            sqlitecon slc = new sqlitecon();

            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();






            string selectc = "SELECT * FROM appointment";
         
            cmd.CommandText = selectc;
            SqliteDataReader ra = cmd.ExecuteReader();
            DataTable temp = new DataTable();

            for (int i = 0; i < ra.FieldCount; i++)
            {
                temp.Columns.Add(new DataColumn(ra.GetName(i)));

            }

            while (ra.Read())
            {
                DataRow dataRow = temp.NewRow();
                for (int i = 0; i < ra.FieldCount; i++)
                {

                    dataRow[temp.Columns[i]] = ra.GetValue(i);




                }
                temp.Rows.Add(dataRow);

            }


            BindingSource bs = new BindingSource();
            bs.DataSource = temp;
            appointmentview.DataSource = bs;
conn.Close();





        }






        private void Add_Click(object sender, EventArgs e)
        {
            //CREATE NEW FORM
            AddAppointment ad = new AddAppointment(this);
            ad.Show();
        }

        private void updateapbtn_Click(object sender, EventArgs e)
        {
            //CREATE A NEW FORM
            UpdateAppointment ua = new UpdateAppointment(this);
            ua.Show();

        }

        private string currentuser;
        public void SetCurrentUser(string a) { this.currentuser = a; }
        public string GetCurrentUser() { return currentuser; }


       




        private void addcustombtn_Click(object sender, EventArgs e)
        {
            
            AddCustomer ac = new AddCustomer(this);
           
         
            ac.Show();
        }



       public void updatecustdata()
        {
            Mainpage test = new Mainpage();
            schedulemain test2 = new schedulemain(test);
            UpdateCustomer uc = new UpdateCustomer(test2);



            uc.setcurrentcustad((int)customerview.CurrentRow.Cells[2].Value);
            uc.setcurrentcustnm(customerview.CurrentRow.Cells[1].Value.ToString());
            uc.setcurrentcustomid((int)customerview.CurrentRow.Cells[0].Value);
            uc.Show();
        }



        public void updatecustbtn_Click(object sender, EventArgs e)
        {
            Mainpage test = new Mainpage();
            schedulemain test2 = new schedulemain(test);
            UpdateCustomer uc = new UpdateCustomer(this);

            uc.SetUCcurrentuser(GetCurrentUser());

            uc.setcurrentcustad(int.Parse((string)customerview.CurrentRow.Cells[2].Value));
            uc.setcurrentcustnm(customerview.CurrentRow.Cells[1].Value.ToString());
            uc.setcurrentcustomid(int.Parse((string)customerview.CurrentRow.Cells[0].Value));
            uc.Show();
            //  MessageBox.Show(getcurrentcustomid().ToString());

            //  MessageBox.Show(customerview.CurrentRow.Cells[0].Value.ToString() +" " +customerview.CurrentRow.Cells[1].Value.ToString()+" "+ customerview.CurrentRow.Cells[2].Value.ToString());
        }

      

        private void viewcalendar_Click(object sender, EventArgs e)
        {
            Calendarview calendarview = new Calendarview();
            calendarview.Show();

          



        }

        List<int> customerid = new List<int>();
        List<string> customername = new List<string>();

        private void smCustomerSQl()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd2 = conn.CreateCommand();



         
            

            
            cmd2.CommandText = "SELECT * FROM customer;";

            SqliteDataReader SqlReader = cmd2.ExecuteReader();

            while (SqlReader.Read())
            {
                customerid.Add(int.Parse(SqlReader[0].ToString()));
                customername.Add(SqlReader[1].ToString());
                // addressid.Add(int.Parse(SqlReader[2].ToString()));

            }


            conn.Close();

        }



        private void removecustbtn_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer(this);
           // UpdateCustomer uc = new UpdateCustomer(this);
            
           // MessageBox.Show("CUSTOMER ID:  "+customerview.CurrentRow.Cells[0].Value.ToString() +" " + customerid.Count);
            //USE currentcell + 1 to match up with customer's id
             int a = int.Parse((string)customerview.CurrentRow.Cells[0].Value);
            



           sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdex = conn.CreateCommand();

          
            

            cmdex.CommandText = "DELETE FROM customer WHERE ID = @currentcustomer;";
            cmdex.Parameters.AddWithValue("@currentcustomer", a);
          
           

            cmdex.ExecuteNonQuery();
            conn.Close();
            SQLloader();
            MessageBox.Show("Customer was removed successfully");

            



        }

        private void removeapbtn_Click(object sender, EventArgs e)
        {
            int a = int.Parse((string)appointmentview.CurrentRow.Cells[0].Value);

            

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdex = conn.CreateCommand();




            cmdex.CommandText = "DELETE FROM appointment WHERE ID = @aptid;";
            cmdex.Parameters.AddWithValue("@aptid", a);



            cmdex.ExecuteNonQuery();
            conn.Close();
            SQLloader();
            MessageBox.Show("Appointment was removed successfully");

           


        }

        private void weeklycalbtn_Click(object sender, EventArgs e)
        {
            weeklyCal m = new weeklyCal();
            m.Show();

          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reports reports = new reports();
            reports.Show();
           

        }

        private void schedulemain_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            label2.Text = current.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.Close();
           
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
