using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApp.Models.Supplier
{
    public class SupplierDTO
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        public string SPhone { get; set; }
        public string SIban { get; set; }
    }
}
