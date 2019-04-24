using System;
using Logic;
using Wrapperklassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    class ZimmerManagementTest
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


        [TestMethod]
        public void KHFastVollTest()
        {

        }




    }
}