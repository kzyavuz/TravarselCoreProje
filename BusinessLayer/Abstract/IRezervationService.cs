using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRezervationService: IGenericService<Rezarvation>
    {
        List<Rezarvation> TGetListRezervationByPendingReservations(int id);
        List<Rezarvation> TGetListRezervationByAcceptted(int id);
        List<Rezarvation> TGetListRezervationByPast(int id);
        public List<Rezarvation> TGetListRezervationReject(int id);
        public int TMyGetRezervationCount(int id);
        public void TGetRejectConfirm(int id);
        public void TGetAccessConfirm(int id);

    }
}
