using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumos.GUI;
using Lumos.GUI.Connection;
using Lumos.GUI.Plugin;
using LumosLIB.Kernel.Log;
using SchedulerAppointment;
using SchedulerLogFileWriter;

namespace SchedulerCommunicator
{
    public class Communicator
    {
        private List<object> lightScenelist = new List<object>();
        private LogFileWriter Log = new LogFileWriter();
        //Starts DMX Lightscene
        public void StartLightscene(string lightscene)
        {
            bool fired = false;
            for (int i = 0; i < ConnectionManager.getInstance().GuiSession.SceneLists.Count; i++)
            {
                if (lightscene == ConnectionManager.getInstance().GuiSession.SceneLists[i].Name)
                {
                    try
                    {
                        var sceneListState = ConnectionManager.getInstance().GuiSession.SceneLists[i].State;
                        if (sceneListState.ToString().Equals("RUNNING"))
                        {
                            ConnectionManager.getInstance().GuiSession.SceneLists[i].stop();
                            //ConnectionManager.getInstance().GuiSession.SceneLists[i].play();
                        }
                        ConnectionManager.getInstance().GuiSession.SceneLists[i].go();
                        fired = true;
                    }
                    catch
                    {
                        Log.LogWrite("Couldn't start lightscene: " + lightscene);
                    }
                }
            }
            if (fired == false)
            {
                Log.LogWrite("Couldn't find following lightscene in current project: " + lightscene);
            }
        }

        public void StopLightscene(string lightscene)
        {
            for (int i = 0; i < ConnectionManager.getInstance().GuiSession.SceneLists.Count; i++)
            {
                if (lightscene == ConnectionManager.getInstance().GuiSession.SceneLists[i].Name)
                {
                    ConnectionManager.getInstance().GuiSession.SceneLists[i].stop();
                }
            }
        }

        public void StopAllLightscenes()
        {
            try
            {
                for (int i = 0; i < ConnectionManager.getInstance().GuiSession.SceneLists.Count; i++)
                {
                    try
                    {
                        ConnectionManager.getInstance().GuiSession.SceneLists[i].stop();
                    }
                    catch
                    {
                        Log.LogWrite("Problems stopping all lightscenes");
                    }

                }
            }
            catch
            {
                Log.LogWrite("No connection to ConnectionManager");
            }

            
        }

        //this method gets the cuelist from DMX Controler and creates a new list cuelist to work wiht in the program 
        public List<object> GetLightSceneList()
        {
            try
            {
                for(int i = 0; i < ConnectionManager.getInstance().GuiSession.SceneLists.Count; i++)
                {
                    lightScenelist.Add(ConnectionManager.getInstance().GuiSession.SceneLists[i].Name);
                }
            }
            catch (Exception e)
            {
                Log.LogWrite("Problems getting SceneLists");
            }
            return lightScenelist;
        }

        public void HasLightscene()
        {
            List<object> lightscenelist = new List<object>();
            lightscenelist = GetLightSceneList();
            List<Appointment> myAppointmentList = AppointmentList.Instance.GetAppointmentList();
            int index = -1;
            
            for (int i = 0; i < myAppointmentList.Count; i++)
            {
                foreach (string name in lightscenelist)
                {
                    Appointment myAppointment = myAppointmentList.ElementAt(i);
                    index = myAppointmentList.IndexOf(myAppointment);
                    if (myAppointment.LightScene == name)
                    {                        
                        try
                        {
                            myAppointment.HasLightScene = true;
                        }
                        catch(Exception ex)
                        {
                            Log.LogWrite("Problems setting HasLightScene too true");
                        }
                        try
                        {
                            AppointmentList.Instance[index] = myAppointment;
                        }
                        catch(Exception ex)
                        {
                            Log.LogWrite("Problems overwriting AppointmentList.Instance with new appointment");
                        }
                        break;
                    }
                    else
                    {
                        try
                        {
                            myAppointment.HasLightScene = false;
                        }
                        catch (Exception e)
                        {
                            Log.LogWrite("Problems setting HasLightScene too true");
                        }
                        try
                        {
                           AppointmentList.Instance[index] = myAppointment;
                        }
                        catch (Exception e)
                        {
                            Log.LogWrite("Problems overwriting AppointmentList.Instance with new appointment");
                        }
                    }
                }
            }
        }
    }  
}

