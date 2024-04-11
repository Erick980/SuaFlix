namespace SuaFLix.Models;
{
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
    public Int16 MovieYear {get; set;}

    
}
}