using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class GuideRankingInfo
    {
        public List<GuideAchievementSummary> details { get; set; }

        public double[] radarMaxValueArray { get; set; }

        public int totalEntityCount { get; set; }
    }
}
