CREATE PROCEDURE IdeaAssignment @JudgeId INT, @IdeasPerJudge INT, @MinTimesIdeaEvaluates INT
AS
;with AssignmentCTE as (
SELECT TOP (@IdeasPerJudge) *, @JudgeId AS JudgeId from IdeaEvaluation.dbo.ideas I where I.EvaluatedCount <= @MinTimesIdeaEvaluates AND NOT EXISTS (SELECT 1 FROM IdeaEvaluation.dbo.evaluation
where IdeaId = I.IdeaId and JudgeId = @JudgeId)
)
INSERT INTO evaluation (IdeaId, JudgeId, IsEvaluationCompleted) (select IdeaId, JudgeId, 0 from AssignmentCTE);

SELECT IdeaId, IdeaName, IdeaDescription, EvaluatedCount from ideas where exists (select 1 from evaluation where evaluation.IdeaId = ideas.IdeaId and evaluation.JudgeId = @JudgeId and evaluation.IsEvaluationCompleted = 0);

GO