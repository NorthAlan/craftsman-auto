using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Manager
{
    public interface IDriverManager
    {
        /// <summary>
        /// get web driver entity.
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Navigate page function
        /// </summary>
        /// <param name="url"></param>
        void NavigateTo(string url);

        /*
         * 单例Driver
         * 多个Driver
         */
    }
}
