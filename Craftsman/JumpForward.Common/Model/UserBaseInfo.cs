using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class UserBaseInfo
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; } //Only for Compliance

        public string LastName { get; set; }

        public GenderType Gender { get; set; } //Male or Female

        public string EmailAddress { get; set; }

        public string Title { get; set; }
    }
}
