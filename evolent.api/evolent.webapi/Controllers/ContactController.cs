using System;
using System.Web.Http;
using evolent.Entities;
using evolent.services;

namespace evolent.webapi.Controllers
{
    public class ContactController : ApiController
    {
        #region Private variables

        private IContactService _contactService;

        #endregion

        #region Constructors

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        #endregion

        // GET api/contact
        [HttpGet]
        public IHttpActionResult Get()
        {
            var contactList = _contactService.GetAll();
            if (contactList != null)
                return Ok(contactList);
            return NotFound();
        }

        // GET api/contact/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var contact = _contactService.GetByKey(id);
            if (contact != null)
                return Ok(contact);
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                ContactModel result = _contactService.Insert(contact);
                if (result !=null && result.ContactId > 0)
                    return Ok(result);
                return InternalServerError(new Exception("Contact not created!"));
            }
            return BadRequest(ModelState);
        }

        // PUT api/contact/5
        public IHttpActionResult Put([FromBody]ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(contact);
                return Ok(contact); 
            }
            return BadRequest(ModelState);
        }

        // DELETE api/contact/5
        public IHttpActionResult Delete(int id)
        {
            if (id > 0)
            {
                _contactService.Delete(id);
                return Ok(true); 
            }
            return BadRequest("ID should be greater than 0.");
        }
    }
}
