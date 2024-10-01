namespace ReciclaMais.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public int RemetenteId { get; set; } // Usuário que enviou a mensagem
        public Usuario Remetente { get; set; }

        public int DestinatarioId { get; set; } // Usuário que vai receber a mensagem
        public Usuario Destinatario { get; set; }

        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; } = DateTime.Now; // Data de envio da mensagem
    }

}
