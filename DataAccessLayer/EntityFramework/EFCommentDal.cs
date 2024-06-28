using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly Context _context;

        public EFCommentDal(Context context)
        {
            _context = context;
        }

        public void ConvertHighlightByComment(int id)
        {
            var values = _context.Comments.Find(id);
            values.State = false;
            _context.Update(values);
            _context.SaveChanges();
        }

        public void ConvertStandOutByComment(int id)
        {
            var values = _context.Comments.Find(id);
            values.State = true;
            _context.Update(values);
            _context.SaveChanges();
        }

        public List<Comment> GetListCommentDestination()
        {
            return _context.Comments.Include(x => x.Destination).Include(x => x.AppUser).OrderByDescending(x=>x.DateTime).ToList();
        }

        public List<Comment> GetListCommentDestinationAndUser(int id)
        {
            return _context.Comments.Where(x => x.DestinationID == id).Include(x => x.AppUser).OrderByDescending(x => x.DateTime).ToList();
        }

        public List<Comment> MyGetListComment(int id)
        {

            return _context.Comments.Include(x => x.AppUser).Include(x => x.Destination).OrderByDescending(x => x.DateTime).Where
                (x => x.AppUserID == id).ToList();
        }

        public int MyGetListCommentCount(int id)
        {
            return _context.Comments.Count(x => x.AppUserID == id);
        }
    }
}
