using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class CampModel
    {
        #region base information
        /// <summary>
        /// get or set 'Camp Name'
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// get or set 'Camp Location'
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// get or set 'Maps Location'
        /// </summary>
        public string MapsLocation { get; set; }
        /// <summary>
        /// get or set 'Time Zone'
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// get or set 'Camp Start Date Time'
        /// </summary>
        public DateTime CampStart { get; set; }
        /// <summary>
        /// get or set 'Camp Start End Time'
        /// </summary>
        public DateTime CampEnd { get; set; }
        /// <summary>
        /// get or set 'Registration Start Date Time'
        /// </summary>
        public DateTime RegistrationStart { get; set; }
        /// <summary>
        /// get or set 'Registration End Date Time'
        /// </summary>
        public DateTime RegistrationEnd { get; set; }
        /// <summary>
        /// get or set 'Confirmation Email Text'
        /// </summary>
        public string ConfirmationEmailText { get; set; }
        #endregion base information

        /// <summary>
        /// 
        /// </summary>
        public IList<CampItemModel> CampItems { get; set; }

        public IList<PurchaseModel> Purchases { get; set; }

        public IList<DefaultCamperQuestionModel> DefaultQuestions { get; set; }

        public IList<CustomQuestionModel> CustomQuestions { get; set; }

        public string CampWaiver { get; set; }
        public string RefundPolicy { get; set; }
        public IList<CustomWaiver> CustomWaivers { get; set; }
        public string AgreementText { get; set; }
        public string CampDescription { get; set; }
        //public IList<object> CampFiles { get; set; }
    }
}
