using Challenge.Core.Models;
using Challenge.Infrastructure.Context;
using Challenge.Infrastructure.Repositories.Interfaces;

namespace Challenge.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ChallengeContext context) : base(context)
        {

        }
    }
}
