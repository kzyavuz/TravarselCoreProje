﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Abstract
{
    public interface IGuideService : IGenericService<Guide> 
    {
        void TConvertTrueByGuid(int id);

        void TConvertFalseByGuid(int id);
        void TConvertStandOutByGuid(int id);

        void TConvertHighlightByGuid(int id);
    }
}
