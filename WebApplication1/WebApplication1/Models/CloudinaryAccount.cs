﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudinaryDotNet;


namespace WebApplication1.Models
{
    public class CloudinaryAccount : Cloudinary
    {
        static Account account = new Account(
            "zomomo",
            "161964652558563",
            "nCU9Op7zsyop4KYoZ44hSMaBM08");
        public Cloudinary Cloud = new Cloudinary(account); 
       
       public CloudinaryAccount() { }
    }
}