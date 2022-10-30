using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.UsuarioCommands
{
    public class UsuarioCreateCommand : Notifiable, ICommand
    {
        public UsuarioCreateCommand(string nome, string sobreNome, string email, DateTime dataNascimento, int escolaridadeId, int historicoEscolarId)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
            HistoricoEscolarId = historicoEscolarId;
        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int EscolaridadeId { get; private set; }
        public int HistoricoEscolarId { get; private set; }

        public void Validate()
        {
            AddNotifications
                (
                    new Validation()
                    .Requires()
                    .ValidarEmail("Email", Email)
                    .ValidarDataNascimento("DataNascimento", DataNascimento)
                    .Notifications
                );
        }
    }
}
