using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class Escolaridade : BaseEntity
    {
        public Escolaridade(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
        public Usuario? Usuario { get; private set; }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}
