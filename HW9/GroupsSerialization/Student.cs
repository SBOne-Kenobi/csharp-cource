using System.Runtime.Serialization;

namespace GroupsSerialization;

[Serializable]
public class Student
{
    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    [NonSerialized]
    private Group? _group;

    public Group? Group
    {
        get => _group;
        set => _group = value;
    }

    public Student(decimal studentId, string firstName, string lastName, int age, Group? group = null)
    {
        StudentId = studentId;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Group = group;
    }

    protected bool Equals(Student other)
    {
        return StudentId == other.StudentId && FirstName == other.FirstName && LastName == other.LastName &&
               Age == other.Age;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Student)obj);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(StudentId, FirstName, LastName, Age);
    }
}