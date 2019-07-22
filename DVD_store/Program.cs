using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store
{
    class Program
    {
        static void Main(string[] args)
        {
            //업무 분석
            //DVD 관리 시스템
            // 회원 관리, DVD 관리 Rental 정보 관리

            //프로그램 시작.
            DVDManager dvdManger = new DVDManager();

            dvdManger.Access();


        }
    }
}

