//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestMVVM
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderLines
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<short> OrderLineNo { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
