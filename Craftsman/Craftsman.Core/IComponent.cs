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

        NotExist,
        NotVisible,
        NotClickable
    }
    public interface IComponent
    {
        bool IsExist();
        bool IsVisible();
        bool IsClickable();
        void Waiting(For type);
        void Waiting(For type, TimeSpan timeout);
    }
}
