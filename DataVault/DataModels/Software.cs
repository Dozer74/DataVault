namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class Software
    {
        public Software()
        {
            RenderTaskSet = new HashSet<RenderTask>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Version { get; set; }
        
        public virtual ICollection<RenderTask> RenderTaskSet { get; set; }

        [Required]
        public virtual SoftwareDeveloper SoftwareDeveloper { get; set; }
    }
}
