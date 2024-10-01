namespace ReciclaMais.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public double PesoAproximado { get; set; }
        public string Medidas { get; set; }
        public StatusMaterial Status { get; set; }
        public int ContribuinteId { get; set; }
        public Contribuinte Contribuinte { get; set; }
        //public ICollection<Coleta> Coletas { get; set; }
    }

    public enum StatusMaterial
    {
        Disponivel,
        Coletado
    }
}
