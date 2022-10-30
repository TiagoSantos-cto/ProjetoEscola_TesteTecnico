using Escola.Domain.Entities;
using Escola.Domain.Handlers.EscolaridadeHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.HandlersTests.EscolaridadeHandlersTests
{
    public class EscolaridadeDeleteHandlerTest
    {
        private readonly IEscolaridadeRepository<Escolaridade> escolaridadeRepository;
        private readonly Escolaridade escolaridade;
        private const int EscolaridadeId = 10;

        public EscolaridadeDeleteHandlerTest()
        {
            escolaridadeRepository = Substitute.For<IEscolaridadeRepository<Escolaridade>>();
            escolaridade = new Escolaridade("Medio");
        }

        [Fact]
        public async Task DeveDeletarEscolaridadeExistente()
        {
            //Arrange
            var handler = new EscolaridadeDeleteHandler(escolaridadeRepository);
            escolaridadeRepository.Get(EscolaridadeId).Returns(escolaridade);

            //Act
            var result = (GenericCommandResult)await handler.Handle(EscolaridadeId);

            //Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task NaoDeveDeletarEscolaridadeInexistente()
        {
            //Arrange
            var handler = new EscolaridadeDeleteHandler(escolaridadeRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(EscolaridadeId);

            //Assert
            Assert.False(result.Success);
        }     
    }
}
