using NUnit.Framework;
using ApiFile.FileProcess;
using System.Collections.Generic;

namespace ApiFile.Test
{
    public class FileProcessTest
    {
        List<int> listElements= new List<int>(){30,30,1,1}; 

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void CalculateTripsTest()
        {
            ProcessFileTxt processFile = new ProcessFileTxt();
            int number= processFile.CalculateTrips(listElements);
            Assert.AreEqual(2,number);
        }
    }
}