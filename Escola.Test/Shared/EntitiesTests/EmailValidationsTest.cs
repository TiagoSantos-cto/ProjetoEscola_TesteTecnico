using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.EntitiesTests
{
    public class EmailValidationsTest
    {
        [Fact]
        public void DeveRetornarNotificacaoSemArroba()
        {
            //Arrange
            var emailValue = "test.com";
            var validation = new Validation().Requires().ValidarEmail("emailValue", emailValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }

        [Fact]
        public void NaoDeveRetornarNotificacaoComArroba()
        {
            //Arrange
            var emailValue = "test@test.com";
            var validation = new Validation().Requires().ValidarEmail("emailValue", emailValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }      
    }
}
