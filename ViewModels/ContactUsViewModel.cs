using System.ComponentModel.DataAnnotations;

namespace JobSite.ViewModels
{
    public class ContactUsViewModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string message { get; set; }
    }
}
