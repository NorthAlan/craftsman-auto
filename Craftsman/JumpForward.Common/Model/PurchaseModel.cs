using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class PurchaseModel
    {
        public decimal Price { get; set; }

        public object Fee { get; set; }

        public string Description { get; set; }

        public bool Unlimited { get; set; }

        public int MaxQty { get; set; }

        public int InitialQty { get; set; }

        public DateTime ExpirationDate { get; set; }
        
    }
}
