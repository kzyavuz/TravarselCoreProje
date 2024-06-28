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
                var values = context.ContactInfos.Where(x => x.MessageStatus == false).OrderByDescending(x => x.MessageDate).ToList();
                return values;
            }
        }

        public List<ContactInfo> GetListContactInfoByTrue()
        {
            using (var context = new Context())
            {
                var values = context.ContactInfos.Where(x => x.MessageStatus == true).OrderByDescending(x => x.MessageDate).ToList();
                return values;
            }
        }

        public int MyGetListContactCount(int id)
        {
            using (var context = new Context())
            {
                return context.ContactInfos.Count(x => x.AppUserID == id);
            }
        }

        public List<ContactInfo> MyGetListContactInfo(int id)
        {
            using (var context = new Context())
            {
                var values = context.ContactInfos.Include(x => x.AppUser).OrderByDescending(x => x.MessageDate)
                .Where(x => x.AppUserID == id).ToList();
                return values;
            }
        }
    }
}
