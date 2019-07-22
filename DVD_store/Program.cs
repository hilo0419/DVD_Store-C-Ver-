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


            //프로그래 시작.
            DVDManager dvdManger = new DVDManager();

            //메뉴가 오픈

            //메뉴 선택
            while (true)
            {
                ScreenOut.Menu();
                Console.Write("선택>>");
                int select = int.Parse(Console.ReadLine());


                //1. 신규회원
                if (select == 1)
                {
                    dvdManger.AddCustomer();
                }
                //2. 회원 조회
                else if (select == 2)
                {
                    dvdManger.PrintAllCustomer();
                }
                //3. 전체 회원 정보 출력.
                else if (select == 3)
                {
                    dvdManger.PrintCustomer();
                }
                //4. DVD 등록
                else if (select == 4)
                {
                    dvdManger.AddDVD();
                }
                //5. DVD 조회
                else if (select == 5)
                {
                    dvdManger.PrintDVD();
                }
                //6. DVD 대여
                else if (select == 6)
                {
                    dvdManger.RentDVD();
                }
                //7. DVD 반납
                else if (select == 7)
                {
                    dvdManger.ReturnDVD();
                }
                else if (select == 8)
                {
                    dvdManger.SearchDVDRent();
                }
                else
                    break;
                
            }



        }
    }
}

