using JobSite.Data.Models;
namespace JobSite.Data.Interfaces
{
    public interface ICaterogyGoods
    {
        IEnumerable<CaterogyGoods> AllCaterogies { get; }
        CaterogyGoods GetCertainCategory(Guid id);
    }
}
