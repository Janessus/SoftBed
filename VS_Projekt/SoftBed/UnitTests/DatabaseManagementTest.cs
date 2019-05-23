using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DatabaseManagementTest
    {
        [TestMethod]
        public void ExecuteQueryWithInsert()
        {
            var dbm = DatabaseManagement.GetInstance();
            var con = dbm.Connect();

            var reader = dbm.ExecuteQuery("INSERT INTO Person(Vorname, Nachname) " +
                             "VALUES(\"Unit\", \"Test\");", con);

            con.Close();

            Assert.IsNotNull(reader);
        }
    }
}
