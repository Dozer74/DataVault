using System;
using System.IO;
using System.Linq;

namespace DataVault.DataModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class GPU
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Range(0, Int16.MaxValue)]
        public short Passmark { get; set; }

        [Required]
        public GpuManufactor Manufactor { get; set; }

        public virtual ICollection<Node> NodeSet { get; set; } = new HashSet<Node>();


        public override string ToString()
        {
            return $"{Manufactor?.Name} {Model}";
        }
    }
}