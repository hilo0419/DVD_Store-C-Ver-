using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store
{
    public class ScreenOut
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("<Menu>");
            Console.WriteLine("1. 신규가입");
            Console.WriteLine("2. 전체조회");
            Console.WriteLine("3. 회원조회");
            Console.WriteLine("4. DVD등록");
            Console.WriteLine("5. DVD조회");
            Console.WriteLine("6. DVD대여");
            Console.WriteLine("7. DVD반납");
            Console.WriteLine("8. DVD대여 이력 조회");
            Console.WriteLine("9.종료");
        }
    }
}
