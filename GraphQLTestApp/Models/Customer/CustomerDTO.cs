using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Customer
{
    public class CustomerDTO
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }

        public string CPhone { get; set; }
    }
}
