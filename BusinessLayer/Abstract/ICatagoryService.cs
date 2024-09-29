    using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICatagoryService : IGenericService<Catagory>
    {
        public void TConvertTrueByCatagory(int id);
        public void TConvertFalseByCatagory(int id);
        public void ConvertFalseStandOutByCatagory(int id);
        public void ConvertTrueStandOutByCatagory(int id);

    }
}
