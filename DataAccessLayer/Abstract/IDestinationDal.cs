using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {
        public Destination GetDestinationsGuide(int id);
        public List<Destination> GetListLastDestination(int sayac);
        public List<Destination> GetListByCatagoryDestination(int? categoryId, bool status);
        public List<Destination> GetListByFilterDestinations(int? categoryId, string city, string district, DateTime? date);
        public int MyGetDestinationCount(bool status);
    }
}
