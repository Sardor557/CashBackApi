namespace CashBackApi.Shared.ViewModels
{
    public sealed class IdValue<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
    }
}
