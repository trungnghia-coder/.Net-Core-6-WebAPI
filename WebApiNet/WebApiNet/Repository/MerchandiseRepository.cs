using Microsoft.EntityFrameworkCore;
using WebApiNet.Data;
using WebApiNet.Models;

namespace WebApiNet.Repository
{
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private readonly MyDBContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public MerchandiseRepository(MyDBContext context)
        {
            _context = context;
        }
        public List<MerchandiseModel> getAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
            var allProducts = _context.Products.Include(hh => hh.Category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.MerchandiseName.Contains(search));
            }

            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price >= from);
            }

            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name (Merchandise Name)
            allProducts = allProducts.OrderBy(hh => hh.MerchandiseName);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.MerchandiseName);
                        break;
                    case "gia_asc":
                        allProducts = allProducts.OrderBy(hh => hh.Price);
                        break;
                    case "gia_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Price);
                        break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            //#endregion

            //var result = allProducts.Select(hh => new MerchandiseModel
            //{
            //    MerchandiseId = hh.MerchandiseId,
            //    MerchandiseName = hh.MerchandiseName,
            //    Price = hh.Price,
            //    CategoryName = hh.Category.Name
            //}).ToList();

            var result = PaginatedList<WebApiNet.Data.Merchandise>.Create(allProducts, page, PAGE_SIZE);
            return result.Select(hh => new MerchandiseModel
            {
                MerchandiseId = hh.MerchandiseId,
                MerchandiseName = hh.MerchandiseName,
                Price = hh.Price,
                CategoryName = hh.Category?.Name
            }).ToList();
        }
    }
}
