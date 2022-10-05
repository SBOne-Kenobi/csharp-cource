namespace Interfaces;

public class StringUniversal : AbstractStringFactory, IStringBuilder, IStringCreator
{
    public override string GetString()
    {
        return "From Abstract";
    }

    string IStringBuilder.GetString()
    {
        return "From Builder";
    }

    string IStringCreator.GetString()
    {
        return "From Creator";
    }
}