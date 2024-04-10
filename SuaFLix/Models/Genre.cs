using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuaFLix.Models;
{
    [Table("")]
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public sbyte Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}