using ChoicesSuperMarket.Application.Common.Abstract;

namespace ChoicesSuperMarket.Application.Orders.Commands.RemoveOrderItem
{
    public class RemoveOrderItemResponse : BaseResponse
    {
        public bool IsRemoved { get; set; }
    }
}