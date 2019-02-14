using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class SetOfUserDetails
    {
        public string userAccountGroup { get; set; } //the group of user = rights id
        public string userId { get; set; }           //the userID of user = DB defined integer
        public string userLastName { get; set; }     //the lastname of user
        public string userFirstName { get; set; }    //the firstname of user
        public string userTaj { get; set; }          //the taj-number of user
        public string userArea { get; set; }         //the workarea of user
        public string userPosition { get; set; }     //the position of user = position in hierarchy

        public SetOfUserDetails()
        {

        }
        /// <summary>
        /// for testing especially
        /// </summary>
        public void completlynessSeek()
        {
            if (userAccountGroup == null || userId == null || userLastName == null ||
                userFirstName == null || userTaj == null || userPosition == null || userArea == null)
                throw new ErrorUserRightCompletlyness("Felhasználói adatok nem teljes");
        }
    }
}
