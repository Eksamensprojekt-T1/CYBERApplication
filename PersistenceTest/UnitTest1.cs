using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuinsnessLogic.Persistence;
using BuinsnessLogic.Models;
using System.Threading;

namespace PersistenceTest
{
    [TestClass]
    public class UnitTest1
    {
        int seconds, waitTime;

        string conPath = "Server=10.56.8.36;Database=PEDB01; User Id = PE-01; Password=OPENDB_01;";

        AnswerRepository arep;
        Answer a1;  
        Answer a2;

        [TestInitialize]
        public void InitializeTest()
        {
            seconds = 10;
            waitTime = seconds * 1000;

            arep = new(conPath);
            a1 = new(1, "test 1", true);
            a2 = new("test 2", false);
        }

        [TestMethod]
        public void Add()
        {
            arep.Add(a1);   
            arep.Add(a2);
            Thread.Sleep(waitTime);
            Assert.AreEqual(2, arep.Answers.Count);
        }

        [TestMethod]
        public void Update()
        {
            arep.Update();
        }

        [TestMethod]
        public void GetByID()
        {
            Assert.AreEqual(1, arep.GetByID(1).AnswerID);
        }


        [TestMethod]
        public void Delete()
        {
            arep.Delete(a1.AnswerID);
            arep.Delete(a2.AnswerID);
            Thread.Sleep(waitTime);
            Assert.AreEqual(0, arep.Answers.Count);
        }
    }
}
