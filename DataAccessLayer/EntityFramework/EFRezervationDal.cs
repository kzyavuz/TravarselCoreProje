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
    public class EFRezervationDal : GenericRepository<Rezarvation>, IRezervationDal
    {
        public List<Rezarvation> GetListRzervationByAcceptted(int id)
        {
            using (var context = new Context())
            {
                return context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Status == "Onaylandı" && x.AppUserID == id).ToList();
            }
        }

        public List<Rezarvation> GetListRzervationByPast(int id)
        {
            using (var context = new Context())
            {
                return context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Status == "Geçmis Rezervasyon" && x.AppUserID == id).ToList();
            }
        }

        public List<Rezarvation> GetListRzervationByPendingReservations(int id)
        {
            using (var context = new Context())
            {
                return context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Status == "Onay Bekliyor" && x.AppUserID == id).ToList();
            }
        }
    }
}
