using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Football
{
    abstract class AgentPlayer
    {
        protected PointF intendedVelocity, intendedBallVelocity;
        protected Utils utils;
        protected int myID;

        public PointF getIntendedVelocity()
        {
            return intendedVelocity;
        }

        public PointF getIntendedBallVelocity()
        {
            return intendedBallVelocity;
        }

        public void updateInformation()
        {
            utils.update();
        }

        public void setUtils(Utils u)
        {
            this.utils = u;
        }

        public void setID(int ID)
        {
            this.myID = ID;
        }

        public abstract void selectAction();

        public AgentPlayer()
        {
            this.intendedBallVelocity = new PointF(0, 0);
            this.intendedVelocity = new PointF(0, 0);
        }

        protected void goToLocation(PointF location)
        {
            this.intendedVelocity = utils.computeVelocity(utils.locations[myID], location);
        }

        protected void shootToGoal()
        {
            this.intendedBallVelocity = utils.computeVelocity(utils.locations[myID], utils.enemyGoalCentralPoint);
        }

        protected void passBallToPlayer(int playerID)
        {
            this.intendedBallVelocity = utils.computeVelocity(utils.locations[myID], utils.locations[playerID]);
        }

        protected int getNearestTeammate()
        {
            return utils.getNearestPlayer(utils.locations[myID], Utils.target.myPlayers, myID);
        }

        protected PointF getPointBetween(PointF first, PointF second)
        {
            return new PointF((first.X + second.X) / 2, (first.Y + second.Y) / 2);
        }

    }
}
