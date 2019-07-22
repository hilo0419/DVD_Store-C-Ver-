using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store.Class
{
    public class Customer
    {    
        public string CusID { get; set; }          
        
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            //       Console.WriteLine($"아이디 : {customer.CusID}");
            //       Console.WriteLine($"이름 : {customer.Name}");
            //       Console.WriteLine($"Phone number : {customer.PhoneNumber}");
            return $"아이디 : {CusID} \n 이름: {Name}\n Phone: {PhoneNumber}\n";
        }


        //중복체크 함수.
        public bool IsRegistCusId(List<Customer> customers,string cusId)
        {

         
            //foreach(var customer in customers)
            //{
            //    if (customer.CusID.Equals(cusId))
            //        return true;
            //}

            

            var query = from customer in customers
                        where customer.CusID.Equals(cusId)
                        select customer;


            if (query.Any())
                return true;
           
            return false;
        }



    }
}
