using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiMongoDB.Domains;
using MinimalApiMongoDB.Services;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Text.Json;
using ZstdSharp.Unsafe;

namespace MinimalApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController(MongoDbService mongoDbService) : ControllerBase
    {
        private readonly IMongoCollection<Product> _product = mongoDbService.GetDatabase().GetCollection<Product>("product");

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Product newProduct)
        {
            try
            {
                Product product = new()
                {
                    Name = newProduct.Name,
                    Price = newProduct.Price,
                    AdditionalAttributes = newProduct.AdditionalAttributes
                };

                _product.InsertOne(product);
                return StatusCode(201, product);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteByName(string name)
        {
            try
            {
                await _product.DeleteOneAsync(p => p.Name!.ToLower() == name.ToLower());
                return Ok("Produto removido com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            try
            {
                // Modo 1
                var product = await _product.Find(p => p.Id == id).FirstOrDefaultAsync();

                return product is not null ? Ok(product) : NotFound();

                // Modo 2
                // Eq --> comparação de valores
                // var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete("DeletarPorNome")]
        public async Task<ActionResult> DeleteById(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, id) ?? throw new Exception("Produto não encontrado!");
                var searchedProduct = _product.FindOneAndDelete(filter);
                return Ok("Produto deletado! " + searchedProduct);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        //[HttpGet]
        //public async Task<ActionResult> GetById(string id)
        //{
        //    try
        //    {
        //        var productSearched = _product.Find(p => p.Id == id);
        //        return Ok();
        //    }
        //    catch (Exception exc)
        //    {
        //        return BadRequest(exc.Message);
        //    }
        //}


        //[HttpPut]
        //public async Task<ActionResult> Update(string id, Product newProduct)
        //{
        //    try
        //    {
        //        await _product.ReplaceOneAsync(id, newProduct);
        //        return Ok("Foi!");
        //    }
        //    catch (Exception exc)
        //    {
        //        return BadRequest(exc.Message);
        //    }
        //}

    }
}
