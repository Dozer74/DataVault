namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class Node
    {
        public int Id { get; set; }
        
        [Required]
        public short GpuCount { get; set; }

        [Required]
        [Index]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }
        
        [Required]
        public virtual GPU Gpu { get; set; }

        public virtual RenderTask RenderTask { get; set; }
    }
}
