﻿using System;
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
            Patient dummy = new Patient("Max", "Mustermann", 123, "01.01.1985", "On", "", new DateTime(2019, 04, 01), "maennlich");

            Assert.IsTrue(patientenManagement.PatientAnlegen(dummy));
        }

        /**
        * Test zum Anlegen eines Patienten
        * schlaegt fehl, wenn ein und der Patient zweimal angelegt werden kann
        */
        [TestMethod]
        public void PatientZweimalAnlegenTest()
        {
            Patient dummy = new Patient("Maxim","Muster", 124, "01.01.1990", "IM","", new DateTime(2019, 04, 01), "maennlich");

            bool result1 = patientenManagement.PatientAnlegen(dummy);
            bool result2 = patientenManagement.PatientAnlegen(dummy);

            Assert.IsTrue(result1 && !result2);
        }

        /**
        * Test zum Anlegen zweier Patienten
        * schlaegt fehl, wenn zwei unterschiedliche Patienten nicht erfolgreich angelegt werden können
        */
        [TestMethod]
        public void ZweiUngleichePatientenAnlegenTest()
        {
            Patient dummy1 = new Patient("Max", "Mustermann", 321, "07.01.1994", "IM", "", new DateTime(2019,04,01), "maennlich");
            Patient dummy2 = new Patient("Helga", "Hase", 322, "07.01.1989", "Gy", "", new DateTime(2019, 04, 01), "weiblich");

            bool result1 = patientenManagement.PatientAnlegen(dummy1);
            bool result2 = patientenManagement.PatientAnlegen(dummy2);

            Assert.IsTrue(result1 && result2);
        }

        /**
        * Test zum Loeschen eines Patienten
        * schlaegt fehl, wenn Patient nicht erfolgreich gelöscht werden kann
        */
        [TestMethod]
        public void PatientLoeschenTest()
        {
            Patient dummy = new Patient("Horst", "Salz", 121, "05.07.1950", "On", "", new DateTime(2019, 04, 01), "maennlich");

            patientenManagement.PatientAnlegen(dummy);

            Assert.IsTrue(patientenManagement.PatientLoeschen(121)); 
        }

        /**
        * Test zum Loeschen eines Patienten
        * schlaegt fehl, wenn ein und der Patient zweimal gelöscht werden kann
        */
        [TestMethod]
        public void PatientZweimalLoeschen()
        {
            Patient dummy = new Patient("Emma", "Erdbeer", 120, "´20.06.2008", "P", "", new DateTime(2019, 04, 01), "weiblich");

            patientenManagement.PatientAnlegen(dummy);

            bool result1 = patientenManagement.PatientLoeschen(120);
            bool result2 = patientenManagement.PatientLoeschen(120);


            Assert.IsTrue(result1 && !result2);

        }
        /**
        * Test zum Aendern eines Patienten
        * schlaegt fehl, wenn Patient nicht geaendert werden kann
        */
        [TestMethod]
        public void PatientAendernTest()
        {
            Patient dummy1 = new Patient("Felix", "Fuß", 232, "01.04.2010", "IM", "", new DateTime(2019, 04, 01), "maennlich");
            Patient dummy2 = new Patient("Felix", "Fuß", 232, "01.04.2010", "P", "", new DateTime(2019, 04, 01), "maennlich");

            patientenManagement.PatientAnlegen(dummy1);

            bool result = patientenManagement.PatientAendern(dummy2); //Station soll geaendert werden
            Assert.IsTrue(result);
        }
    }
}
