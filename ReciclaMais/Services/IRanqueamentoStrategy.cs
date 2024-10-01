// Services/IRanqueamentoStrategy.cs STRATEGY
using ReciclaMais.Models; // Certifique-se de que esta linha esteja presente

namespace ReciclaMais.Services
{
    public interface IRanqueamentoStrategy
    {
        List<Contribuinte> Ranquear(List<Contribuinte> contribuintes);
    }
}
