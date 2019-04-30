using System;
using Logic;
using Wrapperklassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ZimmerManagementTest
    {
        [TestMethod]
        public void PatientenTransferTest()
        {
            int versicherungsNummer = 0;
            ZimmerManagement zimmerManagement = ZimmerManagement.GetInstance();

            bool test1 = zimmerManagement.PatientenTransfer(versicherungsNummer);
        }

        [TestMethod]
        public void SuchePassendesBettTest()
        {
            ZimmerManagement zimmerManagement = ZimmerManagement.GetInstance();
            
        }

        [TestMethod]
        public void KHFülleTest()
        {

        }

        /**
        * Test zum Senden einer E-Mail, wenn das Krankenhaus fast voll ist.
        * schlaegt fehl, wenn E-Mail nicht erfolgreich gesendet wurde.
        */
        [TestMethod]
        public void KHFastVollTest()
        {
            ZimmerManagement zimmerManagement = ZimmerManagement.GetInstance();
            Assert.IsTrue(zimmerManagement.KHFastVoll());
        }
    }
}