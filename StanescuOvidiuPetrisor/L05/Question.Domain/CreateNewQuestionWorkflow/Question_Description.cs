using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    [AsChoice]
    public static partial class Question_Description
    {
        public interface IQuestion_Description { }
        public class UnpublishedQuestion : IQuestion_Description
        {
            public string Question { get; private set; }
            public List<string> Tag { get; private set; }
           
            private UnpublishedQuestion(string question,List<string>tag)
            {
                Question = question;
                Tag = tag;
            }

            public static Result<UnpublishedQuestion> Create(string question,List<string>tag)
            {
                if (IsQuestionValid(question))
                {
                    if(IsTagValid(tag))
                    {
                        return new UnpublishedQuestion(question, tag);
                    }
                    else
                    {
                        return new Result<UnpublishedQuestion>(new InvalidQuestionException2(tag));
                    }
                }
                else
                {
                    return new Result<UnpublishedQuestion>(new InvalidQuestionException1(question));
                }
            }

            private static bool IsQuestionValid(string question)
            {
                if (question.Length<1000)
                {
                    return true;
                }
                return false;
            }
            private static bool IsTagValid(List<string> tag)
            {
                if (tag.Count>=1 && tag.Count<=3)
                {
                    return true;
                }
                return false;
            }
        }
        public class PublishedQuestion : IQuestion_Description
        {
            public string Question { get; private set; }
            public List<string> Tag { get; private set; }

            internal PublishedQuestion(string question, List<string> tag)
            {
                    Question = question;
                    Tag = tag;
            }
        }
    }
}
