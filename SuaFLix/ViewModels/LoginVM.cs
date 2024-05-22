
namespace SuaFLix.ViewModels;

public class LoginVM
{
    [Display(nameof = "Email ou Nome de Usuário")]
    [Required(ErrorMessage = "Por favor, informe seu email ou nome do usuario")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(nameof = "Senha de Acesso")]
    [Required(ErrorMessage = "Por favor, informe sua Senha")]
    public string Password { get; set; }

    [Display(Name = "Manter Conectado ?")]
    public bool RememberMe { get; set; } = false;
    
    public string ReturnUrl { get; set; }
}
