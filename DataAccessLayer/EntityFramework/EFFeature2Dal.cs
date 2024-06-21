using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFFeatureDal2 : GenericRepository<Feature2>, IFeatureDal2
    {
    }
}
