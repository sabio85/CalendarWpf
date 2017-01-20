using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.BL
{
    /// <summary>
    /// Class to store all the necessary Date operations
    /// </summary>
    public class DateTimeOperations
    {
        // Number of positions for each day
        private const int NumberOfPositions = 6;

        /// <summary>
        /// Takes parsed Date and transforms it to Calendar view
        /// </summary>
        /// <param name="parsedDate"></param>
        /// <param name="appType"></param>
        /// <returns></returns>
        public string Stringify(DateTime parsedDate, AplicationType appType = AplicationType.Console)
        {
            var currentDay = parsedDate.Day;

            //Identify 
            var firstDayOfMonthIndex = (int)(parsedDate.AddDays(-currentDay).DayOfWeek + 1);

            //Output first n spaces if month starts not from Monday
            var resultString = "\n" + FixedWidthFormat(string.Empty, NumberOfPositions * (firstDayOfMonthIndex - 1));

            for (int i = 1; i <= DateTime.DaysInMonth(parsedDate.Year, parsedDate.Month); i++)
            {
                resultString += currentDay == i ?
                                           FixedWidthFormat(" [" + i + "]", NumberOfPositions) :
                                           FixedWidthFormat(i.ToString(), NumberOfPositions);

                //Add new string when we reach Sunday
                if (firstDayOfMonthIndex % 7 == 0)
                    resultString += "\n\n";

                firstDayOfMonthIndex++;
            }

            //Need adjustments for Wpf application. See below for details.
            if (appType == AplicationType.Wpf)
            {
                var stringBuilder = new StringBuilder(resultString);

                //The problem is that 'space' size is different on console and Wpf UI.
                //So both replaces necessary to make calendar look similar way both on Wpf and Console.
                stringBuilder.Replace("[", " [");
                stringBuilder.Replace(" ", "  ");
                resultString = stringBuilder.ToString();
            }

            return resultString;
        }

        public DateValidationResult ValidateDate(string dateString)
        {
            DateTime parsedDate;

            var parsingResult = DateTime.TryParse(dateString, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out parsedDate);

            if (!parsingResult)
            {
                return new DateValidationResult { Success = false, Message = "Entered incorrect Date or format is unsupported!" };
            }

            return new DateValidationResult { Success = true, Result = parsedDate };
        }



        #region Private Helpers

        /// <summary>
        /// Inserts value into a fixed width string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string FixedWidthFormat(string value, int length)
        {
            string format = string.Format("{{0,{0}}}", length);

            return string.Format(format, value);
        }

        #endregion
    }
}
