using System;
using System.Collections.Generic;

namespace QuestionBoundedContext.QuestionContext
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }
        public class QuestionCreated : ICreateQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }
            public string Tags { get; private set; }

            public QuestionCreated(Guid QuestionId, string Title, string Description, string Tags)
            {
                this.QuestionId = QuestionId;
                this.Title = Title;
                this.Description = Description;
                this.Tags = Tags;
            }
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }
            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }

    }
}