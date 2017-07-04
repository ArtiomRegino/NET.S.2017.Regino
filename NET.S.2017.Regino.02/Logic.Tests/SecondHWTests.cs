using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class SecondHWTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DataInsertBits.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\DataInsertBits.xml")]
        [TestMethod()]
        public void TestMethod1()
        {
            
            var firstNumber = Convert.ToInt32(TestContext.DataRow["firstNumber"]);
            var secondNumber = Convert.ToInt32(TestContext.DataRow["secondNumber"]);
            var startPosition = Convert.ToInt32(TestContext.DataRow["startPosition"]);
            var finishPosition = Convert.ToInt32(TestContext.DataRow["finishPosition"]);
            var expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            var actual = Logic.SecondHW.InsertBits(firstNumber, secondNumber, startPosition, finishPosition);

            Assert.AreEqual(expected, actual);
        }


    }
}
