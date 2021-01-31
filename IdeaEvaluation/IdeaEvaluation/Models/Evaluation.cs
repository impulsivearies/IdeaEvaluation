using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeaEvaluation.Models
{
    public class Evaluation
    {
        public int JudgeId { get; set; }
        public int IdeaId { get; set; }
        public bool IsEvaluated { get; set; }
    }
}