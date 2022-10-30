using Escola.Domain.Commands.EscolaridadeCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.EscolaridadeHandlers
{
    public class EscolaridadeUpdateHandler : IHandler<EscolaridadeUpdateCommand>
    {
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;

        public EscolaridadeUpdateHandler(IEscolaridadeRepository<Escolaridade> escolaridadeRepository)
        {
            this.escolaridadeRepository = escolaridadeRepository;
        }

        public async Task<ICommandResult> Handle(EscolaridadeUpdateCommand command)
        {
            command.Validate();
            
            if (!command.IsValid())
                return new GenericCommandResult(false, EscolaResource.FalhaExecutarComando, command.Notifications);

            var escolaridade = await escolaridadeRepository.Get(command.Id);
            
            if (escolaridade == null)
                return new GenericCommandResult(false, EscolaResource.EscolaridadeNaoEncontrada, null);

            escolaridade.SetDescricao(command.Descricao);

            await escolaridadeRepository.Update(escolaridade);
            
            return new GenericCommandResult(true, EscolaResource.EscolaridadeAtualizadaSucesso, new GenericOutput(escolaridade.Id, command));
        }
    }
}
