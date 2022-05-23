using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    //NOTE: REMOVE ALL MESSAGE BOXES...LEAVE FOR SUCCESSFUL ENTRIES AND ERRORS
    //AS OF 1/6/2022 ADD CUSTOMER WORKS
    public partial class AddCustomer : Form
    {
        public static Mainpage mp = new Mainpage(); 
        schedulemain sm = new schedulemain(mp);
        public AddCustomer(schedulemain sm2)
        {
            sm = sm2;
            InitializeComponent();

          

            // MessageBox.Show(sm.GetCurrentUser()); //works

            countrysql();
            citySQL();
            addressSQL();
            CustomerSQl();
          
        }
        //List for SQL Runner
        List<int> customerid = new List<int>();
        List<string> customername = new List<string>();
        //*******************************************************//
        List<string> addrname = new List<string>();
        List<int> addressid = new List<int>();
        //******************************************************//
        List<string> countrynm = new List<string>();
        List<int> countryidn = new List<int>();
        //*****************************************************//
        List<string> citynm = new List<string>();
        List<int> cityidn = new List<int>();



     

        private void CustomerSQl()
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

        private bool customercheck(string a)
        {
            for (int i = 0; i < customername.Count; i++)
            {
                if (customername[i].ToString().ToLower() == a.ToLower())
                {
                    setCustomeridn(customerid[i]);
                    return true;
                }

                else
                {
                    setCustomeridn(customerid.Count - 1);
                    break;
                }
            }
           // MessageBox.Show("Customer not found");
            return false;
        }










        private void addressSQL()
        {


            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdaddress = conn.CreateCommand();


            cmdaddress.CommandText = "SELECT * FROM address;";
           
           SqliteDataReader addead = cmdaddress.ExecuteReader();
            while (addead.Read())
            {
                addressid.Add(int.Parse(addead[0].ToString()));
                addrname.Add(addead[1].ToString());
            }

           conn.Close();
        }

        private int currentaddress;
        public int GetCurrentAddress() { return currentaddress; }
        public void SetCurrentAddress(int address) { currentaddress = address; }


        private bool addresschecker(string a)
        {
            addressid.Clear();
            addrname.Clear();
            addressSQL();
            for (int i = 0; i < addrname.Count; i++)
            {
                if (addrname[i].ToString().ToLower() == a.ToLower())
                {


                  //  MessageBox.Show(addressid[i].ToString());

                    SetCurrentAddress(addressid[i]);
                    return true;
                }

                else
                {

                    SetCurrentAddress(addressid[addressid.Count-1]);

                    break;
                }
            }
           // MessageBox.Show("Address not found");
            return false;
        }

       


        private void citySQL()
        {

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmdcity= conn.CreateCommand();



            //City Command
         
            cmdcity.CommandText = "SELECT * FROM city";
         
           SqliteDataReader cityread = cmdcity.ExecuteReader();
            while (cityread.Read())
            {
                cityidn.Add(int.Parse(cityread[0].ToString()));
                citynm.Add(cityread[1].ToString());

            }
           conn.Close();

        }

        private int currentcity;
        public int GetCurrentcity() { return currentcity; }
        public void SetCurrentcity(int a) { currentcity = a; }


        private bool citychecker(string a)
        {
            cityidn.Clear();
            citynm.Clear();
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
                   // MessageBox.Show("city id" + cityidn[cityidn.Count-1].ToString() );
                    SetCurrentcity(cityidn[cityidn.Count-1]);
                    break;
                }
            }
          //  MessageBox.Show("City not found");
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


        private bool countrychecker(string a)
        {
            countryidn.Clear();
            countrynm.Clear();
            countrysql();
            for(int i = 0; i < countrynm.Count; i++)
            {
                if (countrynm[i].ToString().ToLower() == a.ToLower())
                {
                  //  MessageBox.Show("country id: " + countryidn[i].ToString());
                    SetCurrentcountry(countryidn[i]);
                    return true;
                }
           
                else
                {
                  //  MessageBox.Show("Country id "+countryidn[countryidn.Count - 1].ToString());
                    SetCurrentcountry(countryidn[countryidn.Count-1]);
                    break;
                }
            }
          //  MessageBox.Show("Country not found");
            return false;
        }






        private void To_print()
        {


            for (int i = 0; i < countrynm.Count; i++)
            {
               // MessageBox.Show(countrynm[i].ToString());

            }

        }






        private string acCurrentuser;
        public void SetacCurrentuser(string h)
        {
            acCurrentuser = h;
        }
        public string GetacCurrentuser()
        {
            return acCurrentuser;
        }







        private int customeridn;
        public void setCustomeridn(int a) { customeridn = a; }
        public int getCustomeridn() { return customeridn; }


        private void NewSQLadder(string fnln, string addnm, string citynm, string countrynm1)
        {
            CancelEventArgs c = new CancelEventArgs();



            if (countrychecker(countrynm1) == true)
            {   //connect country id number
              //  MessageBox.Show("COUNTRY FOUND");




                if (citychecker(citynm) == true)
                {



                    sqlitecon slc = new sqlitecon();
                    SqliteConnection conn = slc.connection;
                    conn.Open();
                    SqliteCommand cmdex = conn.CreateCommand();



                    cmdex.CommandText = "INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES('" + addnm + "','"+ address2tb.Text  + "'," + GetCurrentcity()+",'" + zipcode +"','" + phone + "','"+ DateTime.Now.ToString() + "','"+ sm.GetCurrentUser() +"','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser()+ "');";
                   


                    cmdex.ExecuteNonQuery();
                
               
                    addresschecker(addnm);



                        cmdex.CommandText = "INSERT INTO customer(customerName, addressID,active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + fnln+"',"+GetCurrentAddress()+","+    1 +",'"+  DateTime.Now.ToString()+"','" + sm.GetCurrentUser() +"','"+ DateTime.Now.ToString() + "','"+ sm.GetCurrentUser() +"' );";
                  


                    cmdex.ExecuteNonQuery();
                   
                  
                    conn.Close();
                   // MessageBox.Show("CITY found");
                }
                else
                {

                    sqlitecon slc = new sqlitecon();
                    SqliteConnection conn = slc.connection;
                    conn.Open();
                    SqliteCommand cmdex1 = conn.CreateCommand();




                    cmdex1.CommandText = "INSERT INTO CITY (city, countyID, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(@cityp,@countryn, @NOW,@usern, @NOW,@usern);";
                    cmdex1.Parameters.AddWithValue("@cityp", citynm);
                    cmdex1.Parameters.AddWithValue("@countryn", GetCurrentcountry());
                    cmdex1.Parameters.AddWithValue("@usern", sm.GetCurrentUser());
              
                    cmdex1.ExecuteNonQuery();
              

                    citychecker(citynm);

                    //INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES();


              
                   
                    cmdex1.CommandText = "INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES('" + addnm + "','" + address2tb.Text + "'," + GetCurrentcity() + ",'" + zipcode + "','" + phone + "','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "');";
              
                 
                

                    cmdex1.ExecuteNonQuery();
              

                    //INSERT INTO customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES();

                    //addressSQL();
                    addresschecker(addnm);

                    //ADD CUSTOMER
                  


                  
                    cmdex1.CommandText = "INSERT INTO customer(customerName, addressID,active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + fnln + "'," + GetCurrentAddress() + "," + 1 + "','" + DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "' );";
       


                    cmdex1.ExecuteNonQuery();
                   conn.Close();
                    sm.SQLloader();
                    this.Close();


                }

            }
            else
            {


                sqlitecon slc = new sqlitecon();
                SqliteConnection conn = slc.connection;
                conn.Open();
                SqliteCommand cmdex4 = conn.CreateCommand();






                cmdex4.CommandText = "INSERT INTO COUNTRY(country, createDate,createdBy,lastUpdate,lastUpdateBy) VALUES(@cnm,@NOW,@user1,@NOW,@user1);";
                cmdex4.Parameters.AddWithValue("@cnm", countrynm1);
                cmdex4.Parameters.AddWithValue("@user1", sm.GetCurrentUser());
                cmdex4.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
              

                cmdex4.ExecuteNonQuery();
               


               // countrysql();
     
                countrychecker(countrynm1);


                if (citychecker(citynm) == true)
                {

                    //connect with city id number, ADD address


                    sqlitecon slc1 = new sqlitecon();
                    SqliteConnection conn1 = slc.connection;
                    conn1.Open();
                    SqliteCommand cmdex = conn1.CreateCommand();


                    cmdex.CommandText = "INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES('" + addnm + "','" + address2tb.Text + "'," + GetCurrentcity() + ",'" + zipcode + "','" +phone+ "',  @NOW,'" + sm.GetCurrentUser() + "', @NOW,'" + sm.GetCurrentUser() + "');";
              

            
                    cmdex.ExecuteNonQuery();
                    conn1.Close();

                    //INSERT INTO customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES();
                 //  addressSQL();
                    addresschecker(addnm);

                    cmdex.CommandText = "INSERT INTO customer(customerName, addressID,active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + fnln + "'," + GetCurrentAddress() + "," + 1 + ", @NOW,'" + sm.GetCurrentUser() + "','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "' );";
                  




                    cmdex.ExecuteNonQuery();
                    conn.Close();
                    sm.SQLloader();
                    this.Close();
                  //  MessageBox.Show("CITY found");
                }
                else
                {

                    //INSERT INTO CITY (city, countryID, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('Brooklyn',1, @NOW,'test', @NOW,'test');
                    //GET CITY NEW ID NUMBER


                    sqlitecon slc1 = new sqlitecon();
                    SqliteConnection conn1 = slc.connection;
                    conn.Open();
                    SqliteCommand cmdex1 = conn.CreateCommand();






                    cmdex1.CommandText = "INSERT INTO CITY (city, countyID, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(@cityn,@countyn, @NOW,@usern, @NOW,@usern);";
                    cmdex1.Parameters.AddWithValue("@cityn", citynm);
                    cmdex1.Parameters.AddWithValue("@countyn", GetCurrentcountry());
                    cmdex1.Parameters.AddWithValue("@usern", sm.GetCurrentUser());
                    cmdex1.Parameters.AddWithValue("@NOW", DateTime.Now.ToString());
                    cmdex1.ExecuteNonQuery();
                  

                   // citySQL();
                    citychecker(citynm);

                    //INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES();

                  
                    cmdex1.CommandText = "INSERT INTO address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy) VALUES('" + addnm + "','" + address2tb.Text + "'," + GetCurrentcity() + ",'" + zipcode + "','" + phone + "','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "', @NOW,'" + sm.GetCurrentUser() + "');";
                    


                    cmdex1.ExecuteNonQuery();
                  

                    //INSERT INTO customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES();
                   // addressSQL();
                    addresschecker(addnm);

                   
                    cmdex1.CommandText = "INSERT INTO customer(customerName, addressID,active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + fnln + "'," + GetCurrentAddress() + "," + 1 + ", @NOW,'" + sm.GetCurrentUser() + "','"+ DateTime.Now.ToString() + "','" + sm.GetCurrentUser() + "' );";
                


                    cmdex1.ExecuteNonQuery();
                   conn.Close();
                    sm.SQLloader();

                    this.Close();

                }



            }



        }

        string firstname;
    
        string firstlast;
        string address;
        string phone;
        string zipcode;
        string country;
        string city;
        

        private void submitac_Click(object sender, EventArgs e)
        {
            CancelEventArgs c = new CancelEventArgs();
            firstname = firstnametb.Text;

            firstlast = firstname;

            address = addresstb.Text;
            phone = phonetb.Text; //IF CONTAINS '-' 
            zipcode = ziptb.Text;
            
            city = citytb.Text;

            if (firstnametb.Text == string.Empty || addresstb.Text == string.Empty || phonetb.Text == string.Empty || ziptb.Text == string.Empty || citytb.Text == string.Empty || countrytb.Text == string.Empty)
            {
                c.Cancel = true;
                MessageBox.Show("There are missing fields");
            }
            else
            {



                if (countrytb.Text == "United States" || countrytb.Text == "US")
                {
                    country = "USA";
                    NewSQLadder(firstlast, address, city, country);

                    MessageBox.Show("New Customer added successfully");
                }
                else
                {
                    country = countrytb.Text;
                    NewSQLadder(firstlast, address, city, country);

                    MessageBox.Show("New Customer added successfully");
                }


                //******************************************//



            }



        }

    }
}
