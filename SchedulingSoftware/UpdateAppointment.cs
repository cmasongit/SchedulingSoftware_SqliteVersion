using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class UpdateAppointment : Form
    {
        Mainpage mpp = new Mainpage();
        schedulemain smm;


        public UpdateAppointment(schedulemain temp)
        {
            smm = temp;
            InitializeComponent();
            
            appointmentSQLloader();
            customerSQLloader();
            currentappointment();

            timechanger();

           // datelock();
          

            /*
            DateTime time2 = (DateTime)smm.appointmentview.CurrentRow.Cells[10].Value;
            for (DateTime endtime = time2.AddHours(0); endtime < time2.AddHours(10); endtime = endtime.AddMinutes(15)) 
            {
               
                endtimebox.Items.Add(endtime.ToShortTimeString());
            }
            */

            appointmentSQLcompare();
            DateTime now = DateTime.Now;
            this.monthCalendar1.SelectionStart = new DateTime(now.Year, now.Month, now.Day);
            this.monthCalendar1.TodayDate = new DateTime(now.Year, now.Month, now.Day);
            Datetb.Text = monthCalendar1.SelectionStart.ToShortDateString();

            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo est = TimeZoneInfo.Utc;
            DateTime openhours = new DateTime(2022, 1, 1, 17, 0, 0);
            // openhours = TimeZoneInfo.ConvertTimeToUtc(openhours);
            openhours = TimeZoneInfo.ConvertTimeFromUtc(openhours, tz);
            DateTime closehour = openhours.AddHours(7).AddMinutes(45);

            label4.Text = "BUSINESS HOURS ARE FROM " + openhours.ToLocalTime().ToShortTimeString() + " TO " + closehour.ToLocalTime().ToShortTimeString() + " " + tz.DisplayName;
            // businesstime();

        }

        List<int> customerid = new List<int>();
        List<int> userid = new List<int>();
        List<string> customername = new List<string>();
        List<int> appointmentid = new List<int>();
        List<int> appointcustid = new List<int>();

        public void customerSQLloader()
        {
            //Load customer list
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand customersql = conn.CreateCommand();




            //Country Command

            customersql.CommandText = "SELECT * FROM customer";
        

           SqliteDataReader customerreader = customersql.ExecuteReader();
            while (customerreader.Read())
            {
                customerid.Add(int.Parse(customerreader[0].ToString()));
                customername.Add(customerreader[1].ToString());
            }

            conn.Close();
        }


        public void appointmentSQLloader()
        {
            //Load customer list
        

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand apsql = conn.CreateCommand();








            //Country Command
          
            apsql.CommandText = "SELECT * FROM appointment";
          
          SqliteDataReader apreader = apsql.ExecuteReader();
            while (apreader.Read())
            {
                appointmentid.Add(int.Parse(apreader[0].ToString()));
                appointcustid.Add(int.Parse(apreader[1].ToString()));
            }

            conn.Close();
        }

        //SELECT start, end FROM appointment;

        public void appointmentSQLcompare()
        {
            //Load customer list

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand apsql = conn.CreateCommand();


            apsql.CommandText = "SELECT ID, start FROM appointment;";
          
           SqliteDataReader apreader = apsql.ExecuteReader();
            while (apreader.Read())
            {
                appID.Add(int.Parse(apreader[0].ToString()));
                dateTimes.Add(DateTime.Parse(apreader[1].ToString()));
              
            }

            conn.Close();
        }

        List<DateTime> dateTimes = new List<DateTime>();
        List<int> appID = new List<int>();




        String name;
        String[] names;
        int currentcustomerid;
        int currentappointmentid;

        private string currentcustomer;
        public string Getcurrentcustomer() { return currentcustomer; }
        public void Setcurrentcustomer(string currentcustomer) { this.currentcustomer = currentcustomer; }

       
        
        //Lambda expression - Use to check if customer id is valid.

        private bool customerfinder(int name)
        {
            CancelEventArgs c = new CancelEventArgs();

           



            
            for (int i = 0; i < customerid.Count; i++)
            {
                if (customerid[i]== name)
                {
                    Setcurrentcustomer(customername[i]);
                    return true;
                }
                else if (i == customerid.Count - 1)
                {

                    MessageBox.Show("Customer was not found!");
                    return false;
                   // Setcurrentcustomer(0);

                    c.Cancel = true;

                    // submitbtn.Enabled = false;
                }
            }
            

            return false;

        }

        DateTime tstart;
        DateTime tend;
        string sdate;
        string edate;
        public void currentappointment()
        {
          
           
            currentcustomerid = int.Parse(smm.appointmentview.CurrentRow.Cells[1].Value.ToString());
            textBox1.Text = currentcustomerid.ToString();
            customerfinder(currentcustomerid);
            name = Getcurrentcustomer();
           // customerfinderbyname(name);
          //  MessageBox.Show(name);


           
         
            custFNtb.Text = name;
           

            tstart = DateTime.Parse(smm.appointmentview.CurrentRow.Cells[9].Value.ToString());
           // tend = (string)smm.appointmentview.CurrentRow.Cells[10].Value;
            //MessageBox.Show(tstart.ToString());

            sdate = tstart.ToShortDateString();
            Datetb.Text = sdate;
            starttimebox.Text = tstart.ToShortTimeString();

            tend = DateTime.Parse(smm.appointmentview.CurrentRow.Cells[10].Value.ToString());
            endtimebox.Text = tend.ToShortTimeString();

            
            Contacttb.Text = (string)smm.appointmentview.CurrentRow.Cells[6].Value;
            Locationtb.Text = (string)smm.appointmentview.CurrentRow.Cells[5].Value;
           typebox.Text = (string)smm.appointmentview.CurrentRow.Cells[7].Value;
           titletb.Text =(string)smm.appointmentview.CurrentRow.Cells[3].Value;
           descriptiontb.Text =(string)smm.appointmentview.CurrentRow.Cells[4].Value;
           URLtb.Text = (string)smm.appointmentview.CurrentRow.Cells[8].Value;
           
           

        


        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Datetb.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void starttimebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            endtimebox.Items.Clear();
            DateTime temp = DateTime.Parse(starttimebox.SelectedItem.ToString());
            temp = temp.AddMinutes(15);

            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo tz2 = TimeZoneInfo.Utc;

           
            if (!(tz.Equals(tz2)))
            {

               // temp = TimeZoneInfo.ConvertTimeToUtc(temp,tz2);
               // temp = TimeZoneInfo.ConvertTimeFromUtc(temp, tz);

                DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
                time2 = TimeZoneInfo.ConvertTimeToUtc(time2, tz2);
                time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);

                DateTime closing = time2.AddHours(7);
                int a = ((closing.Hour - temp.Hour));
                int b = time2.Second - closing.Second;
                
                for (DateTime _time = temp.AddHours(0); _time < temp.AddHours(a); _time = _time.AddMinutes(15)) 
                {

                    endtimebox.Items.Add(_time.ToShortTimeString());
                }
                if (a == 0)
                {
                    for (DateTime _time2 = closing.AddMinutes(0); _time2 < closing.AddMinutes(60); _time2 = _time2.AddMinutes(15)) 
                    {
                        endtimebox.Items.Add(_time2.ToShortTimeString());
                    }

                }

            }
            else
            {

                
                    DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
               temp = TimeZoneInfo.ConvertTimeToUtc(temp);
                time2 = TimeZoneInfo.ConvertTimeToUtc(time2);
               // time2 = time2.AddMinutes(15);
                    DateTime closing = time2.AddHours(7);
                    int a = (closing.Hour - temp.Hour);
                    int b = time2.Second - closing.Second;
               // MessageBox.Show(a.ToString());
                for (DateTime _time = temp.AddHours(0); _time < temp.AddHours(7); _time = _time.AddMinutes(15))
                    {

                        endtimebox.Items.Add(_time.ToShortTimeString());
                    }
                   

                
            }





          


        }

        private void endtimebox_SelectedIndexChanged(object sender, EventArgs e)
        {

         



        }

        private int currentcustomeridd;
        public int Getcurrentcustomerid() { return currentcustomeridd; }
        public void Setcurrentcustomerid(int currentcustomeridd) { this.currentcustomeridd = currentcustomeridd; }




        private bool customerfinderbyname(string name)
        {
            CancelEventArgs c = new CancelEventArgs();
           



            


            
            for (int i = 0; i < customername.Count; i++)
            {
                if (customername[i].ToLower() == name.ToLower())
                {
                    Setcurrentcustomerid(customerid[i]);
                    return true;
                }
                else if (i == customername.Count - 1)
                {

                    MessageBox.Show("Customer was not found!");
                    return false;
                  //  Setcurrentcustomer(0);

                    c.Cancel = true;

                    // submitbtn.Enabled = false;
                }
            }
            
            return false;

        }

        string fnmiln;
        string contact;
        string location;
        string type;
        string description;
        string title;
        string url;
        string stimedate;
        string etimedate;


        private void appoinmentcreator(string contact1, string location1, string title1, string description1, string type1, string url1, string start1, string end1)
        {


            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdrun = conn.CreateCommand();




            cmdrun.CommandText = "UPDATE appointment SET customerID = @custid, userID = @userid, title = @title1, description = @description1, location = @location1, contact = @contact1, type = @type1, url = @url1, start = @start1, end = @end1, lastUpdate = @NOW, lastUpdateBy = @currentuser1 WHERE ID = @currentappoinmentid;";
            //VALUES(@custid, @userid, @titlew, @description,@location, @contact, @type,@url @start, @end, NOW(), @currentuser, NOW(), @currentuser
            //UPDATE appointment SET customerID = @custid, userID = @user1, title = @title1, description = @description1, location = @location1, contact = contact1, type = @type1, url = @url1, start = @start1, end = @end1, lastUpdate = NOW(), lastUpdateBy = @currentuser1 WHERE appointmentID = @currentappoinmentid;

            int currentapid = int.Parse(smm.appointmentview.CurrentRow.Cells[0].Value.ToString());

            cmdrun.Parameters.AddWithValue("@custid", Getcurrentcustomerid());
            cmdrun.Parameters.AddWithValue("@userid", smm.GetCurrentuserid2());
            cmdrun.Parameters.AddWithValue("@title1", title1);
            cmdrun.Parameters.AddWithValue("@description1", description1);
            cmdrun.Parameters.AddWithValue("@location1", location1);
            cmdrun.Parameters.AddWithValue("@contact1", contact1);
            cmdrun.Parameters.AddWithValue("@type1", type1);
            cmdrun.Parameters.AddWithValue("@url1", url1);
            cmdrun.Parameters.AddWithValue("@start1", start1);
            cmdrun.Parameters.AddWithValue("@end1", end1);
            cmdrun.Parameters.AddWithValue("@currentuser1", smm.GetCurrentUser());
            cmdrun.Parameters.AddWithValue("@currentappoinmentid", currentapid);
            cmdrun.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
            cmdrun.ExecuteNonQuery();
            conn.Close();

            // smm.timezonechange();
           
            MessageBox.Show("Update Successful");



        }

        string endtime;
        string starttime;

        public void timechanger()
        {
            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo tz2 = TimeZoneInfo.Utc;

            if (!(tz.Equals(tz2)))
            {
                DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
                time2 = TimeZoneInfo.ConvertTimeToUtc(time2, tz2);
                time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);
                //  DateTime time = (DateTime)smm.appointmentview.CurrentRow.Cells[9].Value;
                // time = TimeZoneInfo.ConvertTimeToUtc(time,tz2);
                //  time = TimeZoneInfo.ConvertTimeFromUtc(time,tz);
                DateTime temp = DateTime.Parse(starttimebox.Text.ToString());
                temp = temp.AddMinutes(15);

                DateTime closing2 = time2.AddHours(7);
                int a2 = ((closing2.Hour - time2.Hour));


                for (DateTime sttime = time2.AddHours(0); sttime < time2.AddHours(a2); sttime = sttime.AddMinutes(15))
                {
                    starttimebox.Items.Add(sttime.ToShortTimeString());

                }

                // DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);


                DateTime closing = time2.AddHours(7);
                int a = ((closing.Hour - temp.Hour));
                int b = time2.Second - closing.Second;

                for (DateTime _time = temp.AddHours(0); _time < temp.AddHours(a); _time = _time.AddMinutes(15))
                {

                    endtimebox.Items.Add(_time.ToShortTimeString());
                }
                if (a == 0)
                {
                    for (DateTime _time2 = closing.AddMinutes(0); _time2 < closing.AddMinutes(60); _time2 = _time2.AddMinutes(15))
                    {
                        endtimebox.Items.Add(_time2.ToShortTimeString());
                    }

                }



            }
            else
            {

                
                    DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
                    time2 = TimeZoneInfo.ConvertTimeToUtc(time2, tz2);

                    DateTime temp = DateTime.Parse(starttimebox.Text.ToString());
                    temp = temp.AddMinutes(15);

                  

                    for (DateTime sttime = time2.AddHours(0); sttime < time2.AddHours(7); sttime = sttime.AddMinutes(15))
                    {
                        starttimebox.Items.Add(sttime.ToShortTimeString());

                    }

                
            }


        }

        DateTime[] listeddates;
        public bool datelock(DateTime x, DateTime y)
        {
           // listeddates = new DateTime[smm.appointmentview.Rows.Count - 1];
           CancelEventArgs e = new CancelEventArgs();
            Boolean ds = false;
            DateTime Startlog;
            DateTime Endlog;
            DateTime currentstartdate = DateTime.Parse(smm.appointmentview.CurrentRow.Cells[9].Value.ToString());
            DateTime currentenddate = DateTime.Parse(smm.appointmentview.CurrentRow.Cells[10].Value.ToString());
            int counter = 1;
            TimeSpan timediff;
            TimeSpan timediff2;
        
 
            for (int i = 0; i < smm.appointmentview.Rows.Count -1; i++)
            {
               //  MessageBox.Show(i.ToString());

                Startlog = DateTime.Parse(smm.appointmentview.Rows[i].Cells[9].Value.ToString());
                Endlog = DateTime.Parse(smm.appointmentview.Rows[i].Cells[10].Value.ToString());
                timediff =  y.Subtract(x);
                timediff2 = Startlog.Subtract(x);
                int m = x.Minute - Startlog.Minute;
                int p = int.Parse(timediff2.TotalMinutes.ToString());
               
                
               
               

                if (smm.appointmentview.Rows[i] != smm.appointmentview.CurrentRow)
                {
                    if (x.Day == Startlog.Day)
                    {
                       // MessageBox.Show(p.ToString());
                        if (x == Startlog && y == Endlog)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found at" + " " + counter);
                            ds = true;
                        }
                        else if(x < Startlog && Startlog < y)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found at" + " " + counter);
                            ds = true;



                        }else if (Startlog < x && x < Endlog)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found w/Start at" + " " + counter);
                            ds = true;
                        }
                        else if (Startlog == x && y < Endlog)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found w/Start at" + " " + counter);
                            ds = true;
                        }
                        else if (Endlog < x && y < Endlog)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found w/Start at" + " " + counter);
                            ds = true;
                        }

                    }
                }

               


            }
            return ds;
        }


        
        Action<string> errormessage = messg =>
        {
            string error1 = $" ERROR: Out of operating hours time selection: Business open at {messg }!";
            MessageBox.Show(error1);
        };

        Action<string> errormessage2 = messg =>
        {
            string error1 = $" ERROR: Out of operating hours time selection: Business Closes at {messg }!";
            MessageBox.Show(error1);
        };







        private void submitbtn_Click(object sender, EventArgs e)
        {

            CancelEventArgs r = new CancelEventArgs();
            
            fnmiln = custFNtb.Text;
            contact = Contacttb.Text;
            location = Locationtb.Text;
            type = typebox.SelectedItem.ToString();
            description = descriptiontb.Text;
            title = titletb.Text;
            url = URLtb.Text;
            stimedate = Datetb.Text + " " + starttimebox.Text;
            etimedate = Datetb.Text + " " + endtimebox.Text;

            DateTime dt1;
            DateTime dt2;
           
            
            dt1 = DateTime.Parse(stimedate);
            dt2 = DateTime.Parse(etimedate);
            int ct = DateTime.Now.Hour - DateTime.UtcNow.Hour;



            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo tz2 = TimeZoneInfo.Utc;

            DateTime now = DateTime.Now;
            DateTime time2 = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);
           // time2 = TimeZoneInfo.ConvertTimeToUtc(time2);
            time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);
            //MessageBox.Show(time2.ToString() +" "+dt1.ToString());
            DateTime closing = time2.AddHours(7);
            
            
            if (dt1.Equals(dt2))
            {
                r.Cancel = true;
                MessageBox.Show("ERROR: The Selected Times are the same");
            }
            else if (dt2 < dt1)
            {
                r.Cancel = true;
                MessageBox.Show("ERROR: Please adjust End Time");
            }else if(dt1.Hour < time2.Hour )
            {
                r.Cancel = true;
                // MessageBox.Show("ERROR: Start Time out of operating hours");
                errormessage(time2.ToLocalTime().ToShortTimeString());

            }
            else if(dt2 > closing && dt2 < time2)
            {
                r.Cancel = true;
                // MessageBox.Show("ERROR: End Time out of operating hours");
                errormessage2(closing.ToLocalTime().ToShortTimeString());
            }
            else
            {

                if (datelock(dt1,dt2) == true)
                {
                    r.Cancel = true;
                  // MessageBox.Show("true");
                }
                else
                {




                    starttime = dt1.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
                    endtime = dt2.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
                    if (customerfinderbyname(fnmiln) == true)
                    {
                        // MessageBox.Show(starttime + " " + endtime + " " + mp.GetCurrentUser() + " " + mp.GetCurrentuserid2() + " " + Getcurrentcustomer());
                        appoinmentcreator(contact, location, title, description, type, url, starttime, endtime);


                        smm.appointmentreload();
                          smm.timezonechange();
                       
                        this.Close();

                    }
                    else
                    {
                        // MessageBox.Show("CUSTOMER WAS NOT FOUND");
                        r.Cancel = true;
                    }
                    int currentapid = int.Parse(smm.appointmentview.CurrentRow.Cells[0].Value.ToString())+ 1;

                    /*
                    MessageBox.Show(currentapid.ToString());
                    for(int i = 0; i < appID.Count; i++)
                    {

                        if(dt1.ToString("g") != dateTimes[i].ToString("g"))
                        {
                            MessageBox.Show("NOT A MATCH" +  currentapid+ dt1.ToString() + dateTimes[i].ToString());


                        }
                        else
                        {
                            MessageBox.Show("ITS A MATCH" + currentapid + dt1.ToString() + dateTimes[i].ToString());



                        }









                    }


                    */


                }
            }
        }

        private void startampm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void typebox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
