using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.DoMain.Models
{
    public class Calculation
    {
        public double Xac { get; set; }
        public double Thuong { get; set; }
        public double Loi { get; set; }
        public List<string> Message { get; set; }
    }
    public class CalculationImport
    {
        public double Xac { get; set; }
        public double Thuong { get; set; }
        public double Loi { get; set; }
        public List<string> messageThuong { get; set; }
        public List<string> messageXac { get; set; }
        public List<string> messageLoi { get; set; }
    }
}
