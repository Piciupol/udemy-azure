using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlApp.Models;
using SqlApp.Services;

namespace SqlApp.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<Product> Products = new List<Product>();

    public void OnGet()
    {
        var productService = new ProductService();
        Products = productService.GetProducts();
    }
}
