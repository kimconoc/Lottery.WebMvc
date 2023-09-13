using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.DoMain.Enum
{
    public enum LotteryEnum
    {
        [Description("Lô")]
        Lo = 0,
        [Description("Đề")]
        De = 1,
        [Description("Lô xiên 2")]
        LoXien2 = 2,
    }
}
