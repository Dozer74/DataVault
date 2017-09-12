namespace DataVault.DataModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Software
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Version { get; set; }
        
        public virtual ICollection<RenderTask> RenderTasks { get; set; } = new HashSet<RenderTask>();

        [Required]
        public virtual SoftwareDeveloper SoftwareDeveloper { get; set; }
    }
}
