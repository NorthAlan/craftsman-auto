using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class ProspectModel
    {
        [JsonProperty(PropertyName = "_id")]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ProjectedYear { get; set; }

        public int CommStatus { get; set; }

        public int Rating { get; set; }

        public int RecruitingCoach { get; set; }

        public int RecruitedPosition { get; set; }

        public bool Selected { get; set; }
    }
}
