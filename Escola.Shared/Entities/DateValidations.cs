namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation ValidarDataNascimento(string property, DateTime dataInformada)
        {
            if (DateTime.UtcNow.Date < dataInformada.Date)
                AddNotification(new Notification(property, $"A data de nascimento não pode ser maior que a data de hoje!"));

            return this;
        }      
    }
}
