using System.Runtime.Serialization;

namespace GroupsSerialization;

[Serializable]
public class Group
{
    public decimal GroupId { get; set; }
    public string Name { get; set; }

    private List<Student> _students;

    public List<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            foreach (var student in _students)
            {
                student.Group = this;
            }
        }
    }

    public int StudentsCount => _students.Count;

    public Group(decimal groupId, string name)
    {
        GroupId = groupId;
        Name = name;
        Students = new List<Student>();
    }

    protected bool Equals(Group other)
    {
        return _students.SequenceEqual(other._students) && GroupId == other.GroupId && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Group)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_students, GroupId, Name);
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        foreach (var student in _students)
        {
            student.Group = this;
        }
    }
}