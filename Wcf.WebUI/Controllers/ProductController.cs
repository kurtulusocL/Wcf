using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wcf.Business.Abstract;
using Wcf.Entities.Concrete;

namespace Wcf.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }
        public ActionResult Detail(int? id)
        {
            return View(_productService.GetById(id));
        }
        public ActionResult Create()
        {
            ViewBag.Categories = _productService.GetCategoryForProduct();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(model);
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Categories = _productService.GetCategoryForProduct();
            var updateProduct = _productService.GetById(id);
            if (updateProduct!=null)
            {
                return View(updateProduct);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model);
                return RedirectToAction(nameof(Edit));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int? id)
        {
            var deleteProduct = _productService.GetById(id);
            if (deleteProduct != null)
            {
                _productService.Delete(deleteProduct);
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "There was an error";
            return RedirectToAction(nameof(Index));
        }
    }
}