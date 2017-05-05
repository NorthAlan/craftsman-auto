using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;

namespace GitHub.TestCase
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var driver = new FirefoxDriver();
        }
    }
}
