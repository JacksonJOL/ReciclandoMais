using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Aqui voc� pode redirecionar para uma p�gina de boas-vindas ou cadastro
        return RedirectToAction("Cadastro", "Usuario");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
