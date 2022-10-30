using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.EntitiesTests
{
    public class DateValidationsTest
    {
        [Fact]
        public void DeveRetornarNotificacaoComDataMaiorQueHoje()
        {
            //Arrange
            var dataTeste = DateTime.UtcNow.Date.AddDays(5);
            var validation = new Validation().Requires().ValidarDataNascimento("dataTeste", dataTeste);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }

        [Fact]
        public void NaoDeveRetornarNotificacaoComDataMenorQueHoje()
        {
            //Arrange
            var dataTeste = DateTime.UtcNow.Date.AddYears(-10);
            var validation = new Validation().Requires().ValidarDataNascimento("dataTeste", dataTeste);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }      
    }
}
