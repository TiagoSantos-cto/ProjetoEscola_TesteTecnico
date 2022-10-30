using Escola.Domain.Commands.UsuarioCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.UsuarioHandlers
{
    public class UsuarioCreateHandler : IHandler<UsuarioCreateCommand>
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;

        public UsuarioCreateHandler(IUsuarioRepository<Usuario> usuarioRepository, IEscolaridadeRepository<Escolaridade> escolaridadeRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.escolaridadeRepository = escolaridadeRepository;   
        }

        public async Task<ICommandResult> Handle(UsuarioCreateCommand command)
        {
            command.Validate();
            
            if(!command.IsValid())
                return new GenericCommandResult(false, EscolaResource.FalhaExecutarComando, command.Notifications);

            if (EscolaridadeNaoExiste(command.EscolaridadeId))
                return new GenericCommandResult(false, string.Format(EscolaResource.EscolaridadeInformadaNaoExiste, command.EscolaridadeId), command.Notifications);

            if (HistoricoJaExiste(command.HistoricoEscolarId))
                return new GenericCommandResult(false, string.Format(EscolaResource.HistoricoJaCadastrado, command.HistoricoEscolarId), command.Notifications);

            var novoUsuario = new Usuario(command.Nome, command.SobreNome, command.Email, command.DataNascimento, command.EscolaridadeId, command.HistoricoEscolarId);

            await usuarioRepository.Create(novoUsuario);

            return new GenericCommandResult(true, EscolaResource.UsuarioCadastradoSucesso, new GenericOutput(novoUsuario.Id, command));
        }

        private bool EscolaridadeNaoExiste(int escolaridadeId) 
            => escolaridadeRepository.EscolaridadeNaoExiste(escolaridadeId);

        private bool HistoricoJaExiste(int historicoEscolarId) 
            => usuarioRepository.HistoricoExiste(historicoEscolarId);
    }
}
