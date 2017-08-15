using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public enum For
    {
        Exist,
        Visible,
        Clickable,
        Invisibility,

        NotExist,
        NotVisible,
        NotClickable,

        TextToBePresent
    }
    public interface IComponent
    {
        bool IsExist();
        bool IsVisible();
        bool IsClickable();
        string GetText();
        void Waiting(For type);
        void Waiting(For type, TimeSpan timeout);
    }
}
