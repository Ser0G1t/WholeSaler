namespace WholeSaler.Facade
{
    public interface IOrderFacade
    {
        Task AddAssortmentToOrder(long AssortmentId);
        Task FinalizeOrder();
    }
}
