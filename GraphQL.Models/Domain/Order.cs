using System;
using System.Collections.Generic;

namespace GraphQL.Models
{
    /// <summary>
    /// Order data model
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate{ get; set; }
        public string CustomerName { get; set; }
        public double TotalAmount { get; set; }
    }
}
