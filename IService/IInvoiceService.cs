using WholeSaler.Entity;

namespace WholeSaler.IService
{
    public interface IInvoiceService
    {
        Task<byte[]> GenerateInvoice(Order order);
    }
}
