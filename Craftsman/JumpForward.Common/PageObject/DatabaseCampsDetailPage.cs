using Craftsman.Core;
using Craftsman.Core.Component;
using JumpForward.Common.Component;
using JumpForward.Common.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.PageObject
{
    public class DatabaseCampsDetailPage : CoachPageBase
    {
        /*
         *  ==> PageObject
         *      ==== Method
         *      @. Action method : return IPageObject
         *      @. Data acquisition / Check method : return data object
         *      ==== Property
         *      @. internal component :  
         *      @. public component : IComponent Use for Checker
         */
        #region Internal component

        #region Base information
        protected TextInput txtCampName;
        protected TextInput txtCampLocation;
        protected TextInput txtMapLocation;
        protected JumpForwardSelect ddlTimeZone;
        protected TextInput txtCampStartDate;
        protected TextInput txtCampEndDate;
        protected TextInput txtRegistrationStartDate;
        protected TextInput txtRegistrationEndDate;
        protected TextInput txtConfirmationEmailText;
        #endregion Base information

        #region Registration items
        protected Button btnAddCampItem;
        protected TextArea txaAddCampPopupTitle;
        protected TextInput txtCampItemPrice;
        protected TextInput txtCampItemDescription;
        protected TextInput txtCampItemQuantity;
        protected CheckBox ckbCampItemUnlimited;
        protected Button btnCampItemDone;
        private Button btnAddExtrasItem;
        private TextArea txaAddExtrasPopupTitle;
        private TextInput txtCampExtraPrice;
        private TextInput txtCampExtraDescription;
        private TextInput txtCampExtraQuantity;
        private CheckBox ckbCampExtraUnlimited;
        private TextInput txtCampExtraExpiration;
        private Button btnCampExtraDone;
        #endregion Registration items

        protected JumpForwardCamperQuestion jfCamperQuestionSelector;

        #region Custom Question
        protected Button btnAddCustomQuestion;
        protected Button btnAddCustomQuestionAnother;
        protected Button btnAddCustomQuestionDone;
        protected CheckBox ckbCustomQuestionTextBox;
        protected CheckBox ckbCustomQuestionDropDown;
        protected TextInput txtCustomQuestionText;
        protected TextInput txtCustomQuestionOptions;
        #endregion Custom Question

        #region Waiver
        protected TextInput txtCampWaiver;
        protected TextInput txtCampRefundPolicy;
        protected Button btnAddWaiver;
        protected TextArea txaAddWaiverPopupTitle;
        protected TextInput txtWaiverHeader;
        protected TextInput txtWaiverText;
        protected Button btnAddWaiverAnother;
        protected Button btnAddWaiverDone;
        #endregion Waiver

        #region Agreement & Description 
        protected TextInput txtCampTermsText;
        protected RichTextBox txtCampDescription;
        #endregion Agreement & Description 

        protected Button btnSave;

        #endregion Internal component

        public DatabaseCampsDetailPage(IWebDriver driver) : base(driver)
        {
            //Init element.
            #region Base information
            txtCampName = new TextInput(driver, By.Id("CampName"));
            txtCampLocation = new TextInput(driver, By.Id("CampLocation"));
            txtMapLocation = new TextInput(driver, By.Id("MapLocation"));
            ddlTimeZone = new JumpForwardSelect(driver, By.XPath(".//span[contains(@class,'ddlTimeZones') and @aria-owns='TimeZoneId_listbox']"));
            txtCampStartDate = new TextInput(driver, By.Id("CampStartDate"));
            txtCampEndDate = new TextInput(driver, By.Id("CampEndDate"));
            txtRegistrationStartDate = new TextInput(driver, By.Id("RegistrationStartDate"));
            txtRegistrationEndDate = new TextInput(driver, By.Id("RegistrationEndDate"));
            txtConfirmationEmailText = new TextInput(driver, By.Id("ConfirmationEmailText"));
            #endregion Base information 

            #region Registration items
            btnAddCampItem = new Button(driver, By.Id("btnAddCampItem"));
            txaAddCampPopupTitle = new TextArea(driver, By.XPath(".//*[@id='camp-items-container']/h3"));
            txtCampItemPrice = new TextInput(driver, By.Id("camp-item-price"));
            txtCampItemDescription = new TextInput(driver, By.Id("camp-item-description"));
            txtCampItemQuantity = new TextInput(driver, By.Id("camp-item-quantity"));
            ckbCampItemUnlimited = new CheckBox(driver, By.Id("camp-item-unlimited"));
            btnCampItemDone = new Button(driver, By.Id("itemDone"));
            #endregion Registration items

            #region Extras items
            btnAddExtrasItem = new Button(driver, By.Id("btnAddCampExtra"));
            txaAddExtrasPopupTitle = new TextArea(driver, By.XPath(".//*[@id='camp-extras-container']/h3"));
            txtCampExtraPrice = new TextInput(driver, By.Id("camp-extra-price"));
            txtCampExtraDescription = new TextInput(driver, By.Id("camp-extra-description"));
            txtCampExtraQuantity = new TextInput(driver, By.Id("camp-extra-quantity"));
            ckbCampExtraUnlimited = new CheckBox(driver, By.Id("camp-extra-unlimited"));
            txtCampExtraExpiration = new TextInput(driver, By.Id("camp-extra-expiration"));
            btnCampExtraDone = new Button(driver, By.Id("extraDone"));
            #endregion Extras items

            jfCamperQuestionSelector = new JumpForwardCamperQuestion(driver, By.XPath(".//*[@id='camper-default-questions']/div/div[contains(@class,'question-item')]"));
            
            #region Custom Question
            btnAddCustomQuestion = new Button(driver, By.XPath(".//*[@id='addcampbottom']//button[text()='Add Question']"));
            ckbCustomQuestionTextBox = new CheckBox(driver, By.XPath(".//*[@id='camp-questions-container']//label[starts-with(text(),'Question Type')]/following-sibling::label[text()='Text Box']"));
            ckbCustomQuestionDropDown = new CheckBox(driver, By.XPath(".//*[@id='camp-questions-container']//label[starts-with(text(),'Question Type')]/following-sibling::label[text()='Drop Down']"));
            txtCustomQuestionText = new TextInput(driver, By.Id("questionText"));
            txtCustomQuestionOptions = new TextInput(driver, By.Id("questionOptions"));
            btnAddCustomQuestionAnother = new Button(driver, By.Id("questionAnother"));
            btnAddCustomQuestionDone = new Button(driver, By.Id("questionDone"));
            #endregion Custom Question

            #region Waiver
            txtCampWaiver = new TextInput(driver, By.Id("CampWaiver"));
            txtCampRefundPolicy = new TextInput(driver, By.Id("CampRefundPolicy"));
            btnAddWaiver = new Button(driver, By.Id("btnAddWaiver"));
            txaAddWaiverPopupTitle = new TextArea(driver, By.XPath(".//*[@id='camp-waiver-container']/h3"));
            txtWaiverHeader = new TextInput(driver, By.Id("waiver-header"));
            txtWaiverText = new TextInput(driver, By.Id("waiver-text"));

            btnAddWaiverAnother = new Button(driver, By.Id("waiverAnother"));
            btnAddWaiverDone = new Button(driver, By.Id("waiverDone"));

            #endregion Waiver

            #region Agreement & Description 
            txtCampTermsText = new TextInput(driver, By.Id("CampTermsText"));
            txtCampDescription = new RichTextBox(driver, By.Id("cke_CampDescription"));
            #endregion Agreement & Description 

            btnSave = new Button(driver, By.XPath(".//button[contains(.,'Save')]"));
            
        }

        #region Action method 
        public DatabaseCampsDetailPage SetCampBaseInformation(CampModel camp)
        {
            // set base information
            txtCampName.SendKeys(camp.Name);
            txtCampLocation.SendKeys(camp.Location);
            txtMapLocation.SendKeys(camp.MapsLocation);
            ddlTimeZone.Select(camp.TimeZone);
            txtCampStartDate.SendKeys(camp.CampStart.ToString());
            txtCampEndDate.SendKeys(camp.CampEnd.ToString());
            txtRegistrationStartDate.SendKeys(camp.RegistrationStart.ToString());
            txtRegistrationEndDate.SendKeys(camp.RegistrationEnd.ToString());
            txtConfirmationEmailText.SendKeys(camp.ConfirmationEmailText);
            return this;
        }
        public DatabaseCampsDetailPage SetCampRegistrationItems(IList<CampItemModel> items)
        {
            foreach (var item in items)
            {
                SetCampRegistrationItem(item);
            }
            return this;
        }
        public DatabaseCampsDetailPage SetCampRegistrationItem(CampItemModel item)
        {
            btnAddCampItem.Click();
            txaAddCampPopupTitle.Waiting(For.Exist);

            txtCampItemPrice.SendKeys(item.Price.ToString());
            txtCampItemDescription.SendKeys(item.Description);
            ckbCampItemUnlimited.SetState(item.Unlimited);
            if (!item.Unlimited)
            {
                txtCampItemQuantity.SendKeys(item.MaxQty.ToString());
            }
            btnCampItemDone.Click();

            //TODO: add discount code.

            //TODO: set exp Date

            return this;
        }

        public DatabaseCampsDetailPage SetCampExtraItems(IList<PurchaseModel> purchases)
        {
            if (purchases == null)
            {
                throw new Exception("[Page]: purchases can't be null!");
            }

            foreach (var purchase in purchases)
            {
                SetCampExtraItem(purchase);
            }
            
            return this;
        }
        public DatabaseCampsDetailPage SetCampExtraItem(PurchaseModel purchase)
        {
            btnAddExtrasItem.Click();
            txaAddExtrasPopupTitle.Waiting(For.Exist);

            txtCampExtraPrice.SendKeys(purchase.Price.ToString());
            txtCampExtraDescription.SendKeys(purchase.Description);
            ckbCampExtraUnlimited.SetState(purchase.Unlimited);
            if (!purchase.Unlimited)
            {
                txtCampExtraQuantity.SendKeys(purchase.MaxQty.ToString());
            }

            if (purchase.ExpirationDate != null)
            {
                txtCampExtraExpiration.SendKeys(purchase.ExpirationDate.ToString());
            }
            btnCampExtraDone.Click();

            return this;
        }


        public DatabaseCampsDetailPage SetDefaultQuestions(CampModel camp)
        {
            return SetDefaultQuestions(camp.DefaultQuestions);
        }
        public DatabaseCampsDetailPage SetDefaultQuestions(IList<DefaultCamperQuestionModel> questions)
        {
            foreach(var question in questions)
            {
                SetDefaultQuestion(question);
            }
            return this;
        }
        public DatabaseCampsDetailPage SetDefaultQuestion(DefaultCamperQuestionModel question)
        {
            jfCamperQuestionSelector.SetItem(question);
            return this;
        }

        
        public DatabaseCampsDetailPage SetCustomQuestions(IList<CustomQuestionModel> models)
        {
            btnAddCustomQuestion.Click();

            for (var i = 0; i < models.Count; i++)
            {
                switch (models[i].Type)
                {
                    case CustomQuestionType.TextBox:
                        ckbCustomQuestionTextBox.Click();
                        break;
                    case CustomQuestionType.DropDown:
                        ckbCustomQuestionDropDown.Click();
                        txtCustomQuestionOptions.SendKeys(models[i].DropDownOptions);
                        break;
                    default: break;
                }
                txtCustomQuestionText.SendKeys(models[i].Text);

                if (i < models.Count - 1)
                { btnAddCustomQuestionAnother.Click(); }
                else
                {
                    btnAddCustomQuestionDone.Click();
                }

            }
            return this;
        }
        public DatabaseCampsDetailPage SetCustomQuestions(CampModel camp)
        {
            return SetCustomQuestions(camp.CustomQuestions);
        }
        public DatabaseCampsDetailPage SetCustomQuestion(CustomQuestionModel model)
        {
            return SetCustomQuestions(new List<CustomQuestionModel> { model });
        }

        public DatabaseCampsDetailPage SetCustomQuestion()
        {
            return this;
        }

        public DatabaseCampsDetailPage SetWaiverInformation(CampModel camp)
        {
            return SetWaiverInformation(camp.CampWaiver, camp.RefundPolicy, camp.CustomWaivers);
        }

        public DatabaseCampsDetailPage SetWaiverInformation(string campWaiver,string refundPolicy, IList<CustomWaiver> customWaivers)
        {
            if (!string.IsNullOrEmpty(campWaiver)) { txtCampWaiver.SendKeys(campWaiver); }
            if (!string.IsNullOrEmpty(refundPolicy)) { txtCampRefundPolicy.SendKeys(refundPolicy); }

            for(var i= 0; i< customWaivers.Count;i++)
            {
                btnAddWaiver.Click();
                txaAddWaiverPopupTitle.Waiting(For.Exist);
                txtWaiverHeader.SendKeys(customWaivers[i].Header);
                txtWaiverText.SendKeys(customWaivers[i].Text);
                if (i != customWaivers.Count - 1)
                {
                    btnAddWaiverAnother.Click();
                }
                else
                {
                    btnAddWaiverDone.Click();
                }
            }
            return this;
        }
        public DatabaseCampsDetailPage SetAgreementAndDescription(string agreement, string description)
        {
            //cke_CampDescription
            txtCampTermsText.SendKeys(agreement);
            txtCampDescription.SendKeys(description);
            return this;
        }

        public DatabaseCampsPage ClickSaveButton()
        {
            btnSave.Click();
            return new DatabaseCampsPage(this.Driver);
        }

        public DatabaseCampsDetailPage ClickSaveButtonError()
        {
            btnSave.Click();
            return this;
        }
        #endregion Action method 
    }
}
