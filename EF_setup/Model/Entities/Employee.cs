using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_setup.Model.Entities
{
    [Table("Employee")]

    public class Employee
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Column("employee_name")]

        public string Name { get; set; }
        [Column("department")]

        public string Department { get; set; }
        [Column("salary")]

        public decimal Salary { get; set; }
        [Column("years_experience")]

        public int YearsExperience { get; set; }
    }
}
