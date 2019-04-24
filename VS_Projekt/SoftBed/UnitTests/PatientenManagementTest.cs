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

        [TestMethod]

        public void PatientAnlegenTest()
        {
            Patient dummy = new Patient("Max", "Mustermann", 123, "01.01.1985", "On", "", "10.04.2019", "maennlich");

            Assert.IsTrue(patientenManagement.PatientAnlegen(dummy));
        }

        [TestMethod]
        public void PatientZweimalAnlegenTest()
        {
            Patient dummy = new Patient("Maxim","Muster", 124, "01.01.1990", "IM","","16.04.2019","maennlich");

            bool result1 = patientenManagement.PatientAnlegen(dummy);
            bool result2 = patientenManagement.PatientAnlegen(dummy);

            Assert.IsTrue(result1 && !result2);
        }

        [TestMethod]
        public void ZweiUngleichePatientenAnlegenTest()
        {
            Patient dummy1 = new Patient("Max", "Mustermann", 321, "07.01.1994", "IM", "", "01.04.2019", "maennlich");
            Patient dummy2 = new Patient("Helga", "Hase", 322, "07.01.1989", "Gy", "", "01.03.2019", "weiblich");

            bool result1 = patientenManagement.PatientAnlegen(dummy1);
            bool result2 = patientenManagement.PatientAnlegen(dummy2);

            Assert.IsTrue(result1 && result2);
        }

        [TestMethod]
        public void PatientLoeschenTest()
        {
            Patient dummy = new Patient("Horst", "Salz", 121, "05.07.1950", "On", "", "06.04.2019", "maennlich");

            patientenManagement.PatientAnlegen(dummy);

            Assert.IsTrue(patientenManagement.PatientLoeschen(121)); 
        }


        [TestMethod]
        public void PatientZweimalLoeschen()
        {
            Patient dummy = new Patient("Emma", "Erdbeer", 120, "´20.06.2008", "P", "", "09.03.2019", "weiblich");

            patientenManagement.PatientAnlegen(dummy);

            bool result1 = patientenManagement.PatientLoeschen(120);
            bool result2 = patientenManagement.PatientLoeschen(120);


            Assert.IsTrue(result1 && !result2);

        }

        [TestMethod]
        public void PatientAendernTest()
        {
            Patient dummy1 = new Patient("Felix", "Fuß", 232, "01.04.2010", "IM", "", "12.04.2019", "maennlich");
            Patient dummy2 = new Patient("Felix", "Fuß", 232, "01.04.2010", "P", "", "12.04.2019", "maennlich");

            patientenManagement.PatientAnlegen(dummy1);

            bool result = patientenManagement.PatientAendern(dummy2);
            Assert.IsTrue(result);
        }
    }
}
