using JobSite.Data.Interfaces;
using JobSite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSite.Data.Repository
{
    public class DeliveryRepository : IDeliveries
    {
        private readonly ApplicationDbContext appDBContent;

        public DeliveryRepository(ApplicationDbContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Delivery> AllDeliveries => appDBContent.Deliveries.Include(c => c.Vehicle);
        public IEnumerable<Delivery> GetFavDeliveries => appDBContent.Deliveries.Where(p => p.isFavourite);
        public Delivery GetCertainDelivery(Guid deliveryId) => appDBContent.Deliveries.First(c => deliveryId == c.Id);
    }
}
