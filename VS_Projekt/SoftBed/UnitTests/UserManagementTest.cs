using System;
using Logic;
using Wrapperklassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UserManagementTest
    {
        [TestMethod]
        public void UserAnlegenTest()
        {
            UserManagement userManagement = UserManagement.GetInstance();
            User dummy = new User("John", "Doe", "Standard", "JonnyBoy", "1234");

            bool firstTime = userManagement.UserAnlegen(dummy);     //sollte klappen
            bool secondTime = userManagement.UserAnlegen(dummy);    //sollte nicht klappen

            Assert.IsTrue(firstTime && !secondTime);    //erste mal muss geklappt haben, zweite mal darf nicht geklappt haben
        }

        [TestMethod]
        public void UserLoeschenTest()
        {

        }

        [TestMethod]
        public void UserAendernTest()
        {

        }

        [TestMethod]
        public void UserLoginTest()
        {

        }
    }
}
