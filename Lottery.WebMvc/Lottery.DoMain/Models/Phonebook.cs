using Lottery.DoMain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.DoMain.Models
{
    public class Phonebook : VBaseModel<int>
    {
        public string Name { get; set; }
        public double TileXac { get; set; }
        public double TileThuong { get; set; }
        public double TileBaSo { get; set; }
        public double BonSo { get; set; }
        public double DaThang { get; set; }
        public double DaXien { get; set; }
        public string PhoneNumber { get; set; }
    }
}
