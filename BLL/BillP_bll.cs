using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasi_HMS.BLL
{
    class BillP_bll
    {
        public string ResID { get; set; }

        public string Guestid { get; set; }

        public string CleanerID { get; set; }

        public string ReceptID { get; set; }
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string numOfday { get; set; }
        public string Room_type { get; set; }

        public string numOfRooms { get; set; }

        public string Discount { get; set; }

        public string Tax { get; set; }
        public string total { get; set; }
    }
}
