using Allergy;

namespace UnitTests;

public class AllergyTests
{
    [Fact]
    public void EmptyTest()
    {
        var mary = new Allergies("Мэри");
        Assert.Equal("Мэри", mary.Name);
        Assert.Equal(0, mary.Score);
        Assert.Equal("У Мэри нет аллергии!", mary.ToString());
        Assert.False(mary.IsAllergicTo(Allergen.Cat));
    }

    [Fact]
    public void ChangeTest()
    {
        
        var mary = new Allergies("Мэри");
        
        mary.AddAllergy(Allergen.Cat);
        Assert.Equal(128, mary.Score);
        Assert.Equal("У Мэри аллергия на кошек", mary.ToString());
        Assert.True(mary.IsAllergicTo(Allergen.Cat));
        Assert.True(mary.IsAllergicTo("кошка"));
        Assert.False(mary.IsAllergicTo(Allergen.Peanut));
        
        mary.AddAllergy("Арахис");
        Assert.Equal(128 + 2, mary.Score);
        Assert.Equal("У Мэри аллергия на арахис и кошек", mary.ToString());
        Assert.True(mary.IsAllergicTo(Allergen.Cat));
        Assert.True(mary.IsAllergicTo("Арахис"));
        Assert.True(mary.IsAllergicTo(Allergen.Peanut));
        
        mary.DeleteAllergy(Allergen.Cat);
        Assert.Equal(2, mary.Score);
        Assert.Equal("У Мэри аллергия на арахис", mary.ToString());
        Assert.False(mary.IsAllergicTo(Allergen.Cat));
        Assert.True(mary.IsAllergicTo(Allergen.Peanut));
    }

    [Fact]
    public void ScoreConstructorTest()
    {
        var mary = new Allergies("Мэри", 128 + 16 + 1);
        Assert.Equal("У Мэри аллергия на яйца, помидоры и кошек", mary.ToString());
    }

    [Fact]
    public void StringConstructorTest()
    {
        var mary = new Allergies("Мэри", "шоколад Клубника Моллюск");
        Assert.Equal(4 + 8 + 32, mary.Score);
        Assert.Equal("У Мэри аллергия на моллюски, клубнику и шоколад", mary.ToString());
    }
}