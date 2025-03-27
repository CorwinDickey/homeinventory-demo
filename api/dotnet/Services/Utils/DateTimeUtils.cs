using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utils
{
    /// <summary>
    /// Utility methods for DateTime variables
    /// </summary>
    public static class DateTimeUtils
    {
        /// <summary>
        /// Converts a <see cref="DateTimeOffset"/> to an ISO-8601 string
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <returns>An ISO-8601 compliant string</returns>
        public static string ToIso(this DateTimeOffset date)
        {
            return date.ToString("O", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTimeOffset"/> to an ISO-8601 string
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <returns>An ISO-8601 compliant string</returns>
        public static string? ToIso(this DateTimeOffset? date)
        {
            if (date == null)
            {
                return null;
            }

            return ToIso(date.Value);
        }
    }
}
