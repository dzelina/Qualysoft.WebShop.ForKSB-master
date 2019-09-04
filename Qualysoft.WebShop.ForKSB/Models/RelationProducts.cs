using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Models
{
    public class RelationProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Visitor { get; set; }

    }
}
