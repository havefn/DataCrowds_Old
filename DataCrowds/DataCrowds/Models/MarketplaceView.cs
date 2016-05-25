using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class MarketplaceView
    {

    }

    public class ReceiptView
    {
        public DataSet boughtData { get; set; }
        public int balance { get; set; }
        public ApplicationUser User { get; set; }
    }
}