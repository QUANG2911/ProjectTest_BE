using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Report
    {
        [Key]
        public int stt { get; set; }

        public required string NoiDung { get; set; } 

        public required string UserID { get; set; }

        public required DateTime ThoiGianQuery { get; set; }

    }
}
