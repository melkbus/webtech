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

    public class EventCreateViewModel {

        Account account = new Account(
           "zomomo",
           "161964652558563",
           "nCU9Op7zsyop4KYoZ44hSMaBM08");
        public Cloudinary cloudinary { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public Event ev { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(300, ErrorMessage = "max description-length = 300 characters")]
        [Display(Name = "Description")]
        public string EventDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string EventImage { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public int EventPrice { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Begin date")]
        public Nullable<System.DateTime> EventBeginDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End date")]
        public Nullable<System.DateTime> EventEndDate { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Begin time")]
        public Nullable<System.DateTime> EventBeginTime { get; set; }

        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End time")]
        public Nullable<System.DateTime> EventEndTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string EventLocation { get; set; }


        public EventCreateViewModel()
        {
            ImageUpload = null;
            cloudinary = new Cloudinary(account);
            ev = new Event();
        }

    }
}