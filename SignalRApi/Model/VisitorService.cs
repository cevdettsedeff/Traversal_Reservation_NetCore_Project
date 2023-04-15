using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DataAccessLayer;
using SignalRApi.Hubs;
using SignalRApi.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable(); //sql sorgularını tolist ile yazamayız.
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", "aaa");
        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using(var command = _context.Database.GetDbConnection().CreateCommand()) //pivot table için sql sorguları yazacağımız kısım burası
            {
                command.CommandText = "query sorgu";
                command.CommandType =System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            visitorChart.Counts.Add(reader.GetInt32(x));
                        });
                        visitorCharts.Add(visitorChart); // liste formatındaki yere visitorchart ekledik.
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}
