using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

[Flags]
public enum Days 
{
    None = 0,
    Lunes = 1 << 0, 
    Martes = 1 << 1,
    Miercoles = 1 << 2,
    Jueves = 1 << 3,
    Viernes = 1 << 4,
    Sabado = 1 << 5,
    Domingo = 1 << 6,
}

[Flags]
public enum Hours
{
    _0 = 1 << 0,
    _1 = 1 << 1,
    _2 = 1 << 2,
    _3 = 1 << 3,
    _4 = 1 << 4,
    _5 = 1 << 5,
    _6 = 1 << 6,
    _7 = 1 << 7,
    _8 = 1 << 8,
    _9 = 1 << 9,
    _10 = 1 << 10,
    _11 = 1 << 11,
    _12 = 1 << 12,
    _13 = 1 << 13,
    _14 = 1 << 14,
    _15 = 1 << 15,
    _16 = 1 << 16,
    _17 = 1 << 17,
    _18 = 1 << 18,
    _19 = 1 << 19,
    _20 = 1 << 20,
    _21 = 1 << 21,
    _22 = 1 << 22,
    _23 = 1 << 23
}
