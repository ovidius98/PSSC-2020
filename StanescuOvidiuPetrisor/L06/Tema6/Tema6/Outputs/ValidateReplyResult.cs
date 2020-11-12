using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;
using Tema6.Inputs;
using Tema6.Model;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class ValidateReplyResult
    {
        public interface IValidateReplyResult { };
        public class ReplyValidated:IValidateReplyResult
        {
            public Reply Reply { get; }
            public ReplyValidated(Reply reply)
            {
                Reply = reply;
            }
        }
        public class InvalidReply:IValidateReplyResult
        {
            public string Reason { get; }
            public InvalidReply(string reason)
            {
                Reason = reason;
            }
        }
        public class InvalidRequest:IValidateReplyResult
        {
            public string ValidationErrors { get; }
            public InvalidRequest(string validationErrors)
            {
                ValidationErrors = validationErrors;
                
            }
        }
    }
}
