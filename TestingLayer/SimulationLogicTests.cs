using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingLayer
{
    [TestClass]
    public class SimulationLogicTests
    {
        List<SimuuBLL> MakeSampleSimuus(int count)
        {
            List<SimuuBLL> proposedReturnValue = new List<SimuuBLL>();
            for (int i = 0; i < count; i++)
            {
                SimuuBLL simuu = new SimuuBLL();
                simuu.SimuuID = i;
                simuu.SimuuName = $"Simuu{i}";
                simuu.SimuuAge = 5 + i;
                simuu.SimuuBirth = new DateTime(1900 + i * 5, 1, 1);
                simuu.SimuuDeath = new DateTime(1900 + i * 5, 1, 1);
                simuu.SimuuXCoordinate = 55;
                simuu.SimuuYCoordinate = 55;
                simuu.ImpulseToRest = 25;
                simuu.ImpulseToDrink = 25;
                simuu.ImpulseToEat = 25;
                simuu.StatEnergy = 100;
                simuu.StatThirst = 100;
                simuu.StatHunger = 100;
                simuu.SimuuMovementSpeed = 5;
                simuu.SimuuSenseRadius = 15;
                simuu.UserID = i % 3;
                proposedReturnValue.Add(simuu);
            }
            return proposedReturnValue;
        }

        SimuuBLL MakeSampleSimuu(int i)
        {
            SimuuBLL simuu = new SimuuBLL();
            simuu.SimuuID = i;
            simuu.SimuuName = $"Simuu{i}";
            simuu.SimuuAge = 5 + i;
            simuu.SimuuBirth = new DateTime(1900 + i * 5, 1, 1);
            simuu.SimuuDeath = new DateTime(1900 + i * 5, 1, 1);
            simuu.SimuuXCoordinate = 55;
            simuu.SimuuYCoordinate = 55;
            simuu.ImpulseToRest = 25;
            simuu.ImpulseToDrink = 25;
            simuu.ImpulseToEat = 25;
            simuu.StatEnergy = 100;
            simuu.StatThirst = 100;
            simuu.StatHunger = 100;
            simuu.SimuuMovementSpeed = 5;
            simuu.SimuuSenseRadius = 15;
            simuu.UserID = i % 3;
            return simuu;
        }

        [TestMethod]
        public void When_SimuuSensesSimuu_Expect_True()
        {
            // arrange
            SimulationLogic logic = new SimulationLogic();
            SimuuBLL simuu1 = MakeSampleSimuu(1);
            SimuuBLL simuu2 = MakeSampleSimuu(2);

            bool expected = true;
            // act
            bool actual = logic.TestSenseCollision(simuu1, simuu2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_SimuuDoesntSenseSimuu_Expect_False()
        {
            // arrange
            SimulationLogic logic = new SimulationLogic();
            SimuuBLL simuu1 = MakeSampleSimuu(1);
            SimuuBLL simuu2 = MakeSampleSimuu(2);
            simuu2.SimuuXCoordinate = 100;
            simuu2.SimuuYCoordinate = 100;

            bool expected = false;
            // act
            bool actual = logic.TestSenseCollision(simuu1, simuu2);

            //assert
            Assert.AreNotEqual(expected, actual);
        }

    }
}
