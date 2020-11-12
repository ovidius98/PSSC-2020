using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Model
{
    public class Reply
    {
        public int ReplyId { get; }
        public int QuestionId { get; }
        public int AuthorId { get; }
        public string Answer { get; }
        public Reply(int replyid,int questionid,int authorid,string answer)
        {
            ReplyId = replyid;
            QuestionId = questionid;
            AuthorId = authorid;
            Answer = answer;
        }
    }
}
