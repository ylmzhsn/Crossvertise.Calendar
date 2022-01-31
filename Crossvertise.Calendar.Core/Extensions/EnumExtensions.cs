namespace Crossvertise.Calendar.Core.Extensions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the string specified on the enum value by using the [Display] attribute.
        /// </summary>
        public static string GetDisplayName(this Enum enumValue)
        {
            MemberInfo member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();

            var attribute = member?.GetCustomAttribute<DisplayAttribute>();

            if (member == null || attribute == null)
            {
                return enumValue.ToString();
            }

            return attribute.Name;
        }
    }
}
