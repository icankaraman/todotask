using Microsoft.VisualStudio.TestTools.UnitTesting;
using todolist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist.Tests
{
    [TestClass()]
    public class SignInWindowTests
    {
        [TestMethod()]
        public void ValidateLinesTest()
        {
            var user = "can";
            var pass = "123456";
            var confirmPass = "123";
            SignInWindow signWin = new SignInWindow();
            Assert.AreEqual(signWin.ValidateLines(user, pass, confirmPass), false);
        }
    }
}