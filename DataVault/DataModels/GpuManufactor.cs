using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataVault.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class GpuManufactor
    {
        
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Name { get; set; }
        
    }
}
