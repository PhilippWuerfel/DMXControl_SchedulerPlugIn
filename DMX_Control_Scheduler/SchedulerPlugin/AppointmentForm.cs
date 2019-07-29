using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lumos.GUI;
using Lumos.GUI.BaseWindow;
using LumosLIB.GUI.Windows;
using WeifenLuo.WinFormsUI.Docking;
using SchedulerAppointment;
using SchedulerCommunicator;

namespace SchedulerPlugin
{
    public partial class AppointmentForm : ToolWindow
    {
        private Appointment myAppointment;
        private int myAppointmentListIndex;
        private List<object> myLightSceneList;

        public AppointmentForm()
        {
            myAppointment = new Appointment();
            myAppointmentListIndex = -1;

            InitializeComponent();

            // Set start values to Today
            dateTimePicker_startDate.Value = DateTime.Today.Date;
            dateTimePicker_endDate.Value = DateTime.Today.Date;            

            Communicator myCommunicator = new Communicator();
            myLightSceneList = myCommunicator.GetLightSceneList();
            var bindingList = new BindingList<object>(myLightSceneList);
            var source = new BindingSource(bindingList, null);
            lb_lightSceneList.DataSource = source;
            
        }
        public AppointmentForm(Appointment appointment, int appointmentListIndex)
        {
            myAppointment = appointment;
            myAppointmentListIndex = appointmentListIndex;

            InitializeComponent();

            Communicator myCommunicator = new Communicator();
            myLightSceneList = myCommunicator.GetLightSceneList();
            var bindingList = new BindingList<object>(myLightSceneList);
            var source = new BindingSource(bindingList, null);
            lb_lightSceneList.DataSource = source;

            // opens AppointmentForm like under "add Appointment" with fields filled depending on the values of selected appointment
            txt_appointmentName.Text = myAppointment.AppointmentName;
            dateTimePicker_startDate.Value = myAppointment.StartDate;
            dateTimePicker_startTime.Value = myAppointment.StartTime;
            dateTimePicker_endDate.Value = myAppointment.EndDate;
            txt_lightSceneName.Text = myAppointment.LightScene;

            // build recurrence pattern depending on "Daily", "Weekly" or "OneTime" Selection
            if (myAppointment.RecurrencePattern.GetType().Name == "Daily")
            {
                rdb_daily.Checked = true;
                // build dailyTicker
                bool[] dailyTicker = myAppointment.RecurrencePattern.GetRecurrenceArray();
                rdb_everyXDays.Checked = dailyTicker[0];
                rdb_everyDay.Checked = dailyTicker[1];

                int everyXDayVal = myAppointment.RecurrencePattern.GetRecurrenceVal();
                txt_everyXDay.Text = everyXDayVal.ToString();
            }

            if (myAppointment.RecurrencePattern.GetType().Name == "Weekly")
            {
                rdb_weekly.Checked = true;
                // build weekdayTicker
                bool[] weekdayTicker = myAppointment.RecurrencePattern.GetRecurrenceArray();
                chk_monday.Checked = weekdayTicker[0];
                chk_tuesday.Checked = weekdayTicker[1];
                chk_wednesday.Checked = weekdayTicker[2];
                chk_thursday.Checked = weekdayTicker[3];
                chk_friday.Checked = weekdayTicker[4];
                chk_saturday.Checked = weekdayTicker[5];
                chk_sunday.Checked = weekdayTicker[6];
            }
            if (myAppointment.RecurrencePattern.GetType().Name == "NoPattern")
            {
                rdb_noPattern.Checked = true;
            }

            // build rangeOfRecurrence
            if (myAppointment.RangeOfRecurrence.Length == 3)
            {
                rdb_noEndDate.Checked = myAppointment.RangeOfRecurrence[0];
                rdb_numOfOccurrences.Checked = myAppointment.RangeOfRecurrence[1];
                rdb_endBy.Checked = myAppointment.RangeOfRecurrence[2];

                txt_numOfOccurences.Text = myAppointment.NumOfOccurences.ToString();
            }
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            myAppointment.AppointmentName = txt_appointmentName.Text.ToString();
            myAppointment.StartDate = dateTimePicker_startDate.Value;
            // assure, that Date of the StartTime property = Date of the StartDate property
            myAppointment.StartTime = new DateTime(dateTimePicker_startDate.Value.Year, dateTimePicker_startDate.Value.Month, dateTimePicker_startDate.Value.Day, dateTimePicker_startTime.Value.Hour, dateTimePicker_startTime.Value.Minute, dateTimePicker_startTime.Value.Second, dateTimePicker_startTime.Value.Millisecond);

            if (rdb_endBy.Checked)
            {
                myAppointment.EndDate = dateTimePicker_endDate.Value;
            }
            else
            {
                myAppointment.EndDate = dateTimePicker_endDate.MaxDate;
            }
            //myAppointment.EndDate = dateTimePicker_endDate.Value;
            myAppointment.LightScene = txt_lightSceneName.Text;

            // build Appointment depending on recurrence pattern
            if (rdb_daily.Checked)
            {
                myAppointment.RecurrencePattern = new Daily();
                // build dailyTicker
                bool[] myDailyTicker = { rdb_everyXDays.Checked, rdb_everyDay.Checked };
                myAppointment.RecurrencePattern.SetRecurrenceArray(myDailyTicker);
                myAppointment.RecurrencePattern.SetRecurrenceVal(Convert.ToInt32(txt_everyXDay.Text));
            }
            if (rdb_weekly.Checked)
            {
                myAppointment.RecurrencePattern = new Weekly();
                // build weekdayTicker
                bool[] myWeekdayTicker = { chk_monday.Checked, chk_tuesday.Checked, chk_wednesday.Checked, chk_thursday.Checked, chk_friday.Checked, chk_saturday.Checked, chk_sunday.Checked };
                myAppointment.RecurrencePattern.SetRecurrenceArray(myWeekdayTicker);
            }
            if (rdb_noPattern.Checked)
            {
                myAppointment.RecurrencePattern = new NoPattern();
            }

            // build rangeOfRecurrence
            bool[] myRangeOfRecurrence = { rdb_noEndDate.Checked, rdb_numOfOccurrences.Checked, rdb_endBy.Checked };
            myAppointment.RangeOfRecurrence = myRangeOfRecurrence;
            myAppointment.NumOfOccurences = Convert.ToInt32(txt_numOfOccurences.Text);

            // Validation before adding myAppointment to AppointmentList
            List<string> errorList = AppointmentList.Instance.Validation(myAppointment);
            if (errorList.Count == 0)
            {
                // add new entry to AppointmentList if myAppointmentListIndex == -1 (accessed via add button) else edit Appointmentlist (via edit button)
                if (myAppointmentListIndex == -1)
                {
                    AppointmentList.Instance.AddAppointment2List(myAppointment);
                }
                else
                {
                    AppointmentList.Instance[myAppointmentListIndex] = myAppointment;
                }

                this.Close();
            }
            else
            {
                // show entries of errorList in MsgBox
                string errorCaption = "Errorlist from validation";
                string errorMessage = string.Join(Environment.NewLine, errorList);
                
                MessageBox.Show(errorMessage, errorCaption);
            }          
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rdb_daily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_daily.Checked)
            {
                rdb_everyXDays.Visible = true;
                txt_everyXDay.Visible = true;
                lbl_everyXDay.Visible = true;

                rdb_everyDay.Visible = true;
            }
            else
            {
                rdb_everyXDays.Visible = false;
                txt_everyXDay.Visible = false;
                lbl_everyXDay.Visible = false;

                rdb_everyDay.Visible = false;
            }
        }
        private void Rdb_weekly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_weekly.Checked)
            {
                chk_monday.Visible = true;
                chk_tuesday.Visible = true;
                chk_wednesday.Visible = true;
                chk_thursday.Visible = true;
                chk_friday.Visible = true;
                chk_saturday.Visible = true;
                chk_sunday.Visible = true;
            }
            else
            {
                chk_monday.Visible = false;
                chk_tuesday.Visible = false;
                chk_wednesday.Visible = false;
                chk_thursday.Visible = false;
                chk_friday.Visible = false;
                chk_saturday.Visible = false;
                chk_sunday.Visible = false;
            }
        }
        private void DateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
        {
            rdb_endBy.Checked = true;
            if(dateTimePicker_endDate.Value < dateTimePicker_startDate.Value)
            {
                dateTimePicker_endDate.Value = dateTimePicker_startDate.Value;
                dateTimePicker_endDate.MinDate = dateTimePicker_startDate.Value;
            }

        }
        private void Lb_lightSceneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_lightSceneName.Text = lb_lightSceneList.SelectedItem.ToString();
        }

        private void DateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_endDate.Value < dateTimePicker_startDate.Value)
            {
                dateTimePicker_endDate.Value = dateTimePicker_startDate.Value;
                dateTimePicker_endDate.MinDate = dateTimePicker_startDate.Value;
            }
        }
    }
}
