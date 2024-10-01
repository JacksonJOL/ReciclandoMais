// Services/IObservador.cs OBSERVER

namespace ReciclaMais.Models
{ 
    public interface IObservador
    {
        void Atualizar(Material material);
    }

    // Services/ColetorObservador.cs
    public class ColetorObservador : IObservador
    {
        private Coletor _coletor;

        public ColetorObservador(Coletor coletor)
        {
            _coletor = coletor;
        }

        public void Atualizar(Material material)
        {
            // Lógica para notificar o coletor
        }
    }
}