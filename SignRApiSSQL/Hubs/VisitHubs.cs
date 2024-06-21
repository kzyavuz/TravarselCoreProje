using Microsoft.AspNetCore.SignalR;
using SignRApiSSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignRApiSSQL.Hubs
{
    public class VisitHubs : Hub
    {
        private readonly VisitService _visitService;

        public VisitHubs(VisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task GetVisitToList()
        {
            await Clients.All.SendAsync("CallVisit", _visitService.GetVisitModelList());
        }
    }
}
