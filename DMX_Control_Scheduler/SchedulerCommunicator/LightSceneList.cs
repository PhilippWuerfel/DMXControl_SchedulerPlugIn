using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerCommunicator
{
    public class LightSceneList
    {
        private List<LightScene> _myLightSceneList = new List<LightScene>();
        //Singleton
        private static LightSceneList instance = null;
        private static readonly object syncRoot = new Object();
        private LightSceneList()
        {
            
        }
        public static LightSceneList Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new LightSceneList();
                    }
                }
                return instance;
            }
        }
        //----------------
        public LightScene this[int index]
        {
            get
            {
                return _myLightSceneList[index];
            }
            set
            {
                _myLightSceneList[index] = value;
                /*if (changed != null)
                {
                    changed(value, EventArgs.Empty);
                }*/
            }
        }
        public List<LightScene> GetLightSceneList()
        {
            return _myLightSceneList;
        }


    }
}
