using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.ViewComponents.Comment
{
    public class _CommentList: ViewComponent
    {
        private readonly ICommnetService _commnetService;

        public _CommentList(ICommnetService commnetService)
        {
            _commnetService = commnetService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commnetService.TGetListCommentDestinationAdUser(id);
            return View(values);
        }
    }
}
