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
    public class TreeTenConverter
    {
        #region tests to converting number 3 to 10 number system
        [TestMethod()]
        public void Test1_3To10_3digit()
        {
            int exp = 15;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("0000000120",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test2_3To10_5digit()
        {
            int exp = 198;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("0000021100",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test3_3To10_10digit_some1()
        {
            int exp = 48249;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("2110012000",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test4_3To10_10digit_some2()
        {
            int exp = 48268;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("2110012201",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test5_3To10_10digit_some3()
        {
            int exp = 8884;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("0110012001",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test6_3To10_10digit_null()
        {
            int exp = 0;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("0000000000",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test7_3To10_10digit_all2()
        {
            int exp = 59048;
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("2222222222",false);
            int act = conv.rightsNumberInTen;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test8_3To10_10digit_wrongDigits()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("2345522228",false);
                Assert.Fail("Not correct converting - not recognizes formatErr");
            }
            catch (ErrorUserRightFormat err)
            {
                if (err.Message != "A program hibát vétett, nem 3SZR-beni számértéket ad")
                    Assert.Fail("Wrong error message");
            }
        }
        [TestMethod()]
        public void Test9_3To10_10digit_all2_wrongDigits()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("0111098704",false);
                Assert.Fail("Not correct converting - not recognizes formatErr");
            }
            catch (ErrorUserRightFormat err)
            {
                if (err.Message != "A program hibát vétett, nem 3SZR-beni számértéket ad")
                    Assert.Fail("Wrong error message");
            }
        }
        [TestMethod()]
        public void Test10_3To10_5digit_wrongSize()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("01110",false);
                Assert.Fail("Not correct converting - not recognizes lengthErr");
            }
            catch (ErrorUserRightLength err)
            {
                if (err.Message != "A program hibát vétett, a szükségesnál rövidebb 3SZR-beni értéket ad")
                    Assert.Fail("Wrong error message");
            }
        }
        [TestMethod()]
        public void Test11_3To10_14digit_wrongSize()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("01110110022000",false);
                Assert.Fail("Not correct converting - not recognizes lengthErr");
            }
            catch (ErrorUserRightLength err)
            {
                if (err.Message != "A program hibát vétett, a szükségesnál hosszabb 3SZR-beni értéket ad")
                    Assert.Fail("Wrong error message");
            }
        }
        [TestMethod()]
        public void Test12_3To10_13digit_wrongSize()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("1012101210121",false);
                Assert.Fail("Not correct converting - not recognizes lengthErr");
            }
            catch (ErrorUserRightLength err)
            {
                if (err.Message != "A program hibát vétett, a szükségesnál hosszabb 3SZR-beni értéket ad")
                    Assert.Fail("Wrong error message");
            }
        }
        #endregion

        #region tests to convertin number 10 to 3 numbet system
        [TestMethod()]
        public void Test13_10To3_3digit()
        {
            string exp = "0000000120";
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("15",true);
            string act = conv.rightsNumberInThree;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test14_10To3_5digit()
        {
            string exp = "0000000001";
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("1",true);
            string act = conv.rightsNumberInThree;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test15_10To3_10digit_all2()
        {
            string exp = "2222222222";
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("59048",true);
            string act = conv.rightsNumberInThree;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test16_10To3_10digit_all0()
        {
            string exp = "0000000000";
            WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("0",true);
            string act = conv.rightsNumberInThree;
            Assert.AreEqual(exp, act, "Not correct converting");
        }
        [TestMethod()]
        public void Test17_10To3_10digit_tooBig1()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("59049",true);
                string act = conv.rightsNumberInThree;
                Assert.Fail("Not sends error for too great decimal number");
            }
            catch (ErrorUserRightFormat urfe)
            {
                if (urfe.getMessage() != "Az adatbázis sérült, jogosultság mezőben túl nagy számérték van")
                {
                    Assert.Fail("Not correct errormessage is arrived");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Not correct errortype is arrived");
            }
        }
        [TestMethod()]
        public void Test18_10To3_10digit_tooBig1()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("100000",true);
                string act = conv.rightsNumberInThree;
                Assert.Fail("Not sends error for too great decimal number");
            }
            catch (ErrorUserRightFormat urfe)
            {
                if (urfe.getMessage() != "Az adatbázis sérült, jogosultság mezőben túl nagy számérték van")
                {
                    Assert.Fail("Not correct errormessage is arrived");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Not correct errortype is arrived");
            }
        }
        [TestMethod()]
        public void Test19_10To3_10digit_tooSmall()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("-10",true);
                string act = conv.rightsNumberInThree;
                Assert.Fail("Not sends error for too great decimal number");
            }
            catch (ErrorUserRightFormat urfe)
            {
                if (urfe.getMessage() != "Az adatbázis sérült, jogosultság mezőben negatív számérték van")
                {
                    Assert.Fail("Not correct errormessage is arrived");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Not correct errortype is arrived");
            }
        }
        [TestMethod()]
        public void Test19_10To3_10digit_decimal()
        {
            try
            {
                WFAThesisProject.TreeTenConverter conv = new WFAThesisProject.TreeTenConverter("10.21", true);
                string act = conv.rightsNumberInThree;
                Assert.Fail("Not sends error for too great decimal number");
            }
            catch (ErrorUserRightFormat urfe)
            {
                if (urfe.getMessage() != "Az adatbázis sérült, jogosultság mezőben nem egész szám van")
                {
                    Assert.Fail("Not correct errormessage is arrived");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Not correct errortype is arrived");
            }
        }
        #endregion
    }
}