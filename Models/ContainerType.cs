﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectTest.Models
{
    public class ContainerType
    {
        [Key]
        [MaxLength(1)]
        public required string IdTypeContainer { get; set; }
        [MaxLength(50)]
        public required string NameTypeContainer { get; set; }

        public ICollection<Container>? Containers { get; set; }
    }
}
