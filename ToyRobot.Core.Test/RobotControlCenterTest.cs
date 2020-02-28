using System;
using System.Collections.Generic;
using Workflow.AI;
using Xunit;

namespace ToyRobot.Core.Test
{
    public class RobotControlCenterTest
    {
        [Fact]
        public void InputCase_1_when_0_0_north_move_move_report()
        {
            RobotControlCenter mission = new RobotControlCenter();
            List<string> allinputs = new List<string>() { "PLACE 0,0,NORTH", "MOVE", "REPORT" };            
            Assert.Equal("0,1,NORTH", mission.MissionControl(allinputs));
        }

        [Fact]
        public void InputCase_2_when_0_0_north_move_left_report()
        {
            RobotControlCenter mission = new RobotControlCenter();
            List<string> allinputs = new List<string>() { "PLACE 0,0,NORTH", "LEFT", "REPORT" };
            Assert.Equal("0,0,WEST", mission.MissionControl(allinputs));
        }

        [Fact]
        public void InputCase_3_when_1_2_east_move_move_left_move_report()
        {
            RobotControlCenter mission = new RobotControlCenter();
            List<string> allinputs = new List<string>() { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };
            Assert.Equal("3,3,NORTH", mission.MissionControl(allinputs));
        }
        [Fact]
        public void InputCase_exceptionInvalidInput_without_place_at_the_begining()
        {
            RobotControlCenter mission = new RobotControlCenter();
            List<string> allinputs = new List<string>() { "1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };

            var ex = Assert.Throws<ArgumentException>(() => mission.MissionControl(allinputs));
            Assert.Equal("instruction should begin with >>>place<<<", ex.Message);
        }


    }
}
