using Escola.Domain.Commands.EscolaridadeCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.EscolaridadeHandlers
{
    public class EscolaridadeCreateHandler : IHandler<EscolaridadeCreateCommand>
    {
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;

        public EscolaridadeCreateHandler(IEscolaridadeRepository<Escolaridade> escolaridadeRepository)
        {
            this.escolaridadeRepository = escolaridadeRepository;
        }

        public async Task<ICommandResult> Handle(EscolaridadeCreateCommand command)
        {
            command.Validate();
            
            if (!command.IsValid())
                return new GenericCommandResult(false, EscolaResource.FalhaExecutarComando, command.Notifications);
            
            var novaEscolaridade = new Escolaridade(command.Descricao);
            
            await escolaridadeRepository.Create(novaEscolaridade);

            return new GenericCommandResult(true, EscolaResource.EscolaridadeCadastradaSucesso, new GenericOutput(novaEscolaridade.Id, command));
        }
    }
}
