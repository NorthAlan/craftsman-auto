using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class CoachUserModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; } //Only for Compliance

        public string LastName { get; set; }

        public GenderType Gender { get; set; } //Male or Female

        public string Title { get; set; }

        public string EmailAddress { get; set; }

        public string Address1 { get; set; } //Only for Compliance

        public string Address2 { get; set; } //Only for Compliance

        public string City { get; set; } //Only for Compliance

        public string Country { get; set; } //Only for Compliance

        public string State { get; set; } //Only for Compliance

        public int Zip { get; set; } //Only for Compliance

        public string PhoneNumber { get; set; }

        public string PhoneNumberType { get; set; }//Only for Coach

        public string Status { get; set; }//Only for Compliance

        public bool AllowSignOn { get; set; }//Only for Compliance

        public string StaffDatabaseTab { get; set; }//Only for Compliance

        public string RequestNewCoachUsers { get; set; }//Only for Compliance

        public string PlaySeason { get; set; }//Only for Compliance

        public string CARAWeek { get; set; }//Only for Compliance

        public string Calendar { get; set; }//Only for Compliance

        public string TMP { get; set; }//Only for Compliance

        public string Comment { get; set; }

        public string Sports { get; set; }  //Only for Coach

        public string CoachCategory { get; set; }//Only for Compliance     
    }
}
