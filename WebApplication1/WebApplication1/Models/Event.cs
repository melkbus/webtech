//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public string EventPicture { get; set; }
        public Nullable<int> EventPrice { get; set; }
        public System.DateTime EventBeginDate { get; set; }
        public System.DateTime EventEndDate { get; set; }
        public Nullable<int> EventParticipants { get; set; }
    }
}
