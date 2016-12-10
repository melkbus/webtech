using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EventViewModel
    {
        public Event ev { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        public EventViewModel() { ev = new Event(); ImageUpload = null; }
    }

    public class EventCreateViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "EventName")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "EventDiscription")]
        public string EventDiscription { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "EventImage")]
        public string EventImage { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "EventPrice")]
        public string EventPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "EventDate")]
        public string EventDate { get; set; }

        [Required]
        [Display(Name = "EventLocation")]
        public string EventLocation { get; set; }
    }
}