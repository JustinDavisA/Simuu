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
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
