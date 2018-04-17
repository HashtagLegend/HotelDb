using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestExample;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           Class1 testCase = new Class1();

           var testResult = testCase.AddTwo(9,4);

            Assert.AreEqual(14, testResult, "addtwo testcases");
        }
    }
}
