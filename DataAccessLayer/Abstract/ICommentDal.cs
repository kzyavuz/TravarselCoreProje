﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentDestination();
        public List<Comment> GetListCommentDestinationAndUser(int id);
        public List<Comment> MyGetListComment(int id);
        public int MyGetListCommentCount(int id);

        void ConvertStandOutByComment(int id);
        void ConvertHighlightByComment(int id);
    }
}
