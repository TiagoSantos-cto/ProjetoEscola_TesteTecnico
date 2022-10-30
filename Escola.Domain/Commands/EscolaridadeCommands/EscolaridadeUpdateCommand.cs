using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.EscolaridadeCommands
{
    public class EscolaridadeUpdateCommand : Notifiable, ICommand
    {
        public EscolaridadeUpdateCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; private set; }
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
