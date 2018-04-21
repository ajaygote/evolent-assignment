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
        /// <summary>
        /// This helper method return the value of Appsettings from the web.config file.
        /// </summary>
        /// <param name="key">key of the app settings</param>
        /// <returns>value of the corresponding app settings</returns>
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

        /// <summary>
        /// Return the HTTPClient object used to call web api.
        /// </summary>
        /// <param name="accessToken">Access Token</param>
        /// <returns>HttpClient object</returns>
        public static HttpClient GetHttpClient(string accessToken)
        {
            HttpClient objHttpClient = new HttpClient();  
            objHttpClient.DefaultRequestHeaders.Accept.Clear();
            objHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return objHttpClient;
        }
    }
}