﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public List<ContactInfo> MyGetListContactInfo(int id)
        {
            return _contactInfoDal.MyGetListContactInfo(id);
        }

        public void TAdd(ContactInfo t)
        {
            _contactInfoDal.Insert(t);
        }

        public void TContactInfoChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ContactInfo t)
        {
            _contactInfoDal.Delete(t);
        }

        public ContactInfo TGetByID(int id)
        {
            return _contactInfoDal.GetByID(id);
        }

        public List<ContactInfo> TGetList()
        {
            return _contactInfoDal.GetList();
        }

        public List<ContactInfo> TGetListContactInfoByFalse()
        {
            return _contactInfoDal.GetListContactInfoByFalse();
        }

        public List<ContactInfo> TGetListContactInfoByTrue()
        {
            return _contactInfoDal.GetListContactInfoByTrue();
        }

        public int TMyGetListContactCount(int id)
        {
            return _contactInfoDal.MyGetListContactCount(id);
        }

        public void TUpdate(ContactInfo t)
        {
            _contactInfoDal.Update(t);
        }
    }
}
