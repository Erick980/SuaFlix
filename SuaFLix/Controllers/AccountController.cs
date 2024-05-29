
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SuaFLix.ViewModels;

namespace SuaFLix.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private string returnurl;

    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager
        )
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login(string returnurl)
    {
        LoginVM login = new() 
        {
            ReturnUrl = returnurl ?? Url.Content("~/")
        };
        return View(login);
    }

    public IActionResult Register(string returnurl)
    {
        RegisterVM register = new()
        {

        };
        return View(register);
    }

    [HttpPost]
    [ValidateAntiforgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {

        }
        return View(login);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            MailAddress mail = new(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

internal class RegisterVM
{
    public string ReturnUrl { get; internal set; }
}

internal class ValidateAntiforgeryTokenAttribute : Attribute
{
}