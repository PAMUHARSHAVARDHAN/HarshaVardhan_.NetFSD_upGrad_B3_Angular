using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required (ErrorMessage = "ContactId is required")]
        public int ContactId { get; set; }
        [Required (ErrorMessage ="Firstname is required")]
        [StringLength(15, MinimumLength =5)]
        public string FirstName {  get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(15, MinimumLength = 5)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Companyname is required")]
        [StringLength(15, MinimumLength = 5)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Mail is required")]
        [StringLength(20, MinimumLength = 5)]
        public string EmailId { get; set; }
        [Required (ErrorMessage ="please enter mobile number")]
        [Range(100000000,9999999999,ErrorMessage ="please enter 10 digit number")]
        public long MobileNo { get; set; }
        [Required(ErrorMessage = "designation is required")]
        [StringLength(15, MinimumLength = 5)]
        public string Designation { get; set; }

    }
}
