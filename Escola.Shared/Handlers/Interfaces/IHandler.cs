using Escola.Shared.Commands.Interfaces;

namespace Escola.Shared.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
