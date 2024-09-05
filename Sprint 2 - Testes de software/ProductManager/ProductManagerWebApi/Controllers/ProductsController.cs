using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagerWebApi.Domains;
using ProductManagerWebApi.Repositories;

namespace ProductManagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _productsRepository;
        public ProductsController() => _productsRepository = new ProductsRepository();

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Product> products = _productsRepository.GetAll();

                if (products == null)
                    return NotFound("Nenhum produto encontrado!");

                return Ok(products);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("{idProduct}")]
        public IActionResult Get(Guid idProduct)
        {
            try
            {
                Product product = _productsRepository.GetProductById(idProduct);

                if (product == null)
                    return NotFound();

                return Ok(product);
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
                if (newProduct == null)
                    return BadRequest("Preencha todos os valores!");

                bool newProductInserted = _productsRepository.RegisterProduct(newProduct);

                if (newProductInserted)
                    return Ok("Produto cadastrado com sucesso!");

                return BadRequest("O produto inserido já existe!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut("{idProduct}")]
        public IActionResult Update(Guid idProduct, Product newProduct)
        {
            try
            {
                Product productUpdated = _productsRepository.Alterar(idProduct, newProduct);

                if (productUpdated != null)
                    return Ok("Produto alterado com sucesso!");

                return BadRequest("Verifique os id passado!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete("{idProduct}")]
        public IActionResult Delete(Guid idProduct)
        {
            try
            {
                bool removedSuccessfuly = _productsRepository.DeleteById(idProduct);

                if (removedSuccessfuly)
                    return Ok("Produto removido com sucesso!");

                return BadRequest("Verifique os id passado!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
