namespace Discount.Grpc.Services
{
    using Discount.Grpc.Data;
    using Discount.Grpc.Models;
    using Mapster;
    using Microsoft.EntityFrameworkCore;

    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoServices.DiscountProtoServicesBase
    {
        public async override Task<CouponModel> GetDiscount(GetDiscountRequest request, global::Grpc.Core.ServerCallContext context)
        {
            var coupon = await dbContext.Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon == null)
                coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };

            logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, global::Grpc.Core.ServerCallContext context)
        {
            return base.CreateDiscount(request, context);
        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, global::Grpc.Core.ServerCallContext context)
        {
            return base.UpdateDiscount(request, context);
        }

        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, global::Grpc.Core.ServerCallContext context)
        {
            return base.DeleteDiscount(request, context);
        }
    }
}
