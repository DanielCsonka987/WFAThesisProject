using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class TreeTenConverter
    {
        public int rightsNumberInTen { get; }
        public string rightsNumberInThree { get; }
        /// <summary>
        /// Converting rights data in a number - from DataBase (true) or ComboBoxes (false)
        /// It gives the possibility to handle the UserSetOfRights container
        /// </summary>
        /// <param name="numberTenToThree">data from DB or CB/param>
        /// <paramref name="ways"/>true = data from DB (10NS) / false = data from program (3NS)/param>
        public TreeTenConverter(string data, bool ways)
        {
            if (ways)   //the data from DB needed in program container
            {
                int numberTenToThree;
                if (!Int32.TryParse(data , out numberTenToThree))
                    throw new ErrorUserRightFormat("Az adatbázis sérült, jogosultság mezőben nem egész szám van");
                if (numberTenToThree == 0)
                    this.rightsNumberInThree = "0000000000";
                else if (numberTenToThree > 59048)
                    throw new ErrorUserRightFormat("Az adatbázis sérült, jogosultság mezőben túl nagy számérték van");
                else if (numberTenToThree < 0)
                    throw new ErrorUserRightFormat("Az adatbázis sérült, jogosultság mezőben negatív számérték van");
                else
                    this.rightsNumberInThree = convetingTenToThree(numberTenToThree);
            }
            else
            {
                //testing is needed, when data cames from ComboBoxes to save to the Database
                overSizeSeek(data); //test the correct size
                mistakeSeek(data);  //test the content, wheater is in 3NS
                this.rightsNumberInTen = convertingThreeToTen(data);
            }

        }

        #region dealin with convertin 10 to 3 number system
        /// <summary>
        /// converting -> reversing -> filling it to 10 digit
        /// </summary>
        /// <param name="numberIn10NS">paramter in 10NS</param>
        /// <returns>3NS digit in string</returns>
        private string convetingTenToThree(int numberIn10NS)
        {
            string temp = "";
            do
            {
                if (numberIn10NS == 3)
                {
                    temp += 0;
                    numberIn10NS = 0;
                }
                else if (numberIn10NS == 2)
                {
                    temp += 2;
                    numberIn10NS = 0;
                }
                else if (numberIn10NS == 1)
                {
                    temp += 1;
                    numberIn10NS = 0;
                }
                else if ((numberIn10NS % 3 == 0))
                {
                    temp += 0;
                    numberIn10NS = numberIn10NS / 3;
                }
                else if ( ((numberIn10NS-1) % 3 == 0))
                {
                    temp += 1;
                    numberIn10NS = numberIn10NS - 1;
                    numberIn10NS = numberIn10NS / 3;
                }
                else if ((numberIn10NS - 2) % 3 == 0)
                {
                    temp += 2;
                    numberIn10NS = numberIn10NS - 2;
                    numberIn10NS = numberIn10NS / 3;
                }
            }
            while (numberIn10NS != 0);
            string revTemp = reverseString(temp);
            return fillintUpTenDigits(revTemp);
        }
        /// <summary>
        /// makes arithemtical reversing
        /// </summary>
        /// <param name="temp">number in backward</param>
        /// <returns>number in forward</returns>
        private string reverseString(string temp)
        {
            string reversed = "";
            for (int i = temp.Length - 1; i > -1; i--)
            {
                reversed += temp[i];
            }
            return reversed;
        }
        /// <summary>
        /// in case the 3NS digit in not enough long it fill up the empty spaces
        /// </summary>
        /// <param name="revTemp">reversed number but not 10 pieces</param>
        /// <returns>completed, 10 piece 3NS digit</returns>
        private string fillintUpTenDigits(string revTemp)
        {
            string filledUp = "";
            if (revTemp.Length < 10)
            {
                for (int i = revTemp.Length; i < 10; i++)
                {
                    filledUp += '0';
                }
            }
            filledUp += revTemp;
            return filledUp;
        }
        #endregion

        #region dealing with convertion 3 to 10 number system
        /// <summary>
        /// makes the conversion 3NS->10NS
        /// </summary>
        /// <param name="numberIn3NS">the stirng in 3NS</param>
        /// <returns>result in 10NS</returns>
        private int convertingThreeToTen(string numberIn3NS)
        {
            double temp = 0;
            for (int i = 0, k = numberIn3NS.Length - 1; i < numberIn3NS.Length; i++, k--)
            {
                if (numberIn3NS[i] == '0')
                {
                    temp += 0 * Math.Pow(3, k);
                }
                else if (numberIn3NS[i] == '1')
                {
                    temp += 1 * Math.Pow(3, k);
                }
                else if (numberIn3NS[i] == '2')
                {
                    temp += 2 * Math.Pow(3, k);
                }
            }
            int temp2 = Convert.ToInt32(temp);
            return temp2;
        }
        #endregion

        #region testers
        /// <summary>
        /// tests the length of the 3NS digit
        /// </summary>
        /// <param name="numberThreeToTen"></param>
        private void overSizeSeek(string numberThreeToTen)
        {
            if (numberThreeToTen.Length > 10)
            {
                throw new ErrorUserRightLength("A program hibát vétett, a szükségesnál hosszabb 3SZR-beni értéket ad");
            }
            else if (numberThreeToTen.Length < 10)
            {
                throw new ErrorUserRightLength("A program hibát vétett, a szükségesnál rövidebb 3SZR-beni értéket ad");
            }
        }
        /// <summary>
        /// testin the content of the 3NS digit - range of the pieces
        /// </summary>
        /// <param name="numberThreeToTen">the 3NS digit</param>
        private void mistakeSeek(string numberThreeToTen)
        {
            if (numberThreeToTen.IndexOf('3') >= 0 || numberThreeToTen.IndexOf('4') >= 0 || numberThreeToTen.IndexOf('5') >= 0 ||
                numberThreeToTen.IndexOf('6') >= 0 || numberThreeToTen.IndexOf('7') >= 0 || numberThreeToTen.IndexOf('8') >= 0 ||
                numberThreeToTen.IndexOf('9') >= 0)
            {
                throw new ErrorUserRightFormat("A program hibát vétett, nem 3SZR-beni számértéket ad");
            }
        }
        #endregion
    }
}
