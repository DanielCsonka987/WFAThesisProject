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
    public class ManageIOConnFileTests
    {
        [TestMethod()]
        public void ManageIOConnFileTest1_Full1()
        {
            try
            {
                UserConnDetails ucd1 = new UserConnDetails("localhost","3306", "vegyszerraktar",
                    "en", "c", "val", "valami");
                ManageIOConnFileController miocf = new ManageIOConnFileController(ucd1, true);
                
                UserConnDetails ucd2 = new UserConnDetails();
                ManageIOConnFileController miocf2 = new ManageIOConnFileController(ucd2, false);
                ucd2 = miocf2.getConnInfos();
                if (ucd2 == null)
                    Assert.Fail("Problem, data container is empty!");
                if (ucd1.host != ucd2.host || ucd1.port != ucd2.port ||
                    ucd1.db != ucd2.db || ucd1.user != ucd2.user ||
                    ucd1.pwd != ucd2.pwd || ucd1.output != ucd2.output ||
                    ucd1.input != ucd2.input)
                {
                    Assert.Fail("Some problem, difference appeard between reading and writting");
                }
                
            }
            catch (ErrorXmlFileWrite e)
            {
                Assert.Fail(e.getMessage());
            }
            catch (ErrorXmlFileRead e)
            {
                Assert.Fail(e.getMessage());
            }
            catch (Exception)
            {
                Assert.Fail("Some problem appeard");
            }
        }
        [TestMethod()]
        public void ManageIOConnFileTest2_Full2()
        {
            try
            {
                UserConnDetails ucd1 = new UserConnDetails("127.0.0.1", "3307", "adatb",
                    "user", "jelszo", "", "");
                ManageIOConnFileController miocf = new ManageIOConnFileController(ucd1, true);

                UserConnDetails ucd2 = new UserConnDetails();
                ManageIOConnFileController miocf2 = new ManageIOConnFileController(ucd2, false);
                ucd2 = miocf2.getConnInfos();
                if (ucd2 == null)
                    Assert.Fail("Problem, data container is empty!");
                if (ucd1.host != ucd2.host || ucd1.port != ucd2.port ||
                    ucd1.db != ucd2.db || ucd1.user != ucd2.user ||
                    ucd1.pwd != ucd2.pwd || ucd1.output != ucd2.output ||
                    ucd1.input != ucd2.input)
                {
                    Assert.Fail("Some problem, difference appeard between reading and writting");
                }

            }
            catch (ErrorXmlFileWrite e)
            {
                Assert.Fail(e.getMessage());
            }
            catch (ErrorXmlFileRead e)
            {
                Assert.Fail(e.getMessage());
            }
            catch (Exception)
            {
                Assert.Fail("Some problem appeard");
            }
        }
        [TestMethod()]
        public void ManageIOConnFileTest3_Full3()
        {
            try
            {
                UserConnDetails ucd1 = new UserConnDetails("", "", "rakt",
                    "felhasznaló", "pwd", "az", "ez");
                ManageIOConnFileController miocf = new ManageIOConnFileController(ucd1, true);

                UserConnDetails ucd2 = new UserConnDetails();
                ManageIOConnFileController miocf2 = new ManageIOConnFileController(ucd2, false);
                ucd2 = miocf2.getConnInfos();
                if (ucd2 == null)
                    Assert.Fail("Problem, data container is empty!");
                if (ucd1.host != ucd2.host || ucd1.port != ucd2.port ||
                    ucd1.db != ucd2.db || ucd1.user != ucd2.user ||
                    ucd1.pwd != ucd2.pwd || ucd1.output != ucd2.output ||
                    ucd1.input != ucd2.input)
                {
                    Assert.Fail("Some problem, difference appeard between reading and writting");
                }

            }
            catch (ErrorXmlFileWrite e)
            {
                Assert.Fail(e.getMessage());
            }
            catch (ErrorXmlFileRead e)
            {
                Assert.Fail(e.getMessage());
            }
            catch (Exception)
            {
                Assert.Fail("Some problem appeard");
            }
        }

    }
}