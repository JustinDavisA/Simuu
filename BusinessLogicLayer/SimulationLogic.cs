using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class SimulationLogic
    {

        public List<SimuuBLL> mySimuus { get; set; }

        // Declare variables to handle canvas size and borders
        int WIDTH = 1280;
        int HEIGHT = 720;

        // Get a random number within a range
        public int RandomInt(int min, int max)
        {
            Random ran = new Random();
            int ret = ran.Next(min, max);
            return ret;
        }

        // Wander movement loop
        public void SimuuWander(SimuuBLL entity)
        {
            // Get random facing direction Up, Right, Down, Left
            int facing = RandomInt(1, 5);

            // Steps taken in a direction
            int moveLength = RandomInt(1, 6);

            // check facing and move
            if (facing == 1)
            {
                for (int i = 0; i < moveLength; i++)
                {
                    entity.SimuuYCoordinate += entity.SimuuMovementSpeed;
                }
            }
            else if (facing == 2)
            {
                for (int i = 0; i < moveLength; i++)
                {
                    entity.SimuuXCoordinate += entity.SimuuMovementSpeed;
                }
            }
            else if (facing == 3)
            {
                for (int i = 0; i < moveLength; i++)
                {
                    entity.SimuuYCoordinate -= entity.SimuuMovementSpeed;
                }
            }
            else if (facing == 4)
            {
                for (int i = 0; i < moveLength; i++)
                {
                    entity.SimuuXCoordinate -= entity.SimuuMovementSpeed;
                }
            }
        }

        // Update Simuu Position
        public void UpdateSimuuPosition(SimuuBLL entity)
        {
            SimuuWander(entity);

            // Bounce off of left and right edge if leaving bounds
            if (entity.SimuuXCoordinate < 15 || entity.SimuuXCoordinate > WIDTH)
            {
                Console.WriteLine(entity + " crossed bounds. Bouncing back.");
                entity.SimuuMovementSpeed = -entity.SimuuMovementSpeed;
            }
            // Bounce off of top and bottom edge if leaving bounds
            if (entity.SimuuYCoordinate < 15 || entity.SimuuYCoordinate > HEIGHT)
            {
                Console.WriteLine(entity + " crossed bounds. Bouncing back.");
                entity.SimuuMovementSpeed = -entity.SimuuMovementSpeed;
            }
        }

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
        public void CheckSimuuCollision(SimuuBLL entity1, SimuuBLL entity2)
        {
            if ((TestSenseCollision(entity1, entity2) == true) && (entity1 != entity2))
            {
                Console.WriteLine(entity1 + " and " + entity2 + " are Colliding");
            }
        }

        // All processes run here
        public void Process()
        {
            foreach (var simuu1 in mySimuus)
            {
                UpdateSimuuPosition(simuu1);
            }
        }

    }
}
