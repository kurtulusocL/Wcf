using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wcf.Business.Abstract;
using Wcf.Entities.Concrete;

namespace Wcf.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }
        public ActionResult Detail(int? id)
        {
            return View(_categoryService.GetById(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(model);
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int? id)
        {
            var updateCategory = _categoryService.GetById(id);
            if (updateCategory != null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(model);
                return RedirectToAction(nameof(Edit));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int? id)
        {
            var deleteCategory = _categoryService.GetById(id);
            if (deleteCategory != null)
            {
                _categoryService.Delete(deleteCategory);
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "There was an error";
            return RedirectToAction(nameof(Index));
        }
    }
}