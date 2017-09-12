namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("SoftwareDevelopers")]
    public partial class SoftwareDeveloper
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        public virtual ICollection<Software> Software { get; set; } = new HashSet<Software>();
    }
}
