using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();

            DateTime temp = new DateTime(2022,1,1);

        

            comboBox1.Items.Add("Presentation");
            comboBox1.Items.Add("Scrum");
            comboBox1.Items.Add("Online");
            comboBox1.Text = "Select Type";

            comboBox2.Text = "Select Consultant";
            comboBox3.Text = "Select Country";

            smUserSQl();
            smcountrySQl();
            //SQL FOR COMBO 2 AND 3
            // sqlmonthother();
        }

        public void sqlmonth(string month)
        {

            sqlitecon slc = new sqlitecon();

            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();


            

            string selectc = "SELECT appointment.type, COUNT(appointment.type) as Total from appointment WHERE appointment.type = @month GROUP BY appointment.type; ";
          
            cmd.CommandText = selectc;
            cmd.Parameters.AddWithValue("@month", month);
           
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
            apptbymonth.DataSource = bs;

            conn.Close();
        }

        public void sqluserappt(string name1)
        {
            sqlitecon slc = new sqlitecon();

            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();




            string selectc = "SELECT * FROM appointment WHERE createdBy = @usern; ";
       
            cmd.CommandText = selectc;
            cmd.Parameters.AddWithValue("@usern", name1);
           
            DataTable temp = new DataTable();
            SqliteDataReader ra = cmd.ExecuteReader();
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
            apptcurrent.DataSource = bs;

            conn.Close();
        }

      
            List<int> userid = new List<int>();
          

      public void smUserSQl()
            {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd2 = conn.CreateCommand();






            cmd2.CommandText = "SELECT ID, userName FROM user;";
                
               SqliteDataReader SqlReader = cmd2.ExecuteReader();
                while (SqlReader.Read())
                {
                    userid.Add(int.Parse(SqlReader[0].ToString()));
                   // username.Add(SqlReader[1].ToString());
                comboBox2.Items.Add(SqlReader[1].ToString());
                    // addressid.Add(int.Parse(SqlReader[2].ToString()));

                }

                
               conn.Close();

            }


        public void smcountrySQl()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd2 = conn.CreateCommand();


            cmd2.CommandText = "SELECT country FROM country GROUP BY country;";
            SqliteDataReader SqlReader = cmd2.ExecuteReader();
            while (SqlReader.Read())
            {
             
                comboBox3.Items.Add(SqlReader[0].ToString());
                // addressid.Add(int.Parse(SqlReader[2].ToString()));

            }


            conn.Close();

        }


        public void sqlcountryappt(string country)
        {

            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();


            string selectc = "SELECT customer.customerName, city.city, country.country FROM customer INNER JOIN address ON address.ID = customer.addressID INNER JOIN city ON city.ID = address.cityid INNER JOIN country ON country.ID = city.countyID WHERE country.country = @country1; ";
               
            
            cmd.CommandText = selectc;
            cmd.Parameters.AddWithValue("@country1", country);
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
            countryappt.DataSource = bs;

          conn.Close();
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            sqlmonth(comboBox1.SelectedItem.ToString());
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqluserappt(comboBox2.SelectedItem.ToString());

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlcountryappt(comboBox3.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
