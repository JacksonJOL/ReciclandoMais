using Microsoft.AspNetCore.Mvc;
using ReciclaMais.Data;
using ReciclaMais.Models;
using System.Linq;

public class MensagemController : Controller
{
    private readonly ApplicationDbContext _context;

    public MensagemController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Exibe as mensagens trocadas entre dois usuários
    public IActionResult Conversa(int usuarioId)
    {
        var usuarioLogadoId = 1; // Substituir pelo ID do usuario logado

        var mensagens = _context.Mensagens
            .Where(m => (m.RemetenteId == usuarioLogadoId && m.DestinatarioId == usuarioId)
                     || (m.RemetenteId == usuarioId && m.DestinatarioId == usuarioLogadoId))
            .OrderBy(m => m.DataEnvio)
            .ToList();

        ViewBag.UsuarioDestinoId = usuarioId; // Passar o ID do destinatário para a view

        return View(mensagens);
    }

    // Enviar uma mensagem
    [HttpPost]
    public IActionResult EnviarMensagem(int destinatarioId, string conteudo)
    {
        var usuarioLogadoId = 1; // Substituir pelo ID do usuario logado

        var mensagem = new Mensagem
        {
            RemetenteId = usuarioLogadoId,
            DestinatarioId = destinatarioId,
            Conteudo = conteudo,
            DataEnvio = DateTime.Now
        };

        _context.Mensagens.Add(mensagem);
        _context.SaveChanges();

        return RedirectToAction("Conversa", new { usuarioId = destinatarioId });
    }
    [HttpPost]
    public IActionResult EnviarMensagens(int destinatarioId, string conteudo)
    {
        var usuarioLogadoId = 1; // Substituir pelo ID do usuario logado

        var mensagem = new Mensagem
        {
            RemetenteId = usuarioLogadoId,
            DestinatarioId = destinatarioId,
            Conteudo = conteudo,
            DataEnvio = DateTime.Now
        };

        _context.Mensagens.Add(mensagem);
        _context.SaveChanges();

        TempData["MensagemSucesso"] = "Mensagem enviada com sucesso!";
        return RedirectToAction("Conversa", new { usuarioId = destinatarioId });
    }
    [HttpPost]
    public IActionResult EnviarMensagensS(int destinatarioId, string conteudo)
    {
        if (string.IsNullOrEmpty(conteudo))
        {
            ModelState.AddModelError("conteudo", "O conteúdo da mensagem é obrigatório.");
            return View("Conversa"); // Retorna a view com os erros de validação se houver
        }

        var usuarioLogadoId = 1; // Substituir pelo ID do usuário logado

        var mensagem = new Mensagem
        {
            RemetenteId = usuarioLogadoId,
            DestinatarioId = destinatarioId,
            Conteudo = conteudo,
            DataEnvio = DateTime.Now
        };

        _context.Mensagens.Add(mensagem);
        _context.SaveChanges();

        return RedirectToAction("Conversa", new { usuarioId = destinatarioId });
    }


}
