using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    /*
     * LAMBDA EXPRESSION 1 is in and  NEAR Button1_click code
     *Other lambda expression can be found in AddAppointment.cs
     * 

    */


    public partial class UpdateCustomer : Form
    {
       public static Mainpage mp2 = new Mainpage();
        schedulemain smpp = new schedulemain(mp2);
        public UpdateCustomer(schedulemain sm5)
        {
        
            smpp = sm5;
          
           



            InitializeComponent();
            ucSQLloader();
            addressSQL();
           // MessageBox.Show("CHECKER: "+  smpp.GetCurrentUser());

            this.Shown += new EventHandler(tempreader);

            // MessageBox.Show(smpp.customerview.Rows[0].Cells[3].Value.ToString());
            int checkboxtool = int.Parse((string)smpp.customerview.CurrentRow.Cells[3].Value);

            if(checkboxtool == 1)
            {
                checkBox1.Checked = true;
             
            }else 
            {
                checkBox2.Checked = true;
               
               
            }







        }

        private string updatecurrentuser;
        public string GetUCcurrentuser() { return updatecurrentuser; }
        public void SetUCcurrentuser(string value) { updatecurrentuser = value; }



        public void tempreader(object sender, EventArgs e)
        {
            // MessageBox.Show((string)sm2.customerview.CurrentRow.Cells[0].Value);
          // MessageBox.Show("THIS UPDATE CUSTOMER: " +getcurrentcustad() + getcurrentcustnm() + getcurrentcustomid());

            addressSQL();
            addresschecker(getcurrentcustad());

            string[] names = getcurrentcustnm().Split(" ");
            upCfntb.Text = getcurrentcustnm();
             smpp.SQLloader();




        }

        string currentfirst;
        string currentsecond;
        string currentthird;


       




        //**********************************************************************//

        private int currentcustomid;
        public int getcurrentcustomid() { return currentcustomid; }
        public void setcurrentcustomid(int a) { currentcustomid = a; }

        private string currentcustnm;

        public string getcurrentcustnm() { return currentcustnm; }

        public void setcurrentcustnm(string a) { currentcustnm = a; }


        private int currentcustad;

        public int getcurrentcustad() { return currentcustad; }

        public void setcurrentcustad(int a) { currentcustad = a; }



        //********************************************************************//


        private void label10_Click(object sender, EventArgs e)
        {

        }

        BindingList<int> customeriduc = new BindingList<int>();
        BindingList<string> customernameuc = new BindingList<string>();
        BindingList<int> addressiduc = new BindingList<int>();


        //INSERT INTO customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('Beth R. Kelly', 1,1,NOW(),'test',Now(),'test');
        private void ucSQLloader()
        {
            //SQLITE

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdcustom = conn.CreateCommand();




            cmdcustom.CommandText = "SELECT * FROM customer;";
        
           SqliteDataReader ucust = cmdcustom.ExecuteReader();
            while (ucust.Read())
            {
                customeriduc.Add(int.Parse(ucust[0].ToString()));
                customernameuc.Add((string)ucust[1]);
                addressiduc.Add(int.Parse(ucust[2].ToString()));

            }

           conn.Close();

        }

      
        /// <summary>
        ///ADDRESS SQL
        /// </summary>
        private int currentaddress;
        public int GetCurrentAddress() { return currentaddress; }
        public void SetCurrentAddress(int address) { currentaddress = address; }

        List<string> addrname = new List<string>();
        List<int> addressid = new List<int>();
        List<int> addcityid = new List<int>();
        List<string> addrname2 = new List<string>();
        List<string> addzip = new List<string>();
        List<string> addphone = new List<string>();



        private void addressSQL()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdaddress = conn.CreateCommand();




            

      

            //Address command
           
            cmdaddress.CommandText = "SELECT ID,  cityid, address, address2, postalCode, phone from address;";
            

            SqliteDataReader addead = cmdaddress.ExecuteReader();
            while (addead.Read())
            {
                addressid.Add(int.Parse(addead[0].ToString())); //ADDRESS ID
                addcityid.Add(int.Parse(addead[1].ToString())); // CITY ID FROM ADDRESS
                addrname.Add((string)addead[2]); // ADDRESS NAME
                addrname2.Add((string)addead[3]);// ADDRESS NAME 2
                addzip.Add((string)addead[4]); // POSTAL CODE
                addphone.Add((string)addead[5]); //PHONE
            }

            conn.Close();
        }

        private bool addresschecker(int a)
        {
          
            for (int i = 0; i < addressid.Count; i++)
            {
                if (addressid[i] == a)
                {
                    // MessageBox.Show("IT'S A MATCH");
                    SetCurrentAddress(addressid[i]);
                    upCphonenumbertb.Text = addphone[i];
                    upCzipTB.Text = addzip[i];
                    SetCurrentcity(addcityid[i]);
                    upCaddtb.Text = addrname[i];
                    upCadd2tb.Text = addrname2[i];

                    citychecker(GetCurrentcity());
                    return true;
                }

                else if(i == addressid.Count)
                {
                    //  SetCurrentAddress(addressid[addressid.Count - 1]);
                    MessageBox.Show("Address not found");
                   // break;
                }
            }
           
            return false;
        }
       //********************************************************************************//

        //BINDINGLIST FOR SQL TABLE DATA

        List<int> customeridc = new List<int>();
        List<string> customernm = new List<string>();
        //*******************************************************//
     
        //******************************************************//
        List<string> countrynm = new List<string>();
        List<int> countryidn = new List<int>();
        //*****************************************************//
        List<string> citynm = new List<string>();
        List<int> cityidn = new List<int>();
        List<int> citycountry = new List<int>();

     

        private void citySQL()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdcity = conn.CreateCommand();







            //City Command
        
            cmdcity.CommandText = "SELECT * FROM city ";
          
            SqliteDataReader cityread = cmdcity.ExecuteReader();
            while (cityread.Read())
            {
                cityidn.Add(int.Parse(cityread[0].ToString()));
                citynm.Add(cityread[1].ToString());
                citycountry.Add(int.Parse(cityread[2].ToString()));
            }
            conn.Close();

        }

        private int currentcity;
        public int GetCurrentcity() { return currentcity; }
        public void SetCurrentcity(int a) { currentcity = a; }


        private bool citychecker(int a)
        {
            citySQL();
            for (int i = 0; i < cityidn.Count; i++)
            {
                if (cityidn[i]== a)
                {
                    // MessageBox.Show("City id: "+cityidn[i].ToString() );
                    upAddCtytb.Text = citynm[i].ToString();
                    SetCurrentcity(cityidn[i]);
                    countrychecker(citycountry[i]);


                    return true;
                }

                else if(i == cityidn.Count)
                {

                    MessageBox.Show("City not found");
                    // MessageBox.Show("city id" + cityidn[cityidn.Count-1].ToString() );
                    //SetCurrentcity(cityidn[cityidn.Count - 1]);
                     break;
                }
            }
            //  
            return false;
        }

        private void countrysql()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdcountry = conn.CreateCommand();







            //Country Command
          
            cmdcountry.CommandText = "SELECT * FROM country";
          
            SqliteDataReader ctryread = cmdcountry.ExecuteReader();
            while (ctryread.Read())
            {
                countryidn.Add(int.Parse(ctryread[0].ToString()));
                countrynm.Add(ctryread[1].ToString());
            }

            conn.Close();

        }

        private int currentcountry;

        
     

        public int GetCurrentcountry() { return currentcountry; }
        public void SetCurrentcountry(int currentcountry) { this.currentcountry = currentcountry; }


        private bool countrychecker(int a)
        {
            countrysql();
            for (int i = 0; i < countryidn.Count; i++)
            {
                //

               


                

                if (countryidn[i] == a)
                {
                    //  MessageBox.Show("country id: " + countryidn[i].ToString());
                    SetCurrentcountry(countryidn[i]);
                    upCcountrytb.Text = countrynm[i].ToString();
                    return true;
                }
               
                else if( i == countryidn.Count)
                {
                    //  MessageBox.Show("Country id "+countryidn[countryidn.Count - 1].ToString());
                    MessageBox.Show("Country not found");
                    
                    // break;
                }
            }
            //  
            return false;
        }
        private bool citycheckername(string a)
        {
            citySQL();
            for (int i = 0; i < citynm.Count; i++)
            {
                if (citynm[i].ToString().ToLower() == a.ToLower())
                {
                    // MessageBox.Show("City id: "+cityidn[i].ToString() );
                    SetCurrentcity(cityidn[i]);
                    return true;
                }

                else
                {
                  
                    break;
                }
            }
            //  MessageBox.Show("City not found");
            return false;
        }


        public void CustomerMod(int addnm, int citynm1, int countrynm1, string countryedit, string cityedit, string phoneedit, string zipedit, string addressedit, string address2edit, string nameedit,int act1)
        {
            CancelEventArgs c = new CancelEventArgs();
            Mainpage tx = new Mainpage();
            schedulemain sm = new schedulemain(tx);


            if (countrychecker(countrynm1) == true)
            {   //connect country id number
                //  MessageBox.Show("COUNTRY FOUND");

                //SELECT country,lastUpdate,lastUpdateBy FROM COUNTRY WHERE countryID = 4;

                sqlitecon slc = new sqlitecon();
                SqliteConnection conn = slc.connection;
                conn.Open();
                SqliteCommand cmdex4 = conn.CreateCommand();






                


                cmdex4.CommandType = CommandType.Text;
                cmdex4.CommandText = "UPDATE country SET country = @newcountry WHERE ID = @countrynum;";
                cmdex4.Parameters.AddWithValue("@countrynum", countrynm1);
                cmdex4.Parameters.AddWithValue("@newcountry", countryedit); //edit
               cmdex4.Parameters.AddWithValue("@currentusera", GetUCcurrentuser());


                cmdex4.ExecuteNonQuery();
                conn.Close();


                // countrysql();

                






                if (citychecker(citynm1) == true)
                {

                    // MessageBox.Show(citynm1.ToString());

                    // citySQL();
                    // citycheckername(cityedit);



                    //connect with city id number, ADD address

                    //INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES();
                  
                    conn.Open();
                    SqliteCommand cmdex = conn.CreateCommand();



                    cmdex.CommandText = "UPDATE city SET city = @newcity, lastUpdate = @NOW, lastUpdateby = @currentusera WHERE ID = @citynum AND countyID = @countrynum;";
                    cmdex.Parameters.AddWithValue("@newcity",cityedit);
                  cmdex.Parameters.AddWithValue("@citynum", citynm1);
                  cmdex.Parameters.AddWithValue("@countrynum",countrynm1);
                   cmdex.Parameters.AddWithValue("@currentusera", GetUCcurrentuser());
                    cmdex.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
                    cmdex.ExecuteNonQuery();
                    conn.Close();

                    if (addresschecker(addnm) == true)
                    {
                       
                        conn.Open();
                        SqliteCommand cmdex6 = conn.CreateCommand();





                      
                        cmdex6.CommandType = CommandType.Text;
                        cmdex6.CommandText = "UPDATE address SET address = @newaddress, address2 = @newaddress2, PostalCode = @newpostcode, phone = @newphone, lastUpdate = @NOW, lastUpdateby = @currentusera WHERE ID = @currentadd AND cityid= @currentcityad;";
                        
                        cmdex6.Parameters.AddWithValue("@newaddress", addressedit);
                        cmdex6.Parameters.AddWithValue("@newaddress2", address2edit);
                        cmdex6.Parameters.AddWithValue("@newpostcode", zipedit);
                        cmdex6.Parameters.AddWithValue("@newphone", phoneedit);
                        cmdex6.Parameters.AddWithValue("@currentusera", GetUCcurrentuser());
                        cmdex6.Parameters.AddWithValue("@currentadd", GetCurrentAddress());
                        cmdex6.Parameters.AddWithValue("@currentcityad", citynm1);
                        cmdex6.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
                        cmdex6.ExecuteNonQuery();
                        conn.Close();


                        //INSERT INTO customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES();


                        //ADD CUSTOMER
                     
                        conn.Open();
                        SqliteCommand cmdex2 = conn.CreateCommand();





                       
                        cmdex2.CommandText = "UPDATE CUSTOMER SET customerName = @newname, active = @act, lastupdate = @NOW, lastUpdateBy = @currentusera WHERE ID = @custid;";
                        cmdex2.Parameters.AddWithValue("@newname", nameedit);
                        cmdex2.Parameters.AddWithValue("@currentusera", GetUCcurrentuser());
                        cmdex2.Parameters.AddWithValue("@custid", getcurrentcustomid());
                        cmdex2.Parameters.AddWithValue("@act", act1);
                        cmdex2.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
                        cmdex2.ExecuteNonQuery();
                        conn.Close();

                        smpp.SQLloader();
                        
                         MessageBox.Show("Update Successful");
                        this.Close();

                    }



                }
                else
                {
                    c.Cancel = true;
                    button1.Enabled = false;

                }

            }
            else
            {



                c.Cancel = true;
                button1.Enabled = false;


            }



        }


        







        string firstname;
        string lastname;
        string middlename;
        string firstlast;
        string address;
        string address2;
        string phone;
        string zipcode;
        string country;
        string city;
        int act2;

        //LAMBDA EXPRESSION USED TO COMBINE THREE STRINGS INTO ONE
        public delegate string namebund(string num);



        private void button1_Click(object sender, EventArgs e)
        {
            Mainpage tx = new Mainpage();
            schedulemain sm = new schedulemain(tx);
            CancelEventArgs c = new CancelEventArgs();
            sm.SQLloader();
            firstname = upCfntb.Text;
       
            address = upCaddtb.Text;
            address2 = upCadd2tb.Text;
            phone = upCphonenumbertb.Text;
            zipcode = upCzipTB.Text;
            country = upCcountrytb.Text;
            city = upAddCtytb.Text;

            if (upCfntb.Text == string.Empty || upCcountrytb.Text == string.Empty || upCaddtb.Text == string.Empty || upCphonenumbertb.Text == string.Empty || upCzipTB.Text == string.Empty || upAddCtytb.Text == string.Empty)
            {
                c.Cancel = true;
                MessageBox.Show("There are missing fields");
            }
            else
            {



                //LAMBDA EXPRESSION USED return string
                namebund nm = delegate (string firstname)
                {

                    return firstname;
                };


                firstlast = nm(firstname);




                if (checkBox1.Checked == true)
                {
                    act2 = 1;
                    if (upCcountrytb.Text == "United States" || upCcountrytb.Text == "US")
                    {
                        country = "USA";
                        CustomerMod(GetCurrentAddress(), GetCurrentcity(), GetCurrentcountry(), country, city, phone, zipcode, address, address2, firstlast, act2);
                        var path = "data.txt";
                        DateTime now = DateTime.Now;
                        string text = now + " " + "User" + " " + sm.GetCurrentUser() + " updated Customer at" + " " + currentcustomid;
                        //File.WriteAllText(path, text);
                        File.AppendAllText(path, text + Environment.NewLine);
                        this.Close();
                    }
                    else
                    {

                        CustomerMod(GetCurrentAddress(), GetCurrentcity(), GetCurrentcountry(), country, city, phone, zipcode, address, address2, firstlast, act2);
                        var path = "data.txt";
                        DateTime now = DateTime.Now;
                        string text = now + " " + "User" + " " + sm.GetCurrentUser() + " updated Customer at" + " " + currentcustomid;
                        //File.WriteAllText(path, text);
                        File.AppendAllText(path, text + Environment.NewLine);
                    }




                }
                else
                {
                    act2 = 0;
                    if (upCcountrytb.Text == "United States" || upCcountrytb.Text == "US")
                    {
                        country = "USA";
                        CustomerMod(GetCurrentAddress(), GetCurrentcity(), GetCurrentcountry(), country, city, phone, zipcode, address, address2, firstlast, act2);

                    }
                    else
                    {

                        CustomerMod(GetCurrentAddress(), GetCurrentcity(), GetCurrentcountry(), country, city, phone, zipcode, address, address2, firstlast, act2);

                    }
                }








                /*
                for (int i = 0; i < citynm.Count; i++)
                {
                    if (citynm[i].ToLower() == city.ToLower())
                    {
                        city= citynm[i];
                        SetCurrentcity(i);
                        SetCurrentcountry(i);

                    }

                }
                */


                //    CustomerMod(GetCurrentAddress(), GetCurrentcity(), GetCurrentcountry(), country, city, phone, zipcode, address, address2, firstlast);







            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
   
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
          
        }
    }
}
