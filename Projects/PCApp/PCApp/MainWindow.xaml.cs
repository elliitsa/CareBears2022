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
            this.user_id = user_id;

            InitializeComponent();

        }

        
        
        private async Task<List<DataModel>> LoadDatas(int user_id)
        {
            Console.WriteLine(user_id);
            List<DataModel> data = await DataProcessor.LoadData(user_id);
            //UserModel user = new UserModel();

            //userID = user.id_user;

            //if (user_id == )
            //{
                /*DatabaseData databaseDataWindow = new DatabaseData(data);
                databaseDataWindow.Show();*/

                //closing the mainwindow
                //this.Close();
            //}
            
            return data;
        
        }

        private async void btnDatabaseData_Click(object sender, RoutedEventArgs e)
        {
           // DataModel data = new DataModel();
            //UserModel user = new UserModel();
            List<DataModel> dlist;

            //Session["user_ID"] = user.id_user;

            //int userID = 0;

            Task<List<DataModel>> dataTask = LoadDatas(user_id);
            
            dlist = await dataTask;

            DatabaseData databaseData = new DatabaseData(dlist);
            databaseData.Show();

            this.Close();
        }

        private void btnSDCardData_Click(object sender, RoutedEventArgs e)
        {
            SD_CardData sdcardData = new SD_CardData();
            sdcardData.Show();

            this.Close();
        }

        private async void btnRealtimeData_Click(object sender, RoutedEventArgs e)
        {
            // DataModel data = new DataModel();
            //UserModel user = new UserModel();
            List<DataModel> dlist;

            //Session["user_ID"] = user.id_user;

            //int userID = 0;

            Task<List<DataModel>> dataTask = LoadDatas(user_id);

            dlist = await dataTask;

            DatabaseData databaseData = new DatabaseData(dlist);
            databaseData.Show();

            this.Close();
        }
    }
}
