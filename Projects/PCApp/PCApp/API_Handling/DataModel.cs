using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCApp
{
    public class DataModel
    {
        //diffrent types of data variables for storing our data we get from http request
        public int id_user_data { get; set; }
        public int id_user { get; set; }
        public double heart_rate { get; set; }
        public double oxygen_level { get; set; }
        public double gps_latitude { get; set; }
        public double gps_longitude { get; set; }
        public int emergency { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
