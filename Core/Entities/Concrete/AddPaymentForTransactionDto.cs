namespace Core.Entities.Concrete
{
    public class AddPaymentForTransactionDto : IDto
    {
        public int Id { get; set; }
        public int PayIn { get; set; }
        public string CardOfBank { get; set; }
        public string CardHolderName { get; set; }
        public string CardMaskedNumber { get; set; }
        public string TransactionIdOfBank { get; set; }
    }
}
