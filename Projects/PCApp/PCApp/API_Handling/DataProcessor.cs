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
        public int userID { get; set; }

        public async static Task<List<DataModel>> LoadData(int userID)
        {
            DataModel dataTest = new DataModel();

            string url = "";

            List<DataModel> ilist = new List<DataModel>();

            url = $"http://82.75.86.150/getdata.php?appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&uid={userID}";  

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
