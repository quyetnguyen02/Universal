using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NavigationViewDemo.config;
using NavigationViewDemo.Entity;
using Newtonsoft.Json;

namespace NavigationViewDemo.Service
{
   public class AccountService
    {
        public async Task<bool> Process(Account account)
        {
            var jsonString = JsonConvert.SerializeObject(account);

            HttpClient httpClient = new HttpClient();
            HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, ApiConfig.MediaType);
            var result = await httpClient.PostAsync($"{ApiConfig.ApitDomain}{ApiConfig.AccountPath}",contentToSend);
            if(result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }










    }
}
