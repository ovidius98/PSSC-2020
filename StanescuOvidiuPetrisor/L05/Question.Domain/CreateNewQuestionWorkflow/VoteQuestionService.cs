using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateNewQuestionWorkflow.CreateNewQuestionResult;
using static Question.Domain.CreateNewQuestionWorkflow.Question_Description;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    public class VoteQuestionService
    {
        public Task SendPermisiuneToVote(PublishedQuestion question)
        {
            //sa confirme cumva ca intrebarea este postata(gen daca este intrebarea sau o vede) si atunci poate vota
            return Task.CompletedTask;
        }
    }
}
