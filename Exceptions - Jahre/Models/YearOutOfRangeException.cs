﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Jahre.Models
{
    internal class YearOutOfRangeException : Exception
    {
        public YearOutOfRangeException() : base("Nur jahre zwischen 1 - 9999 erlaubt") { }
    }
}
