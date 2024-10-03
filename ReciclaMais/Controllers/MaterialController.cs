
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReciclaMais.Data;
using ReciclaMais.Models;

[Authorize]
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
    [HttpPost]
    public IActionResult AlterarStatus(int id, StatusMaterial novoStatus)
    {
        var material = _context.Materiais.Find(id);
        if (material == null)
        {
            return NotFound();
        }

        material.Status = novoStatus;
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult NotificarContribuinte(int id)
    {
        var material = _context.Materiais.Include(m => m.Contribuinte).FirstOrDefault(m => m.Id == id);
        if (material == null)
        {
            return NotFound();
        }

        var mensagem = $"Olá {material.Contribuinte.Nome}, o coletor se interessou pelo seu material: {material.Descricao}.";
        TempData["Mensagem"] = mensagem; 
        return RedirectToAction("Detalhes", new { id = id });
    }

    public IActionResult Index(string status)
    {
        var materiais = _context.Materiais.Include(m => m.Contribuinte).AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            if (status == "Disponivel")
            {
                materiais = materiais.Where(m => m.Status == StatusMaterial.Disponivel);
            }
            else if (status == "Coletado")
            {
                materiais = materiais.Where(m => m.Status == StatusMaterial.Coletado);
            }
        }

        return View(materiais.ToList());
    }
   

}
