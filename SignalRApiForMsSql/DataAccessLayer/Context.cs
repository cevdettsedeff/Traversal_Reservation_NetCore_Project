using Microsoft.EntityFrameworkCore;

namespace SignalRApiForMsSql.DataAccessLayer
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Visitor> Visitors { get; set; }   
    }
}
