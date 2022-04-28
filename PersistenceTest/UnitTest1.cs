using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuinsnessLogic.Persistence;
using BuinsnessLogic.Models;
using System.Threading;

namespace PersistenceTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly string conPath = "Server=10.56.8.36;Database=PEDB01; User Id = PE-01; Password=OPENDB_01;";

        AnswerRepository answerRepo;
        Answer a1;  
        Answer a2;
        int? a1Return, a2Return;
        [TestInitialize]
        public void InitializeTest()
        {
            // Arrange
            answerRepo = new(conPath);
            a1 = new(1, "test 1", true);
            a2 = new("test 2", false);

            // Act
            a1Return = answerRepo.Add(a1);
            a2Return = answerRepo.Add(a2);
            
        }

        [TestMethod]
        public void TestAdd()
        {
            // Asssert
            Assert.AreEqual(a1, answerRepo.GetByID(a1Return));
            // Assert.AreEqual(2, a2Return);
            Assert.AreEqual(2, answerRepo.Answers.Count);
        }

        [TestMethod]
        public void TestGetByID()
        {
            // Assert
            Assert.AreEqual(a1, answerRepo.GetByID(1));
        }


        [TestMethod]
        public void TestDelete()
        {

            // Act
            answerRepo.Delete(a1.AnswerID);
            answerRepo.Delete(a2.AnswerID);
            // Assert
            Assert.AreEqual(0, answerRepo.Answers.Count);
        }
    }
}
