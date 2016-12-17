using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplication1.Models
{
    // Models returned by AccountController actions.
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hometown")]
        public string Hometown { get; set; }

        public Cloudinary cloudinary { get; set; }

        
        

        public string UserId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "First Name must be maximum 20 characters")]
        public string firstname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Last Name must be maximum 20 characters")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "birthday:")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "MMM ddd d yyyy", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> birthday { get; set; }


        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "max description-length = 500 characters")]
        [Display(Name = "Describe yourself")]
        public string description { get; set; }


        [Display(Name = "Profile Picture (optional)")]
        public HttpPostedFileBase ImageUpload { get; set; }

        //[Required]
        //[Display(Name = "Hometown")]
        //public string Hometown { get; set; }

        public ExternalLoginConfirmationViewModel()
        {
            ImageUpload = null;
            cloudinary = new CloudinaryAccount().Cloud;
        }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {


        public List<WebApplication1.Models.Event> events { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        public Cloudinary cloudinary { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserId { get; set; }

        [Display(Name ="First Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "First Name must be maximum 20 characters")]
        public string firstname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Last Name")]
        [StringLength(20, ErrorMessage = "Last Name must be maximum 20 characters")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "birthday:")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "MMM ddd d yyyy", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> birthday { get; set; }


        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "max description-length = 500 characters")]
        [Display(Name = "Describe yourself")]
        public string description { get; set; }


        [Display(Name = "Profile Picture (optional)")]
        public HttpPostedFileBase ImageUpload { get; set; }
    
        //[Required]
        //[Display(Name = "Hometown")]
        //public string Hometown { get; set; }

        public RegisterViewModel()
        {
            ImageUpload = null;
            cloudinary = new CloudinaryAccount().Cloud;
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }


    public class ChangesToProfile
    {
        public Cloudinary cloudinary { get; set; }

        public string UserId { get; set; }


        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "First Name must be maximum 20 characters")]
        public string firstname { get; set; }


       
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Last Name must be maximum 20 characters")]
        public string lastname { get; set; }

       
        [Display(Name = "birthday:")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "MMM ddd d yyyy", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> birthday { get; set; }


        
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "max description-length = 500 characters")]
        [Display(Name = "Describe yourself")]
        public string description { get; set; }


        [Display(Name = "Profile Picture")]
        public HttpPostedFileBase ImageUpload { get; set; }

        
        //[Display(Name = "Hometown")]
        //public string Hometown { get; set; }
        
        public ChangesToProfile()
        {
            ImageUpload = null;
            cloudinary = new CloudinaryAccount().Cloud;
        }



    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
