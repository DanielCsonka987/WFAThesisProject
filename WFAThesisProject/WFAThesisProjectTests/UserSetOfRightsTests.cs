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
    public class UserSetOfRightsTests
    {
        [TestMethod()]
        public void Test1_UR_dataIn3_PozitiveAll0()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000000");
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != 0 || act2 != 0 || act3 != 0 || act4 != 0 || act5 != 0 || act6 != 0 ||
                    act7 != 0 || act8 != 0 || act9 != 0 || act10 != 0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        #region adjust rightMarkers from 3NS with one pc1
        [TestMethod()]
        public void Test2_UR_dataIn3_PozitiveOne1_1()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("1000000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp1 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test3_UR_dataIn3_PozitiveOne1_2()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0100000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp1 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test4_UR_dataIn3_PozitiveOne1_3()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0010000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp1 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test5_UR_dataIn3_PozitiveOne1_4()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0001000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp1 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test6_UR_dataIn3_PozitiveOne1_5()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000100000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp1 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test7_UR_dataIn3_PozitiveOne1_6()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000010000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp1 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test8_UR_dataIn3_PozitiveOne1_7()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000001000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp1 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test9_UR_dataIn3_PozitiveOne1_8()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000100");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp1 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test10_UR_dataIn3_PozitiveOne1_9()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000010");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp1 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test11_UR_dataIn3_PozitiveOne1_10()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000001");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp1)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        #endregion

        #region adjust rightMarkers from 3NS with one pc2
        [TestMethod()]
        public void Test12_UR_dataIn3_PozitiveOne2_1()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("2000000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp2 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test13_UR_dataIn3_PozitiveOne2_2()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0200000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp2 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test14_UR_dataIn3_PozitiveOne2_3()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0020000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp2 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test15_UR_dataIn3_PozitiveOne2_4()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0002000000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp2 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test16_UR_dataIn3_PozitiveOne2_5()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000200000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp2 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test17_UR_dataIn3_PozitiveOne2_6()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000020000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp2 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test18_UR_dataIn3_PozitiveOne2_7()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000002000");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp2 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test19_UR_dataIn3_PozitiveOne2_8()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000200");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp2 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }


        [TestMethod()]
        public void Test20_UR_dataIn3_PozitiveOne2_9()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000020");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp2 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test21_UR_dataIn3_PozitiveOne2_10()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0000000002");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp2)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        #endregion

        #region adjust rightMarkers from 3NS with random
        [TestMethod()]
        public void Test22_UR_dataIn3_Positive_Random()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0200100002");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp2 || act3 != exp0 || act4 != exp0 || act5 != exp1 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp2)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test23_UR_dataIn3_Positive_Random()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("1010102110");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp1 || act2 != exp0 || act3 != exp1 || act4 != exp0 || act5 != exp1 ||
                    act6 != exp0 || act7 != exp2 || act8 != exp1 || act9 != exp1 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }

        [TestMethod()]
        public void Test24_UR_dataIn3_Negative_Random()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0020110010");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp2 || act3 != exp0 || act4 != exp0 || act5 != exp1 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp2)
                {

                }
                else
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        [TestMethod()]
        public void Test25_UR_dataIn3_Negative_Random()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("1012101210");
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp1 || act3 != exp1 || act4 != exp2 || act5 != exp1 ||
                    act6 != exp1 || act7 != exp1 || act8 != exp0 || act9 != exp2 || act10 != exp0)
                {

                }
                else
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        #endregion

        #region testing 3NS digit type_lenght failures
        [TestMethod()]
        public void Test26_UR_dataIn3_WrongSize_small6dig()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("000000");
            }
            catch (ErrorUserRightLength err)
            {
                if (err.Message != "Jogosultság kezelési hiba, túl rövid jelsor érkezett a setterbe")
                    Assert.Fail("Proccessing problem appeared");
            }
        }
        [TestMethod()]
        public void Test27_UR_dataIn3_WrongSize_big()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("000000000111000000000");
            }
            catch (ErrorUserRightLength err)
            {
                if (err.Message != "Jogosultság kezelési hiba, túl hosszú jelsor érkezett a setterbe")
                    Assert.Fail("Proccessing problem appeared");
            }
        }
        [TestMethod()]
        public void Test28_UR_dataIn3_WrongDigits()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("0123456789");
            }
            catch (ErrorUserRightFormat err)
            {
                if (err.Message != "Jogosultság kezelési hiba a setterben, túl széles egyes jogok minősítése")
                    Assert.Fail("Proccessing problem appeared");
            }
        }
        [TestMethod()]
        public void Test29_UR_dataIn3_WrongDigits()
        {
            try
            {
                SetOfUserRights usor = new SetOfUserRights("9023466700");
            }
            catch (ErrorUserRightFormat err)
            {
                if (err.Message != "Jogosultság kezelési hiba a setterben, túl széles egyes jogok minősítése")
                    Assert.Fail("Proccessing problem appeared");
            }
        }
        #endregion

        #region adjust rightMarkers from 10NS
        [TestMethod()]
        public void Test30_UR_dataIn10()
        {
            try
            {
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("233",true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp2 || act7 != exp2 || act8 != exp1 || act9 != exp2 || act10 != exp2)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        [TestMethod()]
        public void Test31_UR_dataIn10()
        {
            try
            {
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("12001", true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp1 || act3 != exp2 || act4 != exp1 || act5 != exp1 ||
                    act6 != exp1 || act7 != exp0 || act8 != exp1 || act9 != exp1 || act10 != exp1)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        [TestMethod()]
        public void Test32_UR_dataIn10()
        {
            try
            {
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("32011", true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp1 || act2 != exp1 || act3 != exp2 || act4 != exp1 || act5 != exp2 ||
                    act6 != exp2 || act7 != exp0 || act8 != exp1 || act9 != exp2 || act10 != exp1)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        [TestMethod()]
        public void Test33_UR_dataIn10()
        {
            try
            {
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("0", true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp0 || act2 != exp0 || act3 != exp0 || act4 != exp0 || act5 != exp0 ||
                    act6 != exp0 || act7 != exp0 || act8 != exp0 || act9 != exp0 || act10 != exp0)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        [TestMethod()]
        public void Test34_UR_dataIn10()
        {
            try
            {
                RightLevels exp0 = RightLevels.NONE;
                RightLevels exp1 = RightLevels.READ;
                RightLevels exp2 = RightLevels.MODiFY;
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("59048",true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);
                RightLevels act1 = usor.getuR1_Req();
                RightLevels act2 = usor.getuR2_AccidLocal();
                RightLevels act3 = usor.getuR3_UserLocal();
                RightLevels act4 = usor.getuR4_UserGlobal();
                RightLevels act5 = usor.getuR5_RightMan();
                RightLevels act6 = usor.getuR6_AccidGlobal();
                RightLevels act7 = usor.getuR7_ProductsMan();
                RightLevels act8 = usor.getuR8_ReqMan();
                RightLevels act9 = usor.getuR9_Order();
                RightLevels act10 = usor.getuR10_Subcontr();

                if (act1 != exp2 || act2 != exp2 || act3 != exp2 || act4 != exp2 || act5 != exp2 ||
                    act6 != exp2 || act7 != exp2 || act8 != exp2 || act9 != exp2 || act10 != exp2)
                {
                    Assert.Fail("Proccessing problem appeared");
                }
            }
            catch (ErrorUserRightLength err)
            {
                Assert.Fail("Proccessing problem appeared - lengthErr");
            }
            catch (ErrorUserRightFormat err)
            {
                Assert.Fail("Proccessing problem appeared - formatErr");
            }
        }
        [TestMethod()]
        public void Test35_UR_dataIn10_wrongRange()
        {
            try
            {
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("59049", true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);

            }
            catch (ErrorUserRightFormat err)
            {
                if (err.Message != "Az adatbázis sérült, jogosultság mezőben túl nagy számérték van")
                    Assert.Fail("Proccessing problem appeared - rangeErr");
            }
        }
        [TestMethod()]
        public void Test36_UR_dataIn10_wrongRange()
        {
            try
            {
                WFAThesisProject.TreeTenConverter ttc = new WFAThesisProject.TreeTenConverter("-1", true);
                SetOfUserRights usor = new SetOfUserRights(ttc.rightsNumberInThree);

            }
            catch (ErrorUserRightFormat err)
            {
                if (err.Message != "Az adatbázis sérült, jogosultság mezőben negatív számérték van")
                    Assert.Fail("Proccessing problem appeared - rangeErr");
            }
        }
        #endregion
    }
}