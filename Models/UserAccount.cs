using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class UserAccount
    {
        [Key]
        public int Stt { get; set; }
        
        [MaxLength(3)]
        public string? MaKH { get; set; }
        [MaxLength(3)]
        public string? MaNv { get; set; }
        public required string LoaiAccount { get; set; }

        public required string Pass { get; set; }
        
        public required string UserName { get; set; }

        [ForeignKey("MaKH")]
        public Customer? Customer { get; set; }
    }
}
