

namespace ReciclaMais.Models
{
    public class Coleta
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; } 
        public int ColetorId { get; set; }
        public Coletor Coletor { get; set; }
        public DateTime DataColeta { get; set; }
    }
}
