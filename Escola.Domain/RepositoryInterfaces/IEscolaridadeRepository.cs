using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface IEscolaridadeRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        bool EscolaridadeNaoExiste(int escolaridadeId);
    }
}
