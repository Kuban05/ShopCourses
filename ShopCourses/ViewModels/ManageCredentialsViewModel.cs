using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopCourses.ViewModels
{
    public class ManageCredentialsViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public ShopCourses.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public DataUser DataUser { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Obecne hasło")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="{0} musi miec conajmniej {2} znaków",MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [Compare("NewPassword",ErrorMessage ="Nowe hasło i potwierdzenie hasła nie pasują")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdzenie nowego hasła")]
        public string ConfirmPassword { get; set; }
    }
}