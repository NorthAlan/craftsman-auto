using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class ClubModel
    {
        public ClubModel()
        {
            this.Address = new AddressModel();
            this.HeadCoach = new ClubHeadCoach();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string TeamName { get; set; }

        public AddressModel Address { get; set; }

        public long SportId { get; set; }

        public string Sport { get; set; }

        public string ClubWebsite { get; set; }

        public string MainPhoneNumber { get; set; }

        public string SeasonRecord { get; set; }

        public string RecentGameResults { get; set; }

        public ClubHeadCoach HeadCoach { get; set; }

    }

    public class ClubHeadCoach
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string OfficePhone { get; set; }

        public string Email { get; set; }
    }


}
