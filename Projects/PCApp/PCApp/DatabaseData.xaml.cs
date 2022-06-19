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
using System.Collections.ObjectModel;
using LiveCharts.Defaults;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PCApp.API;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for DatabaseData.xaml
    /// </summary>
    /// 
    public partial class DatabaseData : Window
    {
        //creating a list called dmodel_list for storing our sensor data
        List<DataModel> dmodel_list { get; set; }
        List<DataModel> dmodel_copy { get; set; }
        public DatabaseData(List<DataModel> dmodel_list)
        {
            InitializeComponent();
            //initializing our http client
            ApiHelper.InitializeClient();
            //setting our dmodel_list all the passed in data from the argument
            this.dmodel_list = dmodel_list;
            this.dmodel_copy = dmodel_list;

            //calling the function LineChart for drawing our linechart
            LineChart();
        }

        //Declaring public SeriesCollection for graph data
        public SeriesCollection SeriesCollection { get; set; }
        //declaring public string array for graph labels
        public string[] Labels { get; set; }
        //declaring the default graph yformatter
        public Func<double, string> YFormatter { get; set; }
        
        public DateTime? SelectedDate { get; set; }
        public DateTime? SelectedDate1 { get; set; }

        DatePicker datePicker = new DatePicker(); 

        private void LineChart()
        {
            //creating a list of ObservableValues for storing our each sensor data with their types
            List<ObservableValue> Heart_rate = new List<ObservableValue>();
            List<ObservableValue> Oxygen_level = new List<ObservableValue>();
            List<string> date_Labels = new List<string>();
            List<string> time_Labels = new List<string>();
            List<ObservableValue> GPS_long = new List<ObservableValue>();
            List<ObservableValue> GPS_lang = new List<ObservableValue>();
            List<ObservableValue> Emergency = new List<ObservableValue>();
            string blah;


            //creating a foreach loop with dmodel_list
            foreach (DataModel dmodel in dmodel_list)
            {
                //adding heart rate data into heart rate list
                Heart_rate.Add(new ObservableValue(dmodel.heart_rate));
                //adding oxygen level data into oxygen level list
                Oxygen_level.Add(new ObservableValue(dmodel.oxygen_level));
                //adding the date and time with a followed space into 1 string variable called blah
                blah = dmodel.date.ToString() + " " + dmodel.time.ToString();
                //adding into data_labels list string blah
                date_Labels.Add(blah);
                //adding into time_labels list string blah
                time_Labels.Add(blah);
                //adding gps_longtitude data into GPS_Long list
                GPS_long.Add(new ObservableValue(dmodel.gps_longitude));
                //adding gps_latitude data into GPS_latitude list
                GPS_lang.Add(new ObservableValue(dmodel.gps_latitude));
                //adding emergency data into Emergency list
                Emergency.Add(new ObservableValue(dmodel.emergency));

            }

            //if there is an emergency display a messagebox saying emergency is on the way
            bool btn_handled = false;
            bool fall_handled = false;
            string emergencytext = "Emergency at: ";
            string usertripped = "User fell down, Help is coming to help the user get up...";

            if (btn_handled == false || fall_handled == false)
            {
                if (dmodel_list[dmodel_list.Count - 1].emergency == 1)
                {
                    if (!btn_handled)
                    {
                        btn_handled = true;
                        MessageBox.Show($"{emergencytext}  GPS_Long: {dmodel_list[dmodel_list.Count - 1].gps_longitude.ToString()} GPS_Lang: {dmodel_list[dmodel_list.Count - 1].gps_latitude.ToString()}");
                    }

                }
                if (dmodel_list[dmodel_list.Count - 1].emergency == 2)
                {
                    if (!fall_handled)
                    {
                        fall_handled = true;
                        MessageBox.Show($"{usertripped}  GPS_Long: {dmodel_list[dmodel_list.Count - 1].gps_longitude.ToString()} GPS_Lang: {dmodel_list[dmodel_list.Count - 1].gps_latitude.ToString()}");
                    }
                }
                if (dmodel_list[dmodel_list.Count - 1].emergency == 0)
                {
                    btn_handled = false;
                    fall_handled = false;
                }
            }

            SeriesCollection = new SeriesCollection
            {
                //creting new lineSeries inside the Series collection with a followed title
                new LineSeries()
                {
                    Title = "HeartbeatData",
                    //Setting the values of our chart, ChartValues with ObservableValue type and getting the HeartRate list with a ObservableValue type
                    Values = new ChartValues<ObservableValue>(Heart_rate)
                },
                
                new LineSeries()
                {
                    Title = "OxygenLevelData",
                    Values = new ChartValues<ObservableValue>(Oxygen_level)
                },

                new LineSeries()
                {
                    Title = "GPS Long:",
                    Values= new ChartValues<ObservableValue>(GPS_long),
                    PointGeometry = null
                },

                new LineSeries()
                {
                    Title = "GPS Lat:",
                    Values= new ChartValues<ObservableValue>(GPS_lang),
                    PointGeometry = null
                },

                new LineSeries()
                {
                    Title = "Emergency:",
                    Values= new ChartValues<ObservableValue>(Emergency),
                    PointGeometry = null
                }

            };

            myLineChart.Series = SeriesCollection;

            //hide the unneccessary serries
            LineSeries GPS_LongHide = (myLineChart.Series[2] as LineSeries);
            GPS_LongHide.Stroke = System.Windows.Media.Brushes.Transparent;
            GPS_LongHide.Fill = System.Windows.Media.Brushes.Transparent;

            LineSeries GPS_LangHide = (myLineChart.Series[3] as LineSeries);
            GPS_LangHide.Stroke = System.Windows.Media.Brushes.Transparent;
            GPS_LangHide.Fill = System.Windows.Media.Brushes.Transparent;

            LineSeries EmergencyHide = (myLineChart.Series[4] as LineSeries);
            EmergencyHide.Stroke = System.Windows.Media.Brushes.Transparent;
            EmergencyHide.Fill = System.Windows.Media.Brushes.Transparent;

            //creating dateArray to store the date's and time's from date_labels list with a conversion of date_labels to date_arrays
            var dateArray = date_Labels.ToArray();

            //setting the Labels of our chart to dateArray
            Labels = dateArray;

            //setting the data context
            DataContext = this;
        }
        //creating a task with a type of list datamodel called LoadDates with the logged in user id and date selected from date picker
        private async Task<List<DataModel>> LoadDates(int user_id, DateTime? datePicker)
        {
            //creating a list of dates with a type of datamodel which is going to call LoadDate function from DateProcessor with the logged in user_id and selected date
            List<DataModel> dates = await DateProcessor.LoadDate(user_id, datePicker);
            
            return dates;
        }
        //function executes when user selects a date form date picker
        private async Task<List<DataModel>> LoadDatas(int user_id)
        {
            List<DataModel> data = await DataProcessor.LoadData(user_id);

            return data;
        }
        public int flag;
        public async void Date_Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //getting the selected date of the user and initializing it to SelectedDate1
            SelectedDate1 = (DateTime)((DatePicker)sender).SelectedDate;
            //creating a task with a type of DataModel list called dateTask which will call the LoadDates task and pass in the user id and input date from the user
            Task<List<DataModel>> dateTask = LoadDates(dmodel_list[0].id_user, SelectedDate1);
            SelectedDate = SelectedDate1;
            //setting dmodel_list with the new date choosed data
            dmodel_list = await dateTask;
            flag = 0;
            if(dmodel_list.Count == 0)
            {
                MessageBox.Show($"No Data Available!");
                //creating a task with a type of list DataModel called dataTask for calling a the LoadDatas task with passing the logged in user_id
                Task<List<DataModel>> dataTask = LoadDatas(dmodel_copy[0].id_user);
                //dlist waiting for the dataTask
                dmodel_list = await dataTask;
                flag = 1;
            }
            //checking if our line chart has already series inside, if so
            if(myLineChart.Series != null)
            {
                //clear the series and set it to our newly updated series
                myLineChart.Series.Clear();
                myLineChart.Series = SeriesCollection;
                //call to the function updatechart
                UpdateChart();
            }
        }
        
        public void UpdateChart()
        {
            //creating a list of ObservableValues for storing our each sensor data with their types
            List<ObservableValue> Heart_rate = new List<ObservableValue>();
            List<ObservableValue> Oxygen_level = new List<ObservableValue>();
            List<string> date_Labels = new List<string>();
            List<string> time_Labels = new List<string>();
            List<ObservableValue> GPS_long = new List<ObservableValue>();
            List<ObservableValue> GPS_lang = new List<ObservableValue>();
            List<ObservableValue> Emergency = new List<ObservableValue>();
            string blah;

            //creating a foreach loop with dmodel_list
            foreach (DataModel dmodel in dmodel_list)
            {
                //adding heart rate data into heart rate list
                Heart_rate.Add(new ObservableValue(dmodel.heart_rate));
                //adding oxygen level data into oxygen level list
                Oxygen_level.Add(new ObservableValue(dmodel.oxygen_level));
                //adding the date and time with a followed space into 1 string variable called blah
                blah = dmodel.date.ToString() + " " + dmodel.time.ToString();
                //adding into data_labels list string blah
                date_Labels.Add(blah);
                //adding into time_labels list string blah
                time_Labels.Add(dmodel.time.ToString());
                //adding gps_longtitude data into GPS_Long list
                GPS_long.Add(new ObservableValue(dmodel.gps_longitude));
                //adding gps_latitude data into GPS_latitude list
                GPS_lang.Add(new ObservableValue(dmodel.gps_latitude));
                //adding emergency data into Emergency list
                Emergency.Add(new ObservableValue(dmodel.emergency));

                //if there is an emergency display a messagebox saying emergency is on the way
                string emergencytext = "Emergency at: ";
                string usertripped = "User fell down, Help is coming to help the user get up...";
                if (dmodel.emergency == 1)
                {
                    MessageBox.Show($"{emergencytext}  GPS_Long: {dmodel.gps_longitude.ToString()} GPS_Lang: {dmodel.gps_latitude.ToString()}");
                }
                if (dmodel.emergency == 2)
                {
                    MessageBox.Show($"{usertripped}  GPS_Long: {dmodel.gps_longitude.ToString()} GPS_Lang: {dmodel.gps_latitude.ToString()}");
                }

            }

            SeriesCollection = new SeriesCollection
            {
                //creting new lineSeries inside the Series collection with a followed title
                new LineSeries()
                {
                    Title = "HeartbeatData",
                    //Setting the values of our chart, ChartValues with ObservableValue type and getting the HeartRate list with a ObservableValue type
                    Values = new ChartValues<ObservableValue>(Heart_rate)
                },

                new LineSeries()
                {
                    Title = "OxygenLevelData",
                    Values = new ChartValues<ObservableValue>(Oxygen_level)
                },

                new LineSeries()
                {
                    Title = "GPS Long: ",
                    Values= new ChartValues<ObservableValue>(GPS_long),
                    PointGeometry = null
                },

                new LineSeries()
                {
                    Title = "GPS Lat: ",
                    Values= new ChartValues<ObservableValue>(GPS_lang),
                    PointGeometry = null

                },

                new LineSeries()
                {
                    Title = "Emergency: ",
                    Values= new ChartValues<ObservableValue>(Emergency),
                    PointGeometry = null
                }
            };

            //setting new values of series collection to our series
            myLineChart.Series = SeriesCollection;

            //hide the unneccessary serries
            LineSeries GPS_LongHide = (myLineChart.Series[2] as LineSeries);
            GPS_LongHide.Stroke = System.Windows.Media.Brushes.Transparent;
            GPS_LongHide.Fill = System.Windows.Media.Brushes.Transparent;

            LineSeries GPS_LangHide = (myLineChart.Series[3] as LineSeries);
            GPS_LangHide.Stroke = System.Windows.Media.Brushes.Transparent;
            GPS_LangHide.Fill = System.Windows.Media.Brushes.Transparent;

            LineSeries EmergencyHide = (myLineChart.Series[4] as LineSeries);
            EmergencyHide.Stroke = System.Windows.Media.Brushes.Transparent;
            EmergencyHide.Fill = System.Windows.Media.Brushes.Transparent;
            
            var dateArray = time_Labels.ToArray();
            //creating dateArray to store the date's and time's from date_labels list with a conversion of date_labels to date_arrays
            if (flag == 0)
            {
                dateArray = time_Labels.ToArray();
            }
            else
            {
                dateArray = date_Labels.ToArray();
            }
            
            
            myLineChart.AxisX[0].Labels = dateArray;

            //setting the Labels of our chart to dateArray
            Labels = dateArray;

            //setting the data context
            DataContext = this;
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
