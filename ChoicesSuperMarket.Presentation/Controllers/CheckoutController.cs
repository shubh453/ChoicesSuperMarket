using ChoicesSuperMarket.Application.Orders.Commands.CancelOrder;
using ChoicesSuperMarket.Application.Orders.Commands.PlaceOrder;
using ChoicesSuperMarket.Presentation.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Presentation.Controllers
{
    public class CheckoutController : BaseController
    {
        public async Task<IActionResult> Index(PlaceOrderCommand command)
        {
            var response = await Mediator.Send(command);
            return View(response);
        }

        // Demo Implementation just to show order completion
        public async Task<IActionResult> Complete(CancelOrderCommand command)
        {
            await Mediator.Send(command);
            return RedirectToAction("Index", "Home", new { subCategoryId = 0 });
        }
    }
}