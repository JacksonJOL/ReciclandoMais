using Microsoft.AspNetCore.Mvc;
using ReciclaMais.Data;
using ReciclaMais.Models;

public class UsuarioController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsuarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Exibe a página de cadastro
    public IActionResult Cadastro()
    {
        return View();
    }

    // Processa o cadastro do usuário
    [HttpPost]
    public IActionResult Cadastro(string nome, string email, string telefone, string endereco, string tipoUsuario)
    {
        Usuario usuario;

        if (tipoUsuario == "Contribuinte")
        {
            usuario = new Contribuinte { Nome = nome, Email = email, Telefone = telefone, Endereco = endereco };
        }
        else if (tipoUsuario == "Coletor")
        {
            usuario = new Coletor { Nome = nome, Email = email, Telefone = telefone, Endereco = endereco };
        }
        else
        {
            // Tipo de usuário inválido
            return BadRequest("Tipo de usuário inválido.");
        }

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }
    public IActionResult Ranking()
    {
        var contribuintes = _context.Usuarios.OfType<Contribuinte>()
            .OrderByDescending(c => c.Materiais.Count) // Ordena por número de materiais postados
            .ToList();

        return View(contribuintes);
    }
    public IActionResult RankingOK()
    {
        var contribuintes = _context.Usuarios
            .OfType<Contribuinte>()
            .OrderByDescending(c => c.Materiais.Count) // Ordena por número de materiais postados
            .ToList();

        return View(contribuintes);
    }

}
