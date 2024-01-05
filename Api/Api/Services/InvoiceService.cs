using Models;
using Repositories;

namespace Services {
    public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
    {
        public Task<Invoice> AddInvoice(Invoice newInvoice)
        {
            return invoiceRepository.AddInvoice(newInvoice);
        }

        public Task DeleteInvoice(int id)
        {
            return invoiceRepository.DeleteInvoice(id);
        }

        public Task<Invoice?> GetInvoice(int id)
        {
            return invoiceRepository.GetInvoice(id);
        }

        public Task<List<Invoice>> GetInvoices()
        {
            return invoiceRepository.GetInvoices();
        }

        public Task UpdateInvoice(Invoice updateMe)
        {
            return invoiceRepository.UpdateInvoice(updateMe);
        }
    }
}