using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public enum AccessType
    {
        NoAccess,
        ViewOnly,
        Edit,
        EditAndLock,
        SetupSeason
    }
}
