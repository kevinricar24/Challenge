using Challenge.Core.Models;
using Challenge.Infrastructure.Context;
using Challenge.Infrastructure.Repositories.Interfaces;

namespace Challenge.Infrastructure.Repositories
{
    public class TimeSheetRepository : GenericRepository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(ChallengeContext context) : base(context)
        {

        }
    }
}
