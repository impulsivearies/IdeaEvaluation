using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeaEvaluation.Models
{
    public class Judge
    {
        public int JudgeId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public List<Idea> AssignedIdeas { get; set; }
    }
}