using ChoicesSuperMarket.Application.Orders.Commands.AddOrderItem;
using ChoicesSuperMarket.Application.Orders.Commands.CancelOrder;
using ChoicesSuperMarket.Application.Orders.Commands.PlaceOrder;
using ChoicesSuperMarket.Application.Orders.Commands.RemoveOrderItem;
using ChoicesSuperMarket.Application.Products.Queries.GetProducts;
using ChoicesSuperMarket.Domain.Entities;
using ChoicesSuperMarket.UI.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.UI.Pages
{
    public class IndexModel : BaseModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public GetProductResponse ProductResponse { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet(int subCategoryId)
        {
            // Bypassing Identity implemetation for brevity
            HttpContext.User.AddIdentity(new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.NameIdentifier, ProductResponse.CurrentCustomer.Id.ToString()) }));

            ProductResponse = await Mediator.Send(new GetProductsQuery(subCategoryId));
        }

        public async Task OnPostCheckout(int userId)
        {
            await Mediator.Send(new PlaceOrderCommand(userId));
        }

        public async Task<JsonResult> OnPostAddOrder(AddOrderItemCommand addOrder)
        {
            return new JsonResult(await Mediator.Send(addOrder));
        }

        public async Task<JsonResult> OnPostCancelOrder(CancelOrderCommand cancelOrder)
        {
            return new JsonResult(await Mediator.Send(cancelOrder));
        }

        public async Task<JsonResult> OnPostRemoveOrder(RemoveOrderItemCommand removeOrder)
        {
            return new JsonResult(await Mediator.Send(removeOrder));
        }
    }
}