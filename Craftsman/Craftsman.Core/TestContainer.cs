﻿using Craftsman.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public class TestContainer
    {
        public static ModelBuilder ModelBuilder { get; set; }
        public static ServiceInvoker ServiceInvoker { get; set; }
        public static DataKeeper DataKeeper { get; set; }
    }
}
