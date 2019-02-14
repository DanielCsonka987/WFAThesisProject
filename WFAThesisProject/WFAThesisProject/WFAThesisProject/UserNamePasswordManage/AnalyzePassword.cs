using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WFAThesisProject.UserNamePasswordManage
{
    public class AnalyzePassword
    {
        private string password;
        private bool digitThere = false;
        private bool lowerCareThere = false;
        private bool upperCaseThere = false;
        private bool specCharThere = false;
        /// <summary>
        /// the part of Login or UserPersonalManage - given/changed passw enough difficult
        /// </summary>
        /// <param name="passw">the new password</param>
        public AnalyzePassword(string passw)
        {
            this.password = passw;
            if (password == "")
                throw new ErrorLogPassContent("", "Nem adott meg jelszót, kérem írja be!");
            passLength();
            passContent();
            passDecission();
        }

        private void passLength()
        {
            if (password.Length < 8)
            {
                throw new ErrorLogPassContent(password, "A jelszó túl rövid, hogy megfelelő legyen");
            }
        }

        private void passContent()
        {
            char[] parts = password.ToCharArray();
            foreach (char c in parts)
            {
                if (char.IsDigit(c))
                    digitThere = true;
                if (char.IsLower(c))
                    lowerCareThere = true;
                if (char.IsUpper(c))
                    upperCaseThere = true;
                if (char.IsPunctuation(c) || char.IsWhiteSpace(c) || char.IsSymbol(c))
                    specCharThere = true;
            }
        }
        //punctuations !"#%&'()*,-./:;?@[\]_{}
        //symbols $+<>=§|~
        private void passDecission()
        {
            if (!digitThere)
                throw new ErrorLogPassContent(password, "A jelszóban nincs számkarakter");
            if(!lowerCareThere)
                throw new ErrorLogPassContent(password, "A jelszóban nincs kisbetűs karatker");
            if (!upperCaseThere)
                throw new ErrorLogPassContent(password, "A jelszóban nincs nagybetűs karakter");
            if (!specCharThere)
                throw new ErrorLogPassContent(password, "A jelszóban nincs speciális karakter");
        }
    }
}
