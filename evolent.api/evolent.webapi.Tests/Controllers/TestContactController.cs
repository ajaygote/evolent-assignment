using evolent.data.UnitOfWork;
using evolent.Entities;
using evolent.services;
using evolent.webapi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;


namespace evolent.webapi.Tests.Controllers
{
    [TestClass]
    public class TestContactController
    { 
        private IContactService _contactService;

        public TestContactController()
        { 
            _contactService = new ContactService(new UnitOfWork());
        }

        [TestMethod]
        public void Get_ShouldReturnAllContacts()
        {
            var testContacts = _contactService.GetAll();
            var controllerResult = new ContactController(_contactService).Get() as OkNegotiatedContentResult<IEnumerable<ContactModel>>;
            Assert.IsNotNull(controllerResult);
            Assert.AreEqual(testContacts.Count(), controllerResult.Content.Count());
        }

        [TestMethod]
        public void GetContact_ShouldReturnContact()
        {
            var testContacts = _contactService.GetAll() as List<ContactModel>;
            var controllerResult = new ContactController(_contactService).Get(1) as OkNegotiatedContentResult<ContactModel>;
            Assert.IsNotNull(controllerResult);
            Assert.AreEqual(testContacts[0].FirstName, controllerResult.Content.FirstName);
        }
    }
}
