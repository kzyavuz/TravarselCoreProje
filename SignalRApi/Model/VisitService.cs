using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.Model
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
            await _hubContext.Clients.All.SendAsync("CallVisitList", GetVisitModelList());
        }
        public List<VisitModel> GetVisitModelList()
        {
            List<VisitModel> visitModels = new List<VisitModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From crosstab('Select VisitDate, City, VisitCount From Visits Order By 1, 2') As ct (VisitDate date, a int , b int , c int , d int)";
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
                            visitModel.Counts.Add(read.GetInt32(x));
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
