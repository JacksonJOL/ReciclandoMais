using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Trabalhar aqui para redirecionar para um tela de boas vindas mostrando algo sobre a ideia do programa.
        return RedirectToAction("Cadastro", "Usuario");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
