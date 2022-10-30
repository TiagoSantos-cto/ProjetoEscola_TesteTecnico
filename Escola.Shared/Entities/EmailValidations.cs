using System.Text.RegularExpressions;

namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation ValidarEmail(string property, string emailInformado)
        {
            var rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(emailInformado))
            {
                AddNotification(new Notification(property, $"Email inválido!"));
            }

            return this;
        }
    }
}
