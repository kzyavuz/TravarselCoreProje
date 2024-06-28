using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactInfoDal : IGenericDal<ContactInfo>
    {
        List<ContactInfo> GetListContactInfoByTrue();
        List<ContactInfo> GetListContactInfoByFalse();

        public List<ContactInfo> MyGetListContactInfo(int id);
        public int MyGetListContactCount(int id);

        void ContactInfoChangeToFalse(int id);
    }
}
