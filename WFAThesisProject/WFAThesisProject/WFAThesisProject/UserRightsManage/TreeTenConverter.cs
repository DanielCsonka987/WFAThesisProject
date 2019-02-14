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
        /// <paramref name="ways"/>which source the data comes from</param>
        public TreeTenConverter(string data, bool ways)
        {
            if (ways)
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
        //convertin -> reversing -> filling it to 10 digit

        public string convetingTenToThree(int number)
        {
            string temp = "";
            do
            {
                if (number == 3)
                {
                    temp += 0;
                    number = 0;
                }
                else if (number == 2)
                {
                    temp += 2;
                    number = 0;
                }
                else if (number == 1)
                {
                    temp += 1;
                    number = 0;
                }
                else if ((number % 3 == 0))
                {
                    temp += 0;
                    number = number / 3;
                }
                else if ( ((number-1) % 3 == 0))
                {
                    temp += 1;
                    number = number - 1;
                    number = number / 3;
                }
                else if ((number - 2) % 3 == 0)
                {
                    temp += 2;
                    number = number - 2;
                    number = number / 3;
                }
            }
            while (number != 0);
            string revTemp = reverseString(temp);
            return fillintUpTenDigits(revTemp);
        }

        private string reverseString(string temp)
        {
            string reversed = "";
            for (int i = temp.Length - 1; i > -1; i--)
            {
                reversed += temp[i];
            }
            return reversed;
        }

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
        public int convertingThreeToTen(string number)
        {
            double temp = 0;
            for (int i = 0, k = number.Length - 1; i < number.Length; i++, k--)
            {
                if (number[i] == '0')
                {
                    temp += 0 * Math.Pow(3, k);
                }
                else if (number[i] == '1')
                {
                    temp += 1 * Math.Pow(3, k);
                }
                else if (number[i] == '2')
                {
                    temp += 2 * Math.Pow(3, k);
                }
            }
            int temp2 = Convert.ToInt32(temp);
            return temp2;
        }
        #endregion

        #region testers
        //the testing, not too long or short in digit was sent
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
        //the testing validiti of the digit
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
