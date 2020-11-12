using System;
using Tema6;
using Tema6.Outputs;
using Access.Primitives.IO;
using Tema6.Adapters;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;

namespace Tema6_18
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var wf = from createReplyResult in BoundedContext.ValidateReply(30, 1, "Deep Learning")
                     let validReply = (ValidateReplyResult.ReplyValidated)createReplyResult
                     from checkLanguageResult in BoundedContext.CheckLanguage(validReply.Reply.Answer)
                     from ownerAck in BoundedContext.SendAckToQuestionOwner((CheckLanguageResult.TextChecked)checkLanguageResult)
                     from authorAck in BoundedContext.SendAckToReplyAuthor((CheckLanguageResult.CheckFailed)checkLanguageResult)
                     select (validReply, checkLanguageResult, ownerAck, authorAck);

            var serviceProvider = new ServiceCollection()
                .AddOperations(typeof(ValidateReplyAdapter).Assembly)
                .AddOperations(typeof(CheckLanguageAdapter).Assembly)
                .AddOperations(typeof(SenAckToQuestionOwnerAdapter).Assembly)
                .AddTransient<IInterpreterAsync>(sp => new LiveInterpreterAsync(sp))
                .BuildServiceProvider();
            var interpreter = serviceProvider.GetService<IInterpreterAsync>();
            var writeContext = new QuestionWriteContext(new List<int>() { 1, 2, 3 }, new List<int>(){ 30, 31, 32 });
            var result = await interpreter.Interpret(wf, writeContext);
            Console.WriteLine("Hello World!");
        }

    }
    internal interface IReplyPosted
    {
    }
}
