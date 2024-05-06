using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());

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
            commentManager.TAdd(c);
            return RedirectToAction("DestinationDetails", "DestinationController1", new { id = c.DestinationID });
        }
    }
}
