//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticeProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetAccountant
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RegistrationNo { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual AspNetEmployee AspNetEmployee { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}