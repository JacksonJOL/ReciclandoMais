﻿using Microsoft.AspNetCore.Authorization;
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
        TempData["Mensagem"] = mensagem; // Usar TempData para passar a mensagem
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
    /*[Authorize]
    public IActionResult Index()
    {
        var materiais = _context.Materiais
            .Include(m => m.Contribuinte)
            .Where(m => m.Status == StatusMaterial.Disponivel)
            .ToList();

        return View(materiais);
    }
    */

}
