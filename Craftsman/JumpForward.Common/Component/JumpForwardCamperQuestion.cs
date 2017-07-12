using Craftsman.Core;
using Craftsman.Core.Component;
using Craftsman.Core.Utilities;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Component
{

    public class JumpForwardCamperQuestion : BaseComponent
    {
        protected string name;
        protected string rootPath;
        public JumpForwardCamperQuestion(IWebDriver driver, By by) : this(driver, by, string.Empty) { }
        public JumpForwardCamperQuestion(IWebDriver driver, By by, string name) : base(driver, by)
        {
            this.name = name;
            this.rootPath = ".//div[contains(@class,'div-question-label')]/label[text()='{0}']/ancestor::div[contains(@class,'question-item')]";
        }


        public bool IsExist(string name)
        {
            return WaitSelector.WaitingFor_ElementExists(_driver, By.XPath(string.Format(rootPath, name)));
        }

        public void SetItem(DefaultCamperQuestionModel model)
        {
            if (!IsExist(model.QuestionName))
            {
                throw new Exception($"[Component]: JumpForwardCamperQuestion - '{model.QuestionName}' not exist!");
            }

            var eleRoot = _driver.FindElement(By.XPath(string.Format(rootPath, model.QuestionName)));
            var eleLabel = eleRoot.FindElement(By.XPath(".//div[contains(@class,'div-question-label')]/label"));

            var btnVisible = eleRoot.FindElement(By.XPath(".//div[contains(@class,'div-question-show')]"));
            var btnRequired = eleRoot.FindElement(By.XPath(".//div[contains(@class,'div-question-required')]"));
            var chkVisible = eleRoot.FindElement(By.XPath(".//div[contains(@class,'div-question-show')]/input[@type='checkbox']"));
            var chkRequired = eleRoot.FindElement(By.XPath(".//div[contains(@class,'div-question-required')]/input[@type='checkbox']"));

            if (eleRoot.GetAttribute("class").Contains("static"))
            {
                throw new Exception("[Component]: JumpForwardCamperQuestions - can't set static element!");
            }

            var isVisible = chkVisible.GetAttribute("checked") == "true";
            if (model.Visibled != isVisible) { btnVisible.Click(); }

            var isRequired = chkRequired.GetAttribute("checked") == "true";
            if (model.Required != isRequired) { btnRequired.Click(); }
        }
    }
}
