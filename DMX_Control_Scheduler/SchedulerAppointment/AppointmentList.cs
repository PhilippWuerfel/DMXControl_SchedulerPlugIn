using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SchedulerAppointment
{
    public class AppointmentList
    {
        private List<Appointment> _myAppointmentList = new List<Appointment>();
        
        //Singleton
        private static AppointmentList instance = null;
        private static readonly object syncRoot = new Object();
        private AppointmentList()
        {
        }
        public static AppointmentList Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if(instance == null)
                    {
                        instance = new AppointmentList();
                    }
                }
                return instance;
            }
        }
        public Appointment this[int index]
        {
            get
            {
                return _myAppointmentList[index];
            }
            set
            {
                _myAppointmentList[index] = value;
                if (changed != null)
                {
                    changed(value, EventArgs.Empty);
                    hasChanged = true;
                }
            }
        }

        public delegate void ChangedHandler(object Sender, EventArgs e);
        public event ChangedHandler changed; 

        public List<Appointment> GetAppointmentList()
        {
            return _myAppointmentList;
        }
        private static bool hasChanged = false;
        public bool HasChanged()
        {
            // tracks, if AppointmentList has unsaved changes
            return hasChanged;
        }
        public void SortAppointmentListByStartDate()
        {
            _myAppointmentList.Sort(delegate (Appointment app1, Appointment app2) { return app1.StartTime.CompareTo(app2.StartTime); });
            if (changed != null)
            {
                changed(_myAppointmentList, EventArgs.Empty);
                hasChanged = true;
            }
        }
        public void AddAppointment2List(Appointment appointment)
        {
            this._myAppointmentList.Add(appointment);
            if(changed != null)
            {
                changed(appointment, EventArgs.Empty);
                hasChanged = true;
            }
        }
        public void DeleteAppointmentFromList(int index)
        {
            this._myAppointmentList.RemoveAt(index);
            if (changed != null)
            {
                changed(index, EventArgs.Empty);
                hasChanged = true;
            }
        }
        public void LoadAppointmentsFromXml(string filename)
        {
            // loading AppointmentList from XML-file

            using (StreamReader sr = new StreamReader(filename))
            {
                _myAppointmentList.Clear();

                XmlSerializer xser = new XmlSerializer(typeof(Appointment[]));

                Appointment[] appointments = (Appointment[])xser.Deserialize(sr);
                foreach(Appointment appointment in appointments)
                {
                    _myAppointmentList.Add(appointment);
                }

            // inform ChangedHandler
            }
            if (changed != null)
            {
                changed(filename, EventArgs.Empty);
                hasChanged = false;
            }
        }
        public void SaveAppointmentList2Xml(string filepath, string filename)
        {
            // saving AppointmentList to XML-file

            StringBuilder sb = new StringBuilder(filepath);
            sb.Append(@"\" + filename);
            string sw_path = sb.ToString();

            using (StreamWriter sw = new StreamWriter(sw_path))
            {
                List<Appointment> serializeList; // work around, because AppointmentList is Singleton
                serializeList = AppointmentList.Instance.GetAppointmentList();

                XmlSerializer xser = new XmlSerializer(serializeList.GetType());
                xser.Serialize(sw, serializeList);
            }

            hasChanged = false;
        }
        public void SaveAppointmentList2Xml(string filename)
        {
            // saving AppointmentList to XML-file

            using (StreamWriter sw = new StreamWriter(filename))
            {
                List<Appointment> serializeList; // work around, because AppointmentList is Singleton
                serializeList = AppointmentList.Instance.GetAppointmentList();

                XmlSerializer xser = new XmlSerializer(serializeList.GetType());
                xser.Serialize(sw, serializeList);              
            }

            hasChanged = false;
        }

        public List<Appointment> CalculateAppointmentsOnDay(DateTime givenDate)
        {
            // returns a List of appointments, which would fire an event on the given date
            List<Appointment> appointmentsOnDay = new List<Appointment>();

            foreach(Appointment currentAppointment in _myAppointmentList)
            {
                // check if StartDate <= date <= EndDate (note: sometimes no EndDate --> depending on RecurrencePattern)
                if(currentAppointment.StartDate.Date <= givenDate.Date)
                {
                    // depend interpretation on recurrence pattern
                    if (currentAppointment.RecurrencePattern.GetType().Name.Equals("Daily"))
                    {
                        bool[] dailyTicker = currentAppointment.RecurrencePattern.GetRecurrenceArray(); // DailyTicker: bool[] = [everXDays, everyDay]
                        int everyXDayVal = currentAppointment.RecurrencePattern.GetRecurrenceVal(); // EveryXDayVal

                        if(dailyTicker[0] == true)
                        {
                            // DailyTicker has EveryXDays ticked true
                            bool[] rangeOfReccurrence = currentAppointment.RangeOfRecurrence; //[NoEndDate, EndAfter, Endby]
                            int n_days = (givenDate.Date - currentAppointment.StartDate.Date).Days;
                            if (n_days % everyXDayVal == 0)
                            {
                                //everyXDayVal is multiple of n_days
                                // check rangeOfReccurrence RadioButtons [NoEndDate, EndAfter, Endby]
                                if(CheckDailyRangeOfReccurrence(currentAppointment, givenDate))
                                {
                                    appointmentsOnDay.Add(currentAppointment);
                                }                               
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if(dailyTicker[1] == true)
                        {
                            // DailyTicker has EveryDay ticked true
                            // check rangeOfReccurrence RadioButtons [NoEndDate, EndAfter, Endby]
                            if (CheckDailyRangeOfReccurrence(currentAppointment, givenDate))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }                
                    }
                    else if (currentAppointment.RecurrencePattern.GetType().Name.Equals("Weekly"))
                    {
                        bool[] weekdayTicker = currentAppointment.RecurrencePattern.GetRecurrenceArray(); // WeekdayTicker: bool[] = [monday, tuesday, wednesday, thursday, friday, saturday, sunday]
                        //check Monday
                        if (givenDate.DayOfWeek == DayOfWeek.Monday && weekdayTicker[0] == true)
                        {
                            if(CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                        //check Tuesday
                        if (givenDate.DayOfWeek == DayOfWeek.Tuesday && weekdayTicker[1] == true)
                        {
                            if (CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                        //check Wednesday
                        if (givenDate.DayOfWeek == DayOfWeek.Wednesday && weekdayTicker[2] == true)
                        {
                            if (CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                        //check Thursday
                        if (givenDate.DayOfWeek == DayOfWeek.Thursday && weekdayTicker[3] == true)
                        {
                            if (CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                        //check Friday
                        if (givenDate.DayOfWeek == DayOfWeek.Friday && weekdayTicker[4] == true)
                        {
                            //tbd
                            if (CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                        //check Saturday
                        if (givenDate.DayOfWeek == DayOfWeek.Saturday && weekdayTicker[5] == true)
                        {
                            if (CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                        //check Sunday
                        if (givenDate.DayOfWeek == DayOfWeek.Sunday && weekdayTicker[6] == true)
                        {
                            if (CheckWeeklyRangeOfReccurrence(currentAppointment, givenDate, givenDate.DayOfWeek))
                            {
                                appointmentsOnDay.Add(currentAppointment);
                            }
                        }
                    }
                    else if (currentAppointment.RecurrencePattern.GetType().Name.Equals("NoPattern"))
                    {
                        if(CheckNoPatternRangeOfReccurrence(currentAppointment, givenDate))
                        {
                            appointmentsOnDay.Add(currentAppointment);
                        }
                    }
                }
                else
                {
                    continue;
                }
                
            // check Recurrencepattern
                
            }

            return appointmentsOnDay;
        }
        private bool CheckDailyRangeOfReccurrence(Appointment currentAppointment, DateTime givenDate)
        {
            bool[] rangeOfReccurrence = currentAppointment.RangeOfRecurrence; //[NoEndDate, EndAfter, Endby]
            
            // check rangeOfReccurrence RadioButtons [NoEndDate, EndAfter, Endby]
            if (rangeOfReccurrence[0] == true)
            {
                // Ticker on NoEndDate
                return true;
            }
            else if (rangeOfReccurrence[1] == true)
            {
                // Ticker on EndAfter <NumOfOccurences>
                int n_days = (givenDate.Date - currentAppointment.StartDate.Date).Days + 1;
                int everyXDayVal = currentAppointment.RecurrencePattern.GetRecurrenceVal(); // EveryXDayVal

                int allowedOccurences = currentAppointment.NumOfOccurences;

                int finishedOccurences = n_days;
                if (everyXDayVal != 0)
                {
                    finishedOccurences = n_days / everyXDayVal;
                }
                if (finishedOccurences <= allowedOccurences)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (rangeOfReccurrence[2] == true)
            {
                // Ticker on Endby
                if (givenDate.Date <= currentAppointment.EndDate.Date)
                {         
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckWeeklyRangeOfReccurrence(Appointment currentAppointment, DateTime givenDate, DayOfWeek day)
        {
            bool[] rangeOfReccurrence = currentAppointment.RangeOfRecurrence; //[NoEndDate, EndAfter, Endby]
            // iwas mit Weekday
            // check rangeOfReccurrence RadioButtons [NoEndDate, EndAfter, Endby]
            if (rangeOfReccurrence[0] == true)
            {
                // Ticker on NoEndDate
                return true;
            }
            else if (rangeOfReccurrence[1] == true)
            {
                // Ticker on EndAfter <NumOfOccurences>
                int allowedOccurences = currentAppointment.NumOfOccurences;
                int finishedOccurences = 0;
                bool[] weekdayTicker = currentAppointment.RecurrencePattern.GetRecurrenceArray(); // WeekdayTicker: bool[] = [monday, tuesday, wednesday, thursday, friday, saturday, sunday]

                for (int i = 0; i<weekdayTicker.Length; i++)
                {
                    // C# DayOfWeek[Sunday-Saturday] weekdayTicker[Monday-Sunday]
                    if (weekdayTicker[i])
                    {
                        if (i == 6)
                        {
                            finishedOccurences += CountSpecificDays((DayOfWeek)0, currentAppointment.StartDate, givenDate);
                        }
                        else
                        {
                            finishedOccurences += CountSpecificDays((DayOfWeek)i + 1, currentAppointment.StartDate, givenDate);
                        }
                                                                 
                    }
                }
                
                //int finishedOccurences = CountSpecificDays(day, currentAppointment.StartDate, givenDate);
                
                if (finishedOccurences <= allowedOccurences)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (rangeOfReccurrence[2] == true)
            {
                // Ticker on Endby
                if (givenDate.Date <= currentAppointment.EndDate.Date)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CheckNoPatternRangeOfReccurrence(Appointment currentAppointment, DateTime givenDate)
        {
            bool[] rangeOfReccurrence = currentAppointment.RangeOfRecurrence; //[NoEndDate, EndAfter, Endby]
            // check rangeOfReccurrence RadioButtons [NoEndDate, EndAfter, Endby]
            if (rangeOfReccurrence[0] == true)
            {
                // Ticker on NoEndDate
                if(currentAppointment.StartDate.Date == givenDate.Date)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (rangeOfReccurrence[1] == true)
            {
                // Ticker on EndAfter <NumOfOccurences>
                int allowedOccurences = currentAppointment.NumOfOccurences;

                int finishedOccurences = (givenDate.Year - currentAppointment.StartDate.Year) +
                    (((givenDate.Month > currentAppointment.StartDate.Month) ||
                    ((givenDate.Month == currentAppointment.StartDate.Month) && (givenDate.Day >= currentAppointment.StartDate.Day))) ? 1 : 0);
                if (finishedOccurences <= allowedOccurences)
                {
                    if (currentAppointment.StartDate.Date == givenDate.Date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (rangeOfReccurrence[2] == true)
            {
                // Ticker on Endby
                if (givenDate.Date <= currentAppointment.EndDate.Date)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        private int CountSpecificDays(DayOfWeek day, DateTime startDate, DateTime endDate)
        {
            int n_totalDays = (endDate.Date - startDate.Date).Days;
            int n_specificDays = (int)Math.Floor((double)n_totalDays / 7);

            int remaindingDays = n_totalDays % 7;
            int sinceLastDay = (int)(endDate.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]
            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remaindingDays >= sinceLastDay) n_specificDays++;

            return n_specificDays;
        }
        public List<string> Validation(Appointment myAppointment)
        {
            // returns empty errorList if validation results in no mistakes
            // returns errorList with Errordescriptions in case of any validationproblems
            List<String> errorList = new List<string>();           

            // check if myAppointment.AppointmentName not empty
            if (myAppointment.AppointmentName == "") errorList.Add("No appointment name entered");

            // check if LightScene was entered
            if (myAppointment.LightScene == "") errorList.Add("No Light Scene entered");
            
            // check if EndDate after Startdate
            if(myAppointment.StartDate > myAppointment.EndDate)
            {
                errorList.Add("EndDate can not be earlier than StartDate");
            }
            // ...

            return errorList;
         }
    }
}
