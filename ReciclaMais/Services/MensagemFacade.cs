// Services/MensagemFacade.cs FACADE

namespace ReciclaMais.Models
{
    public class MensagemFacade
    {
        private ServicoEmail _servicoEmail;
        private ServicoSMS _servicoSMS;

        public MensagemFacade()
        {
            _servicoEmail = new ServicoEmail();
            _servicoSMS = new ServicoSMS();
        }

        public void EnviarMensagemAgradecimento(Contribuinte contribuinte)
        {
            string mensagem = "Obrigado por sua contribuição!";
            _servicoEmail.EnviarEmail(contribuinte.Email, mensagem);
            _servicoSMS.EnviarSMS(contribuinte.Telefone, mensagem);
        }
    }
}