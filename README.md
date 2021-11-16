# Tính năng
App cho phép mã hóa và giải mã RSA giữa 2 người A và người B trong các tập:
- Số
- Z26 (a-z)
- Unicode

# Cách sử dụng
- Người dùng chọn tập dữ liệu (Số, Z26, Unicode)
- Ở phía người A, bấm tạo khóa thì sẽ tạo khóa công khai (E, N) và khóa bí mật (D), khóa công khai sẽ được gửi cho người B
- Người A có thể tự nhập khóa bằng tay
- Button Kiểm tra khóa A sẽ kiểm tra xem khóa vừa tạo có hợp lệ hay không
- Ở phía người B sẽ điền bản rõ và bấm mã hóa. B sẽ dùng khóa công khai mà A vừa gửi để mã hóa
- Người B tiến hành bấm gửi bản mã vừa có cho A
- Người A sẽ nhận bản mã của B vừa gửi tới và dùng khóa bí mật để giải mã bản mã này và hiển thị ở trên bản rõ
- Chúng ta có thể tiến hành thao tác ngược lại. 