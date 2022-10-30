using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;

namespace Escola.Infra.Repositories
{
    public class EscolaridadeRepository<T> : BaseRepository<T>, IEscolaridadeRepository<T> where T : BaseEntity
    {
        private readonly EscolaDbContext _context;

        public EscolaridadeRepository(EscolaDbContext context) : base(context)
        {
            _context = context;
        }

        public bool EscolaridadeNaoExiste(int escolaridadeId) 
            => !_context.Escolaridade.Any(x => x.Id == escolaridadeId);
    }
}
