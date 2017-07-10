using Craftsman.Core.Manager;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public abstract class CraftsmanTestBase
    {
        protected void Initialization()
        {
            InitializationRouteMapper();
            InitializationServiceInvoker();
            InitializationDataKeeper();
            InitializationTestContext();
        }

        public abstract void InitializationRouteMapper();
        public abstract void InitializationServiceInvoker();
        public abstract void InitializationDataKeeper();
        public abstract void InitializationTestContext();
    }
}
