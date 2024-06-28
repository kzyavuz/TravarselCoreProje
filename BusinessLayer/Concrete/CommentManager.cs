using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommnetService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetDestionID(int id)
        {
            return _commentDal.GetListFiltre(x => x.DestinationID == id);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public List<Comment> GetListCommentDestination()
        {
            return _commentDal.GetListCommentDestination();
        }

        public List<Comment> TGetListCommentDestinationAdUser(int id)
        {
            return _commentDal.GetListCommentDestinationAndUser(id);
        }

        public List<Comment> TMyGetListComment(int id)
        {
            return _commentDal.MyGetListComment(id);
        }

        public int TMyGetListCommentCount(int id)
        {
            return _commentDal.MyGetListCommentCount(id);
        }

        public void TConvertStandOutByComment(int id)
        {
            _commentDal.ConvertHighlightByComment(id);
        }

        public void TConvertHighlightByComment(int id)
        {
            _commentDal.ConvertStandOutByComment(id);
        }
    }
}
