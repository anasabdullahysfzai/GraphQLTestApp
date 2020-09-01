using GraphQLTestApp.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Order
{
    public class OrderDTO
    {
        public int OId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime ODate { get; set; }

        public string OType { get; set; }

        public IList<ProductDTO> products { get; set; }
    }
}
