using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        private readonly Context _c;

        public EFDestinationDal(Context c)
        {
            _c = c;
        }

        public Destination GetDestinationsGuide(int id)
        {

            return _c.Destinations.Where(x => x.DestinationID == id).Include(x => x.Guide).FirstOrDefault();

        }

        public List<Destination> GetListLastDestination(int sayac)
        {
            var values = _c.Destinations.Take(sayac).Include(x => x.Guide).Include(x => x.Catagory).Where(x => x.Status == true).OrderByDescending(x => x.DestinationID).ToList();
            return values;

        }

        public List<Destination> GetListByCatagoryDestination(int? categoryId, bool status)
        {
            var values = _c.Destinations.Include(x => x.Guide).Include(x => x.Catagory).Where(x => x.Status == status).OrderByDescending(x => x.DestinationID).AsQueryable();

            if (categoryId.HasValue)
            {
                values = values.Where(x => x.CatagoryID == categoryId.Value);
            }
            return values.ToList();

        }

        public int MyGetDestinationCount(bool status)
        {
            return _c.Destinations.Where(x => x.Status == true).Count();

        }

        public List<Destination> GetListByFilterDestinations(int? categoryId, string city, string district, DateTime? date)
        {
            var query = _c.Destinations.Include(x => x.Guide).Include(x => x.Catagory).Where(x => x.Status == true).AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CatagoryID == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(x => x.City == city);
            }

            if (!string.IsNullOrEmpty(district))
            {
                query = query.Where(x => x.District == district);
            }

            if (date.HasValue)
            {
                query = query.Where(x => x.Date >= date.Value);
            }

            return query.OrderByDescending(x => x.DestinationID).ToList();

        }
    }
}
