using System;
using static Workflow.Models.Enums;

namespace Workflow.Models
{
    public class TableAreaVm
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int XMax { get; set; }
        public int YMax { get; set; }

        public FacingDirections FacingDirections { get; set; }
    }
}
