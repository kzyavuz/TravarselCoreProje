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
    public class EFCatagoryDal : GenericRepository<Catagory>, ICatagoryDal
    {
        private readonly Context _c;

        public EFCatagoryDal(Context c)
        {
            _c = c;
        }
        public void ConvertFalseByCatagory(int id)
        {
            var values = _c.Catagories.Find(id);
            values.Status = false;
            values.StandOut = false;
            _c.Update(values);
            _c.SaveChanges();

        }

        public void ConvertTrueByCatagory(int id)
        {
            var values = _c.Catagories.Find(id);
            values.Status = true;
            _c.Update(values);
            _c.SaveChanges();
        }

        public void ConvertTrueStandOutByCatagory(int id)
        {
            var values = _c.Catagories.Find(id);
            values.StandOut = true;
            _c.Update(values);
            _c.SaveChanges();

        }

        public void ConvertFalseStandOutByCatagory(int id)
        {
            var values = _c.Catagories.Find(id);
            values.StandOut = false;
            _c.Update(values);
            _c.SaveChanges();
        }
    }
}
