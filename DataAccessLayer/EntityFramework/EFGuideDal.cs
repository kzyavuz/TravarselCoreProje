using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFGuideDal : GenericRepository<Guide>, IGuideDal
    {
        private readonly Context _context;

        public EFGuideDal(Context context)
        {
            _context = context;
        }

        public void ConvertFalseByGuid(int id)
        {
            var values = _context.Guides.Find(id);
            values.Status = false;
            values.StandOut = false;
            _context.Update(values);
            _context.SaveChanges();     
        }

        public void ConvertHighlightByGuid(int id)
        {
            var values = _context.Guides.Find(id);
            values.StandOut = false;
            _context.Update(values);
            _context.SaveChanges();
        }

        public void ConvertStandOutByGuid(int id)
        {
            var values = _context.Guides.Find(id);
            values.StandOut = true;
            _context.Update(values);
            _context.SaveChanges();
        }

        public void ConvertTrueByGuid(int id)
        {
            var values = _context.Guides.Find(id);
            values.Status = true;
            _context.Update(values);
            _context.SaveChanges();
        }
    }
}
