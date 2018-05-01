using evolent.Entities;
using evolent.web.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace evolent.web.Services
{
    public class ContactService : BaseService, IContactService
    {
        #region Private variables
        private string apiURI = string.Format("{0}/Contact", BaseURL);
        #endregion
        

        public async Task<Entities.ContactModel> GetContactById(int contactId)
        {
            using (HttpClient objHttpClient = EvolentHelpers.GetHttpClient(string.Empty))
            {
                //HttpResponseMessage response = objHttpClient.GetAsync(string.Format("{0}", apiURI)).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    var contactString = await response.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<ContactModel>(contactString);
                //}

                return JsonConvert.DeserializeObject<ContactModel>(
                await objHttpClient.GetStringAsync(string.Format("{0}/{1}", apiURI, contactId.ToString())));
            }
        }

        public async Task<int> Add(ContactModel contactEntity)
        {
            using (HttpClient objHttpClient = EvolentHelpers.GetHttpClient(string.Empty))
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contactEntity), Encoding.UTF8, "application/json");

                var contactID = await objHttpClient.PostAsync(apiURI + "/Post", content).ContinueWith((postTask) =>
                { 
                    return JsonConvert.DeserializeObject<int>(postTask.Result.Content.ReadAsStringAsync().Result);
                });
                return contactID;
            }
        }

        public async Task<bool> Update(Entities.ContactModel contactEntity)
        {
            using (HttpClient objHttpClient = EvolentHelpers.GetHttpClient(string.Empty))
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contactEntity), Encoding.UTF8, "application/json");

                var contactUpdated = await objHttpClient.PutAsync(apiURI + "/Put", content).ContinueWith((postTask) =>
                {
                    return JsonConvert.DeserializeObject<ContactModel>(postTask.Result.Content.ReadAsStringAsync().Result);
                });
                return contactUpdated != null && contactUpdated.ContactId > 0 ? true : false;
            }
        }

        public async Task<bool> Delete(int contactId)
        {
            using (HttpClient objHttpClient = EvolentHelpers.GetHttpClient(string.Empty))
            {
                HttpResponseMessage reponse = await objHttpClient.DeleteAsync(string.Format("{0}/{1}", apiURI, contactId));
                return JsonConvert.DeserializeObject<bool>(reponse.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<IEnumerable<ContactModel>> GetAll()
        {
            using (HttpClient objHttpClient = EvolentHelpers.GetHttpClient(string.Empty))
            {
                //HttpResponseMessage response = objHttpClient.GetAsync(string.Format("{0}", apiURI)).Result;  
                //if (response.IsSuccessStatusCode) 
                //{
                //    var contactListstring = await response.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<List<ContactModel>>(contactListstring);
                //}

                return JsonConvert.DeserializeObject<List<ContactModel>>(
                await objHttpClient.GetStringAsync(string.Format("{0}", apiURI)));
            }
        }
    }
}