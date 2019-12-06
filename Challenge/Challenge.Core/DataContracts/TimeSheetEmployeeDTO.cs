using Challenge.Core.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Challenge.Core.DataContracts
{
    [DataContract]
    public class TimeSheetEmployeeDTO
    {
        [DataMember(Name ="employee")]
        public Employee employee { get; set; }
        [DataMember(Name = "timesheets")]
        public List<TimeSheetDTO> timeSheets { get; set; }
    }
}
