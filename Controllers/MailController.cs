using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using TestApi.Models;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    private readonly IMailService _mailService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<MailController> _logger;

    public MailController(IMailService mailService, UserManager<ApplicationUser> userManager, ILogger<MailController> logger)
    {
        _mailService = mailService;
        _userManager = userManager;
        _logger = logger;
    }
    [HttpPost]
    public bool SendMail(MailData mailData)
    {
        return _mailService.SendMail(mailData);
    }

    [AllowAnonymous]
    [HttpGet("confirmemail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
        if (userId == null || code == null)
        {
            return BadRequest("Parametri mancanti");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"Impossibile trovare l'utente con ID '{userId}'.");
        }

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        _logger.LogInformation("Conferma email richiesta per l'utente {UserId}", userId);

        if (result.Succeeded)
        {
            return Content("Email confermata con successo. Ora puoi effettuare il login.", "text/plain", Encoding.UTF8);
        }
        else
        {
            return Content("Errore nella conferma email.", "text/plain", Encoding.UTF8);
        }
    }
}