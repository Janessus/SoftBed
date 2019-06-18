using System;
using Logic;
using Wrapperklassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class UserManagementTest
    {
    /**  Hinweise:
     * Eigentlich müsste man noch die Rechte abtesten.
     * Da die Funktionen aber eh nur aus dem Adminbereich aufgerufen werden können ist es nicht nötig
     */

        /**
         * Test zum User Anlegen
         * schlägt fehl wenn User mit gleichem Benutzername zweimal angelegt werden kann
         */
        [TestMethod]
        public void UserAnlegenTest()
        {
            UserManagement userManagement = UserManagement.GetInstance();
            User dummy = new User("John", "Doe", "Standard", "JonnyBoy", "1234");
            User dummy2 = new User("Bat", "Man", "Azubi", "JonnyBoy", "Batman");

            bool firstTime = userManagement.UserAnlegen(dummy);     //sollte klappen da neuer Benutzername
            bool secondTime = userManagement.UserAnlegen(dummy2);    //sollte nicht klappen da gleicher Benutzername wie zuvor

            Assert.IsTrue(firstTime && !secondTime);    //erste mal muss geklappt haben, zweite mal darf nicht geklappt haben

            userManagement.UserLöschen("JonnyBoy");
        }

        /**
         * Test zum User Löschen
         * schlägt fehl wenn der selbe User nach dem löschen nochmal gelöscht werden kann (also nicht gelöscht wurde)
         */
        [TestMethod]
        public void UserLoeschenTest()
        {
            UserManagement userManagement = UserManagement.GetInstance();
            User dummy = new User("John", "Doe", "Standard", "JonnyBoy", "1234");
            userManagement.UserAnlegen(dummy);

            bool firstTime = userManagement.UserLöschen(dummy.Benutzername);    //sollte klappen da User existent
            Thread.Sleep(5000);
            bool secondTime = userManagement.UserLöschen(dummy.Benutzername);   //sollte fehlschlagen da User nicht mehr existent

            Assert.IsTrue(firstTime && !secondTime);

            userManagement.UserLöschen("JonnyBoy");
        }

        /**
         * Test zum Login
         * schlägt fehl wenn gewollter User nicht dem eingeloggten User entspricht
         */
        [TestMethod]
        public void UserLoginTest()
        {
            UserManagement userManagement = UserManagement.GetInstance();
            User dummy = new User("John", "Doe", "Standard", "JonnyBoy", "1234");
            userManagement.UserAnlegen(dummy);

            userManagement.UserLogin(dummy.Benutzername, dummy.Passwort);   
            User loggedin = UserManagement.CurrentUser;

            bool firstTime = loggedin.Benutzername.Equals(dummy.Benutzername);  //klappt, da currentUser dem zuletzt eingeloggten user entspricht

            Assert.IsTrue(firstTime);

            userManagement.UserLöschen("JonnyBoy");
        }

        /**
        * Test zum Logout
        * schlägt fehl wenn am anfang oder nach dem ausloggen nicht der CurrentUser dem dummy entspricht
        */
        [TestMethod]
        public void UserLogoutTest()
        {
            UserManagement userManagement = UserManagement.GetInstance();
            User dummy = new User("Dummy", "Dummy", "Dummy", "Dummy", "Dummy");
            User dummy2 = new User("John", "Doe", "Standard", "JonnyBoy", "1234");
            userManagement.UserAnlegen(dummy2);

            bool firstTime = UserManagement.CurrentUser.Benutzername.Equals(dummy.Benutzername);

            userManagement.UserLogin(dummy2.Benutzername, dummy2.Passwort);
            userManagement.UserLogout();

            bool secondTime = UserManagement.CurrentUser.Benutzername.Equals(dummy.Benutzername);

            Assert.IsTrue(firstTime && secondTime);

            userManagement.UserLöschen("JonnyBoy");
        }

    }
}
