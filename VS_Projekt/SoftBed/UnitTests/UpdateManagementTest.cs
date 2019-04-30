using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrapperklassen;

namespace UnitTests
{
    class UpdateManagementTest
    {

        /**
         * Test zum Patient getten
         * schlägt fehl wenn anderer Patient zurückkommt als gewollt
         */
        [TestMethod]
        public void GetPatientTest()
        {
            UpdateManagement uM = UpdateManagement.GetInstance();
            PatientenManagement pM = PatientenManagement.GetInstance();
            Patient dummy = new Patient("Max", "Mustermann", 123, "01.01.1985", "On", "", new DateTime(2019, 04, 01), "maennlich");

            pM.PatientAnlegen(dummy);

            Patient dummy2 = uM.GetPatient(123);

            Assert.IsTrue(dummy.Equals(dummy2));    
        }


        /**
         * Test zum User getten
         * schlägt fehl wenn anderer User zurückkommt als gewollt
         */
        [TestMethod]
        public void GetUserTest()
        {
            UpdateManagement upM = UpdateManagement.GetInstance();
            UserManagement usM = UserManagement.GetInstance();
            User dummy = new User("John", "Doe", "Standard", "JonnyBoy", "1234");

            usM.UserAnlegen(dummy);

            User dummy2 = upM.GetUser("JonnyBoy");

            Assert.IsTrue(dummy.Equals(dummy2));
        }

        /**
         * Test zum Bettenbelegung getten
         * schlägt fehl wenn falsche Bettenbelegung zurückkommt
         */
        [TestMethod]
        public void GetCurrentBettenbelegungTest()
        {
            UpdateManagement upM = UpdateManagement.GetInstance();
            PatientenManagement pM = PatientenManagement.GetInstance();
            Patient dummy = new Patient("Max", "Mustermann", 123, "01.01.1985", "On", "", new DateTime(2019, 04, 01), "maennlich");
            Patient dummy2 = new Patient("Sven", "Knabe", 456, "02.02.2010", "P", "", new DateTime(2019, 05, 01), "maennlich");
            Patient dummy3 = new Patient("Christina", "Meier", 899, "05.04.1997", "On", "", new DateTime(2019, 09, 01), "weiblich");

            pM.PatientAnlegen(dummy);
            pM.PatientAnlegen(dummy2);
            pM.PatientAnlegen(dummy3);

            Bettenbelegung bettenbelegung1 = new Bettenbelegung();
            bettenbelegung1.Onkologie = 2;
            bettenbelegung1.Paediatrie = 1;

            Bettenbelegung bettenbelegung2 = upM.GetCurrentBettenbelegung();

            Assert.IsTrue(bettenbelegung1.Equals(bettenbelegung2);
        }

        /**
         * Test zum Verlegungsliste getten
         * schlägt fehl wenn andere Verlegungsliste zurückkommt als gewollt
         */
        [TestMethod]
        public void GetCurrentVerlegungsliste()
        {
            UpdateManagement upM = UpdateManagement.GetInstance();
            ZimmerManagement zM = ZimmerManagement.GetInstance();
            PatientenManagement pM = PatientenManagement.GetInstance();
            Patient dummy = new Patient("Max", "Mustermann", 123, "01.01.1985", "On", "", new DateTime(2019, 04, 01), "maennlich");
            Patient dummy2 = new Patient("Sven", "Knabe", 456, "02.02.2010", "P", "", new DateTime(2019, 05, 01), "maennlich");
            Patient dummy3 = new Patient("Christina", "Meier", 899, "05.04.1997", "On", "", new DateTime(2019, 09, 01), "weiblich");

            pM.PatientAnlegen(dummy);
            pM.PatientAnlegen(dummy2);
            pM.PatientAnlegen(dummy3);

            Verlegungsliste verlegungsliste1 = upM.GetCurrentVerlegungsliste();

            Verlegungsliste verlegungsliste2 = new Verlegungsliste();

            VerlegungslistenItem vLI = new VerlegungslistenItem(dummy, "", "On");
            verlegungsliste2.Transferliste.Add(vLI);

            vLI = new VerlegungslistenItem(dummy2, "", "P");
            verlegungsliste2.Transferliste.Add(vLI);

            vLI = new VerlegungslistenItem(dummy3, "", "On");
            verlegungsliste2.Transferliste.Add(vLI);

            Assert.IsTrue(verlegungsliste1.Equals(verlegungsliste2));
        }


    }
}
