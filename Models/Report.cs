using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Report
    {
        [Key]
        public int stt { get; set; }

        public required string NOIDUNG { get; set; } 

        public required string USERID { get; set; }

        public required DateTime THOIGIANQUERY { get; set; }

    }
}
