using Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Context
{

    public class ChallengeContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<TimeSheet> TimeSheet { get; set; }

        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        { }
    }
}
