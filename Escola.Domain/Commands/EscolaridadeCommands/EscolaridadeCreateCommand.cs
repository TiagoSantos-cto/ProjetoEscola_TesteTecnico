using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.EscolaridadeCommands
{
    public class EscolaridadeCreateCommand : Notifiable, ICommand
    {
        public EscolaridadeCreateCommand(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }

        public void Validate()
        {
            AddNotifications
                (
                    new Validation()
                    .Requires()
                    .ValidarEscolaridade("Descricao", Descricao)
                    .Notifications
                );
        }
    }
}
