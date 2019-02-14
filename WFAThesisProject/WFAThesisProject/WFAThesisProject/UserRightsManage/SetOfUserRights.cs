using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class SetOfUserRights
    {

        private RightLevels uR1_Req;
        private RightLevels uR2_AccidLocal;
        private RightLevels uR3_UserLocal;
        private RightLevels uR4_UserGlobal;
        private RightLevels uR5_RightMan;
        private RightLevels uR6_AccidGlobal;
        private RightLevels uR7_StoreMan;
        private RightLevels uR8_ReqMan;
        private RightLevels uR9_Order;
        private RightLevels uR10_Subcontr;
        public SetOfUserRights()
        { }

        /// <summary>
        /// constructor for adjust UserRightMarkers
        /// </summary>
        /// <param name="userRightFromCB_In3">collected roghts</param>
        public SetOfUserRights (string userRight_In3)
        {
            mistakeSeek(userRight_In3);   //testing char mistakes
            overSizeSeek(userRight_In3);  //testing length mistakes
            for (int i = 0; i < 10; i++)
            {
                adjustingRightMarkers(i, userRight_In3[i]);
            }
        }
        
        public void excavateRightsTo10NS()
        {

        }



        #region adjusters of uR markers
        private void adjustingRightMarkers(int i, char v)
        {
            if (i == 0)
            {
                if (v == '0')
                    uR1_Req = RightLevels.NONE;
                else if (v == '1')
                    uR1_Req = RightLevels.READ;
                else if (v == '2')
                    uR1_Req = RightLevels.MODiFY;
            }
            else if (i == 1)
            {
                if (v == '0')
                    uR2_AccidLocal = RightLevels.NONE;
                else if (v == '1')
                    uR2_AccidLocal = RightLevels.READ;
                else if (v == '2')
                    uR2_AccidLocal = RightLevels.MODiFY;
            }
            else if (i == 2)
            {
                if (v == '0')
                    uR3_UserLocal = RightLevels.NONE;
                else if (v == '1')
                    uR3_UserLocal = RightLevels.READ;
                else if (v == '2')
                    uR3_UserLocal = RightLevels.MODiFY;
            }
            else if (i == 3)
            {
                if (v == '0')
                    uR4_UserGlobal = RightLevels.NONE;
                else if (v == '1')
                    uR4_UserGlobal = RightLevels.READ;
                else if (v == '2')
                    uR4_UserGlobal = RightLevels.MODiFY;
            }
            else if (i == 4)
            {
                if (v == '0')
                    uR5_RightMan = RightLevels.NONE;
                else if (v == '1')
                    uR5_RightMan = RightLevels.READ;
                else if (v == '2')
                    uR5_RightMan = RightLevels.MODiFY;
            }
            else if (i == 5)
            {
                if (v == '0')
                    uR6_AccidGlobal = RightLevels.NONE;
                else if (v == '1')
                    uR6_AccidGlobal = RightLevels.READ;
                else if (v == '2')
                    uR6_AccidGlobal = RightLevels.MODiFY;
            }
            else if (i == 6)
            {
                if (v == '0')
                    uR7_StoreMan = RightLevels.NONE;
                else if (v == '1')
                    uR7_StoreMan = RightLevels.READ;
                else if (v == '2')
                    uR7_StoreMan = RightLevels.MODiFY;
            }
            else if (i == 7)
            {
                if (v == '0')
                    uR8_ReqMan = RightLevels.NONE;
                else if (v == '1')
                    uR8_ReqMan = RightLevels.READ;
                else if (v == '2')
                    uR8_ReqMan = RightLevels.MODiFY;
            }
            else if (i == 8)
            {
                if (v == '0')
                    uR9_Order = RightLevels.NONE;
                else if (v == '1')
                    uR9_Order = RightLevels.READ;
                else if (v == '2')
                    uR9_Order = RightLevels.MODiFY;
            }
            else if (i == 9)
            {
                if (v == '0')
                    uR10_Subcontr = RightLevels.NONE;
                else if (v == '1')
                    uR10_Subcontr = RightLevels.READ;
                else if (v == '2')
                    uR10_Subcontr = RightLevels.MODiFY;
            }
        }
        #endregion

        #region getters of uR markers
        public RightLevels getuR1_Req(){ return uR1_Req; }
        public RightLevels getuR2_AccidLocal() { return uR2_AccidLocal; }
        public RightLevels getuR3_UserLocal() { return uR3_UserLocal; }
        public RightLevels getuR4_UserGlobal() { return uR4_UserGlobal; }
        public RightLevels getuR5_RightMan() { return uR5_RightMan; }
        public RightLevels getuR6_AccidGlobal() { return uR6_AccidGlobal; }
        public RightLevels getuR7_ProductsMan() { return uR7_StoreMan; }
        public RightLevels getuR8_ReqMan() { return uR8_ReqMan; }
        public RightLevels getuR9_Order() { return uR9_Order; }
        public RightLevels getuR10_Subcontr() { return uR10_Subcontr; }
        #endregion

        #region testers
        //the testing, not too long or short in digit was sent
        private void overSizeSeek(string numberThreeToTen)
        {
            if (numberThreeToTen.Length > 10)
            {
                throw new ErrorUserRightLength("Jogosultság kezelési hiba, túl hosszú jelsor érkezett a setterbe");
            }
            else if (numberThreeToTen.Length < 10)
            {
                throw new ErrorUserRightLength("Jogosultság kezelési hiba, túl rövid jelsor érkezett a setterbe");
            }
        }
        //the testing validiti of the digit
        private void mistakeSeek(string numberThreeToTen)
        {
            if (numberThreeToTen.IndexOf('3') >= 0 || numberThreeToTen.IndexOf('4') >= 0 || numberThreeToTen.IndexOf('5') >= 0 ||
                numberThreeToTen.IndexOf('6') >= 0 || numberThreeToTen.IndexOf('7') >= 0 || numberThreeToTen.IndexOf('8') >= 0 ||
                numberThreeToTen.IndexOf('9') >= 0)
            {
                throw new ErrorUserRightFormat("Jogosultság kezelési hiba a setterben, túl széles egyes jogok minősítése");
            }
        }
        #endregion
    }

    public enum RightLevels { NONE=0, READ=1, MODiFY=2 }
}
