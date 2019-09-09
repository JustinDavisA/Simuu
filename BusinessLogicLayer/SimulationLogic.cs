using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogicLayer
{
    public class SimulationLogic
    {

        public List<SimuuBLL> mySimuus { get; set; }

        // Declare variables to handle canvas size and border bounds
        int WIDTH = 500;
        int HEIGHT = 500;

        // Declare random now to not repeat seed in loop
        Random ran = new Random();

        // Get a random number within a range
        public int RandomInt(int min, int max)
        {
            return ran.Next(min, max);
        }


        #region SIMUU MOVEMENT

        // Wander movement loop
        public void SimuuWander(SimuuBLL entity)
        {
            // Get random facing direction Up, Right, Down, Left
            int facing = RandomInt(1, 5);

            // check facing and move
            if (facing == 1)
            {
                entity.SimuuYCoordinate += entity.SimuuMovementSpeed;
            }
            else if (facing == 2)
            {
                entity.SimuuXCoordinate += entity.SimuuMovementSpeed;
            }
            else if (facing == 3)
            {
                entity.SimuuYCoordinate -= entity.SimuuMovementSpeed;
            }
            else if (facing == 4)
            {
                entity.SimuuXCoordinate -= entity.SimuuMovementSpeed;
            }
        }

        public void SimuuBoundsBump(SimuuBLL entity)
        {
            if (entity.SimuuXCoordinate < 50)
            {
                entity.SimuuXCoordinate += 25;
            }
            else if (entity.SimuuXCoordinate > (WIDTH - 50))
            {
                entity.SimuuXCoordinate -= 25;
            }

            if (entity.SimuuYCoordinate < 50)
            {
                entity.SimuuYCoordinate += 25;
            }
            else if (entity.SimuuYCoordinate > (HEIGHT - 50))
            {
                entity.SimuuYCoordinate -= 25;
            }
        }

        // Update Simuu Position
        public void UpdateSimuuPosition(SimuuBLL entity)
        {
            SimuuBoundsBump(entity);
            SimuuWander(entity);
        }

        #endregion


        #region SIMUU COLLISION

        // Get distance between two simuus
        public double DistanceBetweenSimuus(SimuuBLL simuu1, SimuuBLL simuu2)
        {
            var vx = simuu1.SimuuXCoordinate - simuu2.SimuuXCoordinate;
            var vy = simuu1.SimuuYCoordinate - simuu2.SimuuYCoordinate;
            return Math.Sqrt(vx * vx + vy * vy);
        }

        // Check distance between two simuus- If either simuu is within either simuus sense range return true
        public bool TestSenseCollision(SimuuBLL simuu1, SimuuBLL simuu2)
        {
            var distance = DistanceBetweenSimuus(simuu1, simuu2);
            if ((distance < simuu1.SimuuSenseRadius) || (distance < simuu2.SimuuSenseRadius))
            {
                return true;
            }
            return false;
        }

        // Check simuu collision states
        public void SimuuCollisionHandler(SimuuBLL entity1, SimuuBLL entity2)
        {
            if ((TestSenseCollision(entity1, entity2) == true) && (entity1 != entity2))
            {
                Console.WriteLine(entity1.SimuuName + " and " + entity2.SimuuName + " are Colliding");
            }
        }

        #endregion


        // All processes run here
        public void Process()
        {
            foreach (var simuu1 in mySimuus)
            {
                UpdateSimuuPosition(simuu1);
                foreach (var simuu2 in mySimuus)
                {
                    SimuuCollisionHandler(simuu1, simuu2);
                }
            }
        }

    }
}
