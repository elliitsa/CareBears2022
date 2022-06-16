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
using System.Net.Http;
using PCApp.API_Handling;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for DatabaseData.xaml
    /// </summary>
    /// 
    public partial class DatabaseData : Window
    {
        
        List<DataModel> dmodel_list { get; set; }
        public DatabaseData(List<DataModel> dmodel_list)
        {
            InitializeComponent();

            ApiHelper.InitializeClient();

            this.dmodel_list = dmodel_list;
            LineChart();
            GPSCoordinates();


        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void LineChart()
        {
            //creating double lists for Heartbeat and oxygenlevel data
            List<double> HeartbeatValues = new List<double>();
            List<double> OxygenLevelValues = new List<double>();
            List<string> dateLabels = new List<string>();
            List<string> timeLabels = new List<string>();
            List<double> gps_long = new List<double>();
            List<double> gps_lang = new List<double>();
            List<int> emergency = new List<int>();

            foreach (DataModel dmodel in dmodel_list)
            {
                HeartbeatValues.Add(dmodel.heart_rate);
                OxygenLevelValues.Add(dmodel.oxygen_level);
                dateLabels.Add(dmodel.date.ToString());
                timeLabels.Add(dmodel.time.ToString());
                gps_long.Add(dmodel.gps_longitude);
                gps_lang.Add(dmodel.gps_latitude);
                emergency.Add(dmodel.emergency);
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries()
                {
                    Title = "HeartbeatData",
                    Values = new ChartValues<double>(HeartbeatValues)
                },

                new LineSeries()
                {
                    Title = "OxygenLevelData",
                    Values = new ChartValues<double>(OxygenLevelValues),
                    PointGeometry = null
                },

                new LineSeries()
                {
                    Title = "gps long",
                    Values= new ChartValues<double>(gps_long),
                    //Visibility = Visibility.Hidden
                },

                new LineSeries()
                {
                    Title = "gps lang",
                    Values= new ChartValues<double>(gps_lang),
                    //Visibility = Visibility.Hidden

                },

                new LineSeries()
                {
                    Title = "emergency",
                    Values= new ChartValues<int>(emergency),
                    //Visibility = Visibility.Hidden

                }
            };

           
            //converting the string list into an array
            //var myArray = dateLabels.ToArray();
            var timeArray = timeLabels.ToArray();
            //setting the label as our newly created array
            Labels = timeArray;

            DataContext = this;
        }

        public LineSeries gps_long { get; set; }
        public LineSeries gps_lang { get; set; }
        public LineSeries emergency { get; set; }

        public double[] myArray { get; set; }
        
        private void GPSCoordinates()
        {
            //base.DataContext = dmodel_list[0];

           /* base.DataContext = new DataModel[]
            {
                /*new DataModel
                {
                    gps_longitude = 54645464645L,
                    gps_latitude = 7888456542L,
                    emergency = 1,
                },
                new DataModel
                {
                    gps_longitude = 34645264645L,
                    gps_latitude = 2888416542L,
                    emergency = 0,
                },
                new DataModel
                {
                    gps_longitude = 14675464645L,
                    gps_latitude = 2888486542L,
                    emergency = 1,
                }
            };*/
        }

        /*private async Task<DataModel> LoadDates(int userID, DateTime date)
        {
            //DataModel data = await DateProcessor.LoadDate(userID, date);

            
   

            
            //return data;
        }*/

        private async Task<List<DataModel>> LoadDates(int user_id,DateTime datePicker)
        {

            List<DataModel> dates = await DateProcessor.LoadDate(user_id, datePicker);

            

 

            return dates;
                
        }

        private void Date_Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            DateTime datePicker = (DateTime)((DatePicker)sender).SelectedDate;
            
            Task<List<DataModel>> dateTask = LoadDates(dmodel_list[0].id_user, datePicker);

            //creating double lists for Heartbeat and oxygenlevel data
            List<double> HeartbeatValues = new List<double>();
            List<double> OxygenLevelValues = new List<double>();
            List<string> dateLabels = new List<string>();
            List<string> timeLabels = new List<string>();
            List<double> gps_long = new List<double>();
            List<double> gps_lang = new List<double>();
            List<int> emergency = new List<int>();

            foreach (DataModel dmodel in dateTask.Result)
            {
                HeartbeatValues.Add(dmodel.heart_rate);
                OxygenLevelValues.Add(dmodel.oxygen_level);
                dateLabels.Add(dmodel.date.ToString());
                timeLabels.Add(dmodel.time.ToString());
                gps_long.Add(dmodel.gps_longitude);
                gps_lang.Add(dmodel.gps_latitude);
                emergency.Add(dmodel.emergency);
            }

            /*
            SeriesCollection = new SeriesCollection
            {
                new LineSeries()
                {
                    Title = "HeartbeatData",
                    Values = new ChartValues<double>(HeartbeatValues)
                },

                new LineSeries()
                {
                    Title = "OxygenLevelData",
                    Values = new ChartValues<double>(OxygenLevelValues),
                    PointGeometry = null
                },

                new LineSeries()
                {
                    Title = "gps long",
                    Values= new ChartValues<double>(gps_long),
                    //Visibility = Visibility.Hidden
                },

                new LineSeries()
                {
                    Title = "gps lang",
                    Values= new ChartValues<double>(gps_lang),
                    //Visibility = Visibility.Hidden

                },

                new LineSeries()
                {
                    Title = "emergency",
                    Values= new ChartValues<int>(emergency),
                    //Visibility = Visibility.Hidden

                }
            };*/

            var workchart = new CartesianChart
            {
                Series = new SeriesCollection()
                {
                    new LineSeries()
                {
                    Title = "HeartbeatData",
                    Values = new ChartValues<double>(HeartbeatValues)
                },

                new LineSeries()
                {
                    Title = "OxygenLevelData",
                    Values = new ChartValues<double>(OxygenLevelValues),
                    PointGeometry = null
                },

                new LineSeries()
                {
                    Title = "gps long",
                    Values= new ChartValues<double>(gps_long),
                    //Visibility = Visibility.Hidden
                },

                new LineSeries()
                {
                    Title = "gps lang",
                    Values= new ChartValues<double>(gps_lang),
                    //Visibility = Visibility.Hidden

                },

                new LineSeries()
                {
                    Title = "emergency",
                    Values= new ChartValues<int>(emergency),
                    //Visibility = Visibility.Hidden

                }
                }
            };



            
                
            


            
            
            var timeArray = timeLabels.ToArray();
            //setting the label as our newly created array
            Labels = timeArray;

            DataContext = this;

            workchart.Update();
        }

        private void btn_Logout(object sender, RoutedEventArgs e)
        {

            LoginScreen login = new LoginScreen();
            login.Show();

            this.Close();
        }
    }
}
