using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.ViewModels
{
    public class PurchaseViewModel
    {
        public double OrderNo { get; set; }
        public Account Account { get; set; }
    }
}
