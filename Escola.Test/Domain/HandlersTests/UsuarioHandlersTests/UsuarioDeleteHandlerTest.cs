using Escola.Domain.Entities;
using Escola.Domain.Handlers.UsuarioHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.UsuarioHandlers
{
    public class UsuarioDeleteHandlerTest
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;
        private readonly Usuario usuario;
        private const int usuarioId = 1;


        public UsuarioDeleteHandlerTest()
        {
            usuarioRepository = Substitute.For<IUsuarioRepository<Usuario>>();
            usuario = new Usuario("Jeff", "Bezos", "jeff.bezos@amazon.com", DateTime.UtcNow.AddYears(-15), 1, 2);
        }

        [Fact]
        public async Task NaoDeveDeletarUsuarioInexistente()
        {
            //Arrange
            var handler = new UsuarioDeleteHandler(usuarioRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(-1);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeveDeletarUsuarioExistente()
        {
            //Arrange
            var handler = new UsuarioDeleteHandler(usuarioRepository);
            usuarioRepository.Get(usuarioId).Returns(usuario);

            //Act
            var result = (GenericCommandResult)await handler.Handle(usuarioId);

            //Assert
            Assert.True(result.Success);
        }
    }
}
