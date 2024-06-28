using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRezervationDal: IGenericDal<Rezarvation>
    {
        List<Rezarvation> GetListRezervationByPendingReservations(int id);
        List<Rezarvation> GetListRezervationByAcceptted(int id);
        List<Rezarvation> GetListRezervationByPast(int id);
        List<Rezarvation> GetListRezervationReject(int id);
        public int MyGetRezervationCount(int id);
        public void GetRejectConfirm(int id);
        public void GetAccessConfirm(int id);
    }
}
