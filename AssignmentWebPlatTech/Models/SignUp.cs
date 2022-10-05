using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssignmentWebPlatTech.Models
{
    public class SignUp
    {
        public int SignUpID { get; set; }

        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Full Name is required"), MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Enter Address...")]
        [DisplayName("Address")]
        public string Address { get; set; }

        
        [DisplayName("City Name")]
        [Required(ErrorMessage = "Select City...")]
        public int CityID { get; set; }

        public string City { get; set; }

        
        [DisplayName("State Name")]
        [Required(ErrorMessage = "Select State...")]
        public int StateID { get; set; }
        
        public string State { get; set; }

        [Display(Name = "Pincode")]
        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression(@"^[1-9][0-9]{5}$", ErrorMessage = "Enter Correct Pincode")]
        public int PinCode { get; set; }

        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please Enter Correct Mobile No.")]
        public string MobileNo { get; set; }

        [Display(Name = "PAN Card Number")]
        [RegularExpression(@"[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "PAN card number is not valid")]
        [Required(ErrorMessage = "PAN Card Number is required")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Upload PAN Image...")]
        [DisplayName("PAN Image")]
        public string PanImage { get; set; }

        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email ID is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Display(Name = "Aadhar Card Number")]
        [RegularExpression(@"^[2-9]{1}[0-9]{3}[0-9]{4}[0-9]{4}$", ErrorMessage = "Aadhar Card number is not valid")]
        [Required(ErrorMessage = "Aadhar Card Number is required")]
        public string AadharNumber { get; set; }

        
        [Required(ErrorMessage = "Upload Aadhar front Image...")]
        [DisplayName("Aadhar Front Image")]
        public string AadharfrontImage { get; set; }

        [Required(ErrorMessage = "Aadhar Back Image...")]
        [DisplayName("Aadhar Back Image")]
        public string AadharBackImage { get; set; }
       

        [Required(ErrorMessage = "Select Gender...")]
        [DisplayName("Gender")]
        public string Gender { get; set; }


    }
}