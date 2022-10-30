using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.EntitiesTests
{
    public class EscolaridadeValidationsTest
    {
        [Fact]
        public void DeveRetornarNotificacaoTipoInvalido()
        {
            //Arrange
            var tipoValue = "EJA";
            var validation = new Validation().Requires().ValidarEscolaridade("tipoValue", tipoValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }

        [Fact]
        public void NaoDeveRetornarNotificacaoTipoInfantil()
        {
            //Arrange
            var tipoValue = "InFanTiL";
            var validation = new Validation().Requires().ValidarEscolaridade("tipoValue", tipoValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void NaoDeveRetornarNotificacaoTipoFundamental()
        {
            //Arrange
            var tipoValue = "funDamental";
            var validation = new Validation().Requires().ValidarEscolaridade("tipoValue", tipoValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void NaoDeveRetornarNotificacaoTipoMedio()
        {
            //Arrange
            var tipoValue = "mediO";
            var validation = new Validation().Requires().ValidarEscolaridade("tipoValue", tipoValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void NaoDeveRetornarNotificacaoTipoSuperior()
        {
            //Arrange
            var tipoValue = "SUPERIOR";
            var validation = new Validation().Requires().ValidarEscolaridade("tipoValue", tipoValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }
    }
}
