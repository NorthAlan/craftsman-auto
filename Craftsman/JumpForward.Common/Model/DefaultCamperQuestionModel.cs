using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class DefaultCamperQuestionModel
    {
        public bool ReadOnly { get; set; }
        public bool Visibled { get; set; }
        public bool Required { get; set; }
        public string QuestionName { get; set; }

        public DefaultCamperQuestionModel()
        {
            this.ReadOnly = false;
        }
    }
}
