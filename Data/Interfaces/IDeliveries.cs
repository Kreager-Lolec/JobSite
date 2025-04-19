using JobSite.Data.Models;
namespace JobSite.Data.Interfaces
{
    public interface IDeliveries
    {
        IEnumerable<Delivery> AllDeliveries { get; }
        IEnumerable<Delivery> GetFavDeliveries { get; }
        Delivery GetCertainDelivery(Guid id);
    }
}
