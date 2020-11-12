using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Tema6.Outputs;

namespace Tema6.Inputs
{
    public class SendAckToQuestionOwnerCmd
    {
        CheckLanguageResult.TextChecked CheckLang;
        public SendAckToQuestionOwnerCmd(CheckLanguageResult.TextChecked check)
        {
            CheckLang = check;
        }

        public string Reply { get;}
    }
}
