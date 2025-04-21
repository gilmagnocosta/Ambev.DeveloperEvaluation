using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM.Helpers;

public static class EntityHelper
{
    public static List<string> GetAttributeNames(Type type)
    {
        var attrs = Attribute.GetCustomAttributes(type);
        var allowedAttiributes = new List<string>();

        foreach (Attribute attr in attrs)
        {
            allowedAttiributes.Add(attr.GetType().Name.ToLower());
        }

        return allowedAttiributes;
    }

    public static IEnumerable<T>? OrderBy<T>(this IEnumerable<T> entities, string propertyName, bool ascending)
    {
        if (entities == null || !entities.Any() || string.IsNullOrEmpty(propertyName))
            return entities;

        var propertyInfo = entities?.First()?.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        return entities.OrderBy(e => propertyInfo.GetValue(e, null));
    }
}
