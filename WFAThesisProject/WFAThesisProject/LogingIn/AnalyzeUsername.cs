using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class AnalyzeUsername
    {
        private string userName;
        private int testNum;
        public AnalyzeUsername(string username)
        {
            this.userName = username;
            analyzeUsername();
        }

        private void analyzeUsername()
        {
            if (userName.Length < 8)
                throw new ErrorLogUsernameFormat(userName, "Ez túl rövid, hogy felhasználónév legyen");
            if (userName.IndexOf(' ') > 0)
                throw new ErrorLogUsernameFormat(userName, "A felhasználónév szóközt tartalmaz");
            if ((!int.TryParse(userName.Substring(userName.Length - 1), out testNum)) &&
                (!int.TryParse(userName.Substring(userName.Length), out testNum)))
                throw new ErrorLogUsernameFormat(userName, "A felhasználónév végén nincs meg a két számkarater");
        }
    }
}
