using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RezervationManager : IRezervationService
    {
        private readonly IRezervationDal _rezervationDal;

        public RezervationManager(IRezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }

        public List<Rezarvation> TGetListRezervationByAcceptted(int id)
        {
            return _rezervationDal.GetListRezervationByAcceptted(id);
        }

        public List<Rezarvation> TGetListRezervationByPast(int id)
        {
            return _rezervationDal.GetListRezervationByPast(id);
        }

        public List<Rezarvation> TGetListRezervationByPendingReservations(int id)
        {
            return _rezervationDal.GetListRezervationByPendingReservations(id);
        }

        public void TAdd(Rezarvation t)
        {
            _rezervationDal.Insert(t);
        }

        public void TDelete(Rezarvation t)
        {
            _rezervationDal.Delete(t);
        }

        public void TGetAccessConfirm(int id)
        {
            _rezervationDal.GetAccessConfirm(id);
        }

        public Rezarvation TGetByID(int id)
        {
            return _rezervationDal.GetByID(id);
        }

        public List<Rezarvation> TGetList()
        {
            return _rezervationDal.GetList();
        }

        public void TGetRejectConfirm(int id)
        {
            _rezervationDal.GetRejectConfirm(id);
        }

        public int TMyGetRezervationCount(int id)
        {
            return _rezervationDal.MyGetRezervationCount(id);
        }

        public void TUpdate(Rezarvation t)
        {
            _rezervationDal.Update(t);
        }

        public List<Rezarvation> TGetListRezervationReject(int id)
        {
            return _rezervationDal.GetListRezervationReject(id);
        }
    }
}
