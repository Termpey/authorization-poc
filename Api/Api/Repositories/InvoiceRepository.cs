using System.Security.Cryptography;
using Microsoft.Extensions.ObjectPool;
using Models;
using Utility;

namespace Repositories {
    public class InvoiceRepository : IInvoiceRepository
    {
        private List<Invoice> _invoices;

        private readonly ILatencyUtility<Invoice> _latencyUtility;

        public InvoiceRepository(ILatencyUtility<Invoice> latencyUtility){
            _latencyUtility = latencyUtility;
            _invoices = SeedData();
        }

        public async Task<Invoice?> GetInvoice(int id)
        {
            return await _latencyUtility.LatencyWithData(_invoices.Find(i => i.Id == id));
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _latencyUtility.LatencyWithListData(_invoices);
        }

        public async Task<Invoice> AddInvoice(Invoice newInvoice)
        {
            _invoices.Add(newInvoice);

            return await _latencyUtility.LatencyWithData(newInvoice);
        }

        public async Task UpdateInvoice(Invoice updateMe)
        {
            int index = _invoices.FindIndex(i => updateMe.Id == i .Id);

            _invoices[index] = updateMe;
            
            return await _latencyUtility.Latency();
        }

        public async Task DeleteInvoice(int id)
        {
            int index = _invoices.FindIndex(i => i.Id == id);

            _invoices.RemoveAt(index);

            return await _latencyUtility.Latency()
        }

        private List<Invoice> SeedData(){
            List<Invoice> temp = new List<Invoice>();

            for(var i = 0; i < 100; i++){
                temp.Add(new Invoice(){
                    Id = i,
                    Customer = i.ToString() + " Customer",
                    Amount = RandomNumberGenerator.GetInt32(800, 4000),
                    Due = DateTime.Today.AddDays(RandomNumberGenerator.GetInt32(10))
                });
            }

            return temp;
        }
    }
}