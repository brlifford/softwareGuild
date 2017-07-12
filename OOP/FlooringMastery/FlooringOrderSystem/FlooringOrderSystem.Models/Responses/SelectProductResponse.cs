using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderSystem.Models.Responses
{
    public class SelectProductResponse : Response
    {
        public Product Product { get; set; }
    }
}
