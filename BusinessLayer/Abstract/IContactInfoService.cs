using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactInfoService : IGenericService<ContactInfo>
    {
        List<ContactInfo> TGetListContactInfoByTrue();
        List<ContactInfo> TGetListContactInfoByFalse();

        void TContactInfoChangeToFalse(int id);
    }
}
