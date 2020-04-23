using System;

namespace TrainDB {
    internal static class DateTimeExtensionMethods {
        /// <summary>
        ///     Converts a <see cref="DateTime"/> object to a culture-invariant string
        ///     as understood by SQLite.
        /// </summary>
        /// <remarks>See https://www.sqlite.org/lang_datefunc.html for details</remarks>
        /// <param name="date">The <see cref="DateTime"/> object to be converted</param>
        /// <returns>A date string as formatted by SQLite</returns>
        internal static string ToSQLiteDateFormat(this DateTime date) {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
