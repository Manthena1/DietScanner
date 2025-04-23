using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DietAndTreatmentScanner.Models
{
    public class DietScheduleModel
    {
        public string Time { get; set; }
        public string Activity { get; set; }
        public string Type { get; set; }
        public string QTY { get; set; }
    }
}