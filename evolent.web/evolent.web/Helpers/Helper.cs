using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace evolent.web.Helpers
{
    public class EvolentHelpers
    {
        public static string GetWebConfigValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                value = string.Empty;
            }
            return value;
        }

        public static HttpClient GetHttpClient(string accessToken)
        {
            HttpClient objHttpClient = new HttpClient();  
            objHttpClient.DefaultRequestHeaders.Accept.Clear();
            objHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return objHttpClient;
        }
    }
}