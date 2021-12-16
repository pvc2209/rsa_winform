using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_APP
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



        public static Tuple<int, int, int> ThamMaPro(int e, int n)
        {
            int start = (int)Math.Sqrt(n);

            // Tính trước các số nguyên tố từ 2 đến n
            bool[] check = Helper.SangNguyenTo(n);

            for (int p = start; p >= 2; p--)
            {
                if (check[p] == true)
                {
                    int q = n / p;

                    if (p * q == n && check[q] == true)
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

            return new Tuple<int, int, int>(-1, -1, -1);
        }

        public static int DecodeNumber(int y, int d, int n)
        {
            return (int)Helper.BinhPhuongNhan(y, d, n);
        }

        public static string DecodeZ26(string y, int d, int n)
        {
            string x = "";

            for (var i = 0; i < y.Length; ++i)
            {
                int temp = DecodeNumber(Helper.CharToIntZ26(y[i]), d, n);
                x += Helper.IntToCharZ26(temp);
            }
            return x;
        }

        public static string DecodeUnicode(string y, int d, int n)
        {
            string x = "";

            for (var i = 0; i < y.Length; ++i)
            {
                int temp = DecodeNumber(Helper.CharToInt(y[i]), d, n);

                x += Helper.IntToChar(temp);
            }
            return x;
        }
    }
}
