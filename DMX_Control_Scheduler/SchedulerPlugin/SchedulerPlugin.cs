using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lumos.GUI;
using Lumos.GUI.Plugin;
using Lumos.GUI.Settings;
using Lumos.GUI.Settings.PE;
using Lumos.GUI.Windows;
using LumosLIB.Kernel.Log;
using org.dmxc.lumos.Kernel.Settings;

namespace SchedulerPlugin
{
    public class SchedulerPlugin : GuiPluginBase
    {
        /// <summary>
        /// Every Plugin has a unique ID
        /// </summary>
        const string PLUGIN_ID = "{37C2CA96-3543-4FD7-B88C-65783A7E5A62}";


        /// <summary>
        /// A logger to write Logfiles
        /// </summary>
        private static readonly ILumosLog log = LumosLogger.getInstance<SchedulerPlugin>();
        
        private SchedulerForm _mySchedulerForm;


        public SchedulerPlugin() : base(PLUGIN_ID, "Scheduler Plugin")
        {

        }

        /// <summary>
        /// Called when Plugin is initialized (on Startup)
        /// </summary>
        protected override void initializePlugin()
        {
            this._mySchedulerForm = new SchedulerForm();

            //Currently bug in DMX Control, can be added after fix
            /*
            // Create own Settingnode
            var myPluginNode = new ConfigurableSettingsNode("Settings:SchedulerPlugin", "SchedulerPlugin", "SchedulerPlugin.png");
            
            //Image File must be placed in Kernel or GUI Symbols Folder and should be of Size 32x32
            var branchId = SettingsManager.getInstance().GetSettignsBranchID();
            var branch = PEManager.getInstance().GetBranchByID(branchId);
            //Add Node to Branch
            branch.AddRecursive(branch.ID, myPluginNode);
            //Now you have a node and all Settings in Category "SchedulerPlugin" will be shown there
            */

        }
        /// <summary>
        /// Called when Plugin is disabled
        /// </summary>
        protected override void shutdownPlugin()
        {
            //Hide Form
            _mySchedulerForm.Hide();
            //Remove Form, so it is not visible any more
            WindowManager.getInstance().RemoveWindow(_mySchedulerForm);
        }

        /// <summary>
        /// Called when Plugin is activated (enabled in PluginManager)
        /// </summary>
        protected override void startupPlugin()
        {
            //Add Form
            WindowManager.getInstance().AddWindow(_mySchedulerForm);
        }
    }
}
