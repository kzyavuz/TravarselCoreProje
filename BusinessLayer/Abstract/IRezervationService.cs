using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRezervationService: IGenericService<Rezarvation>
    {
        List<Rezarvation> GetListRzervationByPendingReservations(int id);
        List<Rezarvation> GetListRzervationByAcceptted(int id);
        List<Rezarvation> GetListRzervationByPast(int id);
    }
}
