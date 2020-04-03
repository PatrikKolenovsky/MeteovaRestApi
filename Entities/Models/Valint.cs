﻿using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Valint
    {
        public long ValIntId { get; set; }
        public int VariableId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }

        public virtual Variable Variable { get; set; }
    }
}
