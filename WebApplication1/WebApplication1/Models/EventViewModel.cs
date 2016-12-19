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
        public logboek log { get; set; }
        public Cloudinary cloudinary { get; set; }
        public Event ev { get; set; }
        public List<WebApplication1.Models.Event> events { get; set; }
        public List<WebApplication1.Models.Tag> tags { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public EventViewModel() {
            ev = new Event();
            events = new List<WebApplication1.Models.Event>();
            tags = new List<WebApplication1.Models.Tag>();
            ImageUpload = null;
            cloudinary = new CloudinaryAccount().Cloud;
             }
    }

    public class EventCreateViewModel 
    {

        public Cloudinary cloudinary { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public Event ev { get; set; }
        public Tag tag { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "ID")]
        public int EventID { get; set; }

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

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "MMM ddd d yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Begin date")]
        public DateTime EventBeginDate { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End date")]
        //[GreaterThanOrEqualTo("EventBeginDate", ErrorMessage="Incorrect end date")]
        public DateTime EventEndDate { get; set; }

        [Required]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Begin time")]
        public Nullable<System.DateTime> EventBeginTime { get; set; }

        [Required]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End time")]
        public Nullable<System.DateTime> EventEndTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string EventLocation { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(105, ErrorMessage = "max description-length = 105 characters")]
        [Display(Name = "Tags")]
        public string TagName { get; set; }


        public EventCreateViewModel()
        {
            ImageUpload = null;
            cloudinary = new CloudinaryAccount().Cloud;
            ev = new Event();
            tag = new Tag();

        }

     

    }
}