USE [IdeaEvaluation]
GO
/****** Object:  Table [dbo].[evaluation]    Script Date: 31-01-2021 20:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evaluation](
	[JudgeId] [int] NOT NULL,
	[IdeaId] [int] NOT NULL,
	[IsEvaluationCompleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JudgeId] ASC,
	[IdeaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ideas]    Script Date: 31-01-2021 20:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ideas](
	[IdeaId] [int] IDENTITY(1,1) NOT NULL,
	[IdeaName] [varchar](100) NOT NULL,
	[IdeaDescription] [varchar](200) NOT NULL,
	[EvaluatedCount] [int] NOT NULL,
 CONSTRAINT [PK_ideas] PRIMARY KEY CLUSTERED 
(
	[IdeaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[judge]    Script Date: 31-01-2021 20:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[judge](
	[JudgeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[EmailId] [varchar](300) NULL,
 CONSTRAINT [PK_judges] PRIMARY KEY CLUSTERED 
(
	[JudgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ideas] ADD  CONSTRAINT [DF_ideas_Evaluations]  DEFAULT ((0)) FOR [EvaluatedCount]
GO
ALTER TABLE [dbo].[evaluation]  WITH CHECK ADD  CONSTRAINT [FK_evaluation_ideas] FOREIGN KEY([IdeaId])
REFERENCES [dbo].[ideas] ([IdeaId])
GO
ALTER TABLE [dbo].[evaluation] CHECK CONSTRAINT [FK_evaluation_ideas]
GO
ALTER TABLE [dbo].[evaluation]  WITH CHECK ADD  CONSTRAINT [FK_evaluation_judges] FOREIGN KEY([JudgeId])
REFERENCES [dbo].[judge] ([JudgeId])
GO
ALTER TABLE [dbo].[evaluation] CHECK CONSTRAINT [FK_evaluation_judges]
GO
/****** Object:  StoredProcedure [dbo].[IdeaAssignment]    Script Date: 31-01-2021 20:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IdeaAssignment] @JudgeId INT, @IdeasPerJudge INT, @MinTimesIdeaEvaluates INT
AS
;with AssignmentCTE as (
SELECT TOP (@IdeasPerJudge) *, @JudgeId AS JudgeId from IdeaEvaluation.dbo.ideas I where I.EvaluatedCount <= @MinTimesIdeaEvaluates AND NOT EXISTS (SELECT 1 FROM IdeaEvaluation.dbo.evaluation
where IdeaId = I.IdeaId and JudgeId = @JudgeId)
)
INSERT INTO evaluation (IdeaId, JudgeId, IsEvaluationCompleted) (select IdeaId, JudgeId, 0 from AssignmentCTE);

SELECT IdeaId, IdeaName, IdeaDescription, EvaluatedCount from ideas where exists (select 1 from evaluation where evaluation.IdeaId = ideas.IdeaId and evaluation.JudgeId = @JudgeId and evaluation.IsEvaluationCompleted = 0);

GO
