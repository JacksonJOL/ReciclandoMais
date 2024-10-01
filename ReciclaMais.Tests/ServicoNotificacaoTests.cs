using ReciclaMais.Services;
using Xunit;

public class ServicoNotificacaoTests
{
    [Fact]
    public void DeveRetornarMesmaInstancia()
    {
        var instancia1 = ServicoNotificacao.Instancia;
        var instancia2 = ServicoNotificacao.Instancia;

        Assert.Same(instancia1, instancia2); // Verifica se é a mesma instância.
    }
}
