using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store.Class
{
   public class Rental
    {
        public string CusId { get; set; }

        public string DVDnum { get; set; }
      
        public string Title { get; set; }

        public DateTime RentDate { get; set; }

        public override string ToString()
        {
            return $"회원아이디:{CusId}\n대여날짜:{RentDate.ToShortDateString()}";
        }

    }
}
