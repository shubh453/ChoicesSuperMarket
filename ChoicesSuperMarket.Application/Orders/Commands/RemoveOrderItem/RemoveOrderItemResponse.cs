using ChoicesSuperMarket.Application.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Orders.Commands.RemoveOrderItem
{
    public class RemoveOrderItemResponse : BaseResponse
    {
        public bool IsRemoved { get; set; }
    }
}
