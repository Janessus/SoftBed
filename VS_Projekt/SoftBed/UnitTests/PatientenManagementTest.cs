using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapperklassen;

namespace UnitTests
{
    [TestClass]
    public class PatientenManagementTest
    {
        private PatientenManagement patientenManagement = PatientenManagement.GetInstance();


        /**
        * Test zum Anlegen eines Patienten
        * schlaegt fehl, wenn Patient nicht erfolgreich angelegt werden kann
        */
        [TestMethod]
        public void PatientAnlegenTest()
        {
            Patient dummy = new Patient("Max", "Mustermann", "X123446789", new DateTime(1985, 01, 01), "Onkologie", "", new DateTime(2019, 04, 01), "m");

            bool result = patientenManagement.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));

            Assert.IsTrue(result);

            patientenManagement.PatientLoeschen("X123446789");
        }

        /**
        * Test zum Anlegen eines Patienten
        * schlaegt fehl, wenn ein und der Patient zweimal angelegt werden kann
        */
        [TestMethod]
        public void PatientZweimalAnlegenTest()
        {
            Patient dummy = new Patient("Maxim","Muster", "Y987654321", new DateTime(1990, 01, 01), "Innere Medizin","", new DateTime(2019, 04, 01), "m");

            bool result1 = patientenManagement.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));
            bool result2 = patientenManagement.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));

            Assert.IsTrue(result1 && !result2);

            patientenManagement.PatientLoeschen("Y987654321");
        }

        /**
        * Test zum Anlegen zweier Patienten
        * schlaegt fehl, wenn zwei unterschiedliche Patienten nicht erfolgreich angelegt werden können
        */
        [TestMethod]
        public void ZweiUngleichePatientenAnlegenTest()
        {
            Patient dummy1 = new Patient("Max", "Mustermann", "Z321321321", new DateTime(1994, 01, 07), "Innere Medizin", "", new DateTime(2019,04,01), "m");
            Patient dummy2 = new Patient("Helga", "Hase", "A322114456", new DateTime(1989, 01, 07), "Gynäkologie", "", new DateTime(2019, 04, 01), "w");

            bool result1 = patientenManagement.PatientAnlegen(dummy1, ZimmerManagement.GetInstance().suchePassendesBett(dummy1));
            bool result2 = patientenManagement.PatientAnlegen(dummy2, ZimmerManagement.GetInstance().suchePassendesBett(dummy2));

            Assert.IsTrue(result1 && result2);
            patientenManagement.PatientLoeschen("Z321321321");
            patientenManagement.PatientLoeschen("A322114456");
        }

        /**
        * Test zum Loeschen eines Patienten
        * schlaegt fehl, wenn Patient nicht erfolgreich gelöscht werden kann
        */
        [TestMethod]
        public void PatientLoeschenTest()
        {
            Patient dummy = new Patient("Horst", "Salz", "B121343565", new DateTime(1950, 07, 05), "Onkologie", "", new DateTime(2019, 04, 01), "m");

            patientenManagement.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));

            Assert.IsTrue(patientenManagement.PatientLoeschen("B121343565"));

        }

        /**
        * Test zum Loeschen eines Patienten
        * schlaegt fehl, wenn ein und der Patient zweimal gelöscht werden kann
        */
        /*[TestMethod]
        public void PatientZweimalLoeschen()
        {
            Patient dummy = new Patient("Emma", "Erdbeer", "C120234687", new DateTime(2008, 06, 20), "Pädiatrie", "", new DateTime(2019, 04, 01), "w");

            bool result = patientenManagement.PatientAnlegen(dummy, ZimmerManagement.GetInstance().suchePassendesBett(dummy));

            bool result1 = patientenManagement.PatientLoeschen("C120234687");
            bool result2 = patientenManagement.PatientLoeschen("C120234687");


            Assert.IsTrue(result1 && !result2);
        }*/

        /**
        * Test zum Aendern eines Patienten
        * schlaegt fehl, wenn Patient nicht geaendert werden kann
        */


        /*[TestMethod]
        public void PatientAendernTest()
        {
            Patient dummy1 = new Patient("Felix", "Fuß", "D232908723", new DateTime(2010, 04, 01), "Innere Medizin", "", new DateTime(2019, 04, 01), "m");
            Patient dummy2 = new Patient("Felix", "Fuß", "D232908723", new DateTime(2010, 04, 01), "Pädiatrie", "", new DateTime(2019, 04, 01), "m");

            patientenManagement.PatientAnlegen(dummy1, ZimmerManagement.GetInstance().suchePassendesBett(dummy1));

            bool result = patientenManagement.PatientAendern(dummy2); //Station soll geaendert werden
            Assert.IsTrue(result);

            patientenManagement.PatientLoeschen("D232908723");
        }*/
    }
}
