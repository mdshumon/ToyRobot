using System;
using System.Collections.Generic;
using Workflow.AI;

namespace ToyRobot.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotControlCenter robot = new RobotControlCenter();
            //input 1
            List<string> allinputs = new List<string>() { "PLACE 0,0,NORTH", "MOVE", "REPORT" };
            Console.WriteLine(robot.MissionControl(allinputs));

            //input 2
            List<string> allinputs2 = new List<string>() { "PLACE 0,0,NORTH", "LEFT", "REPORT" };
            Console.WriteLine(robot.MissionControl(allinputs2));

            //input 3
            List<string> allinputs3 = new List<string>() { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };
            Console.WriteLine(robot.MissionControl(allinputs3));

            //input with no place at the begining
            List<string> allinputs4 = new List<string>() { "1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };
            Console.WriteLine(robot.MissionControl(allinputs4));


        }
    }
}
