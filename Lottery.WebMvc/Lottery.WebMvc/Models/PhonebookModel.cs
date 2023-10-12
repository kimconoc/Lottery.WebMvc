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
        public double TileXac { get; set; }     
        public double TileThuong { get; set; }
        public double TileBaSo { get; set; }
        public double BonSo { get; set; }
        public double DaThang { get; set; }
        public double DaXien { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}