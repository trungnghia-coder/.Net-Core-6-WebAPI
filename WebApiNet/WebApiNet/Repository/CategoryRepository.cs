using WebApiNet.Data;
using WebApiNet.Models;

namespace WebApiNet.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDBContext _context;
        public CategoryRepository(MyDBContext context)
        {
            _context = context;
        }
        public CategoryVM Create(CategoryModel model)
        {
            var category = new Category
            {
                Name = model.Name
            };
            _context.categories.Add(category);
            _context.SaveChanges();
            return new CategoryVM
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public void Delete(int id)
        {
            var category = _context.categories.Find(id);
            if (category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public List<CategoryVM> GetAll()
        {
            var categories = _context.categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList();
            return categories;
        }

        public CategoryVM GetById(int id)
        {
            var category = _context.categories
                .Where(c => c.CategoryId == id)
                .Select(c => new CategoryVM
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                })
                .FirstOrDefault();
            return category;
        }

        public void Update(CategoryVM id)
        {
            var category = _context.categories.Find(id);
            category.Name = id.Name;
            _context.SaveChanges();
        }
    }
}
