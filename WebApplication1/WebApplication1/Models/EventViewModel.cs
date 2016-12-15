﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CloudinaryDotNet;

namespace WebApplication1.Models
{
    public static class StringExtensions
    {
        public static string SubStringTo(this string thatString, int limit)
        {
            if (!String.IsNullOrEmpty(thatString))
            {
                if (thatString.Length > limit)
                {
                    return thatString.Substring(0, limit);
                }
                return thatString;
            }
            return string.Empty;
        }
    }

    public class EventViewModel
    {
        public Cloudinary cloudinary { get; set; }
        public Event ev { get; set; }
        public List<WebApplication1.Models.Event> events { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public EventViewModel() {
            ev = new Event();
            ImageUpload = null;
            cloudinary = new CloudinaryAccount().Cloud;
            events = new List<WebApplication1.Models.Event>(); }
    }

    public class EventCreateViewModel {

        public Cloudinary cloudinary { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public Event ev { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "ID")]
        public string EventID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(20)]
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

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "MMM ddd d yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Begin date")]
        public DateTime EventBeginDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End date")]
        public DateTime EventEndDate { get; set; }

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
            cloudinary = new CloudinaryAccount().Cloud;
            ev = new Event();
        }

    }
}