using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Models;
using Workflow.Utility;
using static Workflow.Models.Enums;

namespace Workflow.AI
{
    public class RobotControlCenter : IRobot
    {

        TableAreaVm tableare = new TableAreaVm();

        //DS: An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.

        public RobotControlCenter()
        {
            tableare.X = TableAreaDefaultValues.MinX;
            tableare.Y = TableAreaDefaultValues.MinY;
            tableare.XMax = TableAreaDefaultValues.MaxX;
            tableare.YMax = TableAreaDefaultValues.MaxY;
            tableare.FacingDirections = FacingDirections.NORTH;
        }

        //DS: Assume that the square directly North from (x, y) is (x, y+1).
        private void MoveContinue()
        {

            if (tableare.FacingDirections == FacingDirections.NORTH)
            {
                tableare.Y += 1;
            }
            else if (tableare.FacingDirections == FacingDirections.SOUTH)
            {
                tableare.Y -= 1;
            }
            else if (tableare.FacingDirections == FacingDirections.EAST)
            {
                tableare.X += 1;
            }
            else if (tableare.FacingDirections == FacingDirections.WEST)
            {
                tableare.X -= 1;
            }
        }
        private void Left_Rotation()
        {
            switch (tableare.FacingDirections)
            {
                case FacingDirections.NORTH:
                    tableare.FacingDirections = FacingDirections.WEST;
                    break;
                case FacingDirections.SOUTH:
                    tableare.FacingDirections = FacingDirections.EAST;
                    break;
                case FacingDirections.EAST:
                    tableare.FacingDirections = FacingDirections.NORTH;
                    break;
                case FacingDirections.WEST:
                    tableare.FacingDirections = FacingDirections.SOUTH;
                    break;
                default:
                    break;
            }
        }

        private void Right_Rotation()
        {
            switch (tableare.FacingDirections)
            {
                case FacingDirections.NORTH:
                    tableare.FacingDirections = FacingDirections.EAST;
                    break;
                case FacingDirections.SOUTH:
                    tableare.FacingDirections = FacingDirections.WEST;
                    break;
                case FacingDirections.EAST:
                    tableare.FacingDirections = FacingDirections.SOUTH;
                    break;
                case FacingDirections.WEST:
                    tableare.FacingDirections = FacingDirections.NORTH;
                    break;
                default:
                    break;
            }
        }

        public string MissionControl(List<string> inputs)
        {
            if (inputs == null)
              throw  new ArgumentException("Invalid input instruction");

            TableAreaVm area = InputHelper.GetFirstLineValuesOnly(inputs);

            this.tableare.X = area.X;
            this.tableare.Y = area.Y;
            this.tableare.FacingDirections = area.FacingDirections;
            
            foreach (var move in InputHelper.GetInstructionValuesOnly(inputs))
            {
                switch (move.ToLower())
                {
                    case "move":
                        this.MoveContinue();
                        break;
                    case "left":
                        Left_Rotation();
                        break;
                    case "right":
                        Right_Rotation();
                        break;
                    case "report":
                        return Report();
                    default:
                        break;
                }
            }
            ValidateTableArea();
            return null;
        }

        private string Report()
        {
            return $"{this.tableare.X},{this.tableare.Y},{tableare.FacingDirections}";
        }

        private void ValidateTableArea()
        {
            if (this.tableare.X < 0 || this.tableare.X > this.tableare.XMax || this.tableare.Y < 0 || this.tableare.Y > this.tableare.YMax)
              throw  new ArgumentException("Invalid Table area for input for MAX X and Y");

        }
    }
}
