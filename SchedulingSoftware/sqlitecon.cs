using Microsoft.Data.Sqlite;

namespace SchedulingSoftware
{
    public class sqlitecon
    {
        private const string CreateUserTable = @"CREATE TABLE IF NOT EXISTS [User] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [userName] VARCHAR(2048)  NULL,
                                               [Password] VARCHAR(2048)  NULL
                                               )";
      
        private const string CreateAppointmentTable = @"CREATE TABLE IF NOT EXISTS [Appointment] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [customerID] INTEGER NULL,
                                               [userID] INTEGER  NULL,
                                                [title] VARHCAR(2048),
                                                [description] VARCHAR(2048),
                                                [location] VARCHAR(2048),
                                                [contact] VARCHAR(2048),
                                                [type] VARCHAR(2048),
                                                [url] VARCHAR(2048),
                                                [start] VARCHAR(2048),
                                                [end] VARCHAR(2048),
                                                [createDate] VARCHAR(2048),
                                               [createdBy] VARCHAR(2048),
                                                 [lastUpdate] VARCHAR(2048),
                                                [lastUpdateBy] VARCHAR(2048)
                                               );";

    //    appointment(customerID, userID, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
        private const string CreateCustomerTable = @"CREATE TABLE IF NOT EXISTS [customer] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [customerName] VARCHAR(2048)  NULL,
                                               [addressID] INTEGER  NULL,
                                                [active] VARCHAR(2048),
                                                 [createDate] VARCHAR(2048),
                                               [createdBy] VARCHAR(2048),
                                                 [lastUpdate] VARCHAR(2048),
                                                [lastUpdateBy] VARCHAR(2048)

                                               );";
        //customerName, addressID,active, createDate, createdBy, lastUpdate, lastUpdateBy

        private const string CreateAddressTable = @"CREATE TABLE IF NOT EXISTS [Address] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [address] VARCHAR(2048)  NULL,
                                                [address2] VARCHAR(2048)  NULL,
                                               [cityid] VARCHAR(2048)  NULL,
                                                [postalCode] VARCHAR(2048),
                                                [phone] VARCHAR(2048)  NULL ,  
                                                 [createDate] VARCHAR(2048),
                                               [createdBy] VARCHAR(2048),
                                                 [lastUpdate] VARCHAR(2048),
                                                [lastUpdateBy] VARCHAR(2048)
                                               );";
        //address(address,address2,cityid,postalCode,phone,createDate,createdBy,lastUpdate,lastUpdateBy)
        private const string CreateCityTable = @"CREATE TABLE IF NOT EXISTS [CITY] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [City] VARCHAR(2048)  NULL,
                                               [countyID] INTERGER,
                                               [createDate] VARCHAR(2048),
                                               [createdBy] VARCHAR(2048),
                                               [lastUpdate] VARCHAR(2048),             
                                                [lastUpdateBy] VARCHAR(2048)
                                               );";
        //city, countryID, createDate, createdBy, lastUpdate, lastUpdateBy
        private const string CreateCountryTable = @"CREATE TABLE IF NOT EXISTS [COUNTRY] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [Country] VARCHAR(2048)  NULL,
                                               [createDate] VARCHAR(2048),
                                               [createdBy] VARCHAR(2048),
                                                [lastUpdate] VARCHAR(2048),
                                                [lastUpdateBy] VARCHAR(2048)
                                               );";
        //country, createDate,createdBy,lastUpdate,lastUpdateBy


        //Create an database and connection


        public SqliteConnection connection = new SqliteConnection("DataSource = scheduler.db");
        public SqliteCommand command { get; set; }

        //CREATE TABLES
        public void createTables (SqliteConnection a)
        {

            a.Open();
            
            
            command = a.CreateCommand();
            command.CommandText = CreateAddressTable;
            command.ExecuteNonQuery();
            command.CommandText = CreateAppointmentTable;
            command.ExecuteNonQuery();
            command.CommandText = CreateCityTable;
            command.ExecuteNonQuery();
            command.CommandText = CreateCountryTable;
            command.ExecuteNonQuery();
            command.CommandText = CreateCustomerTable;
            command.ExecuteNonQuery();
            command.CommandText = CreateUserTable;
            command.ExecuteNonQuery();


            a.Close();


        }

        //REMOVE FROM TABLES

        public void removefromuser(int i, SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "DELETE FROM User WHERE ID = @user;";
            command.Parameters.AddWithValue("@user", i);
            command.ExecuteNonQuery();
            a.Close();

        }
        public void removefromcustomer(int i, SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "DELETE FROM customer WHERE ID = @user;";
            command.Parameters.AddWithValue("@user", i);
            command.ExecuteNonQuery();
            a.Close();

        }

        public void removefromappointment(int i, SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "DELETE FROM Appointment WHERE ID = @user;";
            command.Parameters.AddWithValue("@user", i);
            command.ExecuteNonQuery();
            a.Close();

        }

        public void removefromcity(int i, SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "DELETE FROM CITY WHERE ID = @user;";
            command.Parameters.AddWithValue("@user", i);
            command.ExecuteNonQuery();
            a.Close();

        }

        public void removefromcountry(int i, SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "DELETE FROM COUNTRY WHERE ID = @user;";
            command.Parameters.AddWithValue("@user", i);
            command.ExecuteNonQuery();
            a.Close();

        }

        public void removefromaddress(int i, SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "DELETE FROM Address WHERE ID = @user;";
            command.Parameters.AddWithValue("@user", i);
            command.ExecuteNonQuery();
            a.Close();

        }


        //UPDATE TABLES



        public void insertuser(SqliteConnection a)
        {
            a.Open();
            command = a.CreateCommand();
            command.CommandText = "INSERT INTO user(userName, Password) VALUES ('Test','Test')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO user(userName, Password) VALUES ('2Test','test')";
            command.ExecuteNonQuery();

            a.Close();

        }





    }
}
