using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CloudinaryDotNet;

namespace WebApplication1.Models
{
    
    public class EventViewModel
    {
        Account account = new Account(
            "zomomo",
            "161964652558563",
            "nCU9Op7zsyop4KYoZ44hSMaBM08");
        public Event ev { get; set; }
        public List<WebApplication1.Models.Event> events { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public Cloudinary cloudinary { get; set; }
        public EventViewModel() {
            ev = new Event();
            ImageUpload = null;
            cloudinary = new Cloudinary(account);
            events = new List<WebApplication1.Models.Event>(); }
    }
}