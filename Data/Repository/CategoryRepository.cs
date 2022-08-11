using JobSite.Data.Interfaces;
using JobSite.Data.Models;

namespace JobSite.Data.Repository
{
    public class CategoryRepository : ICaterogyGoods
    {
        private readonly ApplicationDbContext appDBContent;

        public CategoryRepository(ApplicationDbContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<CaterogyGoods> AllCaterogies => appDBContent.Categories;
        public CaterogyGoods GetCertainCategory(Guid id) => appDBContent.Categories.First(c => c.Id == id);
    }
}
