using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace TestProject
{
    [TestClass]
    public class LinqTest
    {
        /// <summary>
        /// https://stackoverflow.com/questions/10454519/best-way-to-compare-two-complex-objects
        /// https://coding.abel.nu/2014/09/net-and-equals/
        /// </summary>
        [TestMethod]
        public void CompareObjects()
        {
            try
            {
                var emp1 = Employee.RandomEmployee();
                var emp2 = Employee.RandomEmployee();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [TestMethod]
        public void MoqTest()
        {
            var mock = new Mock<Employee>(MockBehavior.Strict);
            mock.Setup(m => m.GetEmployeeDetails(It.IsAny<int>())).Returns<int>((a) => new Employee());
        }

        [TestMethod]
        public void Json_SerializeDictionary()
        {
            try
            {
                var employeeDictionary = new Dictionary<string, Employee>()
                {
                    { Guid.NewGuid().ToString("N"), new Employee()
                    {
                        MiddleName = Guid.NewGuid().ToString("N"),
                        LastName = Guid.NewGuid().ToString("N"),
                        Id = Guid.NewGuid().ToString("N"),
                        Age = 25,
                    } }
                };

                var json = JsonConvert.SerializeObject(employeeDictionary);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [TestMethod]
        public void Test_Func()
        {

        }

        [TestMethod]
        public void Test_Class()
        {
            //var testClass = new TestClass("");
            //TestClass.testVariable = "testVariable";

            var singleton = Singleton.Instance;
        }
    }

    /// <summary>
    /// various constructors
    /// </summary>
    public class TestClass
    {
        public static string testVariable;

        /// <summary>
        /// singleton,
        /// if contains only static members,
        /// prevents default constructor
        /// </summary>
        private TestClass()
        {

        }

        public TestClass(string str)
        {

        }

        static TestClass()
        {

        }
    }

    /// <summary>
    /// singleton pattern
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object Padlock = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
}
