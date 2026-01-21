using WebApiNet.Models;

namespace WebApiNet.Repository
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Create(CategoryModel model);
        void Update(CategoryVM loai);
        void Delete(int id);
    }
}
