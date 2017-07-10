using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForward.Common.Model
{
    public class CampItemModel
    {
        public decimal Price { get; set; }

        public object Fee { get; set; }

        public string Description { get; set; }

        public int MaxQty { get; set; }

        public bool Unlimited { get; set; }

        public int RemainingQty { get; set; }

        public IList<object> Discounts { get; set; }

        public DateTime ExpirationDate { get; set; }

        public object WalkUpReg { get; set; }
    }
}
