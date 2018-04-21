using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evolent.Entities;

namespace evolent.web.Services
{
    public interface IContactService
    {
        #region Public methods

        /// <summary>
        /// Get all (not deleted) contacts.
        /// </summary>
        /// <returns>List of Contacts</returns>
        Task<IEnumerable<ContactModel>> GetAll();

        /// <summary>
        /// Get contact by its id.
        /// </summary>
        /// <param name="contactId">CotactId</param>
        /// <returns>Contact object if found else null</returns>
        Task<ContactModel> GetContactById(int contactId);

        /// <summary>
        /// Add new contact into the database.
        /// </summary>
        /// <param name="contactEntity"></param>
        /// <returns></returns>
        Task<int> Add(ContactModel contactEntity);

        /// <summary>
        /// Update the contact object.
        /// </summary>
        /// <param name="contactEntity">Contact object</param>
        /// <returns>Retrun true if succesfully updated else false</returns>
        Task<bool> Update(ContactModel contactEntity);

        /// <summary>
        /// Delete the contact based on the contactId
        /// </summary>
        /// <param name="contactId">ContactId</param>
        /// <returns>Retruns true if deleted succesfully else false.</returns>
        Task<bool> Delete(int contactId);

        #endregion 
    }
}
