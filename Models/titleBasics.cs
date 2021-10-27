using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapProj_Updated_.Models
{
    public class titleBasics
    {
        public string? tconst { get; set; }
        public string? titleType { get; set; }
        public string? primaryTitle { get; set; }
        public string? originalTitle { get; set; }
        public float? isAdult { get; set; }
        public float? startYear { get; set; }
        public string? endYear { get; set; }
        public float? runtimeMinutes { get; set; }
        public string? genres { get; set; }
        public List<titleBasics>? movie { get; set; }
        public List<titleBasics>? recomend { get; set; }

    }
}
