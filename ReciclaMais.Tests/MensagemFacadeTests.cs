using ReciclaMais.Services;
using ReciclaMais.Models;
using Xunit;
using Moq;

public class MensagemFacadeTests
{
    [Fact]
    public void DeveEnviarMensagemAgradecimento()
    {
        var servicoEmailMock = new Mock<ServicoEmail>();
        var servicoSMSMock = new Mock<ServicoSMS>();
        var facade = new MensagemFacade();

        var contribuinte = new Contribuinte { Nome = "Contribuinte Teste", Email = "teste@exemplo.com", Telefone = "12345678" };

        facade.EnviarMensagemAgradecimento(contribuinte);

        // Verifica se os métodos de envio foram chamados
        servicoEmailMock.Verify(s => s.EnviarEmail(contribuinte.Email, It.IsAny<string>()), Times.Once);
        servicoSMSMock.Verify(s => s.EnviarSMS(contribuinte.Telefone, It.IsAny<string>()), Times.Once);
    }
}
