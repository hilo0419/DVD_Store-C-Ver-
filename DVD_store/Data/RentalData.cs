using DVD_store.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store.Data
{
    class RentalData
    {
        List<Customer> customers = new List<Customer>();
        List<DVD> dvds = new List<DVD>();
        List<Rental> rentals = new List<Rental>();
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

        public void ReturnDVD()
        {
            Console.Clear();
            Console.Write("반납할 DVD 번호 : ");
            string num = Console.ReadLine();
            DVD dvd = new DVD();

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

            if (dvd.rentalStatus == true)
            {
                Console.WriteLine("대여 되지 않은 DVD입니다.");
                Console.ReadLine();
                return;
            }
            dvd.rentalStatus = true;
            Console.WriteLine("->DVD반납이 완료 되었습니다.");
            Console.ReadLine();
        }

        public void SearchDVDRent()
        {
            Console.Clear();
            Console.Write("DVD번호 : ");
            string num = Console.ReadLine();
            DVD dvd = new DVD();

            dvd = dvds.Select(x => x).FirstOrDefault(x => x.DVDnum.Equals(num));

            if (dvd == null)
            {
                Console.WriteLine("등록되지 않은 DVD입니다.");
                Console.ReadLine();
                return;
            }

            List<Rental> temp = new List<Rental>();

            temp = rentals.Select(x => x).Where(x => x.DVDnum.Equals(num)).ToList();

            foreach (var rental in temp)
            {
                Console.WriteLine(rental);
            }

            Console.ReadLine();
        }
    }
}
