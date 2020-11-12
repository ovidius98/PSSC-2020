using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Tema6.Outputs;

namespace Tema6.Inputs
{
    public class SendAckToReplyAuthorCmd
    {
        CheckLanguageResult.CheckFailed ProblematicReply;
        public SendAckToReplyAuthorCmd(CheckLanguageResult.CheckFailed problematic)
        {
            ProblematicReply = problematic;
        }

        public string Reply { get; }
    }
}
