using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChoicesSuperMarket.Presentation.Models;
using ChoicesSuperMarket.Presentation.Abstract;
using System.Security.Claims;
using ChoicesSuperMarket.Application.Products.Queries.GetProducts;
using ChoicesSuperMarket.Application.Orders.Commands.CancelOrder;
using ChoicesSuperMarket.Application.Orders.Commands.AddOrderItem;
using ChoicesSuperMarket.Application.Orders.Commands.RemoveOrderItem;
using ChoicesSuperMarket.Application.Products.Queries.GetProductCategories;

namespace ChoicesSuperMarket.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Index(int subCategoryId)
        {
            var categories = await Mediator.Send(new GetCategoriesQuery());

            var response = await Mediator.Send(new GetProductsQuery(subCategoryId));

            // Bypassing Identity implemetation for brevity
            HttpContext.User.AddIdentity(new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.NameIdentifier, response.CurrentCustomer.Id.ToString()) }));
            return View(new ProductPageViewModel { Categories = categories, Products = response });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<JsonResult> CancelOrder(CancelOrderCommand cancelOrder)
        {
            return new JsonResult(await Mediator.Send(cancelOrder));
        }

        public async Task<JsonResult> AddOrderItem(AddOrderItemCommand addOrder)
        {
            return new JsonResult(await Mediator.Send(addOrder));
        }

        public async Task<JsonResult> RemoveOrderItem(RemoveOrderItemCommand removeOrder)
        {
            return new JsonResult(await Mediator.Send(removeOrder));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
