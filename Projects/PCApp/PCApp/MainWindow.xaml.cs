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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PCApp.API;
//using PCApp.API_Handling;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int user_id { get; set; }
        public MainWindow(int user_id)
        {
            //setting the logged in user id which was passed with the argument in the mainwindow to our public user_id
            this.user_id = user_id;

            InitializeComponent();
        }
        
        //creating a task with a type of DataModel list called LoadDatas with the logged in user_id
        private async Task<List<DataModel>> LoadDatas(int user_id)
        {
            List<DataModel> data = await DataProcessor.LoadData(user_id);
            
            return data;
        }

        private async void btnDatabaseData_Click(object sender, RoutedEventArgs e)
        {
            //creating a local list with a type of DataModel called dlist
            List<DataModel> dlist;

            //creating a task with a type of list DataModel called dataTask for calling a the LoadDatas task with passing the logged in user_id
            Task<List<DataModel>> dataTask = LoadDatas(user_id);
            //dlist waiting for the dataTask
            dlist = await dataTask;
            //creating a new instance of DatabaseData with passing the dlist with the argument, & displaying the databasedata window
            DatabaseData databaseData = new DatabaseData(dlist);
            databaseData.Show();
            //closing the main window
            this.Close();
        }
        //function executes when the SDCard data button is pressed
        private void btnSDCardData_Click(object sender, RoutedEventArgs e)
        {
            //creating a new instance of sdcardData screen and display it
            SD_CardData sdcardData = new SD_CardData();
            sdcardData.Show();
            //close the MainWindow screen
            this.Close();
        }
        //function executes when the Realtime data button is pressed
        private async void btnRealtimeData_Click(object sender, RoutedEventArgs e)
        {
            //creating a local list with a type of DataModel called dlist
            List<DataModel> dlist;
            //creating a task with a type of list DataModel called dataTask for calling a the LoadDatas task with passing the logged in user_id
            Task<List<DataModel>> dataTask = LoadDatas(user_id);
            //dlist waiting for the dataTask
            dlist = await dataTask;
            //creating a new instance of Realtimedata with passing the dlist with the argument, & displaying the Realtimedata window
            RealTimeData realtimeData = new RealTimeData(dlist);
            realtimeData.Show();
            //closing the main window
            this.Close();
        }
        private void btn_Logout(object sender, RoutedEventArgs e)
        {
            //creates a new instance of loginscreen and displays the loginscreen back
            LoginScreen login = new LoginScreen();
            login.Show();
            //closes the DatabaseData window
            this.Close();
        }
    }
}
