using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Core.Models
{
    public class TimeSheet : IEntity
    {
        public DateTime DateWorked { get; set; }
        public int HoursWorked { get; set; }

        public Employee Employee { get; set; }
        public int Id { get; set; }
    }
}
