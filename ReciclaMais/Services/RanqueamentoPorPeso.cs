// Services/RanqueamentoPorPeso.cs STRATEGY

using ReciclaMais.Services;
namespace ReciclaMais.Models

{
    public class RanqueamentoPorPeso : IRanqueamentoStrategy
    {
        public List<Contribuinte> Ranquear(List<Contribuinte> contribuintes)
        {
            return contribuintes.OrderByDescending(c => c.Materiais.Sum(m => m.PesoAproximado)).ToList();
        }
    }
}