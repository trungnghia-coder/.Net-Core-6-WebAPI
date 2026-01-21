using WebApiNet.Models;

namespace WebApiNet.Repository
{
    public interface IMerchandiseRepository
    {
        List<MerchandiseModel> getAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
