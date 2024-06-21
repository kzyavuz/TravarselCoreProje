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
    public class Feature2Manager : IFeature2Service
    {
        private readonly IFeatureDal2 _featureDal2;

        public Feature2Manager(IFeatureDal2 featureDal2)
        {
            _featureDal2 = featureDal2;
        }

        public void TAdd(Feature2 t)
        {
            _featureDal2.Insert(t);
        }

        public void TDelete(Feature2 t)
        {
            _featureDal2.Delete(t);
        }

        public Feature2 TGetByID(int id)
        {
            return _featureDal2.GetByID(id);
        }

        public List<Feature2> TGetList()
        {
            return _featureDal2.GetList();
        }

        public void TUpdate(Feature2 t)
        {
            _featureDal2.Update(t);
        }
    }
}
