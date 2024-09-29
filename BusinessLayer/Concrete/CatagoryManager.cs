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
    public class CatagoryManager : ICatagoryService
    {
        private readonly ICatagoryDal _catagoryDal;

        public CatagoryManager(ICatagoryDal catagoryDal)
        {
            _catagoryDal = catagoryDal;
        }

        public void ConvertFalseStandOutByCatagory(int id)
        {
            _catagoryDal.ConvertTrueStandOutByCatagory(id);
        }

        public void ConvertTrueStandOutByCatagory(int id)
        {
            _catagoryDal.ConvertFalseStandOutByCatagory(id);
        }

        public void TAdd(Catagory t)
        {
            _catagoryDal.Insert(t);
        }

        public void TConvertFalseByCatagory(int id)
        {
            _catagoryDal.ConvertTrueByCatagory(id);
        }

        public void TConvertTrueByCatagory(int id)
        {
            _catagoryDal.ConvertFalseByCatagory(id);
        }

        public void TDelete(Catagory t)
        {
            _catagoryDal.Delete(t);
        }

        public Catagory TGetByID(int id)
        {
            return _catagoryDal.GetByID(id);
        }

        public List<Catagory> TGetList()
        {
            return _catagoryDal.GetList();
        }

        public void TUpdate(Catagory t)
        {
            _catagoryDal.Update(t);
        }
    }
}
