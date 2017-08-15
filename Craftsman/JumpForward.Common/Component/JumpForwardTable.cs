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
        protected string _rootXPath;

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public JumpForwardTableCell(IWebDriver driver, By by, int rowIndex, int columnIndex) : base(driver, by)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
            this._rootXPath = $".//div[contains(@class,'k-grid-content')]//tr[{rowIndex}]/td[{columnIndex}]";
        }

        public JumpForwardTableCell(IWebDriver driver, int rowIndex, int columnIndex)
            : base(driver, By.XPath($".//div[contains(@class,'k-grid-content')]//tr[{rowIndex}]/td[{columnIndex}]"))
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
            this._rootXPath = $".//div[contains(@class,'k-grid-content')]//tr[{rowIndex}]/td[{columnIndex}]";
        }

        public string Text
        {
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

        public T GetComponent<T>(string subXPath) where T : BaseComponent
        {
            var by = By.XPath($"{_rootXPath}//{subXPath}");

            Type type = typeof(T);
            var component = (T) Activator.CreateInstance(type, this._driver, by);
            if (!component.IsExist())
            {
                throw new Exception($"[JumpForwardTableCell]: Can't find component for [{by.ToString()}]");
            }
            return component;
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
                var columnIndex = 0;
                var headerCells = this.OriginalElement.FindElements(By.XPath("./div[contains(@class,'k-grid-header')]//th"));
                for (var i = 0; i < headerCells.Count; i++)
                {
                    if (columnName.Equals(headerCells[i].Text))
                    {
                        columnIndex = i + 1;
                        break;
                    }
                }
                if (columnIndex == 0)
                {
                    throw new Exception($"[JumpForwardTable]: can't find the colunm named '[{columnName}]'");
                }
                return this[columnIndex, rowIndex];
            }
        }

        public JumpForwardTableCell this[int columnIndex, int rowIndex]
        {
            get
            {
                var by = By.XPath($".//div[contains(@class,'k-grid-content')]//tr[{rowIndex}]/td[{columnIndex}]");
                var cell = new JumpForwardTableCell(this._driver, by, rowIndex, columnIndex);
                return cell;
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

        public List<JumpForwardTableCell> FindAllCellsByText(string text)
        {
            this.Waiting(For.Visible);
            var cells = new List<JumpForwardTableCell>();
            for (var iRow = 1; iRow <= this.RowCount; iRow++)
            {
                for (var iCol = 1; iCol <= this.ColunmCount; iCol++)
                {
                    var cell = this[iCol, iRow];
                    if (cell.Text.Equals(text))
                    {
                        cells.Add(cell);
                    }
                }
            }
            return cells;
        }
    }
}

