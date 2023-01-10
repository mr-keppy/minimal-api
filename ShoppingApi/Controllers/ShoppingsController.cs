using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShoppingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingsController : ControllerBase
{

    static HttpClient client = new HttpClient();

    private readonly ILogger<ShoppingsController> _logger;

    public ShoppingsController(ILogger<ShoppingsController> logger)
    {
        // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5207");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        _logger = logger;
    }

    [HttpGet(Name = "GetShoppingCart")]
    public async Task<IEnumerable<ShoppingCart>> Get(int id)
    {
            ShoppingItem product =  null;
            HttpResponseMessage response = await client.GetAsync($"/todoitems/{id}");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<ShoppingItem>();
            }
        
        List<ShoppingCart> shoppingCart =new List<ShoppingCart>();
        var item1 = new ShoppingCart(){ID=1, List=new List<ShoppingItem>()};
        item1.List.Add(product);
    
        shoppingCart.Add(item1);
        return await Task.FromResult(shoppingCart);
    }
}
