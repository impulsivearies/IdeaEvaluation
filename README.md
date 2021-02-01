# IdeaEvaluation

Each idea must get evaluated "at least" 3 times. Each judge evaluates "different" ideas. Which means if an idea is assigned to one judge, it cannot be assigned again to same judge.
Total no of ideas = 187, judges = 49. Hence, approx 12 ideas to be evaluated by each judge.
We need to hold count for number of times an idea is evaluated.
We need to hold mapping of which idea will be evaluated by who.(judge)
Also, during assignment, those ideas must get picked which have been evaluated less than 3 times.

Based on this, we can have below database design:

Table: ideas
Columns:
IdeaId (identity autoincrement, PK)
IdeaName
IdeaDescription
EvaluatedCount

Table: judge
Columns:
JudgeId (identity autoincrement, PK)
Name
EmailId
Password

Table: evaluation (Serves to hold mapping)
Columns:
IdeaId (FK)
JudgeId (FK)
ideaid-judgeid (PK composite)
IsEvaluationCompleted

Assignment: A stored procedure runs when any judge logs in, and assigns the judge ideas to evaluate
Ideas to evaluate are picked from evaluation table, hence stored procedure first populates this table with ideas assigned to judge based on below logic:
1. Select top (12) ideas from idea table if that evaluatedcount < 3 and idea does not exist in evaluation table against the judgeid
2. Insert 1 in evaluations table
3. Show ideas from data in evaluation table against judgeid where isevaluationcompleted = 0 (assigned but not yet evaluated)
4. Provide evaluation button on UI, when judge clicks the button, mark isevaluationcompleted = 1 and increment idea counter in ideas table.
