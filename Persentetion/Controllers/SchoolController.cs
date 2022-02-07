using Domain.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Persentetion.Controllers
{
        #region Ctor
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var list = _schoolService.GetAll();
            return View(list);
        }

        #endregion

        #region Create
        [HttpGet]
        public ViewResult Create()
        {
            return View(new SchoolModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolModel model)
        {
            var result = _schoolService.Insert(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(model);
            }

        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _schoolService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolModel model)
        {
            var result = _schoolService.Update(model);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _schoolService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(SchoolModel model)
        {
            var result = _schoolService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);
        } 
        #endregion
    }
}
