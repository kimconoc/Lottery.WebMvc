using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebMvc.Models
{
    public class CalculationModel
    {
        public int LotteryType { get; set; }
        public List<int> Numbers { get; set; }
        public List<int> Chanels { get; set; }
        public int Sl { get; set; }
        public double TileXac { get; set; }
        public double TileThuong { get; set; }
        public double TileBaso { get; set; }
    }
    public class CalculationImportModel
    {
        public List<string> SynTaxes { get; set; }
        public double TileXac { get; set; }
        public double TileThuong { get; set; }
        public double TileBaso { get; set; }
        public double BonSo { get; set; }
        public double DaThang { get; set; }
        public double DaXien { get; set; }
        public int UserId { get; set; }
    }
}