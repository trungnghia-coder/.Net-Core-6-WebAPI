using WebApiNet.Models;

namespace WebApiNet.Repository
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> categories = new List<CategoryVM>
        {
            new CategoryVM{CategoryId = 1, Name = "Tivi"},
            new CategoryVM{CategoryId = 2, Name = "Tủ lạnh"},
            new CategoryVM{CategoryId = 3, Name = "Điều hòa"},
            new CategoryVM{CategoryId = 4, Name = "Máy giặt"},
        };
        public CategoryVM Create(CategoryModel model)
        {
            var cate = new CategoryVM
            {
                CategoryId = categories.Max(lo => lo.CategoryId) + 1,
                Name = model.Name
            };
            categories.Add(cate);
            return cate;
        }

        public void Delete(int id)
        {
            var cate = categories.SingleOrDefault(lo => lo.CategoryId == id);
            categories.Remove(cate);
        }

        public List<CategoryVM> GetAll()
        {
            return categories;
        }

        public CategoryVM GetById(int id)
        {
            return categories.SingleOrDefault(lo => lo.CategoryId == id);
        }

        public void Update(CategoryVM loai)
        {
            var cate = categories.SingleOrDefault(lo => lo.CategoryId == loai.CategoryId);
            if (cate != null)
            {
                cate.Name = loai.Name;
            }
        }
    }
}
