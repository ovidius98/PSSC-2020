using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateNewQuestionWorkflow.Question_Description;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    public class PublishQuestionService
    {
        public Result<PublishedQuestion> PublishQuestion(UnpublishedQuestion question)
        {
            //publica intrebare dupa ce o verificat conditiile 

            return new PublishedQuestion(question.Question,question.Tag);
        }
    }
}
