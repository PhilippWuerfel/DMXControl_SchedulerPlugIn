using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchedulerAppointment
{
    [Serializable]
    public class Appointment
    {
        [System.ComponentModel.DisplayName("Appointment")]
        public string AppointmentName { get; set; }
        [System.ComponentModel.DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [System.ComponentModel.DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [System.ComponentModel.DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        [System.ComponentModel.DisplayName("Lightscene")]
        public string LightScene { get; set; }
       
        [XmlElement("daily", typeof(Daily))]
        [XmlElement("weekly", typeof(Weekly))]
        [XmlElement("noPattern", typeof(NoPattern))]
        public RecurrencePattern RecurrencePattern { get; set; }

        [System.ComponentModel.DisplayName("Has Lightscene")]
        public bool HasLightScene { get; set; }

        //[XmlElement("RangeOfRecurrence")]
        public bool[] RangeOfRecurrence { get; set; } //[NoEndDate, EndAfter, Endby]
        public int NumOfOccurences { get; set; }
        public Appointment()
        {
            this.AppointmentName = "default";
        }        
    }
}