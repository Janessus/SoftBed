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
            Patient dummy = new Patient("Max", "Mustermann", "E987656789", new DateTime(1985, 01, 01), "Onkologie", "", new DateTime(2019, 04, 01), "m");

            PatientenManagement.GetInstance().PatientAnlegen(dummy, "IM-10-F");

            ZimmerManagement zimmerManagement = ZimmerManagement.GetInstance();

            bool test1 = zimmerManagement.PatientenTransfer(dummy.Versicherungsnr, "On-20-T");

            Assert.IsTrue(test1);
        }

        [TestMethod]
        public void SuchePassendesBettTest()
        {
            ZimmerManagement zimmerManagement = ZimmerManagement.GetInstance();
            //Patient dummy = DatabaseManagement.GetInstance().GetPatient("E987656789");


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