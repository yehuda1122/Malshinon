﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Report
    {
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string ReportText { get; set; }
        public DateTime SubmittedAt { get; set; }

    }
}
