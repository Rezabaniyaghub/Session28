using Domain.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Persentetion.Controllers
{
    public class ClassRoomController : Controller
    {
        #region [Ctor]
        private readonly IClassRoomService _classRoomService;
        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        } 
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index(int schoolId)
        {
            ViewBag.schoolId = schoolId;
            var list = _classRoomService.GetAll(schoolId);
             return View(list);
        }

        #endregion

        #region Create
        [HttpGet]
        public ViewResult Create(int SchoolId)
        {
            var model = _classRoomService.GetNewModelForCreate(SchoolId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassRoomModel model)
        {
            var result = _classRoomService.Insert(model);
            if (result.IsSuccess)
            {
                return Redirect($"Index?schoolId={model.SchoolId}");
            }
            else
            {
                ViewBag.Message = result.Message;
                model.SchoolSelectList = _classRoomService.GetNewModelForCreate(model.SchoolId).SchoolSelectList;
                return View(model);
            }

        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _classRoomService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassRoomModel model)
        {
            var result = _classRoomService.Update(model);
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
            var model = _classRoomService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ClassRoomModel model)
        {
            var result = _classRoomService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);
        }
        #endregion
    }
}
