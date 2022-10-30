using Escola.Domain.Entities;
using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface IUsuarioRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        bool HistoricoExiste(int historicoId);
    }
}
