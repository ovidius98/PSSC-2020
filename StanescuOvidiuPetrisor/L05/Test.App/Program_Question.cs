using Question.Domain.CreateNewQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using LanguageExt;
using static Question.Domain.CreateNewQuestionWorkflow.CreateNewQuestionResult;
using static Question.Domain.CreateNewQuestionWorkflow.Question_Description;

namespace Test.App
{
    class Program_Question
    {
        static void Main(string[] args)
        {
            var questionResult = UnpublishedQuestion.Create("What is a neural network?", new List<string>() {"python","neural-network"});


            questionResult.Match(
                    Succ: question =>
                    {
                        VoteQuestionButton(question);
                        Console.WriteLine("Can vote!");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Question could not be published. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );
            Console.ReadLine();
        }
        private static void VoteQuestionButton(UnpublishedQuestion question)
        {
            var publishedQuestionResult = new PublishQuestionService().PublishQuestion(question);
            publishedQuestionResult.Match(
                    QuestionVote=>
                    {
                        new VoteQuestionService().SendPermisiuneToVote(QuestionVote);
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Can not vote!");
                        return Unit.Default;
                    }
                );
        }

    }
}
