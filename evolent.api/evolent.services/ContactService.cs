using System;
using System.Collections.Generic;
using System.Linq;
using evolent.Entities;
using evolent.data;
using evolent.data.UnitOfWork;


namespace evolent.services
{
    public class ContactService : IContactService, IDisposable
    {
        #region Private variables

        private IUnitOfWork _unitOfWork;

        #endregion

        #region Contstructors

        /// <summary>
        /// Initiallise the private variables.
        /// </summary>
        public ContactService()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Insert the new contact it to the database.
        /// </summary>
        /// <param name="contact">Contact obejcts needs to be inserted.</param>
        /// <returns>An Id of newly inserted contact.</returns>
        public int Add(ContactModel contact)
        {
            Contact contactToAdd = contact.ToContactDataModel();
            _unitOfWork.ContactRepository.Insert(contactToAdd);
            _unitOfWork.Commit();
            return contactToAdd.ContactId;
        }

        /// <summary>
        /// Get all contacts (excluding deleted)
        /// </summary>
        /// <returns>List of contacts</returns>
        public IEnumerable<ContactModel> GetAll()
        {
            var contacts = _unitOfWork.ContactRepository.GetAll().Where(c => !c.IsDeleted);
            return contacts.ToContactModelList();
        }

        /// <summary>
        /// Edit the the contacts.
        /// </summary>
        /// <param name="contact">Contact objects which needs to be edited.</param>
        /// <returns>Returns true if data updated successfully else false.</returns>
        public bool Edit(ContactModel contact)
        {
            bool isUpdated = false;
            if (contact == null)
                return isUpdated;
            var contactToUpdate = _unitOfWork.ContactRepository.GetByKey(contact.ContactId);
            if (contactToUpdate != null)
            {
                contactToUpdate = contact.ToContactDataModel();
                _unitOfWork.ContactRepository.Update(contactToUpdate);
                _unitOfWork.Commit();
                isUpdated = true;
            }
            else
                isUpdated = false;
            return isUpdated;
        }

        /// <summary>
        /// Delete the contact based on the primary key provided.
        /// </summary>
        /// <param name="contactID">ContactID whose data need to be deleted.</param>
        /// <returns>Returns true if successfully deleted else false.</returns>
        public bool Delete(int contactID)
        {
            bool isDeleted = false;
            if (contactID > 0)
            {
                var contactToDelete = _unitOfWork.ContactRepository.GetByKey(contactID);
                if (contactToDelete != null)
                {
                    contactToDelete.IsDeleted = true;
                    _unitOfWork.ContactRepository.Update(contactToDelete);
                    _unitOfWork.Commit();
                    isDeleted = true;
                }
            }
            return isDeleted;
        }

        /// <summary>
        /// Gets the contact details baesd on the contact id provided.
        /// </summary>
        /// <param name="contactID">ContactId</param>
        /// <returns>Contact object with details</returns>
        public ContactModel GetDetails(int contactID)
        {
            var contact = _unitOfWork.ContactRepository.GetByKey(contactID);
            if (contact != null)
                return contact.ToContactModel();
            return null;
        }

        /// <summary>
        /// Dispose the object of UnitOfWork class.
        /// </summary>
        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
        
    }
}
