using System;
using System.Collections.Generic;
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
using System.Management;
using System.Windows.Navigation;

namespace PCApp
{
    /// <summary>
    /// Interaction logic for SD_CardData.xaml
    /// </summary>
    public partial class SD_CardData : Window
    {
        List<Card> cards = new List<Card>();
        List<Record> records = new List<Record>();
        string drive_path = "";
        public int user_id { get; set; }

        public SD_CardData(int user_id)
        {
            InitializeComponent();
            FindCards();
            init_cmb();

            this.user_id = user_id;
        }

        void init_cmb()
        {
            foreach (Card card in cards)
            {
                comboBox.Items.Add(card.Drive + " " + card.Name);
            }
        }

        void get_files()
        {
            if (comboBox.SelectedItem != null)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(comboBox.SelectedValue.ToString());

                // Get the root directory and print out some information about it.
                System.IO.DirectoryInfo dirInfo = di.RootDirectory;
                drive_path = dirInfo.Root.ToString();
                Console.WriteLine(dirInfo.Attributes.ToString());

                // Get the files in the directory and print out some information about them.
                System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");

                listBox.Items.Clear();

                foreach (System.IO.FileInfo fi in fileNames)
                {
                    listBox.Items.Add(fi.Name);
                }
            }
        }

        private void FindCards()
        {


            //  Get Disk Drives collection (Win32_DiskDrive)
            string queryDD = "SELECT * FROM Win32_DiskDrive";
            using (ManagementObjectSearcher searchDD = new ManagementObjectSearcher(queryDD))
            {
                ManagementObjectCollection colDiskDrives = searchDD.Get();
                foreach (ManagementBaseObject objDrive in colDiskDrives)
                {
                    //  Get associated Partitions collection (Win32_DiskDriveToDiskPartition)
                    string queryPart = $"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{objDrive["DeviceID"]}'}} WHERE AssocClass = Win32_DiskDriveToDiskPartition";
                    using (ManagementObjectSearcher searchPart = new ManagementObjectSearcher(queryPart))
                    {
                        ManagementObjectCollection colPartitions = searchPart.Get();
                        foreach (ManagementBaseObject objPartition in colPartitions)
                        {
                            //  Get associated Logical Disk collection (Win32_LogicalDiskToPartition)
                            string queryLD = $"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{objPartition["DeviceID"]}'}} WHERE AssocClass = Win32_LogicalDiskToPartition";
                            using (ManagementObjectSearcher searchLD = new ManagementObjectSearcher(queryLD))
                            {
                                ManagementObjectCollection colLogicalDisks = searchLD.Get();
                                foreach (ManagementBaseObject objLogicalDisk in colLogicalDisks)
                                    cards.Add(new Card($"{objLogicalDisk["DeviceID"]}", $"{objDrive["Caption"]}", $"{objLogicalDisk["VolumeName"]}"));
                            }
                        }
                    }
                }
            }
        }

        public class Record
        {
            //&0&heartrate=145&oxygen=85&latitude=183&longitude=98&emergency=1&date=13:06:2022&time=13:22
            public string id { get; set; }
            public string heartrate { get; set; }
            public string oxygen { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string emergency { get; set; }
            public string date { get; set; }
            public string time { get; set; }

            public Record(string id, string heartrate, string oxygen, string latitude, string longitude, string emergency, string date, string time)
            {
                this.id = id;
                this.heartrate = heartrate;
                this.oxygen = oxygen;
                this.latitude = latitude;
                this.longitude = longitude;
                this.emergency = emergency;
                this.date = date;
                this.time = time;
            }
        }
        public class Card
        {
            public string Drive { get; set; }
            public string Name { get; set; }
            public string Label { get; set; }

            public Card(string _drive, string _name, string _label)
            {
                Drive = _drive;
                Name = _name;
                Label = _label;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            get_files();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            records.Clear();
            string[] lines = System.IO.File.ReadAllLines($@"{drive_path}{listBox.SelectedItem}");
            foreach (string line in lines)
            {
                string[] items = line.Split('&');

                string uid = "";
                string heart = "";
                string oxygen = "";
                string latitude = "";
                string longitude = "";
                string emergency = "";
                string date = "";
                string time = "";

                foreach (var pair in items)
                {
                    int position = pair.IndexOf("=");
                    if (position < 0)
                        continue;
                    switch (pair.Substring(0, position))
                    {
                        case "uid":
                            uid = pair.Substring(position + 1);
                            break;
                        case "heartrate":
                            heart = pair.Substring(position + 1);
                            break;
                        case "oxygen":
                            oxygen = pair.Substring(position + 1);
                            break;
                        case "latitude":
                            latitude = pair.Substring(position + 1);
                            break;
                        case "longitude":
                            longitude = pair.Substring(position + 1);
                            break;
                        case "emergency":
                            emergency = pair.Substring(position + 1);
                            break;
                        case "date":
                            date = pair.Substring(position + 1);
                            break;
                        case "time":
                            time = pair.Substring(position + 1);
                            break;
                    }
                }
                Record record = new Record(uid, heart, oxygen, latitude, longitude, emergency, date, time);
                records.Add(record);

            }
            dataGrid.Items.Clear();
            foreach (var record in records)
            {
                dataGrid.Items.Add(record);

            }
            dataGrid.Items.Refresh();
        }
        private void btn_Back(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow(user_id);
            mainWindow.Show();

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
