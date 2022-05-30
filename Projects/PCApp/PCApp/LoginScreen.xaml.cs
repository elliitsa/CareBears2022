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
using MaterialDesignThemes.Wpf;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        
        private void btn_Login(object sender, RoutedEventArgs e)
        {
            //Creating a object of SqlConnection and pass in the address of database
            SqlConnection SQL_Con = new SqlConnection(@"Data Source=ONURKANMSI; Initial Catalog=Project_Integration; Integrated Security=True;");
            
            //Try to connect to the database
            try
            {
                //if the connection to the database is closed then open it
                if(SQL_Con.State == ConnectionState.Closed)
                {
                    SQL_Con.Open();
                }

                //string for storing our query
                String query = "SELECT COUNT(1) FROM UserTable WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, SQL_Con);
                sqlCmd.CommandType = CommandType.Text;
                //passing in the username and the password
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);

                //ExecuteScalar returns first row first column so we will ge the count and convert it to Int32
                int check = Convert.ToInt32(sqlCmd.ExecuteScalar());

                //if check returns 1, then open the mainwindow of the application
                if(check == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    //closing the login window
                    this.Close();
                }
                else
                {
                    //if check returns 0 then credentials are incorrect
                    MessageBox.Show("Username does not exist or password is wrong!");
                }

            }
            catch(Exception ex)
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

        private void btn_Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
