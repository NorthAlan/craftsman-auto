using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class ProspectModel
    {
        #region Prospect Details
        /// <summary>
        /// get or set 'Prospect FirstName'
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// get or set 'Prospect LastName'
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// get or set 'Prospect GradYear'
        /// </summary>
        public string GradYear { get; set; }
        ///<summary>
        ///get or set 'Prospect RecruitedPosition'
        ///</summary>
        public string RecruitedPosition { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string Jersey { get; set; }

        public string Rating { get; set; }

        public string Tag { get; set; }

        public string TagM{get; set;}

        #endregion Prospect Details

    }
}
