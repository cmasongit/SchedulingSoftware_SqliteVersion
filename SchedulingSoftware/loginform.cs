using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.IO;
using Microsoft.Data.Sqlite;

namespace SchedulingSoftware
//CURRENT TASK: TRANSLATE LOGIN INTO SPANISH 12/19/2021
//TASK 2: CREATE A CLASS FOR CURRENT USER, CUSTOMER, APPOINTMENT

{
    public partial class Mainpage : Form
    {
       


        public Mainpage()
        {


            /*
            DateTime test = DateTime.Now;
            DateTime test2 = new DateTime(2022,1,26,22,40,0);
            DateTime test3 = test2.AddMinutes(+15);
            MessageBox.Show(test3.ToString()+" "+test2.ToString());
            if (test2.AddMinutes(+15).Equals(test3))
            {
                MessageBox.Show("This works");
            }
      */
            //NOTES FOR 15 MINUTE NOTIFICATION CODING
            /* if DateTime.Now .Addminutes(+15) equals any appointment time
             * mESSAGEBOX.SHOW(APPOINTMENT IN 15 MINUTES FOR USER
             * 
             * APPOINTMENT SQL WITH APPOINTMENT ID, START TIME AND USER
             * IF USER = CURRENT USER
             * RUN SQL START TIME LOG TO COMPARE
             */
            CultureInfo culture2 = Thread.CurrentThread.CurrentCulture;
           // MessageBox.Show(culture2.DisplayName);

            if (culture2.DisplayName.Contains("Spanish"))
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                setComboint(1);
                //  InitializeComponent();
            }


           


            InitializeComponent();

           loginSQL();

            usernametb.Text = "Test";
            passwordtb.Text = "Test";

            //  usernametb.Text = "user2";
            //  passwordtb.Text = "2Test";
        
            //  SQLloader(); //USE TO LOAD MYSQL DATA INTO DATAGRIDVIEW
            timer2.Start();
            timebox();


          





        }
      
      
    










    //The following code below display the current time and time zone.
    public void timebox()
        {

            
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime current = DateTime.Now;
            DateTime current2 = current.ToLocalTime();
            string timezonename = localZone.DisplayName.ToString();
         //  MessageBox.Show(localZone.IsDaylightSavingTime(current).ToString());
            label2.Text = timezonename;
           // label3.Text = current2.ToString();
            //MessageBox.Show(localZone.StandardName.ToString());

        }


       





        private void loader(object sender, EventArgs e)
        {


        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Language";
            
            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    
                    setComboint(0);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                    
                    setComboint(1);
                    break;



            }
            this.Controls.Clear();
            
            InitializeComponent();

           



            otherlang(getComboint());
        }

        //The following code enables the current date and local time zone to be shown with both language settings.
        public void otherlang(int a)
        {
            if(a == 1)
            {
               
                timebox();
              
            }
            else if(a == 0)
            {
                
                timebox();
               
            }

        }










        //HOW TO IMPORT DATA FROM MYSQL TABLES

        /*
        private void SQLloader()
        {
            string attacher = "SERVER=localhost;DATABASE=newschema;UID=root;PASSWORD=admin12345;";
            MySqlConnection mySql = new MySqlConnection(attacher);
            mySql.Open();

           
            string selectc = "SELECT * FROM country";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = mySql;
            cmd.CommandText= selectc;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable temp = new DataTable();
            da.Fill(temp);

            BindingSource bs = new BindingSource();
            bs.DataSource = temp;
            dataGridView1.DataSource = bs;
            
        }

      */
        public List<int> userid = new List<int>();
        public List<string> usernamelog = new List<string>();
        public List<string> passwordlog = new List<string>();

        public void clearlist()
        {
            userid.Clear();
            usernamelog.Clear();
            passwordlog.Clear();
        }



        //The following code loads USER table from a SQL Database.
        public void loginSQL()
        {
            clearlist();
            
            string logger = "SELECT ID, userName, Password FROM user;";
           

          
          sqlitecon slc = new sqlitecon();

         SqliteConnection conn = slc.connection;
            slc.createTables(conn);
           // slc.insertuser(conn);
            conn.Open();

          //  MySqlCommand cmd = new MySqlCommand();
          SqliteCommand cmd = conn.CreateCommand();
           
         //   cmd.Connection = mySql;
            cmd.CommandText = logger;
           
            SqliteDataReader  ra = cmd.ExecuteReader();
          
            while(ra.Read())
            {
                userid.Add(int.Parse(ra[0].ToString()));
                usernamelog.Add(ra[1].ToString());
                passwordlog.Add(ra[2].ToString());


            }


      
            conn.Close();

        }

        private int comboint;
        public int getComboint() { return comboint; }
        public void setComboint(int a) { comboint = a;  }

        private int currentuserid;
        public void SetCurrentuserid(int a) { this.currentuserid = a; }
        public int GetCurrentuserid() { return currentuserid; }

        public string currentuser { get; set; }



        //The following code uses the table loaded from the SQL Database and compares the table to the data inputted in the textboxes.
        public void logincheck(string a , string b)
        {
            CancelEventArgs cancel = new CancelEventArgs();

         
            int max = usernamelog.Count;



            //  MessageBox.Show(getComboint().ToString()); //USE FOR SPANISH TRANSLATION
            //TRANSLATE INTO SPANISH

            if (getComboint() == 1)
            {

                for (int i = 0; i < usernamelog.Count; i++)
                {
                    if (usernamelog[i] == a && passwordlog[i] == b)
                    {
                        SetCurrentuserid(userid[i]);

                        MessageBox.Show("Iniciar sesión con éxito");
                        var path = "logindata.txt";
                        DateTime now = DateTime.Now;
                        string text = now + " " + "User" + " " + a + " Iniciar sesión con éxito";
                        //File.WriteAllText(path, text);
                        File.AppendAllText(path, text + Environment.NewLine);

                        schedulemain sm = new schedulemain(this);
                        sm.Show();


                        break;

                    }

                    // MessageBox.Show(i.ToString());
                    if (usernamelog[i] == a && passwordlog[i] != b)
                    {

                        MessageBox.Show("La contraseña es incorrecta. Intentar otra vez");
                        break;

                        //  i++;
                    }
                   


                    else if (i == usernamelog.Count - 1)
                    {
                        MessageBox.Show("Usuario no encontrado. Intentar otra vez");
                        errormessagelabel.Text = "El nombre de usuario y la contraseña son sensibles a Caplock.";

                        // break;

                    }
                }
            }

            else
            {


                for (int i = 0; i < usernamelog.Count; i++)
                {



                    if (usernamelog[i] == a && passwordlog[i] == b)
                    {
                        SetCurrentuserid(userid[i]);
                        currentuser = a;
                        MessageBox.Show("User" + " " + a + " login successfully");

                        // SetCurrentUser(smtemp.usernametb.Text);
                        //  SetCurrentuserid2(smtemp.GetCurrentuserid());


                        var path = "logindata.txt";
                        DateTime now = DateTime.Now;
                        string text = now + " " + "User" + " " + a + " login successfully";
                        //File.WriteAllText(path, text);
                        File.AppendAllText(path, text + Environment.NewLine);

                        schedulemain sm = new schedulemain(this);

                   

                        sm.Show();


                        break;

                    }

                    // MessageBox.Show(i.ToString());
                    if (usernamelog[i] == a && passwordlog[i] != b)
                    {

                        MessageBox.Show("Password is Incorrect. Try Again");
                        var path = "logindata.txt";
                        DateTime now = DateTime.Now;
                        string text = now + " " + "User" + " " + a + " Login Failed";
                        //File.WriteAllText(path, text);
                        File.AppendAllText(path, text + Environment.NewLine);
                        break;

                        //  i++;
                    }
                  


                    else if (i == usernamelog.Count - 1)
                    {
                        MessageBox.Show("User not Found. Try Again");
                        errormessagelabel.Text = "UserName and Password are Caplock sensitive.";

                        // break;

                    }





                }


               


            }

        
        }

      






        private void mpsubmit_Click(object sender, EventArgs e)
        {
            clearlist();
            
            loginSQL();
            
            logincheck(usernametb.Text, passwordtb.Text);

        }

        private void Mainpage_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            label3.Text = current.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (comboBox2.SelectedIndex)
            {

                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
               
                    setComboint(0);
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
               
                    setComboint(1);
                    break;



            }
            this.Controls.Clear();

            InitializeComponent();





            otherlang(getComboint());















        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            CreateUser a = new CreateUser();
            a.Show();
        }
    }
}
