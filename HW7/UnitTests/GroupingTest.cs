using Grouping;

namespace UnitTests;

public class GroupingTest
{
    [Fact]
    public void GetInfoAboutSentenceTest()
    {
        var sentence = "Это что же получается:::ходишь, ходишь в школу,а потом бац - вторая смена";
        var expected = "Group 1. Length 10. Count 1\n" +
                       "получается\n" +
                       "\n" +
                       "Group 2. Length 6. Count 3\n" +
                       "ходишь\n" +
                       "ходишь\n" +
                       "вторая\n" +
                       "\n" +
                       "Group 3. Length 5. Count 3\n" +
                       "школу\n" +
                       "потом\n" +
                       "смена\n" +
                       "\n" +
                       "Group 4. Length 3. Count 3\n" +
                       "Это\n" +
                       "что\n" +
                       "бац\n" +
                       "\n" +
                       "Group 5. Length 2. Count 1\n" +
                       "же\n" +
                       "\n" +
                       "Group 6. Length 1. Count 2\n" +
                       "в\n" +
                       "а\n";
        var actual = sentence.GetInfoAboutSentence();
        Assert.Equal(expected, actual);
    }
}