using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDAccount.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }

        public int CustomerID { get; set; }

        [DisplayName("Họ và tên")]
        [MaxLength(125, ErrorMessage = "Họ và tên không quá 125 ký tự.")]
        public string Name { get; set; }

        [DisplayName("Số điện thoại")]
        [MaxLength(15, ErrorMessage = "Số điện thoại không quá 15 ký tự.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Địa chỉ")]
        [MaxLength(1000, ErrorMessage = "Địa chỉ không quá 1000 ký tự.")]
        public string Address { get; set; }

    }
}
