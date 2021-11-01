using KidsCenter.Models;
using KidsCenter.Repository;
using KidsCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenter.Controllers
{
    public class CourseMembershipController : Controller
    {
        CourseMembershipRepository courseMembershipRepository = new CourseMembershipRepository();

        // GET: CourseMembership
        public ActionResult Index()
        {
            //List<CourseMembershipModel> courseMemberships = courseMembershipRepository.GetAllMemberships();
            List<CourseMembershipViewModel> courseMembershipViewModels = courseMembershipRepository.GetAllMembershipsVM();
            return View("Index", courseMembershipViewModels);
        }

        // GET: CourseMembership/Details/5
        public ActionResult Details(int id)
        {
            CourseMembershipModel courseMembershipModel = courseMembershipRepository.GetMembershipByID(id);
          
            return View("Details", courseMembershipModel);
        }

        // GET: CourseMembership/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CourseMembership/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CourseMembershipModel courseMembershipModel = new CourseMembershipModel();
                UpdateModel(courseMembershipModel);
                courseMembershipRepository.InsertMembership(courseMembershipModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: CourseMembership/Edit/5
        public ActionResult Edit(int id)
        {
            CourseMembershipModel courseMembershipModel = courseMembershipRepository.GetMembershipByID(id);
            return View("Edit", courseMembershipModel);
        }

        // POST: CourseMembership/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CourseMembershipModel courseMembershipModel = new CourseMembershipModel();
                UpdateModel(courseMembershipModel);
                courseMembershipRepository.UpdateMembership(courseMembershipModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: CourseMembership/Delete/5
        public ActionResult Delete(int id)
        {
            CourseMembershipModel courseMembershipModel = courseMembershipRepository.GetMembershipByID(id);
            return View("Delete", courseMembershipModel);
        }

        // POST: CourseMembership/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                courseMembershipRepository.DeleteMembership(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
