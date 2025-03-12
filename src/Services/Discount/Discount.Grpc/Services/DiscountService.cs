namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoServices.DiscountProtoServicesBase
    {
        public override Task<CouponModel> GetDiscount(GetDiscountRequest request, global::Grpc.Core.ServerCallContext context)
        {
            return base.GetDiscount(request, context);
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
