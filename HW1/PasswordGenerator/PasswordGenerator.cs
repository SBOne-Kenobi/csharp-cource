using System.Text;

namespace password;

public class PasswordGenerator
{

    private const int MinLength = 6;
    private const int MaxLength = 20;
    private const char WildCard = '@';

    private static char GenerateAnyLetter(Random rnd)
    {
        var type = rnd.Next(0, 2);
        var symbol = (char) rnd.Next('a', 'z');
        return type == 1 ? char.ToUpper(symbol) : symbol;
    }
    
    public static string Generate(Random rnd)
    {
        var length = rnd.Next(MinLength, MaxLength + 1);
        var answer = new StringBuilder(new string(WildCard, length));
        var indexGenerator = new IndexGenerator(length, rnd);

        // generate ground
        var index = indexGenerator.NextIndex();
        answer[index] = '_';

        // generate two upper letters
        for (var i = 0; i < 2; i++)
        {
            index = indexGenerator.NextIndex();
            var symbol = (char)rnd.Next('A', 'Z');
            answer[index] = symbol;
        }

        // generate digits
        var digits = rnd.Next(0, 5);
        while (indexGenerator.HasNext() && digits-- > 0)
        {
            index = indexGenerator.NextIndex();
            var symbol = (char)rnd.Next('0', '9');
            answer[index] = symbol;
            
            if (index > 0 && answer[index - 1] == WildCard)
            {
                answer[index - 1] = GenerateAnyLetter(rnd);
                indexGenerator.Exclude(index - 1);
            }
            
            if (index + 1 < length && answer[index + 1] == WildCard)
            {
                answer[index + 1] = GenerateAnyLetter(rnd);
                indexGenerator.Exclude(index + 1);
            }
        }

        for (var i = 0; i < length; i++)
        {
            if (answer[i] == WildCard)
            {
                answer[i] = GenerateAnyLetter(rnd);
            }
        }

        return answer.ToString();
    }
}