using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCApp.API_Handling
{
    public class DateProcessor
    {
        //declaring public int userID
        public int userID { get; set; }
        //declaring public DateTime date for getting the selected input date
        public DateTime date { get; set; }
        //creating a async static task with a type of DataModel list with the logged in user_id and selected input date
        public async static Task<List<DataModel>> LoadDate(int userID, DateTime? date)
        {
            //creating empty url string
            string url = "";
            //creting a list with a type DataModel called ilist for storing our Choosen Date date
            List<DataModel> ilist = new List<DataModel>();
            //intializing the url string with the given input selected date by the user
            url = $"http://82.75.86.150/getdata.php?appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&uid={userID}&date={date?.ToString("yyyy-MM-dd")}";

            //creating a hhtp response with a using statement for disposing the request after its complete
            //response getting the date_date async with the given url
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if response was successful
                if (response.IsSuccessStatusCode)
                {
                    //read the content of response with a async and read it in string, store it in a string called data
                    string data = await response.Content.ReadAsStringAsync();
                    //using the JsonConvert function to Deserialize and get the selected date data from data with a type of DataModel list and store it in ilist
                    ilist = JsonConvert.DeserializeObject<List<DataModel>>(data);
                    //return ilist
                    return ilist;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
