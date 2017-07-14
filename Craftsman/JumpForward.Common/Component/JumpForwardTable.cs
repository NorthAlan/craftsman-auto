using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsman.Core.Component
{

    public class JumpForwardTableCell : BaseComponent
    {
        public JumpForwardTableCell(IWebDriver driver, By by) : base(driver, by)
        {
        }

        public string Text {
            get
            {
                return this.OriginalElement.Text;
            }
        }
        public void Click()
        {
            this.Waiting(For.Clickable);
            this.OriginalElement.Click();
        }
    }
    public class JumpForwardTable : BaseComponent
    {
        public JumpForwardTable(IWebDriver driver, By by) : base(driver, by)
        {
            //header : .//*[@id='prospectGrid']/div[contains(@class,'k-grid-header')]//th
            //header row-index:$ .//*[@id='prospectGrid']/div[contains(@class,'k-grid-content')]//tr[{rowIndex}]/td[{colunm}]
            
        }
        public JumpForwardTableCell this[string columnName, int rowIndex]
        {
            get
            {
                var colunmIndex = 0;
                var headerCells = this.OriginalElement.FindElements(By.XPath("./div[contains(@class,'k-grid-header')]//th"));
                for (var i = 0; i < headerCells.Count; i++)
                {
                    if (columnName.Equals(headerCells[i].Text))
                    {
                        colunmIndex = i + 1;
                        break;
                    }
                }
                if (colunmIndex == 0)
                {
                    throw new Exception($"[JumpForwardTable]: can't find the colunm named '[{columnName}]'");
                }
                return this[colunmIndex, rowIndex];
            }
        }

        public JumpForwardTableCell this[int colunmIndex, int rowIndex]
        {
            get
            {
                return new JumpForwardTableCell(this._driver, By.XPath($".//div[contains(@class,'k-grid-content')]//tr[{rowIndex}]/td[{colunmIndex}]"));
            }
        }

        public int ColunmCount
        {
            get
            {
                var headerCells = this.OriginalElement.FindElements(By.XPath("./div[contains(@class,'k-grid-header')]//th"));
                return headerCells.Count;
            }
        }
        public int RowCount
        {
            get
            {

                var rows = this.OriginalElement.FindElements(By.XPath("./div[contains(@class,'k-grid-content')]//tr"));
                return rows.Count;
            }
        }

        public JumpForwardTableCell FindCellByText(string text)
        {
            for (var iRow = 1; iRow <= this.RowCount; iRow++)
            {
                for (var iCol = 1; iCol <= this.ColunmCount; iCol++)
                {
                    var cell = this[iCol, iRow];
                    if (cell.Text.Equals(text))
                    {
                        return cell;
                    }
                }
            }
            return null;
        }
    }
}

