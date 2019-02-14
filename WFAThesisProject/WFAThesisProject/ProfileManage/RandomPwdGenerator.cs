using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class RandomPwdGenerator
    {
        private char[] setOfCapitalAlphabets = {
            'A','B','C','D','E','F','G','H','I','J',
            'K','L','M','N','O','P','Q','R','S','T',
            'U','V','W','X','Y','Z' };
        private char[] setOfLowerAlphabets = {
            'a','b','c','d','e','f','g','h','i','j',
            'k','l','m','n','o','p','q','r','s','t',
            'u','v','w','x','y','z' };
        private char[] setOfDigits = { '0','1','2','3','4','5','6','7','8','9' };
        private char[] setOfSymbols = { '\\','!','%','?','-','@','&','#','*', '/'};
        private Random rnd;
        private int[] probability;
        string result;

        public RandomPwdGenerator()
        {
            rnd = new Random();
        }
        public string getRandomPwd()
        {
            result = "";
            probability = new int [] { 3, 3, 1, 1 };
            while (result.Length < 8)
            {
                int type = haveTypeRandom(result);
                if (type == 0)
                    result += haveCharRandom(true);
                else if (type == 1)
                    result += haveCharRandom(false);
                else if (type == 2)
                    result += haveNonCharRandom(true);
                else if (type == 3)
                    result += haveNonCharRandom(false);
            }
            return result;
        }

        private int haveTypeRandom(string content)
        {
            if (content.Length != 0)    //the last character analyze -> readjust probability
            {
                char c = content[content.Length - 1];
                if (char.IsUpper(c))
                    probability[0] -= 1;
                else if (char.IsLower(c))
                    probability[1] -= 1;
                else if (char.IsDigit(c))
                    probability[2] = 0;
                else if (char.IsPunctuation(c))
                    probability[3] = 0;
            }
            int digit;
            bool decide = true;
            do
            {   //diecide, the generated random is accapteble or not
                digit = rnd.Next(4);
                if (probability[0] != 0 && digit == 0)
                    decide = false;
                else if (probability[1] != 0 && digit == 1)
                    decide = false;
                else if (probability[2] != 0 && digit == 2)
                    decide = false;
                else if (probability[3] != 0 && digit == 3)
                    decide = false;
            } while (decide);
            return digit;
        }
        private char haveCharRandom(bool which)
        {
            int digit = rnd.Next(16);
            if (which)
                return setOfCapitalAlphabets[digit];
            else
                return setOfLowerAlphabets[digit];
        }
        private char haveNonCharRandom(bool which)
        {
            int digit = rnd.Next(10);
            if (which)
                return setOfDigits[digit];
            else
                return setOfSymbols[digit];
        }
    }
}
