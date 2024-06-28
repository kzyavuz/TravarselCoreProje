using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Comment/")]
    [Authorize(Policy = "MemberPolicy")]
    public class CommentController : Controller
    {
        private readonly ICommnetService _commnetService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommnetService commnetService, UserManager<AppUser> userManager)
        {
            _commnetService = commnetService;
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var List_value = _commnetService.TMyGetListComment(values.Id);
            return View(List_value);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var values = _commnetService.TGetByID(id);
            return View(values);
        }
        
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Comment comment)
        {
            comment.DateTime = DateTime.Now;
            _commnetService.TUpdate(comment);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commnetService.TGetByID(id);
            _commnetService.TDelete(values);
            return RedirectToAction("Index");
        }


    }
}
