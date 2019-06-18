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
    [TestClass]
    public class UpdateManagementTest
    {

        /**
         * Test zum Patient getten
         * schlägt fehl wenn anderer Patient zurückkommt als gewollt
         * schlägt fehl wenn anderer Patient zurückkommt als gewollt
         */
        [TestMethod]
        public void GetPatientTest()
        {
            UpdateManagement uM = UpdateManagement.GetInstance();
            PatientenManagement pM = PatientenManagement.GetInstance();
            Patient dummy = new Patient("Bilbo", "Beutlin", "X123457788", new DateTime(1985, 01, 01), "Onkologie", "", new DateTime(2019, 04, 01), "m");

            bool result = pM.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));

            Patient dummy2 = uM.GetPatient("X123456788");

            Assert.IsTrue(dummy.Equals(dummy2));

            pM.PatientLoeschen("X123457788");
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

            Assert.IsTrue(dummy.Benutzername.Equals(dummy2.Benutzername));
            usM.UserLöschen("JonnyBoy");
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
            Bettenbelegung bettenbelegung1 = upM.GetCurrentBettenbelegung();
            Patient dummy = new Patient("Max", "Mustermann", "F111222333", new DateTime(1985, 01, 01) , "Onkologie", "", new DateTime(2019, 04, 01), "m");
            Patient dummy2 = new Patient("Sven", "Knabe", "G456789012", new DateTime(2010,02, 02), "Pädiatrie", "", new DateTime(2019, 05, 01), "m");
            Patient dummy3 = new Patient("Christina", "Meier", "H899001233", new DateTime(1997, 04, 05), "Onkologie", "", new DateTime(2019, 09, 01), "w");


            pM.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));
            pM.PatientAnlegen(dummy2, ZimmerManagement.GetInstance().suchePassendesBett(dummy2));
            pM.PatientAnlegen(dummy3, ZimmerManagement.GetInstance().suchePassendesBett(dummy3));

            Bettenbelegung bettenbelegung2 = upM.GetCurrentBettenbelegung();

            Assert.IsTrue(bettenbelegung1.Gesamt()+3 == bettenbelegung2.Gesamt());
        }

        /**
         * Test zum Verlegungsliste getten
         * schlägt fehl wenn andere Verlegungsliste zurückkommt als gewollt
         */
        [TestMethod]
        public void GetCurrentVerlegungslisteTest()
        {
            UpdateManagement upM = UpdateManagement.GetInstance();
            ZimmerManagement zM = ZimmerManagement.GetInstance();
            PatientenManagement pM = PatientenManagement.GetInstance();
            Patient dummy = new Patient("Max", "Mustermann", "I123654789", new DateTime(1985, 01, 01), "Onkologie", "", new DateTime(2019, 04, 01), "m");
            Patient dummy2 = new Patient("Sven", "Knabe", "J987456123", new DateTime(2010, 02, 02), "Pädiatrie", "", new DateTime(2019, 05, 01), "m");
            Patient dummy3 = new Patient("Christina", "Meier", "K899112445", new DateTime(1997, 04, 05), "Onkologie", "", new DateTime(2019, 09, 01), "w");

            pM.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));
            pM.PatientAnlegen(dummy2, ZimmerManagement.GetInstance().suchePassendesBett(dummy2));
            pM.PatientAnlegen(dummy3, ZimmerManagement.GetInstance().suchePassendesBett(dummy3));

            Verlegungsliste verlegungsliste = upM.GetCurrentVerlegungsliste();

            bool max = false;
            bool sven = false;
            bool christina = false;

            foreach(var titem in verlegungsliste.Transferliste)
            {
                if(titem.Person.Nachname.Equals("Mustermann"))
                {
                    max = true;
                }else if (titem.Person.Nachname.Equals("Knabe"))
                {
                    sven = true;
                }else if (titem.Person.Nachname.Equals("Meier"))
                {
                    christina = true;
                }
            }

            Assert.IsTrue(max && sven && christina);

            pM.PatientLoeschen("I123654789");
            pM.PatientLoeschen("J987456123");
            pM.PatientLoeschen("K899112445");

        }


    }
}
