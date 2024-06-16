using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommnetService _commnetService;

        public CommentController(ICommnetService commnetService)
        {
            _commnetService = commnetService;
        }

        public IActionResult Index()
        {
            var values = _commnetService.GetListCommentDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commnetService.TGetByID(id);
            _commnetService.TDelete(values);
            return RedirectToAction("Admin", "Comment", "Index");
        }
    }
}
