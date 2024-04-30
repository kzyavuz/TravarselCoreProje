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
        CommentManager commentManager = new CommentManager(new EFCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.TGetDestionID(id);
            return View(values);
        }
    }
}
