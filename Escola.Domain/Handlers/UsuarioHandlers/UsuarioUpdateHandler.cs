using Escola.Domain.Commands.UsuarioCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.UsuarioHandlers
{
    public class UsuarioUpdateHandler : IHandler<UsuarioUpdateCommand>
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;

        public UsuarioUpdateHandler(IUsuarioRepository<Usuario> usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<ICommandResult> Handle(UsuarioUpdateCommand command)
        {
            command.Validate();

            if (!command.IsValid())
                return new GenericCommandResult(false, EscolaResource.FalhaExecutarComando, command.Notifications);

            var usuario = await usuarioRepository.Get(command.Id);
            
            if(usuario == null)
                return new GenericCommandResult(false, EscolaResource.UsuarioNaoExiste, null);
        
            usuario.SetNome(command.Nome);
            usuario.SetSobreNome(command.SobreNome);
            usuario.SetEmail(command.Email);
            usuario.SetDataNascimento(command.DataNascimento);
            usuario.SetEscolaridadeId(command.EscolaridadeId);
            usuario.SetHistoricoEscolarId(command.HistoricoEscolarId);

            await usuarioRepository.Update(usuario);

            return new GenericCommandResult(true, EscolaResource.UsuarioAtualizadoSucesso, new GenericOutput(usuario.Id, command));
        }
    }
}
