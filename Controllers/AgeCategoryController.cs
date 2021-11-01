using KidsCenter.Models;
using KidsCenter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenter.Controllers
{
    public class AgeCategoryController : Controller
    {
        AgeCategoryRepository ageCategoryRepository = new AgeCategoryRepository();

        // GET: AgeCategory
        public ActionResult Index()
        {
            List<AgeCategoryModel> ageCategories = ageCategoryRepository.GetAllCategories();
            return View("Index", ageCategories);
        }

        // GET: AgeCategory/Details/5
        public ActionResult Details(int id)
        {
            AgeCategoryModel ageCategoryModel = ageCategoryRepository.GetAgeCategoryById(id);
            return View("Details", ageCategoryModel);
        }

        // GET: AgeCategory/Create
        public ActionResult Create()
        {
            return View("CreateAgeCategory");
        }

        // POST: AgeCategory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                AgeCategoryModel ageCategoryModel = new AgeCategoryModel();
                UpdateModel(ageCategoryModel);
                ageCategoryRepository.InsertAgeCategory(ageCategoryModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateAgeCategory");
            }
        }

        // GET: AgeCategory/Edit/5
        public ActionResult Edit(int id)
        {
            AgeCategoryModel ageCategoryModel = ageCategoryRepository.GetAgeCategoryById(id);
            return View("EditAgeCategory", ageCategoryModel);
        }

        // POST: AgeCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AgeCategoryModel ageCategoryModel = new AgeCategoryModel();
                UpdateModel(ageCategoryModel);
                ageCategoryRepository.UpdateAgeCategory(ageCategoryModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditAgeCategory");
            }
        }

        // GET: AgeCategory/Delete/5
        public ActionResult Delete(int id)
        {
            AgeCategoryModel ageCategoryModel = ageCategoryRepository.GetAgeCategoryById(id);
            return View("DeleteAgeCategory", ageCategoryModel);
        }

        // POST: AgeCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ageCategoryRepository.DeleteAgeCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteAgeCategory");
            }
        }
    }
}
