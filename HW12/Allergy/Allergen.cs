namespace Allergy;

public enum Allergen
{
    Egg,
    Peanut,
    Shellfish,
    Strawberry,
    Tomato,
    Chocolate,
    Pollen,
    Cat,
}

public static class AllergenUtils
{
    public static int GetScore(this Allergen allergen)
    {
        return 1 << (int)allergen;
    }

    public static string AllergyOn(this Allergen allergen)
    {
        return allergen switch
        {
            Allergen.Egg => "яйца",
            Allergen.Peanut => "арахис",
            Allergen.Shellfish => "моллюски",
            Allergen.Strawberry => "клубнику",
            Allergen.Tomato => "помидоры",
            Allergen.Chocolate => "шоколад",
            Allergen.Pollen => "пыльцу",
            Allergen.Cat => "кошек",
            _ => throw new ArgumentOutOfRangeException(nameof(allergen), allergen, null)
        };
    }

    public static bool Contains(this int score, Allergen allergen)
    {
        return (score & allergen.GetScore()) != 0;
    }
    
    public static List<Allergen> GetAllergens(this int score)
    {
        var result = new List<Allergen>();

        var current = 0;
        while (score > 0)
        {
            if ((score & 1) == 1)
            {
                result.Add((Allergen)current);
            }

            score >>= 1;
            ++current;
        }

        return result;
    }

    public static Allergen ParseFromRussian(string name)
    {
        name = name.ToLower();
        return name switch
        {
            "яйцо" => Allergen.Egg,
            "арахис" => Allergen.Peanut,
            "моллюск" => Allergen.Shellfish,
            "клубника" => Allergen.Strawberry,
            "помидор" => Allergen.Tomato,
            "шоколад" => Allergen.Chocolate,
            "пыльца" => Allergen.Pollen,
            "кошка" => Allergen.Cat,
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
        };
    }
}