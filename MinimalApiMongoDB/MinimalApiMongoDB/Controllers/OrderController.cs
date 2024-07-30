using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDB.Domains;
using MinimalApiMongoDB.Services;
using MinimalApiMongoDB.ViewModels;
using MongoDB.Driver;

namespace MinimalApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController(MongoDbService mongoDbService) : ControllerBase
    {
        private readonly IMongoCollection<Order> _order = mongoDbService.GetDatabase().GetCollection<Order>("orders");
        private readonly IMongoCollection<Product> _product = mongoDbService.GetDatabase().GetCollection<Product>("product");


        [HttpPost]
        public async Task<ActionResult> Post(PostOrderViewModel newOrderViewModel)
        {
            try
            {
                if (newOrderViewModel == null)
                {
                    return BadRequest("Preencha todos os dados!");
                }

                // Pega os dados novos
                Order newOrder = new()
                {
                    StatusNumber = newOrderViewModel.StatusNumber,
                    Status = newOrderViewModel.Status,
                    ProductsIds = newOrderViewModel.ProductsIds,
                };

                // Verifica se os produtos existem
                foreach (var item in newOrder.ProductsIds!)
                {
                    Product requestResult = await _product.Find(p => p.Id!.ToString() == item).FirstOrDefaultAsync();
                    if (requestResult == null)
                    {
                        return NotFound("Produto não encontrado! verifique a integridade do Id dos produtos.");
                    }
                    newOrder.Products!.Add(requestResult);
                }

                await _order.InsertOneAsync(newOrder);
                return Ok("Pedido cadastrado com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
