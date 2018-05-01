using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evolent.web.Services;
using evolent.web.Helpers;
using System.Threading.Tasks;
using System.Net;
using evolent.web.Models;
using evolent.Entities;

namespace evolent.web.Controllers
{
    public class ContactController : Controller
    {
        #region Varaibles
        private IContactService _contactService;
        #endregion
        #region Constructor
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        #endregion


        // GET: /Contact/
        public async Task<ActionResult> Index()
        {
            var contactList = await _contactService.GetAll(); 
            return View(contactList.ToContactViewModelList());
        }

        //
        // GET: /Contact/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id.HasValue) 
            {
                var contact = await _contactService.GetContactById(id.Value);
                if(contact!=null)
                    return View(contact.ToContactViewModel());
                else
                    return HttpNotFound(string.Format("Contact with the id{0} is not found",id.Value));
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
        }

        // GET: /Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactViewModel contactViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactModel contact = contactViewModel.ToContactModel();
                    if (await _contactService.Add(contact) > 0) 
                            return RedirectToAction("Index");
                }      
            }
            catch
            {
                return View();
            }
            return View(contactViewModel); 
        }

        //
        // GET: /Contact/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id.HasValue)
            {
                var contact = await _contactService.GetContactById(id.Value);
                if (contact != null)
                    return View(contact.ToContactViewModel());
                else
                    return HttpNotFound(string.Format("Contact with the id{0} is not found", id.Value));
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        //
        // POST: /Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ContactViewModel contactViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactModel contact = contactViewModel.ToContactModel();
                    if (await _contactService.Update(contact))
                        return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contact/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id.HasValue)
            {
                var contact = await _contactService.GetContactById(id.Value);
                if (contact != null)
                    return View(contact.ToContactViewModel());
                else
                    return HttpNotFound(string.Format("Contact with the id{0} is not found", id.Value));
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        //
        // POST: /Contact/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if(id > 0 && await _contactService.Delete(id))
                 return RedirectToAction("Index");
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
