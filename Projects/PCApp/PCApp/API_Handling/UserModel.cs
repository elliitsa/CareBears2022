using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCApp
{
    public class UserModel
    {
        //public string variables for storing the user's state and id data which we get from http request
        public string state { get; set; }
        public int id_user { get; set; }

        public string username { get; set; }
        public string password { get; set; }
    }
}
