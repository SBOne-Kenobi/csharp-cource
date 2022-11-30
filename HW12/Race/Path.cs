using System.Text;

namespace Race;

public record Path(State State, CommandType? Command = null, Path? Prev = null)
{
    public override string ToString()
    {
        var commands = new List<CommandType>();
        var states = new List<State>();

        var path = this;
        states.Add(path.State);

        while (path.Prev != null)
        {
            commands.Add(path.Command!.Value);
            path = path.Prev;
            states.Add(path.State);
        }

        var builder = new StringBuilder();

        var commandsString = string.Join("", commands
            .Select(x => x switch
            {
                CommandType.Acceleration => "A",
                CommandType.Reverse => "R",
                _ => throw new ArgumentOutOfRangeException(nameof(x), x, null)
            })
            .Reverse()
        );
        builder.AppendLine(commandsString);

        var positions = string.Join(" -> ", states
            .Select(x => x.Position.ToString())
            .Reverse()
        );
        builder.AppendLine($"Position: {positions}");

        var speed = string.Join(" -> ", states
            .Select(x => x.Speed.ToString())
            .Reverse()
        );
        builder.AppendLine($"Speed: {speed}");

        return builder.ToString();
    }
}