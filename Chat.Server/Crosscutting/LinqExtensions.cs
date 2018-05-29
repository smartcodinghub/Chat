﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Crosscutting
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Enumerate<T>(this T source) { yield return source; }
    }
}
