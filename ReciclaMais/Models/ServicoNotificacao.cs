// Services/ServicoNotificacao.cs   SINGLETON
public class ServicoNotificacao
{
    private static ServicoNotificacao _instancia;

    private ServicoNotificacao() { }

    public static ServicoNotificacao Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = new ServicoNotificacao();
            }
            return _instancia;
        }
    }

    public void EnviarNotificacao(string mensagem, string contato)
    {
        // Implementação do envio de notificação
    }
}
