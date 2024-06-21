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
    class About2Manager : IAbout2Service
    {
        private readonly IAboutDal2 _aboutDal2;

        public About2Manager(IAboutDal2 aboutDal2)
        {
            _aboutDal2 = aboutDal2;
        }

        public void TAdd(About2 t)
        {
            _aboutDal2.Insert(t);
        }

        public void TDelete(About2 t)
        {
            _aboutDal2.Delete(t);
        }

        public About2 TGetByID(int id)
        {
            return _aboutDal2.GetByID(id);
        }

        public List<About2> TGetList()
        {
            return _aboutDal2.GetList();
        }

        public void TUpdate(About2 t)
        {
            _aboutDal2.Update(t);
        }
    }
}
