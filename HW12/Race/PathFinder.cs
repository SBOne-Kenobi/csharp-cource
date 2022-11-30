namespace Race;

public class PathFinder
{
    private readonly int _targetPosition;

    public PathFinder(int targetPosition)
    {
        _targetPosition = targetPosition;
    }

    public Path FindPath()
    {
        var used = new HashSet<State>();
        var queue = new Queue<Path>();

        var initialState = new State(1, 0);
        queue.Enqueue(new Path(initialState));
        used.Add(initialState);

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            if (path.State.Position == _targetPosition)
            {
                return path;
            }
            foreach (var (state, command) in path.State.ProduceNextStates())
            {
                if (used.Contains(state))
                {
                    continue;
                }

                used.Add(state);
                queue.Enqueue(new Path(state, command, path));
            }
        }

        throw new Exception("Unreachable!");
    }
}