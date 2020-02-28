using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.AI
{
    public interface IRobot
    {
        string MissionControl(List<string> inputs);
    }
}
