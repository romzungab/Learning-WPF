using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomDatePicker
{
    public static class CalendarBehavior
    {
        #region BlackOutDatesTextLookup

        public static readonly DependencyProperty BlackOutDatesTextLookupProperty =DependencyProperty.RegisterAttached("BlackOutDatesTextLookup",typeof(Dictionary<DateTime, string>), typeof(CalendarBehavior),new FrameworkPropertyMetadata(new Dictionary<DateTime, string>()));

    public static Dictionary<DateTime,string> GetBlackOutDatesTextLookup(DependencyObject d)
        {
            return (Dictionary<DateTime, string>)d.GetValue(BlackOutDatesTextLookupProperty);
        }

        public static void SetBlackOutDatesTextLookup(DependencyObject d, Dictionary<DateTime, string> value)
    {
        d.SetValue(BlackOutDatesTextLookupProperty, value);
    }

    #endregion

    #region NonWorkingDays

    public static readonly DependencyProperty NonWorkingDaysProperty =
        DependencyProperty.RegisterAttached("NonWorkingDays",typeof(IEnumerable<NonWorkingDayDto>), typeof(CalendarBehavior),new FrameworkPropertyMetadata(null, OnNonWorkingDaysChanged));
    public static IEnumerable<NonWorkingDayDto> GetNonWorkingDays(DependencyObject d)
    {
        return (IEnumerable<NonWorkingDayDto >)d.GetValue(NonWorkingDaysProperty);
    }

    public static void SetNonWorkingDays(DependencyObject d, IEnumerable<NonWorkingDayDto> value)
    {
        d.SetValue(NonWorkingDaysProperty, value);
    }

private static void OnNonWorkingDaysChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
    DatePicker datePicker = d as DatePicker;
    if (e.NewValue != null && datePicker != null)
    {
        IEnumerable< NonWorkingDayDto > localNonWorkingDays = (IEnumerable<NonWorkingDayDto >)e.NewValue;
                Dictionary <DateTime, string> blackoutDatesTextLookup = new Dictionary< DateTime, string> ();

        // IMPORTANT NOTE
        // Due to the way the DatePicker Calendar BlackoutDates collection works
        // It is dog slow to clear the BlackoutDates collection and add items in one by one
        // so we have to perform some voodoo, where we remove the Blackout dates that are not 
        // in the new NonWorking value, 
        // and then add in ONLY those that are missing from the new
        // NonWorking days value into the BlackoutDates collection. 
        // It sucks but it makes a BIG difference
        // Using Clear() and Add in for loop its like 1500ms (Per DatePicker), 
        // and using this method its down to
        // something like 35ms (Per DatePicker).......So please do not change this logic
        var toRemove = datePicker.BlackoutDates.Select
        (x => x.Start).Except(localNonWorkingDays.Select(y => y.Date)).ToList();

        foreach (DateTime dateTime in toRemove)
        {
            datePicker.BlackoutDates.Remove
            (datePicker.BlackoutDates.Single(x => x.Start == dateTime));
        }

        foreach (NonWorkingDayDto nonWorkingDay in localNonWorkingDays)
        {
            if (!datePicker.BlackoutDates.Contains(nonWorkingDay.Date))
            {
                CalendarDateRange range = new CalendarDateRange(nonWorkingDay.Date);
                datePicker.BlackoutDates.Add(range);
            }
            blackoutDatesTextLookup[nonWorkingDay.Date] = nonWorkingDay.Description;
        }
        datePicker.SetValue(BlackOutDatesTextLookupProperty, blackoutDatesTextLookup);
    }
}
    #endregion
}
}
