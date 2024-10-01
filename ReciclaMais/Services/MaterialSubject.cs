// Services/MaterialSubject.cs OBSEVER

namespace ReciclaMais.Models
{
    public class MaterialSubject
    {
        private List<IObservador> _observadores = new List<IObservador>();

        public void AdicionarObservador(IObservador observador)
        {
            _observadores.Add(observador);
        }

        public void RemoverObservador(IObservador observador)
        {
            _observadores.Remove(observador);
        }

        public void Notificar(Material material)
        {
            foreach (var observador in _observadores)
            {
                observador.Atualizar(material);
            }
        }
    }
}