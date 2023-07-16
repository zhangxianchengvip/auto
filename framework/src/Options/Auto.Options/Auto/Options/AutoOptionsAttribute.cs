using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Options
{
    public class AutoOptionsAttribute : Attribute
    {
        public string? Node { get; set; }
    }
}