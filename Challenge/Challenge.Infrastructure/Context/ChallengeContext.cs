using Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Context
{

    public class ChallengeContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<TimeSheet> TimeSheets { get; set; }

        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        { }
    }
}
