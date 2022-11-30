namespace Race;

public enum CommandType
{
    Acceleration,
    Reverse
}

public class Command
{
    public delegate int GetNewSpeed(State state);

    public delegate int GetNewPosition(State state);

    private readonly GetNewSpeed _newSpeed;
    private readonly GetNewPosition _newPosition;

    public readonly CommandType Type;

    private Command(CommandType type, GetNewSpeed newSpeed, GetNewPosition newPosition)
    {
        _newSpeed = newSpeed;
        _newPosition = newPosition;
        Type = type;
    }

    public State GetNewState(State state)
    {
        return new State(_newSpeed(state), _newPosition(state));
    }

    public static Command Create(CommandType type)
    {
        return type switch
        {
            CommandType.Acceleration => new Command(
                type,
                newSpeed: state => Math.Abs(state.Speed) * 2,
                newPosition: state => state.Position + state.Speed
            ),
            CommandType.Reverse => new Command(
                type,
                newSpeed: state => state.Speed > 0 ? -1 : state.Speed,
                newPosition: state => state.Position
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}