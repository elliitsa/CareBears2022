using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCApp.API
{
    public class DataProcessor
    {
        //declaring public userID
        public int userID { get; set; }
        //creating a static task with a type of list DataModel with the logged in userid
        public async static Task<List<DataModel>> LoadData(int userID)
        {
            //creating a new instance of datamodel
            DataModel dataTest = new DataModel();
            //creating a empty string for storing our url
            string url = "";
            //creating a list called ilist with a type datamodel for storing our data converting from JSON
            List<DataModel> ilist = new List<DataModel>();
            //setting our url with the logged in userid
            url = $"http://82.75.86.150/getdata.php?appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&uid={userID}";
            //creating a hhtp response with a using statement for disposing the request after its complete
            //response getting the data async with the given url
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if response was succesful
                if (response.IsSuccessStatusCode)
                {
                    //read the content of response with a async and read it in string, store it in a string called data
                    string data = await response.Content.ReadAsStringAsync();
                    //using the JsonConvert function to Deserialize and get the sensor data from data with a type of DataModel list and store it in ilist
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
