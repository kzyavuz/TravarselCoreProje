using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICatagoryDal : IGenericDal<Catagory>
    {
        public void ConvertTrueByCatagory(int id);
        public void ConvertFalseByCatagory(int id);
        public void ConvertTrueStandOutByCatagory(int id);
        public void ConvertFalseStandOutByCatagory(int id);
    }
}
