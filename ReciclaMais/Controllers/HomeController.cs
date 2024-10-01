using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Aqui você pode redirecionar para uma página de boas-vindas ou cadastro
        return RedirectToAction("Cadastro", "Usuario");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
