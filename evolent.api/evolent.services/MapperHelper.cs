using evolent.data;
using evolent.Entities;
using System.Collections.Generic;

namespace evolent.services
{
    public static class MapperHelper
    {
        /// <summary>
        /// This method convert the ContactModel object to the Contact (Database entity). Copies all the property values.
        /// </summary>
        /// <param name="contactModel">ContactModel object</param>
        /// <returns>Contact object</returns>
        public static Contact ToContactDataModel(this ContactModel contactModel)
        {
            var contactDataModel = new Contact()
            {
                ContactId = contactModel.ContactId,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                PhoneNumber = contactModel.PhoneNumber,
                Email = contactModel.Email,
                IsActive = contactModel.Status
            };
            return contactDataModel;
        }

        /// <summary>
        /// This method convert the Contact object to the ContactModel. Copies all the property values.
        /// </summary>
        /// <param name="contactData">Contact object</param>
        /// <returns>ContactModel object</returns>
        public static ContactModel ToContactModel(this Contact contactData)
        {
            var contactDataModel = new ContactModel()
            {
                ContactId = contactData.ContactId,
                FirstName = contactData.FirstName,
                LastName = contactData.LastName,
                PhoneNumber = contactData.PhoneNumber,
                Email = contactData.Email,
                Status = contactData.IsActive
            };
            return contactDataModel;
        }

        /// <summary>
        /// This method convert the Contact object to the ContactModel. Copies all the property values. And returns the list.
        /// </summary>
        /// <param name="contactDataList">List of Contact object</param>
        /// <returns>List of ContactModel object</returns>
        public static IEnumerable<ContactModel> ToContactModelList(this IEnumerable<Contact> contactDataList)
        {
            List<ContactModel> contactModelList = null;
            if (contactDataList != null)
            {
                contactModelList = new List<ContactModel>();
                foreach (var contactData in contactDataList)
                {
                    contactModelList.Add(new ContactModel()
                    {
                        ContactId = contactData.ContactId,
                        FirstName = contactData.FirstName,
                        LastName = contactData.LastName,
                        PhoneNumber = contactData.PhoneNumber,
                        Email = contactData.Email,
                        Status = contactData.IsActive
                    });
                }
            }
            return contactModelList;
        }
    }
}
