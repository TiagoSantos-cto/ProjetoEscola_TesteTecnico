namespace Escola.Shared.Commands
{
    public class GenericOutput
    {
        public GenericOutput(object id, object command)
        {
            Id = id;
            Command = command;
        }

        public object Id { get; private set; }
        public object Command { get; private set; }
    }
}
