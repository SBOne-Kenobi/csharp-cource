using System.Text;

namespace Allergy;

public class Allergies
{
    public Allergies(string name, int score = 0)
    {
        Name = name;
        Score = score;
    }

    public Allergies(string name, string allergies)
    {
        Name = name;
        Score = allergies
            .Split(' ')
            .Select(AllergenUtils.ParseFromRussian)
            .Distinct()
            .Select(AllergenUtils.GetScore)
            .Sum();
    }

    public string Name { get; }

    public int Score { get; private set; }

    public bool IsAllergicTo(string name)
    {
        return IsAllergicTo(AllergenUtils.ParseFromRussian(name));
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return Score.Contains(allergen);
    }

    public void AddAllergy(string name)
    {
        AddAllergy(AllergenUtils.ParseFromRussian(name));
    }

    public void AddAllergy(Allergen allergen)
    {
        Score |= allergen.GetScore();
    }

    public void DeleteAllergy(string name)
    {
        DeleteAllergy(AllergenUtils.ParseFromRussian(name));
    }

    public void DeleteAllergy(Allergen allergen)
    {
        Score &= ~allergen.GetScore();
    }

    public override string ToString()
    {
        var allergens = Score.GetAllergens();
        if (allergens.Count == 0)
        {
            return $"У {Name} нет аллергии!";
        }

        var builder = new StringBuilder();
        builder.Append($"У {Name} аллергия на {allergens.First().AllergyOn()}");

        for (var i = 1; i < allergens.Count; i++)
        {
            if (i + 1 == allergens.Count)
            {
                builder.Append(" и ");
            }
            else
            {
                builder.Append(", ");
            }

            builder.Append(allergens[i].AllergyOn());
        }

        return builder.ToString();
    }
}