using DVD_store.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store.Data
{
    class DVDData
    {
        List<Customer> customers = new List<Customer>();
        List<DVD> dvds = new List<DVD>();
        List<Rental> rentals = new List<Rental>();

        public void AddDVD()
        {
            Console.Clear();

            DVD dvd = new DVD();

            string dvdid = null;
            string title = null;
            string genre = null;

            while (true)
            {
                Console.Write("DVD 번호 : ");
                dvdid = Console.ReadLine();
                //중복 체크
                if (dvd.IsRegistDVDnum(dvds, dvdid))
                {
                    Console.WriteLine("중복된 DVD 번호 입니다");
                    Console.WriteLine("다시 입력해주세요.");
                    continue;
                }
                else
                    break;
            }

            Console.Write("제목 : ");
            title = Console.ReadLine();
            Console.Write("장르(1.액션/2.코미디/3.공포/4.로맨스) : ");
            genre = Console.ReadLine();

            dvd.DVDnum = dvdid;
            dvd.Title = title;

            if (genre == "1")
            {
                dvd.Genre = "액션";
            }
            else if (genre == "2")
            {
                dvd.Genre = "코미디";
            }
            else if (genre == "3")
            {
                dvd.Genre = "공포";
            }
            else if (genre == "4")
            {
                dvd.Genre = "로맨스";
            }


            dvd.rentalStatus = true;

            dvds.Add(dvd);

            Console.WriteLine("->DVD등록이 완료 되었습니다.");
        }

        public void PrintDVD()
        {
            Console.Clear();

            foreach (var dvd in dvds)
            {
                Console.WriteLine(dvd);
            }
            Console.ReadLine();
        }

        public void RentDVD()
        {
            Console.Clear();

            Console.Write("아이디 : ");
            string id = Console.ReadLine();
            Customer customer = new Customer();

            var cquery = from x in customers
                         where x.CusID.Equals(id)
                         select x;

            customer = cquery.FirstOrDefault();

            if (customer == null)
            {
                Console.WriteLine("가입되지 않은 ID입니다. 다시 입력해주세요");
                Console.ReadLine();
                return;
            }

            DVD dvd = new DVD();
            Console.Write("DVD 번호 : ");
            string num = Console.ReadLine();

            var dquery = from x in dvds
                         where x.DVDnum.Equals(num)
                         select x;

            dvd = dquery.FirstOrDefault();

            if (dvd == null)
            {
                Console.WriteLine("등록되지 않은 DVD입니다.");
                Console.ReadLine();
                return;
            }

            if (dvd.rentalStatus == false)
            {
                Console.WriteLine("대여 중인 DVD입니다.");
                Console.ReadLine();
                return;
            }

            dvd.rentalStatus = false;
            Rental rental = new Rental();
            rental.CusId = customer.CusID;
            rental.DVDnum = dvd.DVDnum;
            rental.Title = dvd.Title;
            Console.Write("대여날짜(ex 20190719) : ");
            string rentData = Console.ReadLine();
            rental.RentDate = DateTime.ParseExact(rentData, "yyyyMMdd", null);

            rentals.Add(rental);
            Console.WriteLine("->DVD대여가 완료 되었습니다.");
            Console.ReadLine();

        }
    }
}
