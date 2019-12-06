using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Core.DataContracts;
using Challenge.Core.Models;
using Challenge.Infrastructure.Repositories.Interfaces;
using Challenge.Infrastructure.Services.Interfaces;

namespace Challenge.Infrastructure.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        public TimeSheetService(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        } 

        public async Task<List<TimeSheet>> CreateTimeSheetAsync(List<TimeSheet> dataClass)
        {
            foreach (var data in dataClass)
            {
                await _timeSheetRepository.CreateAsync(data);
            }
            return dataClass;
        }

        public async Task<TimeSheet> DeleteTimeSheetAsync(int id)
        {
            var timesheet = await _timeSheetRepository.GetByIdAsync(id);
            if (timesheet != null)
            {
                await _timeSheetRepository.DeleteAsync(timesheet);
            }
            return timesheet;
        }

        public async Task<TimeSheetEmployeeDTO> GetTimeSheetsByEmployeeAsync(int id)
        {
            TimeSheetEmployeeDTO result = new TimeSheetEmployeeDTO();
            IEnumerable<TimeSheet> timesheets = new List<TimeSheet>();
            timesheets = await _timeSheetRepository.GetAllByFilterAsync(x => x.Employee.Id == id, null, includeProperties: "Employee");
            if(timesheets != null && timesheets.Count() > 0)
            {
                result.employee = timesheets.Select(x => new Employee()
                {
                    Id = x.Employee.Id,
                    FirstName = x.Employee.FirstName,
                    LastName = x.Employee.LastName
                }).FirstOrDefault();
                result.timeSheets = timesheets.Select(x => new TimeSheetDTO() 
                { 
                    Id = x.Id, 
                    DateWorked = x.DateWorked, 
                    HoursWorked = x.HoursWorked 
                }).ToList();
            }
            return result;
        }

        public async Task<TimeSheet> GetTimeSheetByIdAsync(int id)
        {
            return await _timeSheetRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TimeSheet>> GetTimeSheetsAsync()
        {
            return await _timeSheetRepository.GetAllAsync(includeProperties: "Employee");
        }

        public async Task<TimeSheet> UpdateOrCreateTimeSheetAsync(int id, TimeSheet dataClass)
        {
            var timesheetExist = await _timeSheetRepository.GetByIdAsync(id);
            if (timesheetExist != null)
            {
                timesheetExist.DateWorked = dataClass.DateWorked;
                timesheetExist.HoursWorked = dataClass.HoursWorked;
                timesheetExist.Employee = dataClass.Employee;
                await _timeSheetRepository.UpdateAsync(timesheetExist);
                return timesheetExist;
            }
            else
            {
                await _timeSheetRepository.CreateAsync(dataClass);
                return dataClass;
            }
        }
    }
}
