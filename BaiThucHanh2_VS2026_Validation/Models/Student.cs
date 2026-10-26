using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh2.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có từ 4 đến 100 ký tự.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email bắt buộc phải được nhập.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com.")]
    public string Email { get; set; } = string.Empty;

    // Chỉ dùng cho bài thực hành. Ứng dụng thực tế không nên lưu mật khẩu dạng rõ.
    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn ngành học.")]
    public string Branch { get; set; } = "CE";

    [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
    public string Gender { get; set; } = "Male";

    [Display(Name = "Hệ đào tạo")]
    public bool IsRegular { get; set; } = true;

    [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
    [DataType(DataType.MultilineText)]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn ngày sinh.")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1963-01-01", "2005-12-31", ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005.")]
    public DateTime DateOfBirth { get; set; } = new DateTime(2000, 1, 1);

    [Required(ErrorMessage = "Vui lòng nhập điểm.")]
    [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0.")]
    public float? Score { get; set; }
}
