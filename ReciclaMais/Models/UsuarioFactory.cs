// Models/UsuarioFactory.cs FACTORY METHOD
namespace ReciclaMais.Models
{

    public static class UsuarioFactory
    {
        public static Usuario CriarUsuario(string tipo)
        {
            switch (tipo)
            {
                case "Contribuinte":
                    return new Contribuinte();
                case "Coletor":
                    return new Coletor();
                default:
                    throw new ArgumentException("Tipo de usuário inválido.");
            }
        }
    }
}