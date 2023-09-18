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
        [Description("Bao lô")]
        Lo = 0,
        [Description("Xiên")]
        Xien = 1,
        [Description("Lô Bao đầu")]
        LoDau = 2,
        [Description("Lô Bao đuôi")]
        LoDuoi = 3,
        [Description("Lô đầu đuôi")]
        LoDauDuoi = 4,
        [Description("Bao ba càng")]
        BaoBaCang = 5,
        [Description("Ba càng đầu")]
        BaCangDau = 6,
        [Description("Ba càng đuôi")]
        BaCangDuoi = 7,
        [Description("Ba càng đầu đuôi")]
        BaCangDauDuoi = 8
    }
}
