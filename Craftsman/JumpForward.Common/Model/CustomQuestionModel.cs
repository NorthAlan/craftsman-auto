using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public enum CustomQuestionType
    {
        TextBox,
        DropDown
    }
    public class CustomQuestionModel
    {
        
        public string Text { get; set; }

        public CustomQuestionType Type { get; set; }

        public string DropDownOptions { get; set; }
    }
}
