using AutoWrapper.Wrappers;
using Challenge.Core.DataContracts;
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
    public class TimeSheetsController : ControllerBase
    {
        private readonly ITimeSheetService _timesheetService;

        public TimeSheetsController(ITimeSheetService employeeService)
        {
            _timesheetService = employeeService;
        }

        [HttpGet]
        public async Task<ApiResponse> GetTimeSheetsAsync()
        {
            var response = await _timesheetService.GetTimeSheetsAsync();
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpGet("timesheetsbyemployee/{id}")]
        public async Task<ApiResponse> GetTimeSheetsByEmployeeAsync(int id)
        {
            var response = await _timesheetService.GetTimeSheetsByEmployeeAsync(id);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse> GetTimeSheetByIdAsync(int id)
        {
            var response = await _timesheetService.GetTimeSheetByIdAsync(id);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ApiResponse> CreateTimeSheetAsync([FromBody]List<TimeSheet> timesheet)
        {
            var response = await _timesheetService.CreateTimeSheetAsync(timesheet);
            return ResponseAPI(response, (int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateOrCreateTimeSheetAsync(int id, [FromBody]TimeSheet timesheet)
        {
            var response = await _timesheetService.UpdateOrCreateTimeSheetAsync(id, timesheet);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> DeleteEmployeeAsync(int id)
        {
            var response = await _timesheetService.DeleteTimeSheetAsync(id);
            return ResponseAPI(response, (int)HttpStatusCode.OK);
        }

        private ApiResponse ResponseAPI(object response, int statusCode)
        {
            try
            {
                return response != null ? new ApiResponse(response, statusCode) : new ApiResponse("timesheet not found", (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new ApiException(message, (int)HttpStatusCode.InternalServerError);
            }
        }

    }
}