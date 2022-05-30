using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for DatabaseData.xaml
    /// </summary>
    public partial class DatabaseData : Window
    {
        public DatabaseData()
        {
            InitializeComponent();

            Connect_database();
        }

        public void Connect_database()
        {
            SqlConnection SQL_Con = new SqlConnection(@"Data Source=ONURKANMSI; Initial Catalog=Project_Integration; Integrated Security=True;");

            try
            {
                //if the connection to the database is closed then open it
                if (SQL_Con.State == ConnectionState.Closed)
                {
                    SQL_Con.Open();
                }

                //string for storing our query
                String query = "SELECT COUNT(1) FROM GraphData WHERE Heartbeat=@Heartbeat AND Oxygen_level=@OxygenLevel";
                SqlCommand sqlCmd = new SqlCommand(query, SQL_Con);
                sqlCmd.CommandType = CommandType.Text;
                //passing in the Heartbeat and the Oxygen level
                //sqlCmd.Parameters.AddWithValue("@Heartbeat", txtUsername.Text);
                //sqlCmd.Parameters.AddWithValue("@OxygenLevel", txtPassword.Password);
            }
            catch (Exception ex)
            {
                //display an exception message if it runs into a problem
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closing the connection at the end
                SQL_Con.Close();
            }
        }
    }
}
