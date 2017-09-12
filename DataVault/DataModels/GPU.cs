namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class GPU
    {
        public GPU()
        {
            NodeSet = new HashSet<Node>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        public short Passmark { get; set; }

        [Required]
        public GpuManufactor Manufactor { get; set; }

        public virtual ICollection<Node> NodeSet { get; set; }
    }
}
