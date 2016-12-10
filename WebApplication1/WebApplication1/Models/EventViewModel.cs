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

    public class EventCreateViewModel
    {

        Account account = new Account(
           "zomomo",
           "161964652558563",
           "nCU9Op7zsyop4KYoZ44hSMaBM08");
        public Cloudinary cloudinary { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public EventCreateViewModel()
        {
            ImageUpload = null;
            cloudinary = new Cloudinary(account);
        }

    [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Discription")]
        public string EventDiscription { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string EventImage { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public int EventPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string EventLocation { get; set; }
    }
}