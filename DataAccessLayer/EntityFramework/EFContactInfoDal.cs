using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactInfoDal : GenericRepository<ContactInfo>, IContactInfoDal
    {
        public void ContactInfoChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactInfo> GetListContactInfoByFalse()
        {
            using (var context = new Context())
            {
                var values = context.ContactInfos.Where(x => x.MessageStatus == false).ToList();
                return values;
            }
        }

        public List<ContactInfo> GetListContactInfoByTrue()
        {
            using (var context = new Context())
            {
                var values = context.ContactInfos.Where(x => x.MessageStatus == true).ToList();
                return values;
            }
        }
    }
}
