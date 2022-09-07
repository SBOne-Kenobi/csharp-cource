using password;

namespace Tests;

public class PasswordGeneratorTest
{
    private static void CheckPassword(string password)
    {
        Assert.InRange(password.Length, 6, 20);
        
        var grounds = password.Count(c => c == '_');
        Assert.Equal(1, grounds);
        
        var capitals = password.Count(char.IsUpper);
        Assert.True(capitals >= 2);
        
        var digits = 0;
        for (var i = 0; i < password.Length - 1; i++)
        {
            if (!char.IsDigit(password, i)) continue;
            ++digits;
            Assert.False(char.IsDigit(password[i + 1]));
        }
        Assert.True(digits <= 5);
    }
    
    [Fact]
    public void GenerateTest()
    {
        var numberOfGenerations = 100000;
        for (int i = 0; i < numberOfGenerations; i++)
        {
            var password = PasswordGenerator.Generate(Random.Shared);
            CheckPassword(password);    
        }
    }
}