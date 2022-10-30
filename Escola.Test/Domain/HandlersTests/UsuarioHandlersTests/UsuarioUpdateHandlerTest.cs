using Escola.Domain.Commands.UsuarioCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.UsuarioHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.UsuarioHandlers
{
    public class UsuarioUpdateHandlerTest
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;
        private readonly UsuarioUpdateCommand validUpdateCommand;
        private readonly UsuarioUpdateCommand invalidUpdateCommand;
        private readonly Usuario usuario;

        public UsuarioUpdateHandlerTest()
        {
            usuarioRepository = Substitute.For<IUsuarioRepository<Usuario>>();
            validUpdateCommand = new UsuarioUpdateCommand(1, "Reed", "Hastings", "hastings@netflix.com", DateTime.UtcNow.AddYears(-30), 1, 2);
            invalidUpdateCommand = new UsuarioUpdateCommand(1, "Marc", "Randolph", "marc.com", DateTime.UtcNow.AddDays(3), 1, 2);
            usuario = new Usuario("Tiago", "Santos", "tiago.santos@confitec.com", DateTime.UtcNow.AddYears(-15), 1, 2);
        }

        [Fact]
        public async Task NaoDeveAtualizarUsuarioComComandoInvalido()
        {
            //Arrange
            var handler = new UsuarioUpdateHandler(usuarioRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(invalidUpdateCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task NaoDeveAtualizarUsuarioInexistente()
        {
            //Arrange
            var handler = new UsuarioUpdateHandler(usuarioRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validUpdateCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeveAtualizarUsuario()
        {
            //Arrange
            var handler = new UsuarioUpdateHandler(usuarioRepository);
            usuarioRepository.Get(validUpdateCommand.Id).Returns(usuario);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validUpdateCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
