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
        Task<IEnumerable<ContactModel>> GetAll();
        Task<ContactModel> GetContactById(int contactId);
        Task<int> Add(ContactModel contactEntity);
        Task<bool> Update(ContactModel contactEntity);
        Task<bool> Delete(int contactId);
    }
}
