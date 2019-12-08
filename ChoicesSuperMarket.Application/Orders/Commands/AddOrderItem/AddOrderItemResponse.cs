using ChoicesSuperMarket.Application.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Orders.Commands.AddOrderItem
{
    public class AddOrderItemResponse : BaseResponse
    {
        public bool IsAdded { get; set; }

    }
}
