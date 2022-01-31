namespace Crossvertise.Calendar.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Enum Helper class
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Generates enum list
        /// </summary>
        public static IEnumerable<TEnum> GetEnumList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}
