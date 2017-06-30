using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public enum ComponentWaitType
    {
        IsExist,
        IsVisible,
        IsClickable,

    }
    public interface IComponent
    {
        bool IsExist();
        bool IsVisible();
        bool IsClickable();
        bool WaitingFor(ComponentWaitType type, TimeSpan timeout);
    }
}
