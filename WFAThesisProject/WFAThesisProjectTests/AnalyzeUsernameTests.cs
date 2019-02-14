using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFAThesisProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.Tests
{
    [TestClass()]
    public class AnalyzeUsernameTests
    {
        [TestMethod()]
        public void AnalyUsNameTest1_correct1()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("kiseva01");
            }
            catch (ErrorLogUsernameFormat e)
            {
                Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
        [TestMethod()]
        public void AnalyUsNameTest2_correct2()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("nagiva13");
            }
            catch (ErrorLogUsernameFormat e)
            {
                Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
        [TestMethod()]
        public void AnalyUsNameTest3_nonumber1()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("nagyivett");
                Assert.Fail("No error appeard, finds correct the bad one");
            }
            catch (ErrorLogUsernameFormat e)
            {
                if (e.getMessage() != "A felhasználónév végén nincs meg a két számkarater")
                    Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
        [TestMethod()]
        public void AnalyUsNameTest4_nonumber2()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("galpeter");
                Assert.Fail("No error appeard, finds correct the bad one");
            }
            catch (ErrorLogUsernameFormat e)
            {
                if (e.getMessage() != "A felhasználónév végén nincs meg a két számkarater")
                    Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
        [TestMethod()]
        public void AnalyUsNameTest5_withSpace1()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("gal pe02");
                Assert.Fail("No error appeard, finds correct the bad one");
            }
            catch (ErrorLogUsernameFormat e)
            {
                if (e.getMessage() != "A felhasználónév szóközt tartalmaz")
                    Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
        [TestMethod()]
        public void AnalyUsNameTest6_tooShort1()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("gal");
                Assert.Fail("No error appeard, finds correct the bad one");
            }
            catch (ErrorLogUsernameFormat e)
            {
                if (e.getMessage() != "Ez túl rövid, hogy felhasználónév legyen")
                    Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
        [TestMethod()]
        public void AnalyUsNameTest6_tooShort2()
        {
            try
            {
                AnalyzeUsername an = new AnalyzeUsername("ivanov");
                Assert.Fail("No error appeard, finds correct the bad one");
            }
            catch (ErrorLogUsernameFormat e)
            {
                if (e.getMessage() != "Ez túl rövid, hogy felhasználónév legyen")
                    Assert.Fail("Unexpected format-error appeared");
            }
            catch (Exception e)
            {
                Assert.Fail("Unspecified error type appeard");
            }
        }
    }
}