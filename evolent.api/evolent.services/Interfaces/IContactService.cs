using evolent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolent.services
{
    public interface IContactService
    {
        /// <summary>
        /// Insert the new contact it to the database.
        /// </summary>
        /// <param name="contact">Contact obejcts needs to be inserted.</param>
        /// <returns>An Id of newly inserted contact.</returns>
        int Add(ContactModel contact);

        /// <summary>
        /// Get all contacts (excluding deleted)
        /// </summary>
        /// <returns>List of contacts</returns>
        IEnumerable<ContactModel> GetAll();

        /// <summary>
        /// Edit the the contacts.
        /// </summary>
        /// <param name="contact">Contact objects which needs to be edited.</param>
        /// <returns>Returns true if data updated successfully else false.</returns>
        bool Edit(ContactModel contact);

        /// <summary>
        /// Delete the contact based on the primary key provided.
        /// </summary>
        /// <param name="contactID">ContactID whose data need to be deleted.</param>
        /// <returns>Returns true if successfully deleted else false.</returns>
        bool Delete(int contactID);

        /// <summary>
        /// Gets the contact details baesd on the contact id provided.
        /// </summary>
        /// <param name="contactID">ContactId</param>
        /// <returns>Contact object with details</returns>
        ContactModel GetDetails(int contactID);
    }
}
