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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void TAdd(Annonuncement t)
        {
            _announcementDal.Insert(t);
        }

        public void TDelete(Annonuncement t)
        {
            _announcementDal.Delete(t);
        }

        public Annonuncement TGetByID(int id)
        {
            return _announcementDal.GetByID(id);
        }

        public List<Annonuncement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public void TUpdate(Annonuncement t)
        {
            _announcementDal.Update(t);
        }
    }
}
