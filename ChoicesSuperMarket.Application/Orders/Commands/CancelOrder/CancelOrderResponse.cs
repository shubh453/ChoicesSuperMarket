using ChoicesSuperMarket.Application.Common.Abstract;

namespace ChoicesSuperMarket.Application.Orders.Commands.CancelOrder
{
    public class CancelOrderResponse: BaseResponse
    {
        public bool IsCanceled { get; set; }
    }
}