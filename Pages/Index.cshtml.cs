using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
////using Microsoft.Extensions.Logging;
using Serilog;

namespace SampleApp.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger _logger;

        public IndexModel() //ILogger<IndexModel> logger)
        {
            //_logger = logger;
        }

        public void OnGet()
        {
            Log.Information("Logged from the IndexModel.OnGet method at {Time}", DateTimeOffset.Now);
        }
    }
}
