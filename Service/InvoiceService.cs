using iTextSharp.text.pdf;
using iTextSharp.text;
using WholeSaler.IRepository;
using WholeSaler.IService;
using WholeSaler.Entity;

namespace WholeSaler.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IOrderRepository _orderRepository;

        public InvoiceService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<byte[]> GenerateInvoice(Order order)
        {
            Document document = new Document();
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                document.Add(new Paragraph($"Order number: {order.OrderId}"));
                document.Add(new Paragraph($"Order date: { order.CreationDate }"));
                document.Add(new Paragraph("   "));
                PdfPTable table = new PdfPTable(4);

                // Dodanie nagłówków do tabeli
                table.AddCell("Name");
                table.AddCell("Quantity");
                table.AddCell("Price");
                table.AddCell("Total Cost");

                // Dodanie pól edycyjnych do tabeli
                foreach (var assortment in order.Assortments)
                {
                    var totalCost = assortment.Quantity == 0 ? assortment.Price : assortment.Quantity * assortment.Price; 
                    //name price quantity
                    table.AddCell(new PdfPCell(new Phrase(assortment.Name)));
                    table.AddCell(new PdfPCell(new Phrase(assortment.Quantity)));
                    table.AddCell(new PdfPCell(new Phrase(assortment.Price.ToString())));
                    table.AddCell(new PdfPCell(new Phrase(totalCost.ToString())));
                }

                // Dodanie tabeli do dokumentu
                document.Add(table);

                document.Close();
                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił błąd podczas generowania pliku PDF.", ex);
            }
            finally
            {
                document.Dispose();
            }
        }
    }
}
