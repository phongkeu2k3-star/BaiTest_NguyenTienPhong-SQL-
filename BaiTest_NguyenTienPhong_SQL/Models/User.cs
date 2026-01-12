using System.ComponentModel.DataAnnotations;

namespace BaiTest_NguyenTienPhong_SQL.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên quá dài")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(@"^0\d{9,10}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng số 0 và có 10-11 số")]
        public string PhoneNumber { get; set; }

        public string? Address
        {
            get; set;
        }
    }
}
