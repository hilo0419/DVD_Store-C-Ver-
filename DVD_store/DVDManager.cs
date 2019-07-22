using DVD_store.Class;
using DVD_store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store
{
    public class DVDManager
    {
         CustomerData customerdata = new CustomerData();
         DVDData dvddata = new DVDData();
         RentalData rentaldata = new RentalData();

        public void Access()
        {
            while(true)
            {
                ScreenOut.Menu();
                int select=0;

                try
                {
                    Console.Write("선택>>");
                   select = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요.");
                    Console.ReadLine();
                    continue;
                }

                //int select;

                //Console.Write("선택>>");
                //if (int.TryParse(Console.ReadLine(), out select) == false)
                //{
                //    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요.");
                //    Console.ReadLine();
                //    continue;
                //}

                //1. 신규회원
                if (select == 1)
                {
                    customerdata.AddCustomer();
                }
                //2. 회원 조회
                else if (select == 2)
                {
                    customerdata.PrintAllCustomer();
                }
                //3. 전체 회원 정보 출력.
                else if (select == 3)
                {
                    customerdata.PrintCustomer();
                }
                //4. DVD 등록
                else if (select == 4)
                {
                    dvddata.AddDVD();
                }
                //5. DVD 조회
                else if (select == 5)
                {
                    dvddata.PrintDVD();
                }
                //6. DVD 대여
                else if (select == 6)
                {
                    rentaldata.RentDVD();
                }
                //7. DVD 반납
                else if (select == 7)
                {
                    rentaldata.ReturnDVD();
                }
                else if (select == 8)
                {
                    rentaldata.SearchDVDRent();
                }
                else
                    break;

            }
        }


    }
}
