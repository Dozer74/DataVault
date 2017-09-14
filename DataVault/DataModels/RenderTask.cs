namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class RenderTask
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Index("Name")]
        public string Name { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int RenderTime { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public virtual ICollection<Node> Nodes { get; set; } = new HashSet<Node>();

        [Required]
        public virtual Software Software { get; set; }
        
        [Required]
        public virtual Project Project { get; set; }
    }
}