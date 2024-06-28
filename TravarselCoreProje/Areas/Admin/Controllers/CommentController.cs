using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment/")]
    [Authorize(Policy = "AdminPolicy")]
    public class CommentController : Controller
    {
        private readonly ICommnetService _commnetService;

        public CommentController(ICommnetService commnetService)
        {
            _commnetService = commnetService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _commnetService.GetListCommentDestination();
            return View(values);
        }

        [HttpPost]
        [Route("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commnetService.TGetByID(id);
            _commnetService.TDelete(values);
            return RedirectToAction("Admin", "Comment", "Index");
        }

        [Route("ConvertStandOut/{id}")]
        public IActionResult ConvertStandOut(int id)
        {
            _commnetService.TConvertStandOutByComment(id);
            return RedirectToAction("Index");
        }

        [Route("ConvertHighlight/{id}")]
        public IActionResult ConvertHighlight(int id)
        {
            _commnetService.TConvertHighlightByComment(id);
            return RedirectToAction("Index");
        }
    }
}
