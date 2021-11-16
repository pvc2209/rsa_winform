using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_APP
{
    public class RSA
    {
        private static readonly int UNICODE_LENGTH = 65536;
        private static readonly int DIFF = 100;
        private static readonly int[] primeNumbers = {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59,
            61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127,
            131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191,
            193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257,
            263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331,
            337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401,
            409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467,
            479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563,
            569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631,
            641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709,
            719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797,
            809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877,
            881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967,
            971, 977, 983, 991, 997
        };

        public RSA()
        {
            //TaoKhoa();
        }

        // (E, N) của đối tác
        private int partnerE;
        private int partnerN;

        public void SetPartnerEN(int e, int n)
        {
            partnerE = e;
            partnerN = n;
        }

        public int GetPartnerE => partnerE;

        public int GetPartnerN => partnerN;

        // (E, N) là public key
        // D là private key
        public int MyE { get; set; }
        public int MyD { get; set; }
        public int MyN { get; set; }

        public void TaoKhoaNumber()
        {
            // Bước 1: B (người nhận) tạo hai số nguyên tố lớn ngẫu nhiên p và q
            int p = primeNumbers[Helper.GetRandom(0, primeNumbers.Length)];
            int q = primeNumbers[Helper.GetRandom(0, primeNumbers.Length)];

            while (Math.Abs(p - q) < DIFF)
            {
                q = primeNumbers[Helper.GetRandom(0, primeNumbers.Length)];
            }

            TimEDN(p, q);
        }

        public void TaoKhoaZ26()
        {
            // Chỉ có 2 số 2 và 3 nhân với nhau bằng 26
            // p = 2 và q = 13 <=> n = p * q = 26 là điều bắt buộc
            // vì nếu n < 26 thì sẽ có trường hợp bản rõ x lớn hơn n
            // => mã hóa không chính xác
            // còn nếu n > 26 thì bản mã có thể nằm ngoài phạm vi a-z
            int p = 2;
            int q = 13;


            // Với Z26 thì (e, n, d) chỉ có thể nhận các giá trị:
            // (e, n, d) = (1, 26, 1)   // bản mã trung với bản rõ
            // (e, n, d) = (5, 26, 5)
            // (e, n, d) = (7, 26, 7)
            // (e, n, d) = (11, 26, 11)

            TimEDN(p, q);
        }

        public void TaoKhoaUnicode()
        {
            // Với n = UNICODE_LENGTH = 65536
            // ta không thể tìm được bất cứ cặp p, q nào là số nguyên tố
            // thỏa mãn p * q = 143859 và p, q đều là số nguyên tố
            // => Theo suy luận thì để mã hóa tiếng việt có dấu
            // chỉ cần n = p * q < UNICODE_LENGTH là được rồi
            // vì nếu chỉ dùng lại TaoKhoaNumber(); thì p * q = n có thể
            // rất lớn dẫn đến char UTF-16 không thể chứa được

            int p = primeNumbers[Helper.GetRandom(4, primeNumbers.Length)];
            int q = primeNumbers[Helper.GetRandom(4, primeNumbers.Length)];

            // Khi tìm p, q ta lấy random từ index 4 chứ ko phải từ 0 để
            // loại trừ đi 4 số đầu 2, 3, 5, 7
            // vì nếu p bằng 1 trong 4 số này thì q lớn nhất có thể có là 997
            // => n = p * q = 7 * 997 = 6979 luôn luôn nhỏ hơn 7929 (7929 là 'ỹ' - chữ cái có số lớn nhất)
            // => mà điều kiện là bản rõ x < n (mà nếu x = 'ỹ' = 7929 rồi)
            // => n luôn luôn phải lớn hơn 7929

            // => Điều kiện 7929 < n = p * q <= UNICODE_LENGTH
            while (p * q > UNICODE_LENGTH || p * q <= 7929 || Math.Abs(p - q) < DIFF)
            {
                q = primeNumbers[Helper.GetRandom(0, primeNumbers.Length)];
            }

            TimEDN(p, q);
        }

        private void TimEDN(int p, int q)
        {
            // Bước 2: B tính n = p * q và phi(n) = (p-1)(q-1)
            MyN = p * q;

            int phi = (p - 1) * (q - 1);

            // Bước 3: B chọn một số ngẫu nhiên e(0 < e < phi(n)) sao cho UCLN(e, phi(n)) = 1
            do
            {
                // MyE = Helper.GetRandom(1, phi);
                // Không dùng từ 1 đến phi-1 như lý thuyết 
                // vì nếu e = 1 => d = 1 => bản mã giống hệt bản rõ
                // Cần hỏi lại cô xem có nên để từ 1 hay ko?

                MyE = Helper.GetRandom(1, phi);
            } while (Helper.UCLN(MyE, phi) != 1);

            // Bước 4: B tính d = e**-1 mod phi(n) bằng cách dùng thuật toán Euclid
            MyD = Helper.Euclid(MyE, phi);
        }

        // e và n là của người nhận chứ ko phải phải E, N của người gửi
        // người gửi sẽ dùng e, n của người nhận mã hóa bản tin x của người gửi
        public int EncodeNumber(int x)
        {
            return (int)Helper.BinhPhuongNhan(x, partnerE, partnerN);
        }

        public int DecodeNumber(int y)
        {
            return (int)Helper.BinhPhuongNhan(y, MyD, MyN);
        }

        public string EncodeZ26(string x)
        {
            string y = "";

            for (var i = 0; i < x.Length; ++i)
            {
                int temp = EncodeNumber(Helper.CharToIntZ26(x[i]));
                y += Helper.IntToCharZ26(temp);
            }

            return y;
        }

        public string DecodeZ26(string y)
        {
            string x = "";

            for (var i = 0; i < y.Length; ++i)
            {
                int temp = DecodeNumber(Helper.CharToIntZ26(y[i]));
                x += Helper.IntToCharZ26(temp);
            }
            return x;
        }

        public string EncodeUnicode(string x)
        {
            string y = "";

            for (var i = 0; i < x.Length; ++i)
            {
                int temp = EncodeNumber(Helper.CharToInt(x[i]));

                y += Helper.IntToChar(temp); // Nếu n = p * q quá lớn => temp cũng lớn vì (0 < temp < n)
                                             // => không thể convert 1 số quá lớn về char => tràn số
            }

            return y;
        }

        public string DecodeUnicode(string y)
        {
            string x = "";

            for (var i = 0; i < y.Length; ++i)
            {
                int temp = DecodeNumber(Helper.CharToInt(y[i]));

                x += Helper.IntToChar(temp);
            }
            return x;
        }

        public static bool KiemTraKhoa(int ke, int kn, int kd)
        {
            // Trường hợp check cho Z26 => kn = 26
            // Chỉ có 4 trường hợp
            // (e, n, d) = (1, 26, 1)
            // (e, n, d) = (5, 26, 5)
            // (e, n, d) = (7, 26, 7)
            // (e, n, d) = (11, 26, 11)
            if (kn == 26)
            {
                if (ke == 1 && kd == 1 || ke == 5 && kd == 5 || ke == 7 && kd == 7 || ke == 11 && kd == 11)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Cách đơn giản:
            // n = p * q
            // ta lặp trong mảng primeNumbers để tìm xem có p, q nào thỏa mãn hay ko?

            List<int> listD = new List<int>();

            for (int i = 0; i < primeNumbers.Length - 1; ++i)
            {
                for (int j = i + 1; j < primeNumbers.Length; ++j)
                {
                    int p = primeNumbers[i];
                    int q = primeNumbers[j];

                    //Console.WriteLine($"{p} * {q} = " + p * q);
                    if (p * q == kn)
                    {
                        int phi_n = (p - 1) * (q - 1);
                        if (Helper.UCLN(ke, phi_n) == 1)
                        {
                            int d = Helper.Euclid(ke, phi_n);
                            listD.Add(d);
                        }
                    }
                }
            }

            if (listD.Contains(kd))
            {
                return true;
            }

            return false;
        }
    }
}
