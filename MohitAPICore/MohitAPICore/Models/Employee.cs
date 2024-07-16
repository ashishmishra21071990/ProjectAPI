using System.ComponentModel.DataAnnotations;

namespace MohitAPICore.Models
{
    public class Employee
    {
        [Key]
        public int EID { get; set; }
        public string ?Name { get; set; }
        public int Age { get; set; }
        public string ?MobileNo { get; set; }
        public string ?City { get; set; }
        public string ?Post { get; set; }
        public int Salary { get; set; }
    }
}
