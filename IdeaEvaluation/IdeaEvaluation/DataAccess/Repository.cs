using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdeaEvaluation.Data;
using IdeaEvaluation.Models;

namespace IdeaEvaluation.DataAccess
{
    public class Repository : IRepository
    {
        private IdeaEvaluationEntities context;
        public Repository()
        {
            context = new IdeaEvaluationEntities();
        }

        public Judge GetJudgesData(int judgeId)
        {
            try
            {
                judge user = context.judges.FirstOrDefault(x => x.JudgeId == judgeId);
                if (user != null)
                {
                    Judge dashboardUser = new Judge { JudgeId = user.JudgeId, EmailId = user.EmailId, Name = user.Name, AssignedIdeas = new List<Idea>() };
                    List<IdeaAssignment_Result> result = context.IdeaAssignment(judgeId, 12, 3).ToList();
                    foreach(IdeaAssignment_Result item in result)
                    {
                        dashboardUser.AssignedIdeas.Add(new Idea { EvaluatedCount = item.EvaluatedCount, IdeaDescription = item.IdeaDescription, IdeaId = item.IdeaId, IdeaName = item.IdeaName });
                    }

                    return dashboardUser;
                }

                return null;
            }
            catch (Exception ex)
            {
                // Log here
                return null;
            }
        }

        public int GetLoggedInUser(string email, string password)
        {
            try
            {
                // To Do: store password hashes!!
                judge authenticateUser = context.judges.FirstOrDefault(x => x.EmailId == email && x.Password == password);
                if (authenticateUser != null)
                {
                    return authenticateUser.JudgeId;
                }

                return -1;
            }
            catch (Exception ex)
            {
                // Log Errror here
                return -1;
            }
        }
    }
}