using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Lastfm.Client.Handlers;

/// <summary>
/// The enum reflection
/// </summary>
public static class EnumReflection
{
    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="e">The e.</param>
    /// <returns></returns>
    public static string GetDescription<TEnum>(this TEnum e)
        where TEnum : Enum, IConvertible
    {
        if (e is Enum)
        {
            Type type = e.GetType();
            Array values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
        }

        return string.Empty;
    }
}