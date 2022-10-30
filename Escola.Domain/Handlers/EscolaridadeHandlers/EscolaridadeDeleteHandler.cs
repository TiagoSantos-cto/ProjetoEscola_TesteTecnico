using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Handlers.EscolaridadeHandlers
{
    public class EscolaridadeDeleteHandler
    {
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;

        public EscolaridadeDeleteHandler(IEscolaridadeRepository<Escolaridade> escolaridadeRepository)
        {
            this.escolaridadeRepository = escolaridadeRepository;
        }

        public async Task<ICommandResult> Handle(int EscolaridadeId)
        {
            var Escolaridade = await escolaridadeRepository.Get(EscolaridadeId);
            
            if (Escolaridade == null)
                return new GenericCommandResult(false, EscolaResource.EscolaridadeNaoEncontrada, null);

            await escolaridadeRepository.Delete(Escolaridade);
            
            return new GenericCommandResult(true, EscolaResource.EscolaridadeDeletadaSucesso, Escolaridade.Id);
        }
    }
}
