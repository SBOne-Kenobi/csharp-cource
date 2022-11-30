namespace Race;

public record State(int Speed, int Position)
{
    public List<StateWithCommand> ProduceNextStates()
    {
        return Enum.GetValues(typeof(CommandType))
            .OfType<CommandType>()
            .Select(Command.Create)
            .Select(x => new StateWithCommand(x.GetNewState(this), x.Type))
            .ToList();
    }
}

public record StateWithCommand(State State, CommandType Command);
