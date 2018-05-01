using evolent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evolent.data.Repository;

namespace evolent.services
{
    public interface IContactService : IGenericRepository<ContactModel>
    {
       //If any contact specific method (i.e other than the generic methods) is present then it will be added over here. 
       //e.g. Get contact by email address.
    }
}
