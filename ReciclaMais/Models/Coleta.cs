using ReciclaMais.Models; // Certifique-se de que esta linha esteja presente

namespace ReciclaMais.Models
{
    public class Coleta
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; } // Certifique-se de que o tipo Material esteja correto
        public int ColetorId { get; set; }
        public Coletor Coletor { get; set; }
        public DateTime DataColeta { get; set; }
    }
}
