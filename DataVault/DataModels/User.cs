using System.ComponentModel.DataAnnotations.Schema;

namespace DataVault.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [Index]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"([\w\d\-]+(?:\.[\w\d\-]+)*)@((?:[\w\d\-]+\.)+\w{2,5})",ErrorMessage = "����������� ����� ������� � �������� �������")]
        public string Email { get; set; }

        [Range(0, Int32.MaxValue,ErrorMessage = "������ ������������ �� ����� ���� ������������� ��� ��������� Int32.MaxValue")]
        public decimal Balance { get; set; } = 5;
        
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    }
}
