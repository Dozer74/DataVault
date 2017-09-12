namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class GpuManufactor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
