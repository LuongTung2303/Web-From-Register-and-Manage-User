# WebFormRegister

## Mô tả dự án

Đây là ứng dụng ASP.NET Core MVC cho phép người dùng đăng ký thông tin cá nhân (họ tên, ngày sinh, số điện thoại, email), hiển thị danh sách người dùng đã đăng ký, hỗ trợ sửa và xóa thông tin.

## Yêu cầu hệ thống

- .NET 8 SDK (hoặc phiên bản phù hợp với project)
- SQL Server (Express hoặc Developer)
- Visual Studio hoặc Visual Studio Code

## Hướng dẫn cài đặt và chạy dự án

### 1. Clone dự án về máy

```sh
git clone https://github.com/<tên-user>/<tên-repo>.git
cd WebFormRegister
```

### 2. Cài đặt các package cần thiết

```sh
dotnet restore
```

### 3. Cấu hình chuỗi kết nối database

- Mở file `appsettings.json`
- Sửa lại chuỗi kết nối cho phù hợp với SQL Server trên máy bạn:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=WebFormRegisterDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
  ```

### 4. Tạo database và bảng bằng Entity Framework Core

```sh
dotnet ef database update
```
- Trong trường hợp bạn nhận được thông báo chưa có migration thì bạn có thể chạy lệnh sau đây:
```sh
dotnet ef migrations add InitialCreate
```

### 5. Chạy ứng dụng

```sh
dotnet run
```
- Truy cập [http://localhost:5000](http://localhost:5000) (hoặc cổng mà ứng dụng báo) trên trình duyệt.

## Chức năng chính

- Đăng ký người dùng mới
- Hiển thị danh sách người dùng đã đăng ký
- Sửa thông tin người dùng
- Xóa người dùng

## Thư mục quan trọng

- `Controllers/` - Chứa các controller xử lý logic
- `Models/` - Chứa các model dữ liệu
- `Views/` - Chứa các file giao diện Razor (.cshtml)
- `Data/` - Chứa ApplicationDbContext kết nối database

## Liên hệ

- Tác giả: Lương Thanh Tùng
- Email: tung.luongthanh2004@hcmut.du.vn

---

> *Nếu có vấn đề khi setup hoặc chạy dự án, vui lòng liên hệ hoặc tạo issue trên GitHub repo này.*