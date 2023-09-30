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
        public string TileXac { get; set; }
        public string TileThuong { get; set; }
        public string TileBaSo { get; set; }
    }
}
