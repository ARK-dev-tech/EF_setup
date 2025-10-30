using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_setup.Model.Entities
{
    [Table("Students")] //define table definition, this is what it will map as
    public class Student

    {
        [Column("id")] //setting column mappings
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //for making identity key, generates as new record is added

        public int Id { get; set; }


        [Column("name")]
        public string Name { get; set; }


        [Column("age")]
        public string Age { get; set; }


        [Column("grade_id")]
        public int Grade_Id { get; set; } //is foriegn key

        [ForeignKey("Grade_Id")]
        public Grade Grade { get; set; } //will define in grade
    }
}
