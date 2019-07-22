using DVD_store.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store
{
    public class DVDManager
    {
        List<Customer> customers = new List<Customer>();
        List<DVD> dvds = new List<DVD>();
        List<Rental> rentals = new List<Rental>();


        public void AddCustomer()
        {
            Customer customer = new Customer();

            Console.Clear(); //화면을 리셋 하는 함수.
            string id = null;
            string name = null;
            string number = null;

            while (true)
            {
                Console.Write("아이디 : ");
                id = Console.ReadLine();
                //중복 체크
                if (customer.IsRegistCusId(customers, id))
                {
                    Console.WriteLine("중복된 ID 입니다");
                    Console.WriteLine("다시 입력해주세요.");
                    continue;
                }
                 else
                    break;
            }
            Console.Write("이름 : ");
                name = Console.ReadLine();
                Console.Write("Phone number : ");
                number = Console.ReadLine();

                customer.CusID = id;
                customer.Name = name;
                customer.PhoneNumber = number;

                customers.Add(customer);
                Console.WriteLine("->회원가입이 완료 되었습니다.");
          
        }
        
        public void PrintAllCustomer()
        {
            Console.Clear();
            //foreach (var customer in customers)
            //    {

            //       Console.WriteLine($"아이디 : {customer.CusID}");
            //       Console.WriteLine($"이름 : {customer.Name}");
            //       Console.WriteLine($"Phone number : {customer.PhoneNumber}");

            //    }
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
            Console.ReadLine();
            
        }

        public void PrintCustomer()
        {
            Console.Clear();

            Console.Write("조회 할 아이디: ");
            string id = Console.ReadLine();
            

            var query = from x in customers
                        where x.CusID.Equals(id)
                        select x;

            Customer customer = new Customer();
            customer = query.FirstOrDefault();

            if(customer==null)
            {
                Console.WriteLine("가입되지 않은 ID입니다. 다시 입력해주세요");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("-----------------");
            Console.WriteLine($"아이디:{customer.CusID}\n 이름:{customer.Name}\n Phone:{customer.PhoneNumber}");
            Console.WriteLine("-----------------");
            
            Console.ReadLine();
        }

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
            
            if(genre=="1")
            {
                dvd.Genre = "액션";
            }
            else if(genre=="2")
            {
                dvd.Genre = "코미디";
            }
            else if(genre=="3")
            {
                dvd.Genre = "공포";
            }
            else if(genre=="4")
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

            foreach(var dvd in dvds)
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

            if(customer==null)
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

            if(dvd==null)
            {
                Console.WriteLine("등록되지 않은 DVD입니다.");
                Console.ReadLine();
                return;
            }

            if(dvd.rentalStatus==false)
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

            if(dvd==null)
            {
                Console.WriteLine("등록되지 않은 DVD입니다.");
                Console.ReadLine();
                return;
            }

            List < Rental > temp = new List<Rental>();

            temp = rentals.Select(x => x).Where(x => x.DVDnum.Equals(num)).ToList();

            foreach (var rental in temp)
            {
                Console.WriteLine(rental);
            }

            Console.ReadLine();
        }


    }
}
