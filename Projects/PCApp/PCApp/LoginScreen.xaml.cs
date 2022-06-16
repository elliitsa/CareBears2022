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

            ApiHelper.InitializeClient();
        }

        private async Task<UserModel> LoadUsers(string userName, string Password)
        {
            UserModel user = await UserProcessor.LoadUser(userName, Password);

            if (user.state == "true")
            {
                Console.WriteLine(user.id_user);
                Console.WriteLine("`log screen");

                MainWindow mainWindow = new MainWindow(user.id_user);
                mainWindow.Show();
                //closing the login window
                this.Close();
            }
            else
            {
                //if check returns 0 then credentials are incorrect
                MessageBox.Show("Username does not exist or password is wrong!");

            }
            return user;
        }

        private async void btn_Login(object sender, RoutedEventArgs e)
        {
            UserModel user = new UserModel();
            Task<UserModel> userTask = LoadUsers(txtUsername.Text, txtPassword.Password);
            //LoadUsers(txtUsername.Text, txtPassword.Password);
            user = await userTask;

        }

        private void btn_Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
