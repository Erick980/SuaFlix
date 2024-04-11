using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuaFLix.Models;

[Table("Movie")]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Display(Name = "Título Original")]
    [Required(ErrorMessage = "Por favor, informe o Título Original")]
    [StringLength(100, ErrorMessage = "O Título original deve possuir no máximo :")]
    public string OriginalTitle { get; set; }
   
    [Display(Name = "Título")]
    [Required(ErrorMessage = "Por favor, informe o Título")]
    [StringLength(100, ErrorMessage = "O Título deve possuir no máximo :")]
    public string Title { get; set; }
    
    [Display(Name = "Resumo")]
    [StringLength(8000, ErrorMessage = "O Resumo deve possuir no máximo :")]
    public string Synopsis { get; set; }

    [Column(TypeName = "Year")]
    [Display(Name = "Ano de Estreia")]
    public Int16 MovieYear { get; set; }
    [Column(TypeName = "smallint(3)")]
    [Display(Name = "Duração (em minutos)")]
    [Require(ErrorMessage = "Por favor, informe a Duração")]
    public Int16 Duration { get; set;}

    [Display(Name = "Classificação Etária")]
    [Require(ErrorMessage = "Por favor, informe a classificação Etária")]
    public sbyte AgeRating { get; set; }

    [StringLength(200)]
    [Display(Name = "Foto")]
    public string Image { get; set; }

    [NoteMapped]
    [Display(Name = "Duração")]
    public string HourDuration { get {
        return TimeSpan.FromMinutes(Duration).ToString(@"%h'h 'm'min'"); 
    } }


}