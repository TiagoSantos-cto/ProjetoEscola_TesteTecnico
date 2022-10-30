using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;

namespace Escola.Infra.Repositories
{
    public class UsuarioRepository<T> : BaseRepository<T>, IUsuarioRepository<T> where T : BaseEntity
    {
        private readonly EscolaDbContext _context;

        public UsuarioRepository(EscolaDbContext context) : base(context)
        {
            _context = context;
        }

        public bool HistoricoExiste(int historicoId) 
            => _context.Usuario.Any(x => x.HistoricoEscolarId == historicoId);
    }
}
