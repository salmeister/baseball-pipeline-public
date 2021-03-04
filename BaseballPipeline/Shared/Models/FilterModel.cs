using BaseballPipeline.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballPipeline.Shared.Models
{
    public class FilterModel
    {
        public bool Hitting { get; set; }
        public bool Pitching { get; set; }
        public bool Catching { get; set; }
        public bool Infield { get; set; }
        public bool Outfield { get; set; }
        public bool Baserunning { get; set; }
        public bool SandC { get; set; }
        public bool Mindset { get; set; }
    }
}
