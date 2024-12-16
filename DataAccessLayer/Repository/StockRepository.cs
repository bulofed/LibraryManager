using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class StockRepository(List<Stock> stocks)
    {
        public IEnumerable<Stock> GetAll()
        {
            return stocks;
        }

        public Stock Get(int idLibrary, int idBook)
        {
            return stocks.FirstOrDefault(s => s.IdLibrary == idLibrary && s.IdBook == idBook) ?? throw new InvalidOperationException();
        }
    }
}