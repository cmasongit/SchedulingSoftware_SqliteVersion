using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    /* 
     * Lambda Expressions is in "customerfinder"
     * 
     * 
     * 
     */
    public partial class AddAppointment : Form
    {
        Mainpage sp = new Mainpage();
        schedulemain mp;
        public AddAppointment(schedulemain ks)
        {
            mp = ks;
            InitializeComponent();
            SQLload();
           
           
            //  endtb.Text = monthCalendar1.SelectionEnd.ToShortDateString();

            string[] datenim = starttb.Text.Split('/');

            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo est = TimeZoneInfo.Utc;
            DateTime openhours = new DateTime(2022, 1, 1, 17, 0, 0);
           // openhours = TimeZoneInfo.ConvertTimeToUtc(openhours);
            openhours = TimeZoneInfo.ConvertTimeFromUtc(openhours, tz);
            DateTime closehour = openhours.AddHours(7).AddMinutes(45);
            

            if (!(tz.Equals(est)))
            {
               
                DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);

                time2 = TimeZoneInfo.ConvertTimeToUtc(time2, est);
                time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);

                DateTime closing = time2.AddHours(7);
            //   closing = TimeZoneInfo.ConvertTime(closing, est);
              //  closing = TimeZoneInfo.ConvertTime(closing, tz);
                int a = ((closing.Hour - time2.Hour));
                int b = time2.Second - closing.Second;


                // MessageBox.Show(a.ToString());


                for (DateTime _time = time2.AddHours(0); _time < time2.AddHours(a); _time = _time.AddMinutes(15)) //from 16h to 18h hours
                {
                    comboBox1.Items.Add(_time.ToShortTimeString());
                    // comboBox2.Items.Add(_time.ToShortTimeString());
                }

            }
            else
            {
                

                    DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
               // MessageBox.Show(time2.ToString());
                time2 = TimeZoneInfo.ConvertTimeToUtc(time2);
               // MessageBox.Show(time2.ToString());

                    for (DateTime _time = time2.AddHours(0); _time < time2.AddHours(7); _time = _time.AddMinutes(15)) //from 16h to 18h hours
                    {
                        comboBox1.Items.Add(_time.ToShortTimeString());
                        // comboBox2.Items.Add(_time.ToShortTimeString());
                    }
                
            }

            DateTime now = DateTime.Now;
           this.monthCalendar1.SelectionStart = new DateTime(now.Year, now.Month, now.Day);
            this.monthCalendar1.TodayDate = new DateTime(now.Year, now.Month, now.Day);
            starttb.Text = monthCalendar1.SelectionStart.ToShortDateString();

            comboBox1.Text = "START TIME";
            comboBox2.Text = "END TIME";
            label11.Text = "BUSINESS HOURS ARE FROM " + openhours.ToLocalTime().ToShortTimeString() + " TO " + closehour.ToLocalTime().ToShortTimeString()+ " "+ tz.DisplayName;
           // businesstime();
            submitbtn.Enabled = false;
        }


        public void businesstime()
        {
            /*Eastern Business hours 12PM-7PM
             * PACIFIC 9AM-5PM
             * CENTRAL 11AM-6PM
            */



            TimeZoneInfo tz = TimeZoneInfo.Local;
            DateTime time = new DateTime(2022, 1, 1, 12, 0, 0);
            DateTime[] dateTimes = new DateTime[8];
            //MessageBox.Show(time.AddHours(8).ToString("t"));

            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            for (int i = 0; i < dateTimes.Length; i++)
            {
                dateTimes[i] = time.AddHours(i);
              //  MessageBox.Show(TimeZoneInfo.ConvertTime(dateTimes[i], tz) + " "+TimeZoneInfo.ConvertTime(dateTimes[i],cst)+ " " + TimeZoneInfo.ConvertTime(dateTimes[i], pst));
            }

            if(tz.Equals(est) == true)
            {
                // MessageBox.Show("TRUE");
               // DateTime time = DateTime.Today;
                DateTime time2 = time.AddHours(7);


            



            }
            else
            {
               // MessageBox.Show("FALSE");






            }


        }













        private void AddAppointment_Load(object sender, EventArgs e)
        {
         

        }

        List<string> Customername = new List<string>();
        List<int> CustomerIDap = new List<int>();
        List<int> appointmentnum = new List<int>();


        private void SQLload()
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
                CustomerIDap.Add(int.Parse(customerreader[0].ToString()));
                Customername.Add(customerreader[1].ToString());
            }

            conn.Close();

            for(int i = 0; i < CustomerIDap.Count; i++)
            {
                comboBox3.Items.Add(Customername[i].ToString());
            }


        }

        private int currentcustomer;
        public int Getcurrentcustomer() { return currentcustomer; }
        public void Setcurrentcustomer(int currentcustomer) { this.currentcustomer = currentcustomer; }


        //TWO LAMBDA EXPRESSIONS BELOW
        //Used to find entry customer's id if customer is registered. If not, code will return an error messagebox and will cancel.
        private bool customerfinder(string name)
        {
            CancelEventArgs c = new CancelEventArgs();


            string customername = Customername.Find(x => x == name); //USED TO CHECK IF CUSTOMER NAME IS VALID IN THE SQL
            int ctx = Customername.FindIndex(0, Customername.Count, x => x == name); // USED TO LOCATE TO INDEX OF CUSTOMER NAME IN THE SQL TABLES



            //MessageBox.Show(customername + ctx);

            if(!(ctx == -1) && customername != string.Empty)
            {
                Setcurrentcustomer(CustomerIDap[ctx]);
                return true;
            }
            else
            {
                MessageBox.Show("Customer was not found!");
                return false;
                Setcurrentcustomer(0);

                c.Cancel = true;
            }
            /*
            for(int i = 0; i < Customername.Count; i++)
            {
                if (Customername[i].ToLower() == name.ToLower())
                {
                    Setcurrentcustomer(CustomerIDap[i]);
                   return true;
                }
                else if(i == Customername.Count - 1)
                {
                    
                    MessageBox.Show("Customer was not found!");
                    return false;
                    Setcurrentcustomer(0);
                    
                    c.Cancel = true;

                   // submitbtn.Enabled = false;
                }
            }
            */
            return false;

        }

      






  

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            starttb.Text = monthCalendar1.SelectionStart.ToShortDateString();
            // endtb.Text = monthCalendar1.SelectionEnd.ToShortDateString();

           
            // endtb.Text = comboBox1.Text;
            /*
            string[] datenim = starttb.Text.Split('/');

            foreach (string d in datenim)
            {
                MessageBox.Show(d);
            }
            */

        }

        private void currentuserfinder()
        {

        }






        private void label1_Click(object sender, EventArgs e)
        {

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

        private void appoinmentcreator(string contact1,string location1, string title1, string description1, string type1, string url1,string start1, string end1)
        {


            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdrun = conn.CreateCommand();






            //Country Command

          
            cmdrun.CommandText = "INSERT INTO appointment(customerID,userID,title,description,location,contact,type,url,start,end,createDate,createdBy,lastUpdate, lastUpdateBy) VALUES(@custid, @userid, @titlew, @description,@location, @contact, @type,@url, @start, @end, @NOW, @currentuser, @NOW, @currentuser );";
            //VALUES(@custid, @userid, @titlew, @description,@location, @contact, @type,@url @start, @end, NOW(), @currentuser, NOW(), @currentuser




             cmdrun.Parameters.AddWithValue("@custid", Getcurrentcustomer());
            cmdrun.Parameters.AddWithValue("@userid", mp.GetCurrentuserid2());
             cmdrun.Parameters.AddWithValue("@titlew", title1);
             cmdrun.Parameters.AddWithValue("@description", description1);
             cmdrun.Parameters.AddWithValue("@location", location1);
             cmdrun.Parameters.AddWithValue("@contact", contact1);
             cmdrun.Parameters.AddWithValue("@type", type1);
             cmdrun.Parameters.AddWithValue("@url", url1);
             cmdrun.Parameters.AddWithValue("@start", start1);
            cmdrun.Parameters.AddWithValue("@end", end1);
             cmdrun.Parameters.AddWithValue("@currentuser", mp.GetCurrentUser());
            cmdrun.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
            cmdrun.ExecuteNonQuery();
            conn.Close();


            mp.appointmentreload();
         
            mp.timezonechange();


            // 







        }

        string endtime;
        string starttime;


        List<DateTime> starttimelog = new List<DateTime>();
        List<DateTime> endtimelog = new List<DateTime>();

        public void timecomparer(DateTime start, DateTime end)
        {
            //Load customer list

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand customersql = conn.CreateCommand();




            customersql.CommandText = "SELECT start, end FROM appointment";
       
           SqliteDataReader customerreader = customersql.ExecuteReader();
            while (customerreader.Read())
            {
                starttimelog.Add(DateTime.Parse(customerreader[0].ToString()));
                endtimelog.Add(DateTime.Parse(customerreader[1].ToString()));
            }

            conn.Close();


            for(int i = 0; i < starttimelog.Count; i++)
            {
               //MessageBox.Show(start.ToString() + " " + end.ToString());

                if (start == starttimelog[i] && end == endtimelog[i])
                {
                   // MessageBox.Show("THERE IS A MATCH");
                    break;

                }
                else
                {
                   // MessageBox.Show("There is no match");
                    
                }
            }


        }







        public void time2compare()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand customersql = conn.CreateCommand();




            customersql.CommandText = "SELECT start, end FROM appointment";

            SqliteDataReader customerreader = customersql.ExecuteReader();
           
            while (customerreader.Read())
            {
                starttimelog.Add(DateTime.Parse(customerreader[0].ToString()));
                endtimelog.Add(DateTime.Parse(customerreader[1].ToString()));
            }

            conn.Close();

            

        }

        public bool time(DateTime start, DateTime end)
        {
            time2compare();
            bool tf = false;

            for (int i = 0; i < starttimelog.Count; i++)
            {
                //MessageBox.Show(start.ToString() + " " + end.ToString());

                if (start == starttimelog[i] && end == endtimelog[i])
                {
                    // MessageBox.Show("THERE IS A MATCH");
                    tf = true;

                }
             


            }

            return tf;


        }



        public bool datelock(DateTime x, DateTime y)
        {
            if (mp.appointmentview.Rows.Count < 1)
            {
                // listeddates = new DateTime[smm.appointmentview.Rows.Count - 1];
                CancelEventArgs e = new CancelEventArgs();
                Boolean ds = false;
                DateTime Startlog;
                DateTime Endlog;
                DateTime currentstartdate = DateTime.Parse(mp.appointmentview.CurrentRow.Cells[9].Value.ToString());
                DateTime currentenddate = DateTime.Parse(mp.appointmentview.CurrentRow.Cells[10].Value.ToString());
                int counter = 1;


                for (int i = 0; i < mp.appointmentview.Rows.Count - 1; i++)
                {
                    //  MessageBox.Show(i.ToString());

                    Startlog = DateTime.Parse(mp.appointmentview.Rows[i].Cells[9].Value.ToString());
                    Endlog = DateTime.Parse(mp.appointmentview.Rows[i].Cells[10].Value.ToString());






                    if (x.Day == Startlog.Day)
                    {
                        // MessageBox.Show(p.ToString());
                        if (x == Startlog && y == Endlog)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found at " + counter);
                            ds = true;
                        }
                        else if (x < Startlog && Startlog < y)
                        {
                            counter++;
                            MessageBox.Show("Time Conflict found at" + " " + counter);
                            ds = true;



                        }
                        else if (Startlog < x && x < Endlog)
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
                return ds;
            }
            else
            {
                return false;
            }
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






        //The Lambda expression below converts the current start and end times into string version of mySQL Date format
        public delegate String Reformater(DateTime datey);


        private void submitbtn_Click(object sender, EventArgs e)
        {
            CancelEventArgs r = new CancelEventArgs();

           if (contacttb.Text == string.Empty || locationtb.Text == string.Empty || descriptiontb.Text == string.Empty )
            {
                MessageBox.Show("ERROR: Fields are Uncompleted"); 
                r.Cancel = true;
            
            }
            else
            {






                fnmiln = comboBox3.SelectedItem.ToString();
                contact = contacttb.Text;
                location = locationtb.Text;
                type = Typebox.SelectedItem.ToString();
                description = descriptiontb.Text;
                title = titletb.Text;
                
                stimedate = starttb.Text + " " + comboBox1.Text;
                etimedate = starttb.Text + " " + comboBox2.Text;

                DateTime dt1;
                DateTime dt2;
                dt1 = DateTime.Parse(stimedate);
                dt2 = DateTime.Parse(etimedate);


                DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
                
                //time2 = TimeZoneInfo.ConvertTimeToUtc(time2);
                time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, TimeZoneInfo.Local);
                // MessageBox.Show(time2.ToString());
                DateTime closing = time2.AddHours(7);
               closing = closing.AddMinutes(45);
           

               // MessageBox.Show(dt2.ToShortTimeString() + closing.ToShortTimeString());
                if (dt2 < dt1)
                {
                    r.Cancel = true;
                    MessageBox.Show("The Selected End time is earlier than the start time");
                }
                else if (dt2.Equals(dt1))
                {
                    r.Cancel = true;
                    MessageBox.Show("The selected times are the same. Please adjust");
                }

            else if (dt1.Hour < time2.Hour)
            {
                r.Cancel = true;
                // MessageBox.Show("ERROR: Start Time out of operating hours");
                errormessage(time2.ToLocalTime().ToShortTimeString());

            }
            else if (dt2 > closing && dt2 < time2)
            {
                r.Cancel = true;
                // MessageBox.Show("ERROR: End Time out of operating hours");
                errormessage2(closing.ToLocalTime().ToShortTimeString());
            }
            else
                {

                    if (datelock(dt1, dt2) == true && mp.appointmentview.Rows.Count != 0)
                    {
                        r.Cancel = true;
                    }
                    else
                    {

                        //The Lamdba expression below converts the current start and end times into string version of mySQL Date format
                        Reformater dq = delegate (DateTime p)
                        {
                            return p.ToString("yyyy-MM-dd H:mm:ss");
                            
                        };


                       
                        //starttime = dt1.ToString("yyyy-MM-dd H:mm:ss");
                        starttime = dq(dt1.ToUniversalTime());
                        endtime = dq(dt2.ToUniversalTime());
                      //  endtime = dt2.ToString("yyyy-MM-dd H:mm:ss");









                        if (customerfinder(fnmiln) == true)
                        {
                            if (time(dt1, dt2) == true)
                            {
                                MessageBox.Show("Duplicate dates found: Choose different date");
                                r.Cancel = true;


                            }
                            else
                            {
                                if (urltb.Text == string.Empty)
                                {
                                    url = "N/A";
                                    appoinmentcreator(contact, location, title, description, type, url, starttime, endtime);
                                    
                                   
                                    MessageBox.Show("Appoinment added successfully");
                                    this.Close();
                                }
                                else
                                {
                                    url = urltb.Text;
                                    appoinmentcreator(contact, location, title, description, type, url, starttime, endtime);
                                    //   mp.timezonechange();
                                    MessageBox.Show("Appoinment added successfully");
                                    this.Close();
                                }




                            }


                        }
                    }
                }


            }

              


        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(starttb.Text + " " + comboBox1.Text);

            DateTime dt;
            dt = DateTime.Parse(starttb.Text + " " + comboBox1.Text);
            // MessageBox.Show(dt.ToString("yyyy-MM-dd H:mm:ss"));

            DateTime temp = DateTime.Parse(comboBox1.Text);
            temp = temp.AddMinutes(15);
           // TimeZoneInfo tz = TimeZoneInfo.Local;
           



            /*******************************************/
            TimeZoneInfo tz = TimeZoneInfo.Local;
            TimeZoneInfo est = TimeZoneInfo.Utc;

            if (tz.Equals(est))
            {

                DateTime time = DateTime.Today;
                DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
                
                time2 = TimeZoneInfo.ConvertTimeToUtc(time2, est);
               
                //time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);

                DateTime closing = time2.AddHours(7);

            
                //closing = TimeZoneInfo.ConvertTimeToUtc(closing);
               
                int a = ((closing.Hour - time2.Hour));
                int b = time2.Second - closing.Second;

             
                comboBox2.Items.Clear();
                for (DateTime _time = time2.AddHours(0); _time < time2.AddHours(7); _time = _time.AddMinutes(15)) //from 16h to 18h hours
                {

                    comboBox2.Items.Add(_time.ToShortTimeString());



                }

                if (a == 0)
                {
                    for (DateTime _time2 = closing.AddMinutes(0); _time2 < closing.AddMinutes(60); _time2 = _time2.AddMinutes(15)) //from 16h to 18h hours
                    {
                        comboBox2.Items.Add(_time2.ToShortTimeString());
                    }

                }


                // MessageBox.Show(a.ToString());


            }
            else if (!(tz.Equals(est)))
            {

                DateTime time2 = new DateTime(2022, 1, 1, 17, 0, 0);
            //  MessageBox.Show(  time2.ToUniversalTime().ToString());
                time2 = TimeZoneInfo.ConvertTimeToUtc(time2, est);
                time2 = TimeZoneInfo.ConvertTimeFromUtc(time2, tz);

               // temp = TimeZoneInfo.ConvertTimeToUtc(temp, est);
              //  temp = TimeZoneInfo.ConvertTimeFromUtc(temp, tz);



                DateTime closing = time2.AddHours(7);
               // closing = TimeZoneInfo.ConvertTimeToUtc(closing, est);
              // closing = TimeZoneInfo.ConvertTimeFromUtc(closing, tz);
                int a = ((closing.Hour - temp.Hour));
                int b = time2.Second - closing.Second;


                // MessageBox.Show(a.ToString());
                comboBox2.Items.Clear();
                for (DateTime _time = temp.AddHours(0); _time < temp.AddHours(a); _time = _time.AddMinutes(15)) //from 16h to 18h hours
                {

                    comboBox2.Items.Add(_time.ToShortTimeString());

                }

                if (a == 0)
                {
                    for (DateTime _time2 = closing.AddMinutes(0); _time2 < closing.AddMinutes(60); _time2 = _time2.AddMinutes(15)) //from 16h to 18h hours
                    {
                        comboBox2.Items.Add(_time2.ToShortTimeString());
                    }

                }






            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          CancelEventArgs y = new CancelEventArgs();
            DateTime dt;
            dt = DateTime.Parse(starttb.Text + " " + comboBox2.Text);
            
            DateTime dt2;
            dt2 = DateTime.Parse(starttb.Text + " " + comboBox1.Text);

            timecomparer(dt2, dt);
           // MessageBox.Show(time(dt2, dt).ToString());
            if(time(dt2, dt) == true)
            {
              //  MessageBox.Show(time(dt2,dt).ToString());
                y.Cancel = true;
              
            };
          

            //  MessageBox.Show(dt.ToString("yyyy-MM-dd H:mm:ss"));








        }

        private void Typebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitbtn.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            //fnmiln = fntb.Text + " " + mitb.Text + " " + lntb.Text;
            string name = comboBox3.SelectedItem.ToString();
            textBox1.Text = CustomerIDap[(int)comboBox3.SelectedIndex].ToString();
          
            


        }
    }
}
