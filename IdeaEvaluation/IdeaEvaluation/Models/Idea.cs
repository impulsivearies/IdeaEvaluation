using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeaEvaluation.Models
{
    public class Idea
    {
        public int IdeaId { get; set; }
        public string IdeaName { get; set; }
        public string IdeaDescription { get; set; }
        public int EvaluatedCount { get; set; }

    }
}