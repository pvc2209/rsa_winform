using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacHamCoBan
{
    public class Hacker
    {
        public static Tuple<int, int, int> ThamMa(int e, int n)
        {
            int start = (int)Math.Sqrt(n);

            for (int p = start; p >= 2; p--)
            {
                if (Helper.IsPrimeNumber(p))
                {
                    int q = n / p;

                    if (p * q == n && Helper.IsPrimeNumber(q))
                    {
                        int phi_n = (p - 1) * (q - 1);

                        if (Helper.UCLN(e, phi_n) == 1)
                        {
                            int d = Helper.Euclid(e, phi_n);

                            return new Tuple<int, int, int>(d, p, q);
                        }
                    }
                }
            }

            return new Tuple<int, int, int>(-1, -1, -1); ;
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
