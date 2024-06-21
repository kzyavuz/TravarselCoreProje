using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignRApiSSQL.DAL;
using SignRApiSSQL.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignRApiSSQL.Model
{

    public class VisitService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitHubs> _hubContext;

        public VisitService(Context context, IHubContext<VisitHubs> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IQueryable<Visit> GetList()
        {
            return _context.Visits.AsQueryable();
        }

        public async Task SaveVisit(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisit", GetVisitModelList());
        }
        public List<VisitModel> GetVisitModelList()
        {
            List<VisitModel> visitModels = new List<VisitModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select tarih,[1],[2],[3],[4],[5] from (select[City],CityVisitCount,Cast([VisitDate] as Date) as tarih from Visitors) as visitTable Pivot (Sum(CityVisitCount) For City in([1],[2],[3],[4],[5])) as pivottable order by tarih asc";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        VisitModel visitModel = new VisitModel();
                        visitModel.VisitDate = read.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(read[x]))
                            {
                                visitModel.Counts.Add(0);
                            }
                            else
                            {
                                visitModel.Counts.Add(read.GetInt32(x));
                            }
                        });
                        visitModels.Add(visitModel);
                    }
                }
                _context.Database.CloseConnection();
                return visitModels;
            }
        }
    }
}
