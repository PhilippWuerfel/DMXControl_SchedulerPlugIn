using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Reflection;
using SchedulerAppointment;
using SchedulerCommunicator;
using SchedulerLogFileWriter;

namespace SchedulerTimer
{

    public class EventWatchdog
    {
        private List<System.Timers.Timer> _myEventTimerList = new List<System.Timers.Timer>();
        private System.Timers.Timer _eventtimer;
        private LogFileWriter Log = new LogFileWriter();

        //Singleton
        private static EventWatchdog instance = null;
        private static readonly object syncRoot = new Object();
        private EventWatchdog()
        {
        }
        public static EventWatchdog Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new EventWatchdog();
                    }
                }
                return instance;
            }
        }



        public void StartWatchDog()
        {
            //Gets the appointmentlist created in UI
            List<Appointment> todaysAppointmentList = AppointmentList.Instance.CalculateAppointmentsOnDay(DateTime.Now);
            SetTimerForNextEvents(todaysAppointmentList);
        }

        private void SetTimerForNextEvents(List<Appointment> todaysAppointmentList)
        {
            foreach (Appointment appointment in todaysAppointmentList)
            {
                TimeSpan startTime = appointment.StartTime.TimeOfDay;
                string lightscene = appointment.LightScene;
               

                if (startTime >= DateTime.Now.TimeOfDay)
                {
                    CalculateTimespan(startTime, lightscene);
                }/*
                else
                {
                    Log.LogWrite(lightscene + "... already passed");
                }*/
            }
        }

        //Calculates the Timespan to firing the event
        private void CalculateTimespan (TimeSpan starttime, string lightscene)
        {
            TimeSpan Diff = (starttime - DateTime.Now.TimeOfDay);
            double timeDiff = Diff.TotalMilliseconds;
            SetTimer(timeDiff, lightscene);

        }
        
        //Sets the Timer 
        private void SetTimer(double timeDiff, string lightscene)
        {          
            _eventtimer = new System.Timers.Timer();
            _eventtimer.Interval = timeDiff;
            _eventtimer.Elapsed += (sender, e) => OnTimedEvent(sender, e, lightscene);
            _eventtimer.AutoReset = false;
            _eventtimer.Start();

            // save Timer in _myEventTimerList for later access
            _myEventTimerList.Add(_eventtimer);
        }

        public void StopWatchdog()
        {
            // Stops all started Timers and clears EventTimerList afterwards
            for (int i = 0; i<_myEventTimerList.Count; i++)
            {
                _myEventTimerList[i].Stop();
            }
            _myEventTimerList.Clear();

            // Stop all LightScened in DMXControl
            Communicator myCommunicator = new Communicator();
            myCommunicator.StopAllLightscenes();

        }

        private void OnTimedEvent(object source, EventArgs e, string lightscene)
        {
            Communicator myCommunicator = new Communicator();
            try
            {
                myCommunicator.StartLightscene(lightscene);
            }
            catch (Exception ex)
            {
                Log.LogWrite("Couldn't start lightscene: " + lightscene);
            }
        }
    }
}


