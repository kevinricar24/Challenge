using Challenge.Core.Models;
using Challenge.Infrastructure.Repositories.Interfaces;
using Challenge.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> CreateEmployeeAsync(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                await _employeeRepository.CreateAsync(employee);
            }
            return employees;

        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(employee);
            }
            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public async Task<Employee> UpdateOrCreateEmployeeAsync(int id, Employee dataClass)
        {
            var employeeExist = await _employeeRepository.GetByIdAsync(id);
            if (employeeExist != null)
            {
                employeeExist.FirstName = dataClass.FirstName;
                employeeExist.LastName = dataClass.LastName;
                await _employeeRepository.UpdateAsync(employeeExist);
                return employeeExist;
            }
            else
            {
                await _employeeRepository.CreateAsync(dataClass);
                return dataClass;
            }
        }
    }
}
