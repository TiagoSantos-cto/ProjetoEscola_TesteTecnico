using Escola.Domain.Commands.EscolaridadeCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.EscolaridadeHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.HandlersTests.EscolaridadeHandlersTests
{
    public class EscolaridadeCreateHandlerTest
    {
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;
        private readonly EscolaridadeCreateCommand validCreateCommand;
        private readonly EscolaridadeCreateCommand invalidCreateCommand;

        public EscolaridadeCreateHandlerTest()
        {
            escolaridadeRepository = Substitute.For<IEscolaridadeRepository<Escolaridade>>();          
            validCreateCommand = new EscolaridadeCreateCommand("Infantil");
            invalidCreateCommand = new EscolaridadeCreateCommand("EAD");
        }

        [Fact]
        public async Task DeveCadastrarEscolaridadeComComandoValido()
        {
            //Arrange
            var handler = new EscolaridadeCreateHandler(escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validCreateCommand);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task NaoDeveCadastrarEscolaridadeComComandoInvalido()
        {
            //Arrange
            var handler = new EscolaridadeCreateHandler(escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(invalidCreateCommand);

            //Assert
            Assert.False(result.Success);
        }      
    }
}
