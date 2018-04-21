using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evolent.web.Models;
using evolent.Entities;

namespace evolent.web.Helpers
{
    public static class MapperHelper
    {
        /// <summary>
        /// This method convert the ContactModel to the contactViewModel. Copies the property. Returns the list.
        /// </summary>
        /// <param name="contactModelList">List of ContactModel objects</param>
        /// <returns>List of ContactViewModel objects</returns>
        public static List<ContactViewModel> ToContactViewModelList(this IEnumerable<ContactModel> contactModelList)
        {
            var contactViewModelList = new List<ContactViewModel>();
            if (contactModelList != null && contactModelList.Count() > 0)
            {
                foreach (var contactModel in contactModelList)
                {
                    contactViewModelList.Add(new ContactViewModel()
                {
                    ContactId = contactModel.ContactId,
                    FirstName = contactModel.FirstName,
                    LastName = contactModel.LastName,
                    PhoneNumber = contactModel.PhoneNumber,
                    Email = contactModel.Email,
                    Status = contactModel.Status
                });
                }
            }
            return contactViewModelList;
        }

        /// <summary>
        /// This method converts the ContactViewModel object to the ContactModel. Copies the property. 
        /// </summary>
        /// <param name="contactViewModelList">ContactViewModel object</param>
        /// <returns>ContactModel object</returns>
        public static List<ContactModel> ToContactModelList(this IEnumerable<ContactViewModel> contactViewModelList)
        {
            var contactModelList = new List<ContactModel>();
            if (contactViewModelList != null && contactViewModelList.Count() > 0)
            {
                foreach (var contactViewModel in contactViewModelList)
                {
                    contactModelList.Add(new ContactModel()
                    {
                        ContactId = contactViewModel.ContactId,
                        FirstName = contactViewModel.FirstName,
                        LastName = contactViewModel.LastName,
                        PhoneNumber = contactViewModel.PhoneNumber,
                        Email = contactViewModel.Email,
                        Status = contactViewModel.Status
                    });
                }
            }
            return contactModelList;
        }

        /// <summary>
        /// This method converts ContactModel object to ContactViewModel object. Copies propery values.
        /// </summary>
        /// <param name="contactModel">ContactModel object</param>
        /// <returns>ContactViewModel object</returns>
        public static ContactViewModel ToContactViewModel(this ContactModel contactModel)
        {
            return new ContactViewModel()
                    {
                        ContactId = contactModel.ContactId,
                        FirstName = contactModel.FirstName,
                        LastName = contactModel.LastName,
                        PhoneNumber = contactModel.PhoneNumber,
                        Email = contactModel.Email,
                        Status = contactModel.Status
                    };
        }

        /// <summary>
        /// This method converts ContactViewModel to the ContactModel object. Copies property values.
        /// </summary>
        /// <param name="contactViewModel">ContactViewModel object</param>
        /// <returns>ContactModel object</returns>
        public static ContactModel ToContactModel(this ContactViewModel contactViewModel)
        {
            return new ContactModel()
                    {
                        ContactId = contactViewModel.ContactId,
                        FirstName = contactViewModel.FirstName,
                        LastName = contactViewModel.LastName,
                        PhoneNumber = contactViewModel.PhoneNumber,
                        Email = contactViewModel.Email,
                        Status = contactViewModel.Status
                    };
        }
    }
}