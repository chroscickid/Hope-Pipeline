﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccr_hope_pipeline.Models.DbEntities.Tracking
{
    public class TrackRefList
    {
        public string studentName { get; set; }
        public List<TrackRefRow> list { get; set; }
        public Guid ClientCode { get; set; }
    }

    public class TrackRefRow
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime inputdate { get; set; }
        public Guid refCode { get; set; }

    }
}