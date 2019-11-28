namespace Challenge.Core.Models
{
    public class Employee : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
    }
}
