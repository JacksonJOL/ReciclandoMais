using ReciclaMais.Services;
using ReciclaMais.Models;
using Xunit;
using Moq;

public class MaterialSubjectTests
{
    [Fact]
    public void DeveNotificarObservadoresQuandoMaterialPostado()
    {
        // Cria o Subject (Material) e observadores (Coletores)
        var subject = new MaterialSubject();
        var observadorMock = new Mock<IObservador>();
        subject.AdicionarObservador(observadorMock.Object);

        // Posta o material e notifica
        var material = new Material();
        subject.Notificar(material);

        // Verifica se o observador foi notificado
        observadorMock.Verify(o => o.Atualizar(It.IsAny<Material>()), Times.Once);
    }
}
