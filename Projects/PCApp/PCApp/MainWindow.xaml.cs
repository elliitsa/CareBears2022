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

namespace PCApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDatabaseData_Click(object sender, RoutedEventArgs e)
        {
            DatabaseData databaseData = new DatabaseData();
            databaseData.Show();

            this.Close();
        }

        private void btnSDCardData_Click(object sender, RoutedEventArgs e)
        {
            SD_CardData sdcardData = new SD_CardData();
            sdcardData.Show();

            this.Close();
        }

        private void btnRealtimeData_Click(object sender, RoutedEventArgs e)
        {
            RealTimeData realtimeData = new RealTimeData();
            realtimeData.Show();

            this.Close();
        }
    }
}
