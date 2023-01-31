using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiandApiTest.Pages.Api.DTO
{
    public class ListOfUserDTO
    {
        public long page { get; set; }
        public long perPage { get; set; }
        public long total { get; set; }
        public long totalPages { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public long id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri avatar { get; set; }
    }
}
