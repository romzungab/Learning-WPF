using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CustomDatePicker
{
    public class CalendarToolTipConverter : IMultiValueConverter
    {
        private CalendarToolTipConverter()
        {

        }

        static CalendarToolTipConverter()
        {
            Instance = new CalendarToolTipConverter();
        }

        public static CalendarToolTipConverter Instance { get; private set; }


        #region IMultiValueConverter Members

        /// &lt;summary>
        /// Gets a tool tip for a date passed in. Could also return null
        /// &lt;/summary>
        /// &lt;remarks>
        /// The 'values' array parameter has the following elements:
        /// 
        /// values[0] = Binding #1: The date to be looked up. 
        /// This should be set up as a pathless binding; 
        /// the Calendar control will provide the date.
        /// 
        /// values[1] = Binding #2: A binding reference to the 
        /// DatePicker control that is invoking this converter.
        ///
        /// values[2] = Binding #3: Attached property CalendarBehavior.BlackOutDatesTextLookup for DatePicker
        /// &lt;/remarks>
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            // Exit if values not set
            if (values[0] == null || values[1] == null || values[2] == null)
                return null;

            // Get values passed in
            DateTime targetDate = (DateTime)values[0];
            DatePicker dp = (DatePicker)values[1];
            Dictionary < DateTime, string> blackOutDatesTextLookup = (Dictionary <DateTime, string>)values[2];
            string tooltip = null;
            blackOutDatesTextLookup.TryGetValue(targetDate, out tooltip);
            return tooltip;
        }

        /// &lt;summary>
        /// Not used.
        /// &lt;/summary>
        public object[] ConvertBack(object value, Type[] targetTypes,
             object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[0];
        }
        #endregion
    }
}
