using Challenge.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Services.Interfaces
{

    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> CreateEmployeeAsync(List<Employee> dataClass);
        Task<Employee> UpdateOrCreateEmployeeAsync(int id, Employee dataClass);
        Task<Employee> DeleteEmployeeAsync(int id);
    }


}
