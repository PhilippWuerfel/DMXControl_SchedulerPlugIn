using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SchedulerAppointment
{
    public abstract class RecurrencePattern
    {
        public abstract bool[] GetRecurrenceArray();
        public abstract void SetRecurrenceArray(bool[] val);
        public abstract int GetRecurrenceVal();
        public abstract void SetRecurrenceVal(int val);
    }

    public class Daily : RecurrencePattern
    {
        public bool[] DailyTicker { get; set; } // {everyXDays, everyDay}
        public int EveryXDayVal { get; set; }
        public override bool[] GetRecurrenceArray()
        {
            return this.DailyTicker;
        }

        public override int GetRecurrenceVal()
        {
            return this.EveryXDayVal;
        }

        public override void SetRecurrenceArray(bool[] val)
        {
            this.DailyTicker = val;
        }
        public override void SetRecurrenceVal(int val)
        {
            this.EveryXDayVal = val;
        }
    }
    public class Weekly : RecurrencePattern
    {
        public bool[] WeekdayTicker { get; set; } // {monday, tuesday, wednesday, thursday, friday, saturday, sunday}
        public override bool[] GetRecurrenceArray()
        {
            return WeekdayTicker;
        }

        public override int GetRecurrenceVal()
        {
            throw new NotImplementedException();
        }

        public override void SetRecurrenceArray(bool[] val)
        {
            this.WeekdayTicker = val;
        }

        public override void SetRecurrenceVal(int val)
        {
            throw new NotImplementedException();
        }
    }
    public class NoPattern : RecurrencePattern
    {
        public override bool[] GetRecurrenceArray()
        {
            throw new NotImplementedException();
        }

        public override int GetRecurrenceVal()
        {
            throw new NotImplementedException();
        }

        public override void SetRecurrenceArray(bool[] val)
        {
            throw new NotImplementedException();
        }

        public override void SetRecurrenceVal(int val)
        {
            throw new NotImplementedException();
        }
    }

}
