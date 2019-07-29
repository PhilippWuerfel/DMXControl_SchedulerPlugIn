using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerCommunicator
{
    public class LightScene
    {
        public string LightSceneName { get; set; }

        public override string ToString()
        {
            return LightSceneName;
        }
    }
}
