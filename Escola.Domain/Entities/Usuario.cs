using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string sobreNome, string email, DateTime dataNascimento, int escolaridadeId, int historicoEscolarId)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
            HistoricoEscolarId = historicoEscolarId;    
        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int EscolaridadeId { get; private set; }
        public Escolaridade? Escolaridade { get; private set; }
        public int HistoricoEscolarId { get; private set; }

        public void SetNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void SetSobreNome(string novoSobreNome)
        {
            SobreNome = novoSobreNome;
        }

        public void SetEmail(string novoEmail)
        {
            Email = novoEmail;
        }

        public void SetDataNascimento(DateTime novaDataNascimento)
        {
            DataNascimento = novaDataNascimento;
        }

        public void SetEscolaridadeId(int novaEscolaridade)
        {
            EscolaridadeId = novaEscolaridade;
        }

        public void SetHistoricoEscolarId(int novoHistorico)
        {
            HistoricoEscolarId = novoHistorico;
        }
    }
}
