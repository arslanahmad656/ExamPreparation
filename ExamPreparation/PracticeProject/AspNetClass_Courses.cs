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
    
    public partial class AspNetClass_Courses
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsActive { get; set; }
    
        public virtual AspNetClass AspNetClass { get; set; }
        public virtual AspNetCours AspNetCours { get; set; }
    }
}