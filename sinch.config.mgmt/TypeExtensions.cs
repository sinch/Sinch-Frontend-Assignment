using System.Text;

namespace Sinch.Config.Mgmt;

public static class TypeExtensions
{
    public static string FriendlyTypeName(this Type type)
    {
        if (!type.IsGenericType)
        {
            return type.Name;
        }

        var builder = new StringBuilder();
        var name = type.Name;
        var index = name.IndexOf('`');

        builder.Append(name[..index]);
        builder.Append('<');

        var first = true;

        foreach (var arg in type.GetGenericArguments())
        {
            if (!first)
            {
                builder.Append(',');
            }

            builder.Append(FriendlyTypeName(arg));

            first = false;
        }

        builder.Append('>');

        return builder.ToString();
    }

}
