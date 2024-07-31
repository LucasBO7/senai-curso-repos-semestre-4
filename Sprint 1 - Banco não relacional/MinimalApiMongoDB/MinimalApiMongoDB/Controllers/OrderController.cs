using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDB.Domains;
using MinimalApiMongoDB.Services;
using MinimalApiMongoDB.ViewModels;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MinimalApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController(MongoDbService mongoDbService) : ControllerBase
    {
        private readonly IMongoCollection<Order> _order = mongoDbService.GetDatabase().GetCollection<Order>("orders");
        private readonly IMongoCollection<Product> _product = mongoDbService.GetDatabase().GetCollection<Product>("product");
        private readonly IMongoCollection<Client> _client = mongoDbService.GetDatabase().GetCollection<Client>("clients");


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
                    //StatusNumber = newOrderViewModel.StatusNumber,
                    Status = newOrderViewModel.Status,
                    ProductsIds = newOrderViewModel.ProductsIds,
                    ClientId = newOrderViewModel.ClientId
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


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                // Busca os dados no banco
                Order searchedOrder = await _order.Find(o => o.Id.ToString() == id).FirstOrDefaultAsync();
                Client searchedOrderClient = await _client.Find(c => c.Id.ToString() == searchedOrder.ClientId).FirstOrDefaultAsync();

                // Verificação se foi encontrado o pedido
                if (searchedOrder == null)
                    return NotFound("Pedido não encontrado!");

                List<Product> products = [];

                // Associa os produtos
                if (searchedOrder.ProductsIds!.Count > 0)
                {
                    foreach (var item in searchedOrder.ProductsIds!)
                    {
                        products.Add(await _product.Find(p => p.Id == item).FirstOrDefaultAsync());
                    }
                }

                // Associa o client
                searchedOrder.Client = searchedOrderClient;

                GetOrderViewModel getOrderViewModel = new()
                {
                    // Order
                    Id = searchedOrder.Id.ToString(),
                    Date = searchedOrder.Date,
                    //StatusNumber = searchedOrder.StatusNumber,
                    Status = searchedOrder.Status!.ToString(),

                    // Products
                    Products = products,

                    // Client
                    ClientId = searchedOrder.Client.Id.ToString(),
                    UserId = searchedOrder.Client.UserId,
                    Cpf = searchedOrder.Client.Cpf,
                    Phone = searchedOrder.Client.Phone,
                    Address = searchedOrder.Client.Address,
                    ClientAdditionalValues = searchedOrder.Client.AdditionalValues
                };

                // Retorna o Client
                return Ok(getOrderViewModel);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                List<Order> searchedOrders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                List<GetOrderViewModel> getOrderViewModel = [];

                if (searchedOrders.Count == 0)
                    return NotFound("Não há nenhum pedido cadastrado!");

                foreach (var item in searchedOrders)
                {
                    // Busca o Client da Order
                    Client searchedOrderClient = _client.Find(c => c.Id.ToString() == item.ClientId).FirstOrDefault();

                    // Verifica se o Client pesquisado existe. Se sim, associa-o
                    if (searchedOrderClient != null)
                        item.Client = searchedOrderClient;

                    // Cria um filtro e busca todos os produtos cujo Id sejam igual ao ProductsIds
                    var filter = Builders<Product>.Filter.In(p => p.Id, item.ProductsIds);
                    List<Product> orderProducts = await _product.Find(filter).ToListAsync();

                    // Passa os dados aos Products
                    item.Products = orderProducts;
                }



                return Ok(searchedOrders);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(string id)
        {
            try
            {
                await _order.DeleteOneAsync(o => o.Id.ToString() == id);
                return Ok("Pedido removido com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(string id, Order newOrder)
        {
            try
            {
                // Pega Client e User do banco
                Order clientInDb = await _order.Find(c => c.Id.ToString() == id).FirstOrDefaultAsync();

                Order orderToInsert = new()
                {
                    Id = clientInDb.Id,
                    Date = newOrder.Date == null? clientInDb.Date : newOrder.Date,
                    //Status = String.IsNullOrEmpty(newClientUserViewModel.Address) ? clientInDb.Address : newClientUserViewModel.Address,


                };

                await _order.ReplaceOneAsync(o => o.Id.ToString() == id, newOrder);

            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

    }
}
