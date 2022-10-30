using Escola.Domain.Commands.UsuarioCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.UsuarioHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.HandlersTests.UsuarioHandlersTests
{
    public class UsuarioCreateHandlerTest
    {
        private readonly IUsuarioRepository<Usuario> usuarioRepository;
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;
        private readonly UsuarioCreateCommand validCreateCommand;
        private readonly UsuarioCreateCommand invalidCreateCommand;

        public UsuarioCreateHandlerTest()
        {
            usuarioRepository = Substitute.For<IUsuarioRepository<Usuario>>();
            escolaridadeRepository = Substitute.For<IEscolaridadeRepository<Escolaridade>>();
            validCreateCommand = new UsuarioCreateCommand("Bill", "Gates", "bill.gates@microsoft.com", DateTime.UtcNow.AddYears(-30), 1, 2);
            invalidCreateCommand = new UsuarioCreateCommand("Steve", "Jobs", "steve.jobs", DateTime.UtcNow.AddDays(3), 1, 2);
        }

        [Fact]
        public async Task NaoDeveCadastrarUsuarioComComandoInvalido()
        {
            //Arrange
            var handler = new UsuarioCreateHandler(usuarioRepository, escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(invalidCreateCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeveCadastrarUsuarioComComandoValido()
        {
            //Arrange
            usuarioRepository.HistoricoExiste(validCreateCommand.HistoricoEscolarId).Returns(false);
            escolaridadeRepository.EscolaridadeNaoExiste(validCreateCommand.EscolaridadeId).Returns(false);
            
            var handler = new UsuarioCreateHandler(usuarioRepository, escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validCreateCommand);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task NaoDeveCadastrarUsuarioComEscolaridadeInexistente()
        {
            //Arrange
            usuarioRepository.HistoricoExiste(validCreateCommand.HistoricoEscolarId).Returns(false);
            escolaridadeRepository.EscolaridadeNaoExiste(validCreateCommand.EscolaridadeId).Returns(true);
                             
            var handler = new UsuarioCreateHandler(usuarioRepository, escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validCreateCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task NaoDeveCadastrarUsuarioComHistoricoDuplicado()
        {
            //Arrange                
            usuarioRepository.HistoricoExiste(validCreateCommand.HistoricoEscolarId).Returns(true);
            escolaridadeRepository.EscolaridadeNaoExiste(validCreateCommand.EscolaridadeId).Returns(false);

            var handler = new UsuarioCreateHandler(usuarioRepository, escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validCreateCommand);

            //Assert
            Assert.False(result.Success);
        }
    }
}
