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
    
    public partial class Salary
    {
        public int SalaryID { get; set; }
        public string EmpID { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> NoOfDays { get; set; }
        public Nullable<double> OTRate { get; set; }
        public Nullable<int> OThours { get; set; }
        public Nullable<double> Bouns { get; set; }
        public Nullable<double> Deduction { get; set; }
        public Nullable<int> ETF { get; set; }
        public double Allowance { get; set; }
        public Nullable<float> Netsal { get; set; }
        public string Status { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}