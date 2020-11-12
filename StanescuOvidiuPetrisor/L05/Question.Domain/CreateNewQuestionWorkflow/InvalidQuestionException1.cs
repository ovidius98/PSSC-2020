using System;
using System.Collections.Generic;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException1 : Exception
    {
        public InvalidQuestionException1()
        {
        }

        public InvalidQuestionException1(string question) : base($"The value \"{question}\" cannot be longer than 1000 characters.")
        {
        }

    }
}