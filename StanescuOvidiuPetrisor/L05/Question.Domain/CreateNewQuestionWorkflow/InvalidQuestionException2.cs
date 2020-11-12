using System;
using System.Collections.Generic;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException2: Exception
    {
        public InvalidQuestionException2()
        {
        }

        public InvalidQuestionException2(List<string> tag) : base($"The tag is \"{tag.Count}\".Must have at least one tag and at most 3!")
        {
        }

    }
}