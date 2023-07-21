using Newtonsoft.Json;

namespace CashBackApi.Shared.ViewModels
{
    public sealed class Answer<T> : AnswerBasic
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        public Answer()
        {
            AnswerId = 0L;
            AnswerMessage = "default";
            AnswerComment = "";
        }

        public Answer(long inAnswereId, string inAnswereMessage, string inAnswereComment)
        {
            AnswerId = inAnswereId;
            AnswerMessage = inAnswereMessage;
            AnswerComment = inAnswereComment;
        }

        public Answer(long inAnswereId, string inAnswereMessage)
        {
            AnswerId = inAnswereId;
            AnswerMessage = AnswerComment = inAnswereMessage;
        }

        public Answer(long inAnswereId, string inAnswereMessage, string inAnswereComment, T inData)
        {
            AnswerId = inAnswereId;
            AnswerMessage = inAnswereMessage;
            AnswerComment = inAnswereComment;
            Data = inData;
        }

        public Answer(T inData)
        {
            AnswerId = 1L;
            AnswerMessage = "Ok";
            AnswerComment = "";
            Data = inData;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
