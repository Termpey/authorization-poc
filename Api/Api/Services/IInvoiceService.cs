using Models;

namespace Services {
    public interface IInvoiceService {
        public Task<Invoice?> GetInvoice(int id);
        public Task<List<Invoice>> GetInvoices();
        public Task<Invoice> AddInvoice(Invoice newInvoice);
        public Task UpdateInvoice(Invoice updateMe);
        public Task DeleteInvoice(int id);
    }
}