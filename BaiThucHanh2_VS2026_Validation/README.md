# Bài thực hành 2 + 3 — ASP.NET Core MVC (Visual Studio 2026)

## Chạy project
1. Giải nén ZIP vào một thư mục mới.
2. Mở `BaiThucHanh2.csproj` bằng Visual Studio 2026.
3. Project nhắm đến `.NET 10` (`net10.0`), cần cài .NET 10 SDK.
4. Chọn **Build > Rebuild Solution**, sau đó nhấn **Ctrl + F5**.
5. Mở `/Student/Index` để xem danh sách; dùng **Create Student** để thêm sinh viên.

## Chức năng
- Giao diện Management System với menu trái, thanh điều hướng và bảng sinh viên.
- Xem, tìm kiếm, thêm, sửa và xóa sinh viên.
- Partial Views, Layout, RenderBody, RenderSection và ViewComponent.
- Validation bằng Data Annotations, thông báo lỗi tiếng Việt ở form Create và Edit.

## Quy tắc Validation
- Họ tên bắt buộc, từ 4 đến 100 ký tự.
- Email bắt buộc, đúng định dạng và phải kết thúc bằng `@gmail.com`.
- Mật khẩu bắt buộc, ít nhất 8 ký tự.
- Bắt buộc chọn ngành, giới tính và nhập địa chỉ.
- Ngày sinh từ 01/01/1963 đến 31/12/2005.
- Điểm bắt buộc, từ 0.0 đến 10.0.

## Lưu ý
- Dữ liệu mẫu lưu trong bộ nhớ nên sẽ trở về dữ liệu ban đầu khi khởi động lại ứng dụng.
- Validation phía trình duyệt dùng jQuery Validation qua CDN; nếu ngoại tuyến, validation phía server vẫn hoạt động.
- Mật khẩu chỉ là dữ liệu minh họa cho bài thực hành; không lưu mật khẩu dạng rõ trong ứng dụng thực tế.
