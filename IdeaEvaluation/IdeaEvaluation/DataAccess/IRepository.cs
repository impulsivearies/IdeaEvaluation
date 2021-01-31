using IdeaEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaEvaluation.DataAccess
{
    public interface IRepository
    {
        int GetLoggedInUser(string email, string password);

        Judge GetJudgesData(int judgeId);
    }
}
