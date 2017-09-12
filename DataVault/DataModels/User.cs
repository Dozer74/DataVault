namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class User
    {
        public User()
        {
            RenderTaskSet = new HashSet<RenderTask>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public decimal Balance { get; set; }
        
        public virtual ICollection<RenderTask> RenderTaskSet { get; set; }
    }
}
