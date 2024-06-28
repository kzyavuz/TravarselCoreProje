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
        public List<Rezarvation> GetListRezervationByAcceptted(int id)
        {
            using (var context = new Context())
            {
                return context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Destination.Status == true && x.Status == "Onaylandı" && x.AppUserID == id).OrderByDescending(x=> x.RezarvationDate).ToList();
            }
        }

        public List<Rezarvation> GetListRezervationReject(int id)
        {
            using (var context = new Context())
            {
                var rezervations = context.Rezarvations.Include(r => r.Destination)
                    .Where(r => r.Status == "Reddedildi" && r.AppUserID == id).OrderByDescending(x => x.RezarvationDate)
                    .ToList();
                return rezervations;
            }
        }

        public List<Rezarvation> GetListRezervationByPast(int id)
        {
            using (var context = new Context())
            {
                var rezervations = context.Rezarvations.Include(r => r.Destination)
                    .Where(r => r.Status == "Geçmis Rezervasyon" && r.AppUserID == id).OrderByDescending(x => x.RezarvationDate)
                    .ToList();
                return rezervations;
            }
        }

        public List<Rezarvation> GetListRezervationByPendingReservations(int id)
        {
            using (var context = new Context())
            {
                return context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Destination.Status == true && x.Status == "Onay Bekliyor" && x.AppUserID == id).OrderByDescending(x => x.RezarvationDate).ToList();
            }
        }

        public int MyGetRezervationCount(int id)
        {
            using (var context = new Context())
            {
                return context.Rezarvations.Include(x => x.Destination).Where
                    (x => x.Status == "Geçmis Rezervasyon" && x.AppUserID == id).Count();
            }
        }

        public void GetAccessConfirm(int id)
        {
            using (var context = new Context())
            {
                var values = context.Rezarvations.Find(id);
                values.Status = "Onaylandı";
                context.Update(values);
                context.SaveChanges();
            }
        }

        public void GetRejectConfirm(int id)
        {
            using (var context = new Context())
            {
                var values = context.Rezarvations.Find(id);
                values.Status = "Reddedildi";
                context.Update(values);
                context.SaveChanges();
            }
        }
    }
}
