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

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string Title { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberType { get; set; }

        public string Comment { get; set; }
    }
}
