using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommnetService _commnetService;

        public CommentController(ICommnetService commnetService)
        {
            _commnetService = commnetService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment c)
        {
            c.DateTime = Convert.ToDateTime(DateTime.Now);
            c.State = true;
            _commnetService.TAdd(c);
            return RedirectToAction("DestinationDetails", "Destination", new { id = c.DestinationID });
        }
    }
}
