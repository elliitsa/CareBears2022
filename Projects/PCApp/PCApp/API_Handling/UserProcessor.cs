using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace PCApp
{
    public class UserProcessor
    {
        
        public async static Task<UserModel> LoadUser(string userName, string Password)
        {
            //creating a new list with a type of UserModel for storing the converted data from JSON
            List<UserModel> ilist = new List<UserModel>();
            //creating a new instance of UserModel called userTest
            UserModel userTest= new UserModel();

            //declaration of string called url for storing our url link
            string url = "";
            //url with the sensor data with the provided input of user
            url = $"http://82.75.86.150/getuser.php?appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&username={userName}&password={Password}";
            //creating a hhtp response with a using statement for disposing the request after its complete
            //response getting the user async with the given url
            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if response was successful
                if(response.IsSuccessStatusCode)
                {
                    //read the content of response with a async and read it in string, store it in a string called Messageuser
                    string Messageuser = await response.Content.ReadAsStringAsync();
                    //using the JsonConvert function to Deserialize and get the user data from messageuser with a type of UserModel list and store it in ilist
                    ilist = JsonConvert.DeserializeObject<List<UserModel>>(Messageuser);
                   
                    userTest.id_user = ilist[1].id_user;
                    userTest.state = ilist[0].state;

                    return userTest;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
