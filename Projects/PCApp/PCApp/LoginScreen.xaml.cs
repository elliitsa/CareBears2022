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

            //initializing our http client
            ApiHelper.InitializeClient();
        }

        private async Task<UserModel> LoadUsers(string userName, string Password)
        {
            //new instance of UserModel calling LoadUser function in the UserProcessor class with passing the input given by the user
            UserModel user = await UserProcessor.LoadUser(userName, Password);
            //if user exists
            if (user.state == "true")
            {
                //write to the console the logged in user id
                Console.WriteLine("User with following id entered: ");
                Console.WriteLine(user.id_user);
                //create a new instance of mainwindow and pass in the main window the logged in user id, & display the mainwindow
                MainWindow mainWindow = new MainWindow(user.id_user);
                mainWindow.Show();

                //closing the login window
                this.Close();
            }
            else
            {
                //if user state is false that means user doesnt exist in database
                MessageBox.Show("Username and password does not exist or they are wrong!, Please try again...");

            }
            return user;
        }

        private async void btn_Login(object sender, RoutedEventArgs e)
        {
            //creating a new instance of user model
            UserModel user = new UserModel();
            //creating a task called userTask with a type of UserModel class for passing the credentials: username and password to the LoadUsers function
            Task<UserModel> userTask = LoadUsers(txtUsername.Text, txtPassword.Password);
            //setting the user to await the userTask
            user = await userTask;

        }

        private void btn_Quit(object sender, RoutedEventArgs e)
        {
            //application shuts down when the button is pressed
            Application.Current.Shutdown();
        }

    }
}
