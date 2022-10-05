using Interfaces;

var stringUniversal = new StringUniversal();
Console.WriteLine(stringUniversal.GetString()); // From Abstract
Console.WriteLine(((IStringBuilder) stringUniversal).GetString()); // From Builder
Console.WriteLine(((IStringCreator) stringUniversal).GetString()); // From Creator
