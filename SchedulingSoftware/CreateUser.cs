using Microsoft.Data.Sqlite;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchedulingSoftware
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        /*
        private const string CreateUserTable = @"CREATE TABLE IF NOT EXISTS [User] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [userName] VARCHAR(2048)  NULL,
                                               [Password] VARCHAR(2048)  NULL
                                               )";

        */
        public void submitentry(string a, string b)
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO User(userName, Password) VALUES(@User, @Pass);";
            cmd.Parameters.AddWithValue("@User",a);
            cmd.Parameters.AddWithValue("@Pass", b);
            cmd.ExecuteNonQuery();

            conn.Close();

        }
        public bool userfound { get; set; }
        public BindingList<string> userlist { get; set; }
        public bool usernamefound(string a)
        {
            bool flag = false;
            userlog();

            foreach(string b in userlist)
            {
                if (a.Equals(b))
                {
                    flag = true;
                }
            }
           

            
            return flag;
        }


        public void userlog()
        {
            sqlitecon slc = new sqlitecon();
            SqliteConnection conn = slc.connection;
            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();
            userlist = new BindingList<string>();  

            cmd.CommandText = "SELECT userName FROM user;";
            SqliteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               
                    userlist.Add(reader[0].ToString());
                
            }

            conn.Close();
        }



        private void showpasscb_CheckedChanged(object sender, System.EventArgs e)
        {
            if(showpasscb.Checked == true)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';

            }
        }

        private void cancelbtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        
        private void submitbtn_Click(object sender, System.EventArgs e)
        {
            CancelEventArgs a = new CancelEventArgs();
            if(usernamefound(textBox1.Text) == true)
            {
                MessageBox.Show("Username taken. Choose another");
                a.Cancel = true;

            }
            
            if (usernamefound(textBox1.Text) == false)
            {
                


                submitentry(textBox1.Text, textBox2.Text);
                MessageBox.Show("New User was created successfully");

                Mainpage mp = new Mainpage();

                mp.loginSQL();
                mp.logincheck(textBox1.Text, textBox2.Text);





                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if(usernamefound(textBox1.Text) == true)
            {
                usernameerror.Text = "Username taken";
             
            }
            else
            {
                usernameerror.Text = " ";
            }
        }

        private void CreateUser_Load(object sender, System.EventArgs e)
        {

        }
    }
}
