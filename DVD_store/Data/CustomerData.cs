using DVD_store.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store.Data
{
    public class CustomerData
    {
       List<Customer> customers = new List<Customer>();

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

            if (customer == null)
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
    }
}
