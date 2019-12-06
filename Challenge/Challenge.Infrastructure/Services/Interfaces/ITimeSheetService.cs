using Challenge.Core.DataContracts;
using Challenge.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Services.Interfaces
{
    public interface ITimeSheetService
    {
        Task<IEnumerable<TimeSheet>> GetTimeSheetsAsync();
        Task<TimeSheetEmployeeDTO> GetTimeSheetsByEmployeeAsync(int id);
        Task<TimeSheet> GetTimeSheetByIdAsync(int id);
        Task<List<TimeSheet>> CreateTimeSheetAsync(List<TimeSheet> dataClass);
        Task<TimeSheet> UpdateOrCreateTimeSheetAsync(int id, TimeSheet dataClass);
        Task<TimeSheet> DeleteTimeSheetAsync(int id);
    }
}
