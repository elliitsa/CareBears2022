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
            List<UserModel> ilist = new List<UserModel>();

            UserModel userTest= new UserModel();


            string url = "";

            url = $"http://82.75.86.150/getuser.php?appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&username={userName}&password={Password}";

            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    string Messageuser = await response.Content.ReadAsStringAsync();
                    ilist= JsonConvert.DeserializeObject<List<UserModel>>(Messageuser);
                 
                   
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
