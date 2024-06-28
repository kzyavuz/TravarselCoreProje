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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void TConvertFalseByGuid(int id)
        {
            _guideDal.ConvertTrueByGuid(id);
        }

        public void TConvertHighlightByGuid(int id)
        {
            _guideDal.ConvertStandOutByGuid(id);
        }

        public void TConvertStandOutByGuid(int id)
        {
            _guideDal.ConvertHighlightByGuid(id);
        }

        public void TConvertTrueByGuid(int id)
        {
            _guideDal.ConvertFalseByGuid(id);
        }

        public void TDelete(Guide t)
        {
            _guideDal.Delete(t);
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public void TUpdate(Guide t)
        {
            _guideDal.Update(t);
        }
    }
}
