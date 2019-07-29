using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lumos.GUI;
using Lumos.GUI.Settings;
using Lumos.GUI.BaseWindow;
using LumosLIB.GUI.Windows;
using WeifenLuo.WinFormsUI.Docking;
using SchedulerAppointment;
using System.IO;
using System.Xml.Serialization;
using org.dmxc.lumos.Kernel.Settings;
using SchedulerLogFileWriter;
using SchedulerCommunicator;
using System.Reflection;

namespace SchedulerPlugin
{
    public partial class SchedulerForm : ToolWindow
    {
        public bool IsRunning { get; set; } // checks if SchedulerPlugin is turned on in DMX-Control
        public string LastEditedFilePath { get; set; } // Path of last file for AutoLoad of last edited AppointmentList (which was saved as XML-File)

        private LogFileWriter Log = new LogFileWriter();
        public SchedulerForm()
        {
            Log.LogWrite("Test Log....");
            InitializeComponent();

            //Define in which Menu the window will be displayed
            this.MainFormMenu = MenuType.Windows;
            //Defining TabText for DMX Control Plugin
            this.TabText = "Scheduler Plug In";

            AppointmentList.Instance.changed += Instance_changed;

            //Setting for "autorun" of Scheduler on start-up: Get value of Scheduler_chkbox IsRunning marked on last session
            try
            {
                IsRunning = SettingsManager.getInstance().getGuiSetting<bool>("SchedulerAutoRun.SETTING");
                chkbox_isSchedulerRunning.Checked = IsRunning;
            }
            catch(Exception e)
            {
                Log.LogWrite("Couln't load SchedulerAutoRun.SETTING");
                try
                {
                    SettingsManager.getInstance().setGuiSetting("SchedulerAutoRun.SETTING", false);
                    Log.LogWrite("Couln't load SchedulerAutoRun.SETTING, AutoRun is now set to false");
                }catch(Exception ex)
                {
                    Log.LogWrite("Couldn't set SchedulerAutoRun.SETTING");
                }
            }
            

            //AutoLoad of last edited AppointmentList (which was saved as XML-File)
            try
            {
                LastEditedFilePath = SettingsManager.getInstance().getGuiSetting<string>("LastEditedFilePath.SETTING");
                AppointmentList.Instance.LoadAppointmentsFromXml(LastEditedFilePath);
            }
            catch (Exception e)
            {
                Log.LogWrite("Couldn't load XML-File");
                try
                {
                    string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    StringBuilder sb = new StringBuilder(m_exePath);
                    sb.Append(@"\default.xml");
                    string xml_path = sb.ToString();

                    //AppointmentList.Instance.SaveAppointmentList2Xml(m_exePath, "default.xml");
                    AppointmentList.Instance.SaveAppointmentList2Xml(xml_path);
                    SettingsManager.getInstance().setGuiSetting("LastEditedFilePath.SETTING", xml_path);

                    Log.LogWrite("Couldn't load XML file, default XML-File was created in GUI Plug-In folder");
                }
                catch(Exception ex)
                {
                    Log.LogWrite("Couldn't create default XML-File in GUI Plug-In folder");
                }
            }

            // AutoStart EventWatchdog if Setting IsRunning is true
            if (IsRunning)
            {
                SchedulerTimer.EventWatchdog.Instance.StartWatchDog();
            }
            else
            {
                //SchedulerTimer.EventWatchdog.Instance.StopWatchdog();
            }
        }
        private void Instance_changed(object Sender, EventArgs e)
        {
            var bindingList = new BindingList<Appointment>(AppointmentList.Instance.GetAppointmentList());
            var source = new BindingSource(bindingList, null);

            gv_appointmentList.DataSource = source;
            gv_appointmentList.CellFormatting += GridView_CellFormatting;
            
            // only the first 6 Columns will be displayed
            for (int i = 0; i < gv_appointmentList.ColumnCount; i++)
            {
                if (i > 6) gv_appointmentList.Columns[i].Visible = false;
            }

            // Make days in calendar bolded, if Scheduler would fire an event
            MakeDaysWithAppointmentBolded(30);
        }
        private DialogResult SaveAppointments()
        {
            SaveFileDialog sfd_appointments = new SaveFileDialog();
            sfd_appointments.Filter = "XML files|*.xml";
            sfd_appointments.Title = "Save Appointments as XML File";
            sfd_appointments.RestoreDirectory = true;
            DialogResult sfd_result = sfd_appointments.ShowDialog();
            if (sfd_result == DialogResult.OK)
            {
                // saving AppointmentList as XML-file         
                try
                {
                    AppointmentList.Instance.SaveAppointmentList2Xml(sfd_appointments.FileName);
                }
                catch (Exception e)
                {
                    Log.LogWrite("Couldn't save XML file");
                }
                try
                {
                    SettingsManager.getInstance().setGuiSetting("LastEditedFilePath.SETTING", sfd_appointments.FileName);
                }
                catch (Exception e)
                {
                    Log.LogWrite("Couldn't set LastEditedFilePath.SETTING");
                }
            }

            return sfd_result;
        }
        private DialogResult OpenAppointments()
        {
            // run OpenFileDialog
            OpenFileDialog ofd_appointments = new OpenFileDialog();
            ofd_appointments.Filter = "XML files|*.xml|all files|*.*";
            DialogResult ofd_result = ofd_appointments.ShowDialog();
            if (ofd_result == DialogResult.OK)
            {
                string datatype_test = Path.GetExtension(ofd_appointments.FileName);
                if(datatype_test == ".xml")
                {
                    try
                    {
                        AppointmentList.Instance.LoadAppointmentsFromXml(ofd_appointments.FileName);      
                    }
                    catch (Exception e)
                    {
                        Log.LogWrite("Couldn't load XML file");
                    }
                    try
                    {
                        SettingsManager.getInstance().setGuiSetting("LastEditedFilePath.SETTING", ofd_appointments.FileName);
                    }
                    catch (Exception e)
                    {
                        Log.LogWrite("Couldn't set LastEditedFilePath.SETTING");
                    }

                    //Check if LightScenes of AppointmentList exist in current Project of DMXControl
                    //Fill Column "Has LightScene" in GridView
                    Communicator myCommunicator = new Communicator();
                    myCommunicator.HasLightscene();
                }
                else
                {
                    MessageBox.Show("Wrong Datatype! Cannot load files of type: " + datatype_test);
                }
            }         

            return ofd_result;
        }

        private void Btn_loadAppointments_Click(object sender, EventArgs e)
        {
            if (AppointmentList.Instance.HasChanged())
            {

                string unsaved_msg = "Do you want to save changes on current AppointmentList?";
                string unsaved_caption = "Unsaved changes on current AppointmentList";
                MessageBoxButtons unsaved_btns = MessageBoxButtons.YesNoCancel;
                DialogResult unsaved_result;

                unsaved_result = MessageBox.Show(unsaved_msg, unsaved_caption, unsaved_btns);

                if (unsaved_result == System.Windows.Forms.DialogResult.Yes)
                {
                    // save before open new file
                    DialogResult my_sfd_result = SaveAppointments();
                    if (my_sfd_result == DialogResult.OK)
                    {
                        MessageBox.Show("Changes saved!");
                        // run OpenFileDialog
                        DialogResult my_ofd_result = OpenAppointments();
                    }
                }else if (unsaved_result == DialogResult.No)
                {
                    // run OpenFileDialog
                    DialogResult my_ofd_result = OpenAppointments();
                }
                else if(unsaved_result == DialogResult.Cancel)
                {
                    // returns and keeps current AppointmentList opened
                    return;
                }
            }
            else
            {
                // run OpenFileDialog
                DialogResult my_ofd_result = OpenAppointments();
            }
        }
        private void Btn_saveAppointments_Click(object sender, EventArgs e)
        {
            DialogResult my_sfd_result = SaveAppointments();
            /*if(my_sfd_result == DialogResult.OK)
            {
                MessageBox.Show("Changes saved!");
            }*/
        }
        private void Btn_addAppointment_Click(object sender, EventArgs e)
        {
            new AppointmentForm().ShowDialog();

            //Check if LightScenes of AppointmentList exist in current Project of DMXControl
            //Fill Column "Has LightScene" in GridView
            Communicator myCommunicator = new Communicator();
            myCommunicator.HasLightscene();
        }
        private void Btn_editAppointment_Click(object sender, EventArgs e)
        {
            // TBD (DMX has issues here!)
            // Entries in StartDate change while DMX opened and new appointment is added
            int row_index = gv_appointmentList.CurrentRow.Index;
            AppointmentList myAppointmentList = AppointmentList.Instance;
            Appointment myAppointment = myAppointmentList[row_index];

            AppointmentForm myAppointmentForm = new AppointmentForm(myAppointment, row_index);
            myAppointmentForm.ShowDialog();

            //Check if LightScenes of AppointmentList exist in current Project of DMXControl
            //Fill Column "Has LightScene" in GridView
            Communicator myCommunicator = new Communicator();
            myCommunicator.HasLightscene();
        }
        private void Btn_delAppointment_Click(object sender, EventArgs e)
        {
            int row_index = gv_appointmentList.CurrentRow.Index;
            AppointmentList.Instance.DeleteAppointmentFromList(row_index);
        }
        private void SchedulerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppointmentList.Instance.changed -= Instance_changed;
        }

        //-----------------------------------------------------------------------------------
        private void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.gv_appointmentList.Columns[e.ColumnIndex].Name == "StartDate" || this.gv_appointmentList.Columns[e.ColumnIndex].Name == "EndDate")
            {
                ShortFormDateFormat(e);
            }
            else if (this.gv_appointmentList.Columns[e.ColumnIndex].Name == "StartTime")
            {
                DateTimeToTimeFormat(e);
            }
            else if (this.gv_appointmentList.Columns[e.ColumnIndex].Name == "RecurrencePattern")
            {
                //DateTimeToTimeFormat(e);
                RecurrencePatternFormat(e);
            }
        }
        private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());

                    dateString.Append(theDate.Day);
                    dateString.Append(".");
                    dateString.Append(theDate.Month);
                    dateString.Append(".");
                    dateString.Append(theDate.Year);
                    formatting.Value = dateString.ToString();
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
            }
        }
        private static void DateTimeToTimeFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());

                    dateString.Append(theDate.ToLongTimeString());
                    formatting.Value = dateString.ToString();
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
            }
        }
        private static void RecurrencePatternFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    System.Text.StringBuilder recurrencePatternString = new System.Text.StringBuilder();
                    String thePattern = formatting.Value.ToString();

                    recurrencePatternString.Append(thePattern);
                    recurrencePatternString.Replace("SchedulerAppointment.", "");
                    formatting.Value = recurrencePatternString.ToString();
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
            }
        }
        private void chkbox_isSchedulerRunning_CheckedChanged(object sender, EventArgs e)
        {
            // Read and Write of Settings
            IsRunning = chkbox_isSchedulerRunning.Checked;
            try
            {
                SettingsManager.getInstance().setGuiSetting("SchedulerAutoRun.SETTING", IsRunning);
            }
            catch (Exception ex)
            {
                Log.LogWrite("Couldn't set SchedulerAutoRun.SETTING");
            }
            //Start EventWatchDog from Timer, if AutoRun is true, Stop EventWatchDog from Timer, if AutoRun is false
            if (IsRunning)
            {
                SchedulerTimer.EventWatchdog.Instance.StartWatchDog();
            }
            else
            {
                SchedulerTimer.EventWatchdog.Instance.StopWatchdog();
            }
        }

        private void btn_SortByStartDateTime_Click(object sender, EventArgs e)
        {
            AppointmentList.Instance.SortAppointmentListByStartDate();
        }

        private void MakeDaysWithAppointmentBolded(int numberOfCheckedDays)
        {
            // Make days in calendar bolded, if Scheduler would fire an event

            // reset bolded dates
            calendar_month_scheduler.RemoveAllBoldedDates();

            // make matching days bolded
            List<DateTime> boldedDates = new List<DateTime>();
            for (int i = 0; i < numberOfCheckedDays; i++)
            {
                List<Appointment> FiredApps = AppointmentList.Instance.CalculateAppointmentsOnDay((DateTime.Today.AddDays(i)));
                if (FiredApps.Count > 0)
                {
                    boldedDates.Add((DateTime.Today.AddDays(i)));
                }
            }
            calendar_month_scheduler.BoldedDates = boldedDates.ToArray();
        }
        
        //private void button1_Click(object sender, EventArgs e)
        //{
            /*
             * TestButton = Best Button ;)
            List<Appointment> FiredAppointments = AppointmentList.Instance.CalculateAppointmentsOnDay(DateTime.Today);
            List<string> firedApps = new List<string>();
            foreach (Appointment firedAppointment in FiredAppointments){
                firedApps.Add(firedAppointment.AppointmentName);
            }
            // show entries of errorList in MsgBox
            string firingCaption = "Fired Lightscenes of Appointments";
            string firingMessage = string.Join(Environment.NewLine, firedApps);

            MessageBox.Show(firingMessage, firingCaption);

            SchedulerTimer.EventWatchdog.Instance.StartWatchDog();
            */
            /*
            try
            {
                string lightscene = FiredAppointments[0].LightScene;
                Communicator myCommunicator = new Communicator();
                myCommunicator.StartLightscene(lightscene);
            }
            catch (Exception ex)
            {
                Log.LogWrite("Cannot start Lightscene");
            }
            */

            //calendar_month_scheduler.BoldedDates = new DateTime[] { };



            //SettingsManager.getInstance().setGuiSetting("SchedulerAutoRun.SETTING", true);
            //var check = SettingsManager.getInstance().getGuiSetting<bool>("SchedulerAutoRun.SETTING");
            //var check = SettingsManager.getInstance().getGuiSetting<string>("LastEditedFilePath.SETTING");
            //MessageBox.Show("Test: "+check.ToString());

            /*
            testLog.LogWrite("This is a crash test");
            */
            /*
            List<Appointment> myAppointmentList = AppointmentList.Instance.GetAppointmentList();
            int index = -1;
            for(int i = 0; i< myAppointmentList.Count ; i++)
            {
                Appointment myAppointment = myAppointmentList.ElementAt(i);

                index = myAppointmentList.IndexOf(myAppointment);
                try
                {
                    myAppointment.HasLightScene = true;
                }
                catch (Exception ex)
                {
                    Log.LogWrite("Problems setting HasLightScene too true");
                }
                try
                {
                    AppointmentList.Instance[index] = myAppointment;
                }
                catch (Exception ex)
                {
                    Log.LogWrite("Problems overwriting AppointmentList.Instance with new appointment");
                }

            }
            */

            /*Communicator myCommunicator = new Communicator();
            myCommunicator.HasLightscene();*/
            /*
            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StringBuilder sb = new StringBuilder(m_exePath);
            sb.Append(@"\default.xml");
            string xml_path = sb.ToString();

            MessageBox.Show(xml_path);
            */
            /*
            Communicator myCommunicator = new Communicator();
            myCommunicator.StartLightscene("FirstShow");
            */
            /*
            MessageBox.Show(SettingsManager.getInstance().getGuiSetting<string>("LastEditedFilePath.SETTING"));
            MessageBox.Show(SettingsManager.getInstance().getGuiSetting<bool>("SchedulerAutoRun.SETTING").ToString());
            */
        //}
    }
}
