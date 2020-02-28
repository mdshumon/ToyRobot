using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Models;
using static Workflow.Models.Enums;

namespace Workflow.Utility
{
    public sealed class InputHelper
    {
        static List<string> faces = new List<string>() { "north", "south", "east", "west" };
        static List<string> validActions = new List<string>() { "move", "report", "left", "right" };

        public static List<string> GetInstructionValuesOnly(List<string> inputs)
        {
            if (inputs == null)
                throw new ArgumentException("Invalid input values");

            List<string> values = inputs.Skip(1).Select(x => x.ToLower()).ToList();

            if (!values.Any(x => validActions.Contains(x.ToLower())))
                throw new ArgumentException("Invalid instruction values");
            return values;
        }

        //DS: PLACE {digit},{digit},{north|south|east|west}
        public static TableAreaVm GetFirstLineValuesOnly(List<string> inputs)
        {
            if (inputs == null)
                new ArgumentException("Invalid input values");
            TableAreaVm area = new TableAreaVm();
            string firstline = inputs.FirstOrDefault().ToLower();
            int x = 0, y = 0;

            var linesSpaces = firstline.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (linesSpaces[0] != "place")
                throw new ArgumentException("instruction should begin with >>>place<<<");
            var linesCommas = linesSpaces[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (!faces.Any(x => x == linesCommas.LastOrDefault()))
                throw new ArgumentException("invalid face direction");
            else if (!int.TryParse(linesCommas[0], out x) || !int.TryParse(linesCommas[1], out y))
                throw new ArgumentException("invalid co-ordinate");
            area.X = x;
            area.Y = y;
            area.FacingDirections = (FacingDirections)Enum.Parse(typeof(FacingDirections), linesCommas[2].ToUpper());
            area.XMax = TableAreaDefaultValues.MaxX;
            area.YMax = TableAreaDefaultValues.MaxY;

            return area;
        }
    }
}
