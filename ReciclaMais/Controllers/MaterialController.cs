using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReciclaMais.Data;
using ReciclaMais.Models;

/*
public class MaterialController : Controller
{
    private readonly ApplicationDbContext _context;

    public MaterialController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Exibe o formulário de postagem de material
    public IActionResult PostarMaterial()
    {
        return View();
    }

    // Processa o envio do material para coleta
    [HttpPost]
    public IActionResult PostarMaterial(string descricao, double pesoAproximado, string medidas)
    {
        var contribuinte = _context.Usuarios.OfType<Contribuinte>().FirstOrDefault(); // Aqui você precisa ajustar para pegar o contribuinte logado

        if (contribuinte == null)
        {
            return BadRequest("Contribuinte não encontrado.");
        }

        var material = new Material
        {
            Descricao = descricao,
            PesoAproximado = pesoAproximado,
            Medidas = medidas,
            Status = StatusMaterial.Disponivel,
            ContribuinteId = contribuinte.Id,
            Contribuinte = contribuinte
        };

        _context.Materiais.Add(material);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
*/
public class MaterialController : Controller
{
    private readonly ApplicationDbContext _context;

    public MaterialController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult PostarMaterial()
    {
        return View();
    }

    [HttpPost]
    public IActionResult PostarMaterial(string descricao, double pesoAproximado, string medidas)
    {
        var material = new Material
        {
            Descricao = descricao,
            PesoAproximado = pesoAproximado,
            Medidas = medidas,
            Status = StatusMaterial.Disponivel
        };

        _context.Materiais.Add(material);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
