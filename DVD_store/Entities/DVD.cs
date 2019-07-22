using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD_store.Class
{
    public class DVD
    {
        public string DVDnum { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        /// <summary>
        /// 대여 상태 표시 true면 대여가능 false 면 대여불가
        /// </summary>
        public bool rentalStatus { get; set; }

        public override string ToString()
        {
            return $"DVD 번호 : {DVDnum} \n제목 : {Title}\n장르 : {Genre}\n";
        }

        public bool IsRegistDVDnum(List<DVD> dvds, string dvdid)
        {
            var query = from dvd in dvds
                        where dvd.DVDnum.Equals(dvdid)
                        select dvd;


            if (query.Any())
                return true;

            return false;
        }
    }
}
