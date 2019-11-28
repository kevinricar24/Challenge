using AutoWrapper.Wrappers;
using Challenge.Core.Models;
using Challenge.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Challenge.Web.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ApiResponse GetEmployees()
        {
            var response = _employeeService.GetEmployees();
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse> GetEmployeeByIdAsync(int id)
        {
            var response = await _employeeService.GetEmployeeByIdAsync(id);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ApiResponse> CreateEmployeeAsync([FromBody]List<Employee> employee)
        {
            var response = await _employeeService.CreateEmployeeAsync(employee);
            return ResponseAPI(response, (int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateOrCreateEmployeeAsync(int id, [FromBody]Employee person)
        {
            var response = await _employeeService.UpdateOrCreateEmployeeAsync(id, person);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> DeleteEmployeeAsync(int id)
        {
            var response = await _employeeService.DeleteEmployeeAsync(id);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        private ApiResponse ResponseAPI(object response, int statusCode)
        {
            try
            {
                return response != null ? new ApiResponse(response, statusCode) : new ApiResponse("person not found", (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new ApiException(message, (int)HttpStatusCode.InternalServerError);
            }
        }


    }
}