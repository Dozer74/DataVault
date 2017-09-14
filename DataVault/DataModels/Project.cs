using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataVault.DataModels
{
    public class Project
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public ICollection<RenderTask> RenderTasks { get; set; }
        
        [Required]
        public virtual User User { get; set; }
    }
}