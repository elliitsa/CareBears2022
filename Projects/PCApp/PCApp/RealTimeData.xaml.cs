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
using LiveCharts;
using LiveCharts.Wpf;
using System.Configuration;
using PCApp.API_Handling;
using LiveCharts.Defaults;
using System.Windows.Threading;
using System.Threading;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for RealTimeData.xaml
    /// </summary>
    public partial class RealTimeData : Window
    {
        //creating a list called dmodel_list for storing our sensor data
        List<DataModel> dmodel_list { get; set; }

        public RealTimeData(List<DataModel> dmodel_list)
        {
            InitializeComponent();
            //initializing our http client
            ApiHelper.InitializeClient();
            //setting our dmodel_list all the passed in data from the argument
            this.dmodel_list = dmodel_list;
            //calling the function LineChart for drawing our linechart
            Realtimer();
        }

        private DispatcherTimer dispatcherTimer;

        private void Realtimer()
        {
            //ininitialising the timer and starts the timer
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            wdw.Title = "updating";
        }
        public int count = 0;
        private async Task<List<DataModel>> LoadDates(int user_id)
        {
            //creating a list of dates with a type of datamodel which is going to call LoadDate function from DateProcessor with the logged in user_id and selected date
            List<DataModel> dates = await DateProcessor.LoadDate(user_id, System.DateTime.Now);

            return dates;
        }

        private async void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //creating a task with a type of DataModel list called dateTask which will call the LoadDates task and pass in the user id and input date from the user
            Task<List<DataModel>> dateTask = LoadDates(dmodel_list[0].id_user);
            count++;
            //setting dmodel_list with the new date choosed data
            dmodel_list = await dateTask;
            
           // wdw.Title = "Updating";
            updateRealtimer();

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        //creating a task with a type of list datamodel called LoadDates with the logged in user id and date selected from date picker
        
        
        public void updateRealtimer()
        {
            wdw.Title = "Realtime Data "+ count.ToString();
            
                //if there is an emergency display a messagebox saying emergency is on the way
                string emergencytext = "Emergency at: ";
                if (dmodel_list[dmodel_list.Count-1].emergency == 1)
                {
                    MessageBox.Show($"{emergencytext}  GPS_Long: {dmodel_list[dmodel_list.Count-1].gps_longitude.ToString()} GPS_Lang: {dmodel_list[dmodel_list.Count-1].gps_latitude.ToString()}");
                }
            heart_rate.Text = "Heart Rate: " + dmodel_list[dmodel_list.Count - 1].heart_rate.ToString() + " " + " Updated times: " + count.ToString();
            oxygen_level.Text = "Oxygen Level: " + dmodel_list[dmodel_list.Count - 1].oxygen_level.ToString();
            gps1.Text= "GPS Longtitude: " + dmodel_list[dmodel_list.Count-1].gps_longitude.ToString();
            gps2.Text = "GPS Latitude: " + dmodel_list[dmodel_list.Count-1].gps_latitude.ToString();
            emerg.Text = "Emergency: " + dmodel_list[dmodel_list.Count-1].emergency.ToString();
            date.Text = "Date: " + dmodel_list[dmodel_list.Count - 1].date.ToString();
            time.Text = "Time: " + dmodel_list[dmodel_list.Count - 1].time.ToString();
        }

        //function executes whhen back button is pressed
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(dmodel_list[0].id_user);
            mainWindow.Show();

            this.Close();
        }

        //function executes whhen logout button is pressed
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
