using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CacHamCoBan
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /*
            var personA = new RSA();

            // ===========Z26===========
            personA.TaoKhoaZ26();
            Console.WriteLine("e (A) = " + personA.MyE);
            Console.WriteLine("n (A) = " + personA.MyN);
            Console.WriteLine("d (A) = " + personA.MyD);

            var personB = new RSA();
            personB.setEN(personA.MyE, personA.MyN);

            //// B mã hóa bản rõ x = 99 "của B" với khóa (e, n) của A
            //int thongDiepTuBGuiToiA = personB.EncodeNumber(99);
            //Console.WriteLine(thongDiepTuBGuiToiA);

            //// A giải mã bản mã y = ... do B gửi tới
            //Console.WriteLine(personA.DecodeNumber(thongDiepTuBGuiToiA));

            Console.WriteLine(personB.EncodeNumber(99));
            Console.WriteLine("-------------------------------------");
            
            string y = personB.EncodeZ26("phamcuong");
            Console.WriteLine("y = " + y);

            Console.WriteLine("x = " + personA.DecodeZ26(y));
            */

            // ===========Unicode===========
            var personA = new RSA();

            personA.TaoKhoaUnicode();
            Console.WriteLine("e (A) = " + personA.MyE);
            Console.WriteLine("n (A) = " + personA.MyN);
            Console.WriteLine("d (A) = " + personA.MyD);

            var personB = new RSA();
            personB.setEN(personA.MyE, personA.MyN);

            Console.WriteLine("-------------------------------------");

            string y = personB.EncodeUnicode("phạm cường");
            Console.WriteLine("y = " + y);

            Console.WriteLine("x = " + personA.DecodeUnicode(y));

            // Đúng là UNICODE_LENGTH = 65536 vì nếu thử convert 65536 ToChar
            // sẽ bị lỗi System.OverflowException: Value was either too large or too small for a character.
            // còn giảm lại 1 giá trị là 65535 là convert được luôn
            // Console.WriteLine(Convert.ToChar(65536));

            //Console.WriteLine((int)'ỹ');
        }

        private void TimKyTuLonNhat()
        {
            char[] kyTu = new char[] {
                'á', 'à', 'ả', 'ã', 'ạ',
                'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ',
                'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ',
                'đ',
                'é', 'è', 'ẻ', 'ẽ', 'ẹ',
                'ế', 'ề', 'ể', 'ễ', 'ệ',
                'í', 'ì', 'ỉ', 'ĩ', 'ị',
                'ó', 'ò', 'ỏ', 'õ', 'ọ',
                'ố', 'ồ', 'ổ', 'ỗ', 'ộ',
                'ớ', 'ờ', 'ở', 'ỡ', 'ợ',
                'ú', 'ù', 'ủ', 'ũ', 'ụ',
                'ứ', 'ừ', 'ử', 'ữ', 'ự',
                'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ',
            };

            int max = 0;
            for (var i = 0; i < kyTu.Length; i++)
            {
                int value = (int)kyTu[i];

                if (value > max)
                {
                    max = value;
                }
            }

            Console.WriteLine("Max = " + max); // 7929
            //Console.WriteLine(Convert.ToChar(7929)); // ỹ
        }
    }
}
