using Escola.Domain.Commands.EscolaridadeCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.EscolaridadeHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.HandlersTests.EscolaridadeHandlersTests
{
    public class EscolaridadeUpdateHandlerTest
    {
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;
        private readonly Escolaridade escolaridade;
        private readonly EscolaridadeUpdateCommand validUpdateCommand;
        private readonly EscolaridadeUpdateCommand invalidUpdateCommand;

        public EscolaridadeUpdateHandlerTest()
        {
            escolaridadeRepository = Substitute.For<IEscolaridadeRepository<Escolaridade>>();
            escolaridade = new Escolaridade("Medio");            
            validUpdateCommand = new EscolaridadeUpdateCommand(1, "Infantil");
            invalidUpdateCommand = new EscolaridadeUpdateCommand(1, "EAD");        
        }

        [Fact]
        public async Task DeveAtualizarEscolaridadeComComandoValido()
        {
            //Arrange
            var handler = new EscolaridadeUpdateHandler(escolaridadeRepository);
            escolaridadeRepository.Get(validUpdateCommand.Id).Returns(escolaridade);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validUpdateCommand);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task NaoDeveAtualizarEscolaridadeComComandoInvalido()
        {
            //Arrange
            var handler = new EscolaridadeUpdateHandler(escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(invalidUpdateCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task NaoDeveAtualizarEscolaridadeInexistente()
        {
            //Arrange
            var handler = new EscolaridadeUpdateHandler(escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(validUpdateCommand);

            //Assert
            Assert.False(result.Success);
        }       
    }
}
