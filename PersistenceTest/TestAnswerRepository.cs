using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuinsnessLogic.Persistence;
using BuinsnessLogic.Models;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace PersistenceTest
{
    [TestClass]
    public class TestAnswerRepository
    {
        private readonly string conPath = "Server=10.56.8.36;Database=PEDB01; User Id = PE-01; Password=OPENDB_01;";
        AnswerRepository answerRepo;
        
        Answer a1, a2;
        int? a1Return, a2Return;

        [TestInitialize]
        public void InitializeTest()
        {
            // Arrange
            answerRepo = new(conPath);
            a1 = new("test 1", true);
            a2 = new("test 2", false);
        }
        [TestCleanup]
        public void FinalizeTest()
        {
            answerRepo.Answers.Clear();
        }

        [TestMethod]
        public void TestAdd()
        {
            // Act
            answerRepo.Add(a1);
            answerRepo.Add(a2);
            // Asssert
            Assert.AreEqual(2, answerRepo.Answers.Count);
        }
        [TestMethod]
        public void TestGeAll()
        {
            // Assert
            Assert.IsInstanceOfType(answerRepo.GetAll(), typeof(IEnumerable));
            Assert.IsInstanceOfType(answerRepo.GetAll(), typeof(List<Answer>));
        }

        [TestMethod]
        public void TestGetByID()
        {
            // Act
            a1Return = answerRepo.Add(a1);
            a2Return = answerRepo.Add(a2);
            // Assert
            Assert.AreEqual(a1Return, answerRepo.GetByID(a1.AnswerID).AnswerID);
            Assert.AreEqual(a2Return, answerRepo.GetByID(a2.AnswerID).AnswerID);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Arrange
            a1.AnswerDescription = "Test 1 updatet";
            a2.AnswerDescription = "Test 2 updatet";
            a1.IsItCorrect = false;
            a2.IsItCorrect = true;

            // Act
            answerRepo.Update(a1);
            answerRepo.Update(a2);

            // Assert
            Assert.AreEqual("Test 1 updatet", answerRepo.GetByID(a1.AnswerID).AnswerDescription);
            Assert.AreEqual("Test 2 updatet", answerRepo.GetByID(a2.AnswerID).AnswerDescription);
            Assert.AreEqual(false, answerRepo.GetByID(a1.AnswerID).IsItCorrect);
            Assert.AreEqual(true, answerRepo.GetByID(a2.AnswerID).IsItCorrect);
        }
        [TestMethod]
        public void TestDelete()
        {
            // Arange
            answerRepo.Add(a1);
            answerRepo.Add(a2);
            // Act
            answerRepo.Delete(a1.AnswerID);
            answerRepo.Delete(a2.AnswerID);

            // Assert
            Assert.AreEqual(0, answerRepo.Answers.Count);
        }
    }
}