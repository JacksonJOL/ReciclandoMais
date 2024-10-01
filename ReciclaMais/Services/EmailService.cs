using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;

public class EmailService
{
    public async Task EnviarEmailAsync(string destinatario, string assunto, string mensagem)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("Recicla +", "seu-email@exemplo.com"));
        email.To.Add(new MailboxAddress("", destinatario));
        email.Subject = assunto;
        email.Body = new TextPart("plain")
        {
            Text = mensagem
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.servidor.com", 587, SecureSocketOptions.StartTls); // Conecte ao servidor SMTP
        await smtp.AuthenticateAsync("seu-email@exemplo.com", "sua-senha"); // Autenticação do e-mail
        await smtp.SendAsync(email); // Envia o e-mail
        await smtp.DisconnectAsync(true); // Desconecta o cliente SMTP
    }
}
