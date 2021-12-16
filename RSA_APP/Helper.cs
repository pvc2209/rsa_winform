using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_APP
{
    public class Helper
    {
        // Phải tạo 1 biến static random trong Helper class thay vì sử dụng trực tiếp Random random = new Random();
        // trong hàm tạo khóa RSA vì khi ta tạo nhiều biến random nhưng cùng 1 lúc
        // thì các biến random nó có cùng tick (do thời gian tạo 2 đối tượng Random() quá gần nhau)
        // => kết quả random.Next sẽ là như nhau 
        // Khắc phục bằng cách chỉ dùng 1 đối tượng Random duy nhất trong Helper class
        private static Random random = new Random();

        // Lấy ngẫu nhiên 1 số từ [a, b - 1]
        public static int GetRandom(int a, int b)
        {
            return random.Next(a, b);
        }

        public static int Euclid(int a, int n)
        {
            if (a > n)
            {
                (a, n) = (n, a);
            }

            int x1 = n;
            int x2 = a;
            int b1 = 0;
            int b2 = 1;

            while (x2 != 1)
            {
                int y = x1 / x2;
                int temp_x2 = x2;
                x2 = x1 % x2;
                x1 = temp_x2;

                int temp_b2 = b2;
                b2 = b1 - (b2 * y);
                b1 = temp_b2;
            }

            if (b2 < 0)
            {
                return b2 + n;
            }

            return b2;
        }

        // Trong giáo trình trang 98 gọi thuật toán này là thuật toán "bình phương và nhân"
        public static BigInteger BinhPhuongNhan(BigInteger a, BigInteger x, BigInteger n)
        {
            // a**x % n
            BigInteger d = 1;
            while (x != 0)
            {
                if (x % 2 != 0)
                {
                    d = d * a % n;
                }

                x /= 2;
                a = a * a % n;
            }

            return d;
        }

        public static bool IsPrimeNumber(int n)
        {
            if (n < 2) return false;

            for (var i = 2; i < Math.Sqrt(n); ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            return a;
        }

        public static char IntToCharZ26(int num)
        {
            return (char)(num + 97);
        }

        public static int CharToIntZ26(char c)
        {
            return (int)c - 97;
        }

        public static char IntToChar(int num)
        {
            return (char)num;
        }

        public static int CharToInt(char c)
        {
            return (int)c;
        }

        public static bool[] SangNguyenTo(int n)
        {
            // 1 List để biết số nào là số nguyên tố từ 2 đến n
            // Mặc định tất cả các số đều là số nguyên tố
            bool[] check = Enumerable.Repeat<bool>(true, n + 1).ToArray();

            // số 0 và 1 ko phải là số nguyên tố
            check[0] = false;
            check[1] = false;

            // Thuật toán sàng nguyên tố
            for (int i = 2; i <= n; ++i)
            {
                if (check[i] == true)
                {
                    for (int j = 2 * i; j <= n; j += i)
                    {
                        check[j] = false;
                    }
                }
            }


            return check;
        }
    }
}
