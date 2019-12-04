using ChoicesSuperMarket.UI.Abstract;
using Microsoft.Extensions.Logging;

namespace ChoicesSuperMarket.UI.Pages
{
    public class IndexModel : BaseModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}