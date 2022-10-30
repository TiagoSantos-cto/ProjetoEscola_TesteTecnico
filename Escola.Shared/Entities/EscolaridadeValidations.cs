namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation ValidarEscolaridade(string property, string descricao)
        {
            if (!"Infantil".ToLower().Equals(descricao.ToLower()) && !"Fundamental".ToLower().Equals(descricao.ToLower()) && !"Medio".ToLower().Equals(descricao.ToLower()) && !"Superior".ToLower().Equals(descricao.ToLower()))
                AddNotification(new Notification(property, "Escolaridade inválida! Tipos de escolaridades permitidas: Infantil, Fundamental, Médio ou Superior"));

            return this;
        }
    }
}
