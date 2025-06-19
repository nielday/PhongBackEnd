using System.ComponentModel.DataAnnotations;

namespace LAB3.Models
{
    public class User
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [Display(Name = "Mã sinh viên")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Tài khoản từ 2 - 20 ký tự")]
        [Display(Name = "Tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6 - 10 ký tự")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [EmailAddress(ErrorMessage = "Sai định dạng email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
