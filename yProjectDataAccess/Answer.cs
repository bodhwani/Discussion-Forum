//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace yProjectDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public int aid { get; set; }
        public string abody { get; set; }
        public Nullable<System.DateTime> adate { get; set; }
        public Nullable<int> alikes { get; set; }
        public int uid { get; set; }
        public int qid { get; set; }
        public int Question_qid { get; set; }
        public Nullable<int> aapprove { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
