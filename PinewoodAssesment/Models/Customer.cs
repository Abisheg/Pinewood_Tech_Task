using PinewoodAssessment.Repositories;

namespace PinewoodAssessment.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public byte ClientType { get; set; }

       
    }
}
