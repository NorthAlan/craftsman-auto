using Craftsman.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core
{
    public class TestContainer
    {
        public WebDriverManager CreateWebDriverManager()
        {
            return new WebDriverManager();
        }
    }
}
