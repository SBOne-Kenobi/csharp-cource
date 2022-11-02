using System.Text;

namespace StringSerialization;
public static class SerializationUtil
{
    public static byte[] SerializeString(this string s)
    {
        return Encoding.UTF8.GetBytes(s);
    }


    public static string DeserializeString(this byte[] s)
    {
        return Encoding.UTF8.GetString(s);
    }

}
