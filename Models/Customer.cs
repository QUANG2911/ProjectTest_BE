using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectTest.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(3)]
        public required string IdCustomer { get; set; }
        [MaxLength(50)]
        public required string CustomerName { get; set; }

        [MaxLength(10)]
        public required string CustomerPhone { get; set; }
        [MaxLength(13)]
        public required string TaxCode { get; set; }

        public ICollection<Container>? Containers { get; set; }

        public ICollection<UserAccount>? UserAccounts { get; set; }
    }
}
