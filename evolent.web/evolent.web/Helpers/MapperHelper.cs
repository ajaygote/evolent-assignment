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