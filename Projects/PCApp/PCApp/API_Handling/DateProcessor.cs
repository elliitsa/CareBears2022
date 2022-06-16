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
        public int userID { get; set; }
        public DateTime date { get; set; }

        public async static Task<List<DataModel>> LoadDate(int userID, DateTime date)
        {
            DataModel dateTest = new DataModel();

            string url = "";



            List<DataModel> ilist = new List<DataModel>();

            url = $"http://82.75.86.150/getdata.php?appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&uid={userID}&date={date.ToString("yyyy-MM-dd")}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    ilist = JsonConvert.DeserializeObject<List<DataModel>>(data);
                    //dataTest = ilist[];

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
