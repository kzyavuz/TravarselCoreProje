using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationsGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x=> x.DestinationID == id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetListLastDestination()
        {
            using (var c = new Context())
            {
                var values = c.Destinations.Take(4).Include(x => x.Guide).OrderByDescending(x => x.DestinationID).ToList();
                return values;
            }
        }
    }

}
