using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebMvc.Models
{
    public class PhonebookModel
    {
        public int? Id { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string TileXac { get; set; }
        public string TileThuong { get; set; }
        public string TileBaSo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}