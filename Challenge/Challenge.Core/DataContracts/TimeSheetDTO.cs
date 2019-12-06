using System;
using System.Runtime.Serialization;

namespace Challenge.Core.DataContracts
{
    [DataContract]
    public class TimeSheetDTO
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "dateWorked")]
        public DateTime DateWorked { get; set; }
        [DataMember(Name = "hoursWorked")]
        public int HoursWorked { get; set; }
    }
}
