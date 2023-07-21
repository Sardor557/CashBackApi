namespace CashBackApi.Shared.ViewModels
{
    public class AnswerBasic
    {
        public long AnswerId { get; set; }

        public string AnswerMessage { get; set; }

        public string AnswerComment { get; set; }

        public AnswerBasic()
        {
            AnswerId = 1L;
            AnswerMessage = "default";
            AnswerComment = "";
        }

        public AnswerBasic(long inAnswereId, string inAnswereMessage)
        {
            AnswerId = inAnswereId;
            AnswerMessage = AnswerComment = inAnswereMessage;
        }

        public AnswerBasic(long inAnswereId, string inAnswereMessage, string inAnswereComment)
        {
            AnswerId = inAnswereId;
            AnswerMessage = inAnswereMessage;
            AnswerComment = inAnswereComment;
        }
    }
}
