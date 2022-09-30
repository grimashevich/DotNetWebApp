﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Data
{
    [Table("Employee")]
    public class Employee
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }

        [ForeignKey(nameof(EmployeeType))]
        public Guid EmployeeTypeId { get; set; }

        [Column, StringLength(255)]
        public string FirstName { get; set; }

        [Column, StringLength(255)]
        public string Surname { get; set; }

        [Column, StringLength(255)]
        public string Patronymic { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        
        public EmployeeType EmployeeType { get; set; }
        public Department Department { get; set; }
    }
}
