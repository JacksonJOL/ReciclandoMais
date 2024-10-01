namespace ReciclaMais.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }

    public class Contribuinte : Usuario
    {
        public ICollection<Material> Materiais { get; set; }
    }

    public class Coletor : Usuario
    {
        public ICollection<Coleta> Coletas { get; set; }
    }
}
