//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sarasi_HMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class evPay
    {
        public string paymentID { get; set; }
        public string eventID { get; set; }
        public Nullable<double> advance { get; set; }
        public Nullable<double> remainning { get; set; }
        public Nullable<double> paid { get; set; }
        public Nullable<double> change { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
        public Nullable<double> total { get; set; }
    }
}