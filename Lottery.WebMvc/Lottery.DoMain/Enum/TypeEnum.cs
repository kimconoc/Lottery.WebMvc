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
        DangXuLy = 0,
        [Description("Đề")]
        DangVanChuyen = 1,
        [Description("Lô xiên")]
        DonDaGiao = 2,
    }
}
