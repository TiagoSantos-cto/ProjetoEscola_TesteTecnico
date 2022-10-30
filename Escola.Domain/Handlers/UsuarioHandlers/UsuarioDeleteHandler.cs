using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Handlers.UsuarioHandlers
{
    public class UsuarioDeleteHandler
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;

        public UsuarioDeleteHandler(IUsuarioRepository<Usuario> usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<ICommandResult> Handle(int UsuarioId)
        {
            var Usuario = await usuarioRepository.Get(UsuarioId);
            
            if (Usuario == null)
                return new GenericCommandResult(false, EscolaResource.UsuarioNaoExiste, null);

            await usuarioRepository.Delete(Usuario);

            return new GenericCommandResult(true, EscolaResource.UsuarioDeletadoSucesso, Usuario.Id);
        }
    }
}
