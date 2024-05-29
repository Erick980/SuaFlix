using System.ComponentModel.DataAnnotations;

namespace SuaFLix.ViewModels;

public class RegisterVM{

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(60, ErrorMessage = "O Nome deve possuir no máximo 60 caracteres")]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "Por favor, informe a Data de Nascimento")]
    public DateTime Birthday { get; set; }

    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-mail do Usuário")]
    [Required(ErrorMessage = "Por favor, informe seu E-mail")]
    public string Email { get; set; }

    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-mail do Usuário Novamente")]
    [Required(ErrorMessage = "Por favor, Confirme seu Email")]
    [Compare(nameof(ConfirmEmail), ErrorMessage = "Os E-mails devem ser iguais")]
    public string ConfirmEmail { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso")]
    [Required(ErrorMessage = "Por favor, informe sua Senha")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso Novamente")]
    [Required(ErrorMessage = "Por favor, Confirme sua Senha")]
    [Compare(nameof(Password), ErrorMessage = "As Senhas devem ser iguais")]
    public string ConfirmPassword { get; set; }
}