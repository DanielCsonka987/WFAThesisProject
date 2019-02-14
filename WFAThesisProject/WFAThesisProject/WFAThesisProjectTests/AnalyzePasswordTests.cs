using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFAThesisProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject.Tests
{
    [TestClass()]
    public class AnalyzePasswordTests
    {
        [TestMethod()]
        public void AnalyPwdTest1_correct1()
        {
            try {
                AnalyzePassword ap = new AnalyzePassword("passWord1_");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest2_correct2()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("Passw0rd%");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest3_shortButGood1()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("pAsswo ");
                Assert.Fail("Failure is not recognised");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszó túl rövid, hogy megfelelő legyen")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest4_shortButGood2()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("w0Rd&");
                Assert.Fail("Failure is not recognised");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszó túl rövid, hogy megfelelő legyen")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest5_noPassword()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("");
                Assert.Fail("Failure is not recognised");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "Nem adott meg jelszót, kérem írja be!")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest6_noDigit1()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("Password+");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs számkarakter")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest7_noDigit2()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("*passWord");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs számkarakter")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTestt8_noUppercase1()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("7password!");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs nagybetűs karakter")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest9_noUppercase2()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("pas5_word");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs nagybetűs karakter")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest10_noLowercase1()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("PAS5WORD-");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs kisbetűs karatker")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest11_noLowercase2()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("PAS5/WORD");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs kisbetűs karatker")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest12_noSpec1()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("pas2sWord");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs speciális karakter")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
        [TestMethod()]
        public void AnalyPwdTest12_noSpec2()
        {
            try
            {
                AnalyzePassword ap = new AnalyzePassword("pAssword9");
                Assert.Fail("Wrong error is given");
            }
            catch (ErrorLogPassContent e)
            {
                if (e.getMessage() != "A jelszóban nincs speciális karakter")
                    Assert.Fail("Wrong error is given");
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected error is given");
            }
        }
    }
}