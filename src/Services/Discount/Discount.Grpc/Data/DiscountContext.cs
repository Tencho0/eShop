namespace Discount.Grpc.Data
{
    using Discount.Grpc.Models;
    using Microsoft.EntityFrameworkCore;

    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options)
            : base(options)
        {

        }
    }
}
