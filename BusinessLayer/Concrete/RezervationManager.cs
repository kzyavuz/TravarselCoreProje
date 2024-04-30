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
        IRezervationDal _rezervationDal;

        public RezervationManager(IRezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }

        public List<Rezarvation> GetListRzervationByAcceptted(int id)
        {
            return _rezervationDal.GetListRzervationByAcceptted(id);
        }

        public List<Rezarvation> GetListRzervationByPast(int id)
        {
            return _rezervationDal.GetListRzervationByPast(id);
        }

        public List<Rezarvation> GetListRzervationByPendingReservations(int id)
        {
            return _rezervationDal.GetListRzervationByPendingReservations(id);
        }

        public void TAdd(Rezarvation t)
        {
            _rezervationDal.Insert(t);
        }

        public void TDelete(Rezarvation t)
        {
            throw new NotImplementedException();
        }

        public Rezarvation TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rezarvation> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Rezarvation t)
        {
            throw new NotImplementedException();
        }
    }
}
