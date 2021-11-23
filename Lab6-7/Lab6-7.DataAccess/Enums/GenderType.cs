using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Enums
{
    public enum GenderType
    {
        [Description("Чоловік")]
        Male = 0,

        [Description("Жінка")]
        Female = 1,

        [Description("Винищувач")]
        Il_2_Sturmovik = 2,
    }
}
