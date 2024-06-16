using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommnetService: IGenericService<Comment>
    {
        List<Comment> TGetDestionID(int id);
        List<Comment> GetListCommentDestination();
    }
}
