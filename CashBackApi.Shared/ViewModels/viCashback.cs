using AsbtCore.UtilsV2;

namespace CashBackApi.Shared.ViewModels
{
    public sealed class viCashback
    {
        public int UserId { get; set; }
        public long Income { get; set; }
        public long Outcome { get; set;}

        public AnswerBasic Validate()
        {
            if (UserId == 0) return new AnswerBasic(500, "Пользователь не найден");
            if (Income == 0 && Outcome == 0) return new AnswerBasic(500, "Приход или расход из кошелька не сделаны");

            return new AnswerBasic(0, "");
        }
    }
}
