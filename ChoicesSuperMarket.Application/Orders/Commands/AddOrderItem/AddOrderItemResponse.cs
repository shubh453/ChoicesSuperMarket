using ChoicesSuperMarket.Application.Common.Abstract;

namespace ChoicesSuperMarket.Application.Orders.Commands.AddOrderItem
{
    public class AddOrderItemResponse : BaseResponse
    {
        public bool IsAdded { get; set; }
    }
}