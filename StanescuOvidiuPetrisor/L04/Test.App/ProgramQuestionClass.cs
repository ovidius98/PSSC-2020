using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Test.App
{
    class ProgramQuestionClass
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("Titlu1", "Descriere1", "c#");
            var result = CreateQuestion(cmd);
            result.Match(
                ProcessQuestionCraeted,
                ProcessQuestionNotCreated,
                ProcessInvalidQuestion
                );
            Console.ReadLine();
        }
        private static ICreatedQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Validarea intrebarii a esuat: ");
            foreach(var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }
        private static ICreatedQuestionResult ProcessQuestionNotCreated(QuestionNotCreated questionNotCreatedResult)
        {
            Console.WriteLine($"Intrebare necreata: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }
        private static ICreatedQuestionResult ProcessQuestionCreated(QuestionCreated question)
        {
            Console.WriteLine($"Intrebare {question.QuestionId}");
            return question;
        }
        public static ICreatedQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if(string.IsNullOrWhiteSpace(createQuestionCommand.Title) || string.IsNullOrWhiteSpace(createQuestionCommand(Description))) 
            {
                var errors = new List<string>() { "Titlu sau descriere invalida" };
                return new QuestionValidationFailed(errors);
            }
            if(new Random().Next(10)>1)
            {
                return new QuestionNotCreated("Intrebarea nu a putut fi validata");
            }
            var questionId = Guid.NewGuid();
            var results = new QuestionCreated(questionId, createQuestionCommand.Title, createQuestionCommand.Description);
            return results;
        }
    }

}
