using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    public static partial class SendAckToReplyAuthorResult
    {
        public interface ISendAskToReplyAuthorResult { };
        public class ReplyPublished:ISendAskToReplyAuthorResult
        {
            public string ConfirmationMessage { get; }
            public ReplyPublished(string confirmationMessage)
            {
                ConfirmationMessage = confirmationMessage;
            }
        }
        public class InvalidReplyPublished : ISendAskToReplyAuthorResult
        {
            public string ErrorMessage { get; }
            public InvalidReplyPublished(string errormessage)
            {
                ErrorMessage = errormessage;
            }
        }
    }
}
