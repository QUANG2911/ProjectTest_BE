using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class UserAccount
    {
        [Key]
        public int Stt { get; set; }
        
        [MaxLength(3)]
        public string? IdCustomer { get; set; }
        [MaxLength(3)]
        public string? IdStaff { get; set; }
        public required string AccountType { get; set; }

        public required string Pass { get; set; }
        
        public required string UserName { get; set; }

        [ForeignKey("IdCustomer")]
        public Customer? Customer { get; set; }
    }
}
