using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Football
{
    class AgentSimpleDefender : AgentPlayer
    {
        public override void selectAction()
        {
            if (utils.getNearestPlayer(utils.ballLocation, Utils.target.myPlayers) == myID)
                goToLocation(getPointBetween(utils.ballLocation, utils.ourGoalCentralPoint));
            else
                goToLocation(utils.myPenaltyPoint);
            passBallToPlayer(getNearestTeammate());
        }
    }

    class AgentSimpleBallSeeker : AgentPlayer
    {
        public override void selectAction()
        {
            goToLocation(utils.ballLocation);
            passBallToPlayer(getNearestTeammate());

        }
    }

    class AgentSimpleOffender : AgentPlayer
    {
        public override void selectAction()
        {
            goToLocation(utils.enemyPenaltyPoint);
            shootToGoal();
        }
    } 
}
