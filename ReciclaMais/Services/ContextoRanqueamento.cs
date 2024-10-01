using ReciclaMais.Models; // Adicione esta linha para importar o namespace

namespace ReciclaMais.Services
{
    public class ContextoRanqueamento
    {
        private IRanqueamentoStrategy _strategy;

        public ContextoRanqueamento(IRanqueamentoStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<Contribuinte> ExecutarEstrategia(List<Contribuinte> contribuintes)
        {
            return _strategy.Ranquear(contribuintes);
        }
    }
}
