using System.ComponentModel.DataAnnotations;

namespace JobSite.ViewModels
{
    public class ConfirmPersonViewModel
    {

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
