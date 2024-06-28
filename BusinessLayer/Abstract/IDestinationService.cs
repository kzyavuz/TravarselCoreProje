using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public Destination TGetDestinationsGuide(int id);
        public List<Destination> TGetListLastDestination(int sayac);
        public List<Destination> TGetListByCatagoryDestination(int? categoryId, bool status);
        public List<Destination> TGetListByFilterDestinations(int? categoryId, string city, string district, DateTime? date);
        public int TMyGetDestinationCount(bool status);
    }
}
