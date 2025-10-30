using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_setup.Model.Entities
{
    [Table("Grade")]
    public class Grade
    {
        [Column("id")] 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("grade_name")]
        public string? GradeName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
